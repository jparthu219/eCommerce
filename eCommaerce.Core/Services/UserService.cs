using eCommaerce.Core.DTO;
using eCommaerce.Core.Entities;
using eCommaerce.Core.IRepo;
using eCommaerce.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommaerce.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            var result = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
            if (result == null)
            {
                return null;
            }
            return new AuthenticationResponse
            {
                UserId = result.UserId,
                Email = result.Email,
                PersonName = result.PersonName,
                Gender = result.Gender,
                Token = "Token",
                Sucess = true
            };
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            var appUser = new ApplicationUser
            {
                UserId = Guid.NewGuid(),
                PersonName = registerRequest.PersonName,
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                Gender = registerRequest.GenderOptions.ToString(),
            };
            var user = await _userRepository.AddUser(appUser);
            if (user == null)
            {
                return null;
            }
            return new AuthenticationResponse
            {
                UserId = user.UserId,
                Email = user.Email,
                PersonName = user.PersonName,
                Gender = user.Gender,
                Token = "Token",
                Sucess = true

            };
         
        }
    }
}
