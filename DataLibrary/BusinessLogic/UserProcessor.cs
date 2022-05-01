using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class UserProcessor
    {
        public static int CreateUser(string username, string password, string mail)
        {
            UserModel data = new UserModel
            {
                Username = username,
                Password = password,
                Mail = mail
            };

            string sql = @"insert into dbo.Users (Username, Password, Mail)
                            values (@Username, @Password, @Mail);";

            return SqlDataAccessUser.SaveData(sql, data);
        }

        static List<UserModel> LoadUsers()
        {
            string sql = @"select Id, Username, Password, Mail from dbo.Users;";

            return SqlDataAccessUser.LoadData<UserModel>(sql);
        }
    }
}
