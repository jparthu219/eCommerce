using eCommaerce.Core.Entities;
using eCommaerce.Core.IRepo;
using eCommerce.Infra.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infra.Repo
{
    public class UserRepo : IUserRepository
    {
        private readonly ApplicationContext _applicationContext;
        public UserRepo(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task<ApplicationUser?> AddUser(ApplicationUser applicationUser)
        {
            _applicationContext.ApplicationUsers.Add(applicationUser);
            await _applicationContext.SaveChangesAsync();
            return applicationUser;
        }
        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string email, string passWord)
        {
            var result = await _applicationContext.ApplicationUsers.FirstOrDefaultAsync(x => x.Email == email && x.Password == passWord);
            return result;
        }
    }
}
