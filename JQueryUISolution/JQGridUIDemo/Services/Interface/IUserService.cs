using JQGridUIDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQGridUIDemo.Services.Interface
{
    public interface IUserService
    {
        ResultModel Insert(UserModel user);

        ResultModel Modify(UserModel user);

        ResultModel Remove(int ID);

        UserModel GetFirstOrDefault(int ID);

        IEnumerable<UserModel> GetAll();
    }
}
