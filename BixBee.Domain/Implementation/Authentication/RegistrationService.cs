using Bixbee.Data.Contexts;
using Bixbee.Data.Models;
using BixBee.Domain.Interface.IAuthentication;
using BixBee.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BixBee.Domain.Implementation.Authentication
{
    public class RegistrationService : IRegistrationService
    {
        private readonly EducationAppContext _context;

        public RegistrationService(EducationAppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result> Registration(RegistrationModel user)
        {
            try
            {
                if (_context.RegisteredUsers.Any(x => x.Email == user.Email))
                {
                    return new Result { IsSuccessful = false, Message = "user already exists" };
                }


                CreatePasswordhash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

                var Users = new RegisteredUser
                {
                    PhoneNo = user.Phone,
                    Email = user.Email,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    LastAccess = DateTime.Now,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    VerificationToken = CreateRandomToken()
                };

                _context.RegisteredUsers.Add(Users);
                await _context.SaveChangesAsync();

                return new Result { IsSuccessful = true, Message = "Registration Successful" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccessful = false, Message = ex.Message.ToString() };
            }
            
        }

        public async Task<Result> Login(LoginModel user)
        {
            try
            {
                var IsExist =  await _context.RegisteredUsers.Where(x => x.Email == user.Email).FirstOrDefaultAsync();
                if (IsExist == null)
                {
                    return new Result { IsSuccessful = false, Message = "user does not exist" };
                }

                if(!VerifyPasswordhash(user.Password, IsExist.PasswordHash, IsExist.PasswordSalt))
                {
                    return new Result { IsSuccessful = false, Message = "incorrect password" };
                }

                if(IsExist.ActivationStatus == false)
                {
                    return new Result { IsSuccessful = false, Message = "Please check your email for an activation mail to activate your account" };
                }
                
                return new Result { IsSuccessful = true, Message = $"Login Successful! Welcome {IsExist.Firstname}" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccessful = false, Message = ex.Message.ToString() };
            }

        }

        private void CreatePasswordhash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordhash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateRandomToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}
