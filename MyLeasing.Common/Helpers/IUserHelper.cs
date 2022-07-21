using Microsoft.AspNetCore.Identity;
using MyLeasing.Common.Data.Ententies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeasing.Common.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserbyEmailAsync(string email);


        Task<IdentityResult> AddUserAsync(User user, string password);


    }
}
