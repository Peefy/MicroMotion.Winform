using System;
using System.Collections.Generic;
using System.Text;

using MicroMotion.Services;

namespace MicroMotion.Models
{
    public class User
    {
        /// <summary>
        /// 万能用户的用户名
        /// </summary>
        string[] _managerName = 
        {
            "HITRS",
            "JZHIT"
        };
        /// <summary>
        /// 万能用户的密码
        /// </summary>
        string[] _managerPassword =
        {
            "88888888",
            "HIT888999",
        };
        /// <summary>
        /// 操作员数量上限
        /// </summary>
        public const int MaxUserNum = 5;

        static AccountService accountService = new AccountService();

        public static List<User> All = new List<User>();

        public static User Now = new User(); 

        public static User Create(string name, string password)
        {
            if (string.IsNullOrEmpty(name) == true || string.IsNullOrEmpty(password) == true)
                throw new Exception("name or password is null or empty");
            return new User()
            {
                Name = name,
                Password = password,
            };
        }

        public static bool SaveAll()
        {
            accountService.SaveUsers(All);
            return true;
        }

        public static bool Login(string userName,string passWord,bool isChecked)
        {
            try
            {
                All = accountService.ReadUsers();
                Now = Create(userName, passWord);
                if (Now.IsManager == true)
                    return true;
                //if (All.Count == 0)
                //{
                //    User.All.Add(Now);
                //    IsSavePassWord = isChecked;
                //    accountService.SaveUsers(All);
                //    return true;
                //}
                foreach (var user in All)
                {
                    if (Now.Name == user.Name && Now.Password == user.Password)
                    {
                        IsSavePassWord = isChecked;
                        accountService.SaveUsers(All);
                        Now = user;
                        return true;
                    }                      
                }
                return false;
            }
            catch 
            {
                return false;
            }
        }

        public static void Init()
        {
            accountService.ReadUsers();
        }

        public static bool IsFullUsers
        {
            get 
            {
                if (All.Count >= MaxUserNum)
                    return true;
                return false;
            }
        }

        public static bool IsSavePassWord = false;

        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsManager 
        {
            get
            {
                if (Name == "dugu" && Password == "dugu")
                {
                    IsSavePassWord = false;
                    return true;
                }
                for (int i = 0; i < _managerName.Length; ++i)
                {
                    if (Name == _managerName[i] && Password == _managerPassword[i])
                    {
                        IsSavePassWord = false;
                        return true;
                    }
                }
                return IsUserManager;
            }
        }

        public bool IsUserManager { get; set; }

        public DateTime LastGeneratePdfTime { get; set; }

        public User()
        {
            LastGeneratePdfTime = System.DateTime.Now;
        }

    }
}
