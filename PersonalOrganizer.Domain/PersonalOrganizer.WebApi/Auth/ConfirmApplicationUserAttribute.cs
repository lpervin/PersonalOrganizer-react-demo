using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PersonalOrganizer.Domain.Models;
using PersonalOrganizer.Domain.Repos.Notes;

namespace PersonalOrganizer.WebApi.Auth
{
    public class ConfirmApplicationUserAttribute : TypeFilterAttribute
    {
        
        public ConfirmApplicationUserAttribute() : base(typeof(ConfirmApplicationUserFilter))
        {
        }
    }

    public class ConfirmApplicationUserFilter : IAuthorizationFilter
    {
      
        private readonly IAppUser _appUserRepo;

        public ConfirmApplicationUserFilter(IAppUser appUserRepo)
        {
            _appUserRepo = appUserRepo;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity == null)
                return;

            //check if we have this user
            //using (_appUserRepo)
            //{
                var uid = context.HttpContext.User.Identity.Name;
                var user = _appUserRepo.GetByUserbyIdentifier(uid).Result;
                if (user != null) //user exists do nothing
                    return;

                //parse claims
                var claims = context.HttpContext.User.Claims.ToList();
                //add new user
                var issuer = GetClaim(claims, "iss")?.Value;
                var employeeid = GetClaim(claims, "employeeid")?.Value;
                var email = GetClaim(claims, "email")?.Value;
                _appUserRepo.Add(new AppUser()
                    {UserIdentifier = uid, IdProvider = issuer, EmployeeId = employeeid, UserEamil = email}).Wait();
            //}

        }

            private Claim GetClaim(List<Claim> claims, string claimType)
            {
                return claims.FirstOrDefault(c => c.Type == claimType);
            }

        }
    }
