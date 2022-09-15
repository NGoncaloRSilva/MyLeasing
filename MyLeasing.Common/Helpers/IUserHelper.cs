using Microsoft.AspNetCore.Identity;
using MyLeasing.Common.Data.Ententies;
using MyLeasing.Common.Data.Models;
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

        Task<IdentityResult> DeleteUserAsync(User user);

        Task<SignInResult> LoginAsync(LoginViewModel model);
        Task LogoutAsync();

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task CheckRoleAsync(string roleName);
        Task AddUserToRoleAsync(User user, string roleName);
        Task<bool> IsUserInRoleAsync(User user, string roleName);
    }
}
