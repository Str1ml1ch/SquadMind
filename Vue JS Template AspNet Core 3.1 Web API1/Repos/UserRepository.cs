using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.RegularExpressions;
using Vue_JS_Template_AspNet_Core_3._1_Web_API1.Model;

namespace Vue_JS_Template_AspNet_Core_3._1_Web_API1.Repos
{
    public class UserRepository
    {
        //класс-репозиторий напрямую обращается к контексту базы данных
        private readonly ApplicationContext context;

        public UserRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public List<User> GetArticles()//Select all users
        {
            try
            {
               var quaryResulet = context.User.OrderBy(x => x.Name).ToList();
                return quaryResulet;
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }

        public List<Role> GetAllRoles()//Select all roles
        {
            var result = context.Role.ToList();
            return result;
        }

        public ExpandoObject GetArticleById(int id)
        {
            try
            {
                var result = context.User.Include(u => u.Role).Include(p => p.RoleSettingses).ThenInclude(o => o.Settings).Single(x => x.Id == id);
                var allRoles = this.GetAllRoles();
                var union = allRoles.Union(allRoles);
                dynamic obj = new ExpandoObject();
                obj.role = allRoles;
                obj.user = result;
                return obj;
            }
            catch(InvalidOperationException) 
            {
                throw new Exception();  
            }
        }//find user by id

        public List<User> SerarchUsers(string findData)//search user by user property
        {
            try
            {
                var result = context.User.Where(h => h.Name.Contains(findData) || h.LastName.Contains(findData) || h.Skype.Contains(findData) || h.Email.Contains(findData) || h.Signature.Contains(findData)).ToList();
                return result;
            }
            catch (InvalidOperationException) 
            {
                throw new Exception();
            }
        }

        public List<User> AddNewUser(User user) // add new clean user
        {
            try
            {
                var firstsettings = context.Settings.Single(x => x.SettingsId == 1);
                context.User.Add(user);
                RoleSettings settings = new RoleSettings { User = user, IsEnable = false, Settings = firstsettings };
                context.RoleSettings.Add(settings);
                context.SaveChanges();
                return this.GetArticles();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public string SaveArticle()
        {
            try
            {
                Role role = new Role { RoleName = "User"};
                Role rol1 = new Role { RoleName = "Manager" };
                Role role2 = new Role { RoleName = "Support" };
                Role role3 = new Role { RoleName = "Admin" };
                context.Role.AddRange(rol1, role, role2);
                context.SaveChanges();
                return "Good";
            }
            catch(SqlException)
            {
                throw new InvalidCastException();
            }
            catch(DbUpdateException e)
            {
                throw new InvalidCastException();
           }
        }// need to save this befo start, this function is saving all roles

        public bool ChangeUser(User entity)//update user
        {
            User user = context.User.Single(x => x.Id == entity.Id);
            if (context.User.Any(o => o.Email == entity.Email) && user.Email != entity.Email)
            {
                throw new Exception("Такой Email уже существует в базе!");
            }

            if (context.User.Any(o => o.Skype == entity.Skype) && user.Skype != entity.Skype)
            {
                throw new Exception("Такой Skype уже существует в базе");
            }

            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(entity.Email, pattern, RegexOptions.IgnoreCase);

            if(!isMatch.Success)
            {
                throw new Exception("Ваш Email не прошёл валидацию!");
            }


            user.Name = entity.Name;
            user.Skype = entity.Skype;
            user.LastName = entity.LastName;
            user.Email = entity.Email;
            user.Signature = entity.Signature;
            user.RoleIdenty = entity.RoleIdenty;


            RoleSettings roleSettings = context.RoleSettings.Single(c => c.UserId == user.Id && c.SettingsId == 1);

            bool isfalse = entity.RoleSettingses.Single(c => c.UserId == user.Id && c.SettingsId == 1).IsEnable;
            roleSettings.IsEnable = isfalse;

            context.SaveChanges();


            return isfalse;
        }

        public List<User> GetEnabledUSer()//Show all enable users 
        {
            var query = context.User.Include(x => x.RoleSettingses).ToList();
            List<User> Enablelist = new List<User>();

            foreach (User data in query)
            {
                foreach (RoleSettings roleSettings in data.RoleSettingses)
                {
                    if (roleSettings.IsEnable == true)
                    {
                        Enablelist.Add(data);
                    }
                }
            }
            return Enablelist;
        }

        public List<User> GetDisableUser()//Show all disable user
        {
            var query = context.User.Include(x => x.RoleSettingses).ToList();
            List<User> Enablelist = new List<User>();

            foreach (User data in query)
            {
                foreach (RoleSettings roleSettings in data.RoleSettingses)
                {
                    if (roleSettings.IsEnable == false)
                    {
                        Enablelist.Add(data);
                    }
                }
            }
            return Enablelist;
        }
    }
}
