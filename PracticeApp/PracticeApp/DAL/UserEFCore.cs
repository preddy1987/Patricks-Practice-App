using System;
using System.Collections.Generic;
using System.Text;
using PracticeApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PracticeApp.DAL
{
    public class UserEFCore
    {
        #region Properties and Member Variables
        DbContextOptions<PracticeAppContext> _options;
        #endregion

        #region Constructors
        public UserEFCore(DbContextOptions<PracticeAppContext> options)
        {
            _options = options;
        }
        #endregion

        #region Methods
        public int? CreateUser(User newUser)
        {
            int? id;
            User user = new User();
            {
                user.FirstName = newUser.FirstName;
                user.LastName = newUser.LastName;
                user.UserName = newUser.UserName;
            }
            using (var context = new PracticeAppContext(_options))
            {
                context.User.Add(user);
                context.SaveChanges();
                id = context.User.Last().Id;
            }
            return id;
        }

        public User GetUser(string name)
        {
            using (var context = new PracticeAppContext(_options))
            {
                User user = context.User.Single(u => u.UserName == name);
                return user;
            }
        }

        #endregion
    }
}
