using Entities.DTO.Request;
using Entities.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IInvoiceDetailsService
    {
        public Task<InvoiceDetailsResponseDto> AddNewInvoiceDetails(InvoiceDetailsRequestDto invoiceDetailsRequest);
        public Task<List<InvoiceDetailsResponseDto>> GetInvoiceDetailsOfInvoice(Guid invoiceId);
        public Task<InvoiceDetailsResponseDto> UpdateInvoiceDetails(Guid invoiceDetailsId, InvoiceDetailsRequestDto invoiceDetailsRequest);
        public Task<bool> DeleteInvoiceDetails(Guid invoiceDetailsId);
    }
}
