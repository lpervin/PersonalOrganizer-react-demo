using System;
using System.Linq;
using PersonalOrganizer.Domain.DataAccess;
using PersonalOrganizer.Domain.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PersonalOrganizer.Domain.Repos.Notes
{
    public class AppUserRepository : IAppUser
    {
        private readonly TrackerDbContext _dbContext;

        public AppUserRepository(TrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AppUser> GetByUserbyIdentifier(string userIdentifier)
        {
            var appUser = await _dbContext.AppUsers.FirstOrDefaultAsync(a => a.UserIdentifier == userIdentifier);
            return appUser;
        }

        public async Task<AppUser>  Add(AppUser appUser)
        {
                 var newAppUser=  await  _dbContext.AppUsers.AddAsync(appUser);
                 await  _dbContext.SaveChangesAsync();
                 return newAppUser.Entity;
             
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}