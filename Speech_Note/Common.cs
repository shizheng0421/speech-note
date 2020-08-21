using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Speech_Note
{
    static class Common
    {
        public static string[] KeyWords;
        public static string dataSource, uid, pwd;
        public static string keysTBName = "";
        public static string user;
        public static DateTime t = new DateTime(2000, 1, 1, 21, 21, 21);

        public static string[] GetFiles()
        {
            string _path = Application.StartupPath + "\\recent_files";

            string[] _txtFiles = Directory.GetFiles(_path, "*.txt", SearchOption.AllDirectories);

            return _txtFiles;
        }

        public static string GetFileName(string address)
        {
            string name = "";
            string[] add = address.Split('\\');
            name = add[add.Length - 1];
            add = name.Split('.');
            name = add[0];
            return name;
        }

        public static string[] getKeys()
        {
            DataTable dt = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from keystb", null).Tables[0];
            KeyWords = new string[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                KeyWords[i] = dt.Rows[i][0].ToString();
            }
            return KeyWords;
        }



        public static string GetDataBaseInfo()
        {
            string path = Application.StartupPath + "//init//db.dat";
            string con = "";
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            MySqlHelper.Conn = "";

            int i = 0;
            while ((line = sr.ReadLine()) != null)
            {
                string[] str = line.Split('=');
                switch (i)

                {

                    case 1:
                        dataSource = str[1];
                        break;
                    case 2:
                        uid = str[1];
                        break;
                    case 3:
                        pwd = str[1];
                        break;

                }
                MySqlHelper.Conn += line.ToString();
                i++;
            }
            sr.Close();
            return con;
        }

        public static bool SetDataBaseInfo(string dataSource, string uid, string pwd)
        {
            bool setsuccess = true;
            string path = Application.StartupPath + "//init//db.dat";
            Common.dataSource = dataSource;
            Common.uid = uid;
            Common.pwd = pwd;
            StreamWriter sw = new StreamWriter(path);
            //开始写入


            sw.WriteLine("Database='db_speechnote';");
            sw.WriteLine("Data Source=" + Common.dataSource);
            sw.WriteLine("User Id=" + Common.uid);
            sw.WriteLine("Password=" + Common.pwd);
            sw.WriteLine("charset = 'utf8';");
            sw.WriteLine("pooling = true;");
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            return setsuccess;
        }

    }
}
