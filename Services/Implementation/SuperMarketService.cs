using AutoMapper;
using Entities.Database_Context;
using Entities.DTO;
using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Models.SuperMarketModels;
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

        public SupermarketService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SuperMarketResponseDto> Authenticate(string email, string password)
        {
            var supermarket = await _context.SuperMarkets
                .SingleOrDefaultAsync(s => s.Email == email);

            if (supermarket == null || !VerifyPassword(password, supermarket.Password))
            {
                return null;
            }

            return _mapper.Map<SuperMarketResponseDto>(supermarket);
        }

        private bool VerifyPassword(string passwordToVerify, string password)
        {
            return passwordToVerify == password;
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
                .SingleOrDefaultAsync(s => s.Id == supermarketId);

            if (superMarket is null)
            {
                return false;
            }

            _context.Remove(superMarket);

            await _context.SaveChangesAsync();

            return true;
                       
        }
        
        public async Task<SuperMarketResponseDto?> GetSuperMarket(Guid supermarketId)
        {
            var superMarket = await _context.SuperMarkets
                .SingleOrDefaultAsync(s => s.Id == supermarketId);

            var superMarketResponse = _mapper.Map<SuperMarketResponseDto>(superMarket);

            return superMarketResponse;

        }

        public async Task<List<SuperMarketResponseDto>> GetSuperMarkets()
        {
            var superMarkets = await _context.SuperMarkets
                .Include(s => s.Employees)
                .ToListAsync();

            var superMarketResponseList = _mapper.Map<List<SuperMarketResponseDto>>(superMarkets);

            return superMarketResponseList;
        }

        public async Task<bool> UpdateSupermarket(SuperMarketRequestDto superMarketRequest, Guid supermarketId)
        {
            var supermarket = await _context.SuperMarkets
                .SingleOrDefaultAsync(s => s.Id == supermarketId);

            if (supermarket is null)
            {
                return false;
            }

            try
            {
                UpdateSupermarketDetails(supermarket, superMarketRequest);

                await _context.SaveChangesAsync();

                return true;
            } 
            catch(Exception e)
            {
                return false;
            }
        }

        private void UpdateSupermarketDetails(SuperMarket superMarket, SuperMarketRequestDto superMarketRequest)
        {
            superMarket.SupermarketName = superMarketRequest.SupermarketName;
            superMarket.PhoneNumber = superMarketRequest.PhoneNumber;
            superMarket.Address = superMarketRequest.Address;
            superMarket.Email = superMarketRequest.Email;
            superMarket.Password = superMarketRequest.Password;
        }
    }
}
