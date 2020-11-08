using Dapper;
using JQGridUIDemo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JQGridUIDemo.Repositorys
{
    public class UserRepository
    {
        private string connStr;

        public UserRepository()
        {
            connStr = ConfigurationManager.ConnectionStrings["jqGridDb"].ConnectionString;
        }

        public  ResultModel Create(UserModel userModel)
        {
            ResultModel result = new ResultModel();
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string Sql = @"INSERT INTO [dbo].[User]
                                            ([Id]
                                            ,[Name]
                                            ,[PhoneNumber]
                                            ,[Photo])
                                      VALUES
                                            (@Id
                                            ,@Name
                                            ,@PhoneNumber
                                            ,@Photo)";
                    if (conn.Execute(Sql, userModel) > 0)
                    {
                        result.Msg = null;
                    }
                    else
                    {
                        result.Msg = "INSERT User Fail!";
                    }
                }
            }
            catch (Exception ex)
            {
                result.errMsg = ex.Message;
            }

            return result;
        }

        public  UserModel RetrieveUserById(int ID)
        {
            UserModel userModel = new UserModel();
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string Sql = @"SELECT * FROM [dbo].[User] WHERE Id = @Id";
                    userModel = conn.QueryFirstOrDefault<UserModel>(Sql, new { Id = ID });
                }
                return userModel;
            }
            catch (Exception ex)
            {
                return userModel;
            }
        }

        public  ResultModel Update(UserModel userModel)
        {
            ResultModel result = new ResultModel();
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string Sql = @"UPDATE [dbo].[User]
                                    SET [Name] = @Name
                                       ,[PhoneNumber] = @PhoneNumber
                                       ,[Photo] = @Photo
                                  WHERE Id = @Id";
                    if (conn.Execute(Sql, userModel) > 0)
                    {
                        result.Msg = null;
                    }
                    else
                    {
                        result.Msg = "UPDATE User Fail!";
                    }
                }
            }
            catch (Exception ex)
            {
                result.errMsg = ex.Message;
            }

            return result;
        }

        public  ResultModel Delete(int ID)
        {
            ResultModel result = new ResultModel();
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string Sql = @"DELETE FROM [dbo].[User] WHERE Id = @Id";
                    if (conn.Execute(Sql, new { Id = ID }) > 0)
                    {
                        result.Msg = null;
                    }
                    else
                    {
                        result.Msg = "Delete User Fail!";
                    }
                }
            }
            catch (Exception ex)
            {
                result.errMsg = ex.Message;
            }

            return result;
        }

        public  IEnumerable<UserModel> GetAll()
        {
            IEnumerable<UserModel> userModelList = new List<UserModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string Sql = @"SELECT * FROM [dbo].[User] ";
                    userModelList = conn.Query<UserModel>(Sql);
                }
                return userModelList;
            }
            catch (Exception ex)
            {
                return userModelList;
            }
        }
    }
}