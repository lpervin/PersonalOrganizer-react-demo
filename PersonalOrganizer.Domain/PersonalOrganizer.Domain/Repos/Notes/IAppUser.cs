using System;
using System.Threading.Tasks;
using PersonalOrganizer.Domain.Models;

namespace PersonalOrganizer.Domain.Repos.Notes
{
    public interface IAppUser : IDisposable
    {
        Task<AppUser> GetByUserbyIdentifier(string userIdentifier);
        Task<AppUser> Add(AppUser appUser);
    }
}