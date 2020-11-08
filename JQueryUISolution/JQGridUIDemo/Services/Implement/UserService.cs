using JQGridUIDemo.Models;
using JQGridUIDemo.Repositorys;
using JQGridUIDemo.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JQGridUIDemo.Services.Implement
{
    public class UserService : IUserService
    {
        private UserRepository userRepository;

        public UserService()
        {
            userRepository = new UserRepository();
        }

        public IEnumerable<UserModel> GetAll()
        {
            return userRepository.GetAll();
        }

        public UserModel GetFirstOrDefault(int ID)
        {
            return userRepository.RetrieveUserById(ID);
        }

        public ResultModel Insert(UserModel user)
        {
            return userRepository.Create(user);
        }

        public ResultModel Modify(UserModel user)
        {
            return userRepository.Update(user);
        }

        public ResultModel Remove(int ID)
        {
            return userRepository.Delete(ID);
        }
    }
}