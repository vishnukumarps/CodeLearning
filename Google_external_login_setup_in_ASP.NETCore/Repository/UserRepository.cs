using Google_external_login_setup_in_ASP.NETCore.Controllers.Models;
using Google_external_login_setup_in_ASP.NETCore.IRepository;
using Maintenance.DbModels;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Google_external_login_setup_in_ASP.NETCore.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly ObjectContext _context = null;
        public UserRepository(IOptions<Settings> settings)
        {
            _context = new ObjectContext(settings);
        }

        public async Task<User> Add(User User)
        {
           await _context.Users.InsertOneAsync(User);
            return User;
        }

   
        public async Task<User> Get(string Id)
        {
            var User = Builders<User>.Filter.Eq("Id", Id);
            return await _context.Users.Find(User).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.Find(x => true).ToListAsync();
        }

       
        public async  Task<DeleteResult> Remove(string Id)
        {
           return await _context.Users.DeleteOneAsync(Builders<User>.Filter.Eq("Id", Id));
        }

        public async Task<DeleteResult> RemoveAll(string Id)
        {
            return await _context.Users.DeleteManyAsync(new BsonDocument());
        }

        public async Task<Boolean> Update(User User, string Id)
        {
          var result= await _context.Users.ReplaceOneAsync(x=>x.Id==Id,User); 
            if(result!=null)
            {
                return true;
            }
            return false;
        }


        public async Task<User> Find(string Id)
        {
            var User = Builders<User>.Filter.Eq(Id, Id);
            return await _context.Users.Find(User).FirstOrDefaultAsync();
        }

        

       
        public async  Task<IEnumerable<User>> FindAll(string th)
        {
            //  await Task.FromResult(0);
            //var result=  Builders<IEnumerable<User>>.Filter.AnyEq(th,th);

            //  List<User> users =Builders<User>.Filter.AnyEq(th, th);

            // return await _context.Users.Find(x =>true).ToListAsync();
       throw new NotImplementedException();
        }
    }
}
