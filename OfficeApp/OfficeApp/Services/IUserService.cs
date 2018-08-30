using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OfficeApp.Models;

namespace OfficeApp.Services
{
    public interface IUserService
    {
        Task<bool> SignupAsync(User user);
        Task<string> LoginAsync(User user);

    }
}
