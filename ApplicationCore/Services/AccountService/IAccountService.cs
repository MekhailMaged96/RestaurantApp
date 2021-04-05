using Domain.Aggregates.UserAgg;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.AccountService
{
    public interface IAccountService
    {
        public Task<User> Register(User user, string password);
        public Task<User> Login(string username, string password);
        public Task<bool> UserExists(string username);
    }
}
