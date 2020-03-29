using Google_external_login_setup_in_ASP.NETCore.Controllers.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Google_external_login_setup_in_ASP.NETCore.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task <User> Add(User User);
        Task<DeleteResult> Remove(string Id);
        Task<DeleteResult> RemoveAll(string Id);
        Task<User> Get(string Id);
        Task<Boolean> Update(User User, string Id);
      
        
        Task<User> Find(string th);
        Task<IEnumerable<User>> FindAll(string th);

    }
}
