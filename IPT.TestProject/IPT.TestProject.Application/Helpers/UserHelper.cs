using IPT.TestProject.Domain.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;

namespace IPT.TestProject.Application.Helpers
{
    public static class UserHelper
    {
        private static IHttpContextAccessor _httpContextAccessor;

        private static UserClaimEnum _userClaimEnum = new UserClaimEnum();

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }
         
        public static Guid AuthId()
        {
           return Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == _userClaimEnum.UserId).Value);
        }

        public static bool HasPermission(string permissionName)
        {
           var claims =  _httpContextAccessor.HttpContext.User.Claims.ToList();
            
           return true;
        }

    }
}
