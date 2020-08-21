using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speech_Note
{
    class UserInformation
    {
        public UserInformation() { }
        public UserInformation(int id, string userName, string password, string keysTBName)
        {
            this.ID = id;
            this.UserName = userName;
            this.Password = password;
            this.KeysTBName = keysTBName;

        }
        public int ID { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string KeysTBName { get; private set; }

        //检测用户名和密码是否匹配
        //Check if the username and password are match
        public bool IsPasswordTrue(string password)
        {
            if (password.Equals(Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
