using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Text;

using MicroMotion.Models;

using System.Windows.Forms;

namespace MicroMotion.Services
{
    public class AccountService
    {
        static string savePath = Application.StartupPath;
        static string userConfigFileName = "\\login.uni";

        public List<User> ReadUsers()
        {
            List<User> users = new List<User>();
            try
            {
                if (Directory.Exists(savePath) == false) Directory.CreateDirectory(savePath);
                FileStream fs = new FileStream(savePath + userConfigFileName, FileMode.Open);
                using (BinaryReader r = new BinaryReader(fs))
                {
                    User.Now.Name = r.ReadString();
                    User.Now.Password = r.ReadString();
                    User.IsSavePassWord = r.ReadBoolean();
                    var count = r.ReadInt32();
                    for (int i = 0; i < count; ++i)
                    {
                        users.Add(new User() 
                        {
                            Name = r.ReadString(),
                            Password = r.ReadString(),
                            LastGeneratePdfTime = DateTime.Parse(r.ReadString()),
                            IsUserManager = r.ReadBoolean(),
                        });
                    }
                }
            }
            catch
            {
                
            }
            return users;
        }

        public bool SaveUsers(List<User> users)
        {
            try
            {
                if (Directory.Exists(savePath) == false) Directory.CreateDirectory(savePath);
                FileStream fsn = new FileStream(savePath + userConfigFileName, FileMode.Create);
                BinaryWriter w = new BinaryWriter(fsn);
                w.Write(User.Now.Name);
                w.Write(User.Now.Password);
                w.Write(User.IsSavePassWord);
                w.Write(users.Count);
                for (int i = 0; i < users.Count; ++i)
                {
                    w.Write(users[i].Name);
                    w.Write(users[i].Password);
                    w.Write(users[i].LastGeneratePdfTime.ToString());
                    w.Write(users[i].IsUserManager);
                }
                w.Flush();
                w.Close();
                fsn.Close();
                return true;
            }
            catch 
            {
                return false;
            }

        }

    }
}
