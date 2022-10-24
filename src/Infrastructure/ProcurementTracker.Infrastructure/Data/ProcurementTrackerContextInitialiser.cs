using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProcurementTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Infrastructure.Data
{
    public class ProcurementTrackerContextInitialiser
    {
        private readonly ILogger<ProcurementTrackerContextInitialiser> _logger;
        private readonly ProcurementTrackerContext _context;

        public ProcurementTrackerContextInitialiser(ILogger<ProcurementTrackerContextInitialiser> logger, ProcurementTrackerContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
               await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        private async Task TrySeedAsync()
        {
            if(!_context.Roles.Any())
            {
                var adminRole = new Role()
                {
                    Name = "admin"

                };

                var siteManager = new Role()
                {
                    Name = "siteManager"
                };

                _context.Roles.Add(adminRole);
                _context.Roles.Add(siteManager);

                if (!_context.Users.Any())
                {
                    var admin = new User()
                    {
                        Created = DateTime.Now,
                        Email = "admin@system.com",
                        FirstName = "admin",
                        LastName = "admin",
                        LastModified = DateTime.Now,
                        Role = adminRole,
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin"),
                    };

                    _context.Users.Add(admin);
                }
            }
        }
    }
}
