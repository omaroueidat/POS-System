using Entities.Database_Context;
using Entities.Domain.Application;
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
    public class AdminService : IAdminService
    {

        private readonly AppDbContext _context;

        public AdminService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNewAdmin(Admin admin)
        {
            await _context.AddAsync(admin);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAdmin(Guid adminId)
        {
            var admin = await _context.Admins
                .SingleOrDefaultAsync(a => a.AdminId == adminId);

            if (admin is null)
            {
                return false;
            }

            _context.Remove(admin);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Admin?> GetAdmin(Guid appUserId)
        {
            var admin = await _context.Admins
                .SingleOrDefaultAsync(a => a.AppUserId == appUserId);

            return admin;
        }

        public async Task<bool> UpdateAdmin(Guid adminId, string email, string password)
        {
            var admin = await _context.Admins
                .Include(a => a.AppUser)
                .SingleOrDefaultAsync(a => a.AdminId == adminId);

            if (admin is null)
            {
                return false;
            }

            UpdateAdminDetails(admin, email, password);

            await _context.SaveChangesAsync();

            return true;
            
        }

        private void UpdateAdminDetails(Admin admin, string email, string password)
        {
            admin.AppUser.Email = email;
            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            admin.AppUser.PasswordHash = passwordHasher.HashPassword(new AppUser(), password);
        }
    }
}
