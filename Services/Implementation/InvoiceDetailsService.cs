using AutoMapper;
using Entities.Database_Context;
using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Models.InvoiceModels;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class InvoiceDetailsService : IInvoiceDetailsService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public InvoiceDetailsService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InvoiceDetailsResponseDto> AddNewInvoiceDetails(InvoiceDetailsRequestDto invoiceDetailsRequest)
        {
            var invocieDetails = _mapper.Map<InvoiceDetails>(invoiceDetailsRequest);

            await _context.InvoiceDetailss.AddAsync(invocieDetails);

            await _context.SaveChangesAsync();

            return _mapper.Map<InvoiceDetailsResponseDto>(invocieDetails);
        }

        public async Task<bool> DeleteInvoiceDetails(Guid invoiceDetailsId)
        {
            var invoice = await _context.InvoiceDetailss
                .SingleOrDefaultAsync(i => i.InvoiceDetailsId == invoiceDetailsId);

            if (invoice is null)
            {
                return false;
            }

            _context.InvoiceDetailss.Remove(invoice);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<InvoiceDetailsResponseDto>> GetInvoiceDetailsOfInvoice(Guid invoiceId)
        {
            var invoiceDetails = await _context.InvoiceDetailss
                .Where(i => i.InvoiceId == invoiceId)
                .ToListAsync();

            if (invoiceDetails is null)
            {
                return null;
            }

            return _mapper.Map<List<InvoiceDetailsResponseDto>>(invoiceDetails);
        }

        public async Task<InvoiceDetailsResponseDto> UpdateInvoiceDetails(Guid invoiceDetailsId, InvoiceDetailsRequestDto invoiceDetailsRequest)
        {
            var invoiceDetailsToUpdate = await _context.InvoiceDetailss
                .SingleOrDefaultAsync(i => i.InvoiceDetailsId == invoiceDetailsId);

            if (invoiceDetailsToUpdate is null)
            {
                return null;
            }

            UpdateInvoiceDetailsDetails(invoiceDetailsToUpdate, invoiceDetailsRequest);

            await _context.SaveChangesAsync();

            return _mapper.Map<InvoiceDetailsResponseDto>(invoiceDetailsToUpdate);
        }

        private void UpdateInvoiceDetailsDetails(InvoiceDetails invoiceDetails, InvoiceDetailsRequestDto invoiceDetailsRequest)
        {
            invoiceDetails.ProductId = invoiceDetailsRequest.ProductId;
            invoiceDetails.Quantity = invoiceDetailsRequest.Quantity;
        }
    }
}
