using AutoMapper;
using Entities.Database_Context;
using Entities.Domain.Application;
using Entities.DTO;
using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Models.SuperMarketModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class SupermarketService : ISuperMarketService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> userManager;

        public SupermarketService(AppDbContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<SuperMarketResponseDto> CreateNewSupermarket(SuperMarketRequestDto superMarketRequest)
        {
            SuperMarket superMarket = _mapper.Map<SuperMarket>(superMarketRequest);

            await _context.AddAsync(superMarket);

            await _context.SaveChangesAsync();

            var superMarketResponse = _mapper.Map<SuperMarketResponseDto>(superMarket);

            return superMarketResponse;
        }

        public async Task<bool> DeleteSupermarket(Guid supermarketId)
        {
            var superMarket = await _context.SuperMarkets
                .Include(s => s.AppUser)
                .SingleOrDefaultAsync(s => s.SuperMarketId == supermarketId);

            if (superMarket is null)
            {
                return false;
            }

            // Delete the App User asscoiated with superMarket, cant do it cascade since of chain cascade relations
            await userManager.DeleteAsync(superMarket.AppUser);

            _context.Remove(superMarket);

            await _context.SaveChangesAsync();

            return true;
                       
        }
        
        public async Task<SuperMarketResponseDto?> GetSuperMarket(Guid supermarketId)
        {
            var superMarket = await _context.SuperMarkets
                .SingleOrDefaultAsync(s => s.SuperMarketId == supermarketId);

            if (superMarket is null)
            {
                return null;
            }

            var superMarketResponse = _mapper.Map<SuperMarketResponseDto>(superMarket);

            return superMarketResponse;

        }

        public async Task<SuperMarket?> GetSuperMarketByAppUserId(Guid appUserId)
        {
            var superMarket = await _context.SuperMarkets
                .SingleOrDefaultAsync(s => s.AppUserId == appUserId);


            return superMarket;
        } 

        public async Task<List<SuperMarketResponseDto>> GetSuperMarkets()
        {
            var superMarkets = await _context.SuperMarkets
                .Include(s => s.Employees)
                .ToListAsync();

            var superMarketResponseList = _mapper.Map<List<SuperMarketResponseDto>>(superMarkets);

            return superMarketResponseList;
        }

        public async Task<bool> UpdateSupermarket(SuperMarketRequestDto superMarketRequest, Guid supermarketId, string email, string password)
        {
            var supermarket = await _context.SuperMarkets
                .Include(s => s.AppUser)
                .SingleOrDefaultAsync(s => s.SuperMarketId == supermarketId);

            if (supermarket is null)
            {
                return false;
            }

           
            UpdateSupermarketDetails(supermarket, superMarketRequest, email, password);

            await _context.SaveChangesAsync();

            return true;
             
        }

        private void UpdateSupermarketDetails(SuperMarket superMarket, SuperMarketRequestDto superMarketRequest, string email, string password)
        {
            superMarket.SupermarketName = superMarketRequest.SupermarketName;
            superMarket.PhoneNumber = superMarketRequest.PhoneNumber;
            superMarket.Address = superMarketRequest.Address;

            // Update the email and password
            superMarket.AppUser.Email = email;

            // Hash the password before updating it
            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            superMarket.AppUser.PasswordHash = passwordHasher.HashPassword(new AppUser(), password);
        }
    }
}
