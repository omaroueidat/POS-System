using Entities.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAdminService
    {
        public Task<bool> AddNewAdmin(Admin admin);
        public Task<bool> DeleteAdmin(Guid adminId);
        public Task<bool> UpdateAdmin(Guid adminId, string email, string password);
        public Task<Admin> GetAdmin(Guid appUserId);
    }
}
