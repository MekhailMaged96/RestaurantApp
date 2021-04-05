using Domain.Aggregates.UserAgg;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<User> Login(string username, string password)
        {
            var user = await _unitOfWork.UserRepo.FindAsync(e => e.UserName == username);

            if(user == null)
            {
                return null;
            }
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _unitOfWork.UserRepo.Insert(user);
            await _unitOfWork.SaveAsync();
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                Encoding utf8 = Encoding.UTF8;
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(utf8.GetBytes(password));

            }
        }
        public async Task<bool> UserExists(string username)
        {
            if (await _unitOfWork.UserRepo.AnyAsync(e => e.UserName == username))
            {
                return true;
            }
            return false;
        }

        private bool VerifyPasswordHash(string password, byte[] savedpasswordHash, byte[] savedpasswordSalt)
        {
            using (var hmac = new HMACSHA512(savedpasswordSalt))
            {
                Encoding utf8 = Encoding.UTF8;
                var passwordHash = hmac.ComputeHash(utf8.GetBytes(password));
                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if (passwordHash[i] != savedpasswordHash[i])
                    {
                        return false;
                    }
                }

            }
            return true;
        }

    }
}
