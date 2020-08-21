using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;

namespace Speech_Note
{
    public partial class Form_Vocabulary_Bank : Skin_Mac
    {
        public Form_Vocabulary_Bank()
        {
            InitializeComponent();
        }
        //处理文档，删掉标点符号
        //Handle the document, delete the punctuation mark
        private void btn_TextProcessing_Click(object sender, EventArgs e)
        {
            string t = tbx_Article.Text;
            if (t == null || t == "")
            {
                MessageBox.Show("文本不可为空，请重新输入/Text can not be empty, please re-enter");
                return;
            }
            else
            {
                t = t.Replace(",", "");
                t = t.Replace(".", "");
                t = t.Replace(";", "");
                t = t.Replace(":", "");
                t = t.Replace("'", "");
                t = t.Replace("\"", "");
                t = t.Replace("?", "");
                t = t.Replace("<", "");
                t = t.Replace(">", "");
                t = t.Replace("/", "");
                t = t.Replace("|", "");
                t = t.Replace("[", ""); t = t.Replace("]", "");
                t = t.Replace("{", ""); t = t.Replace("}", "");
                t = t.Replace("-", ""); t = t.Replace("_", "");
                t = t.Replace("+", "");
                t = t.Replace("=", "");
                t = t.Replace("(", ""); t = t.Replace(")", "");
                t = t.Replace("$", "");
                t = t.Replace("!", "");
                t = t.Replace("@", "");
                t = t.Replace("#", "");
                t = t.Replace("%", ""); t = t.Replace("^", "");
                t = t.Replace("&", ""); t = t.Replace("*", "");
                t = t.Replace("\r", " ");
            }
            tbx_Article.Text = t;
        }
        //将单词存入数据库中备用
        //Save the word in the database
        private void btn_InputDataBase_Click(object sender, EventArgs e)
        {
            string[] arr = tbx_Article.Text.Split(' ');
            foreach (string i in arr)
            {
                int ex;
                string cmd;
                if (i == ""|i==null) { continue; }
                cmd = "SELECT * FROM `"+Common.keysTBName+"` WHERE `Keys`='" + i.ToLower() + "'";
                ex = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from " +Common.keysTBName, null).Tables.Count;
                try { 
                    cmd = "INSERT INTO "+Common.keysTBName+" VALUES ('" + i.ToLower() + "')";
                    ex = MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, cmd, null);
                }
                catch { continue; }

            }
            Common.getKeys();

            Form_Keys d = new Form_Keys();
            d.Show();
        }

        private void btn_Recognition_Click(object sender, EventArgs e)
        {
        
            Thread t = new Thread(new ParameterizedThreadStart(delegate { Application.Run(new Form_Speech_To_Text()); }));
            t.ApartmentState = ApartmentState.STA;
            t.Start();
            this.Close();

        }

        private void Form_Vocabulary_Bank_Load(object sender, EventArgs e)
        {

        }
    }
}
