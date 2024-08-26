using AutoMapper;
using Entities.Database_Context;
using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Models.EmployeeModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public EmployeeService(AppDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _webHostEnviroment = webHostEnvironment;
        }

        public async Task<Employee?> Authenticate(int passcode)
        {
            var employee = await _context.Employees
                .Include(e => e.EmployeePasscode)
                .SingleOrDefaultAsync(e => e.EmployeePasscode.Passcode == passcode);

            return employee;
        }

        public async Task<EmployeeResponseDto?> AddNewEmployee(EmployeeRequestDto employeeRequest, IFormFile image)
        {
            // Map the EmployeeRequest to Employee
            var employee = _mapper.Map<Employee>(employeeRequest);
            
            // Get the Image URL from the Method Add Photo so we can save it to the database
            string imageUrl = await AddPhoto(image, employee.EmployeeId);
            employee.EmployeeImage = imageUrl;

            // Add the Employee to the database
            await _context.Employees.AddAsync(employee);

            // SaveChanges
            await _context.SaveChangesAsync();

            // Map the Employee to EmployeeResponse
            var employeeResponse = _mapper.Map<EmployeeResponseDto>(employee);

            return employeeResponse;
        }

        public async Task<bool> DeleteEmployee(Guid employeeId)
        {
            var employee = await _context.Employees
                .SingleOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (employee is null)
            {
                return false;
            }

            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<EmployeeResponseDto?> GetEmployee(Guid employeeId)
        {
            var employee = await _context.Employees
                .Include(e => e.EmployeePasscode)
                .Include(e => e.EmployeeLogs)
                .SingleOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (employee is null)
            {
                return null;
            }

            var employeeResponse = _mapper.Map<EmployeeResponseDto>(employee);

            return employeeResponse;
        }

        public async Task<List<EmployeeResponseDto>> GetEmployeesOfSuperMarket(Guid superMarketId)
        {
            var employees = await _context.Employees
                .Where(e => e.SupermarketId == superMarketId)
                .ToListAsync();

            if (employees is null)
            {
                return null;
            }

            var employeeResponse = _mapper.Map<List<EmployeeResponseDto>>(employees);

            return employeeResponse;
        }

        public async Task<List<EmployeeResponseDto>> GetEmployees()
        {
            return _mapper.Map<List<EmployeeResponseDto>>(await _context.Employees.ToListAsync());
        }

        public async Task<EmployeeResponseDto?> UpdateEmployee(Guid employeeId, EmployeeRequestDto employeeRequest, int passcode, IFormFile image)
        {
            var employeeToUpdate = await _context.Employees
                .Include(e => e.EmployeePasscode)
                .SingleOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (employeeToUpdate is null)
            {
                return null;
            }

            // Update the details
            UpdateEmployeeDetails(employeeToUpdate, employeeRequest, passcode);

            // Update the image, no need to save new image fileName since the name is the employeeId
            await AddPhoto(image, employeeId);

            await _context.SaveChangesAsync();

            var employeeResponse = _mapper.Map<EmployeeResponseDto>(employeeToUpdate);

            return employeeResponse;

        }

        private void UpdateEmployeeDetails(Employee employee, EmployeeRequestDto employeeRequest, int passcode)
        {
            employee.Address = employeeRequest.Address;
            employee.PhoneNumber = employeeRequest.PhoneNumber;
            employee.EmployeeName = employeeRequest.EmployeeName;
            employee.EmployeePasscode.Passcode = passcode;
        }

        // Method to update or add an image
        private async Task<string> AddPhoto(IFormFile image, Guid employeeId)
        {
            // This Gets the File Extension
            var fileExtension = Path.GetExtension(image.FileName);


            // The Image name should be the employeeId
            var imageNewName = $"{employeeId}{fileExtension}";

            // Set the Path where we should save the File
            // The Path should be the project location on server + folder name in wwwroot + (imageFileName + guid + fileExtension)
            var localPathFile = Path.Combine(_webHostEnviroment.ContentRootPath, "wwwroot", "EmployeeImages", imageNewName);
            

            // Save the file by Uploading it to the specified Path on the server
            using var stream = new FileStream(localPathFile, FileMode.Create);
            // If the employee Already have an image it will overwrite it
            await image.CopyToAsync(stream);

            // We want to save the Url of the image for the user to access
            // The Url should depends on our domain so we have to extract the domain of the server from the request
            var imageUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}" +
                           $"{_httpContextAccessor.HttpContext.Request.PathBase}/images/{imageNewName}";

            return imageUrl;
        }
    }
}
