using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;
using MongoDB.Driver;

namespace BLL
{
    public class UsersBL
    {
        private readonly MongoService<User> _repository;

        internal UsersBL()
        {
            _repository = new MongoService<User>();
            //_repository = new UsersMongoService();
        }
        public static UsersBL Instance = new UsersBL();
        /// <summary>
        /// Find All Users
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> FindAll()
        {
            var result = await _repository.FindAll();
            return result;
        }

        public async Task<IEnumerable<User>> FindByFilter(FilterDefinition<User> filter)
        {
            return await _repository.FindByFilter(filter);
        }
        /// <summary>
        /// Find All Active Users
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> FindAllActive()
        {
            var result = await _repository.FindAllActive();
            return result;
        }
        public async Task Create(User user)
        {
            await _repository.Create(user);
        }
        /// <summary>
        /// Find an User by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> FindById(string id)
        {
            return await _repository.FindById(id);
        }        

        /// <summary>
        /// Find an active User by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> FindActiveById(string id)
        {
            return await _repository.FindActiveById(id);
        }
        /// <summary>
        /// Save User 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Save(User user, string id)
        {
            await _repository.Save(user, id);
        }

        public async Task Save(User user)
        {
            await Save(user, user.Id);
        }
        /// <summary>
        /// Deactive an user 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task LogicalRemove(string id)
        {
            await _repository.LogicalRemove(id);
        }
        /// <summary>
        /// Remove an user from Database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Remove(string id)
        {
            await _repository.Remove(id);
        }
    }
}
