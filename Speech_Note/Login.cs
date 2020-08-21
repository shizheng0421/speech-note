using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;

namespace Speech_Note
{
    public partial class Login : Skin_Mac
    {
        EventArgs e1;
        public object DbWrapper { get; private set; }
        private SpeechRecognitionEngine SRE = new SpeechRecognitionEngine();

        public Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
                string pwd = tbx_Password.Text.Trim();
                string user = tbx_UserName.Text.Trim();
                if (pwd == "" || user == "")
                {
                    MessageBox.Show("用户名或密码为空，请重新输入//The user name or password is empty, please re-enter", "系统提示//SYSTEM WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string cmd = "SELECT * FROM `userstb` WHERE `UserName`= '" + user + "'";

                dataGridView1.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, cmd, null).Tables[0].DefaultView;
                string pwdtb = "";
                try
                {
                    pwdtb = dataGridView1.Rows[0].Cells[2].Value.ToString();

                    if (pwdtb.Equals(pwd))//密码正确/The password is correct
                {
                        int id = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value.ToString());
                        string keystb = dataGridView1.Rows[0].Cells[3].Value.ToString();
                        UserInformation u = new UserInformation(id, user, pwd, keystb);
                        Common.keysTBName = u.KeysTBName;
                        Common.user = user;

                        Thread t = new Thread(new ParameterizedThreadStart(delegate { Application.Run(new Form1()); }));
                        t.ApartmentState = ApartmentState.STA;
                        t.Start();
                        this.Close();
                    }
                else//密码错误，清空重输入/The password is incorrect and re-entered
                {
                        MessageBox.Show("密码错误，请重新输入/Wrong password, please re-enter", "系统提示/SYSTEM WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbx_UserName.Text = "";
                        tbx_Password.Text = "";

                    }
                }
                catch
                {
                //用户名不存在，清空重输入/The user name does not exist and re-entered
                {
                    MessageBox.Show("用户名错误，请重新输入//Username is wrong, please re-enter", "系统提示//SYSTEM WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbx_UserName.Text = "";
                        tbx_Password.Text = "";

                    }
                
            }
           

            //MessageBox.Show(pd);


        }

        private void Login_Load(object sender, EventArgs e)
        {
            Common.GetDataBaseInfo();
            tbx_Password.Text = "123456";
            tbx_UserName.Text = "rd";
            dataGridView1.Visible = false;

            //SRE.SetInputToDefaultAudioDevice();     // 默认的语音输入设备
            //GrammarBuilder GB = new GrammarBuilder();

            //GB.Append(new Choices(new string[] { "Yes" }));

            //Grammar G = new Grammar(GB);

            //G.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(G_SpeechRecognized);
            //SRE.LoadGrammar(G);
            //SRE.RecognizeAsync(RecognizeMode.Single);//异步调用识别引擎，允许多次识别

            //e1 = e;

        }

        private void btn_Initial_Click(object sender, EventArgs e)
        {
            Form_Init f = new Form_Init();
            f.PrintEvent += new Form_Init.PrintInfoShow(fo_PrintEvent);
            f.ShowDialog();
        }
        void fo_PrintEvent(object sender, EventArgs e)
        {
            Login_Load(sender, e);
        }

        private void btn_Registe_Click(object sender, EventArgs e)
        {
            string user = tbx_UserName.Text.Trim();
            string cmd = "SELECT * FROM `userstb` WHERE `UserName`= '" + user + "'";

            dataGridView1.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, cmd, null).Tables[0].DefaultView;
            if (dataGridView1.RowCount == 1)
            //说明数据库中没有该用户，则建立新账户
            //Indicates that the user is not in the database, and a new account is created
            {
                    Common.keysTBName = user + "keystb";
                    cmd = "INSERT INTO `userstb` SET `UserName`='" + user + "',`Password`='" + tbx_Password.Text.Trim() + "',`KeystbName`='" + Common.keysTBName + "'";
                    int ex = MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, cmd, null);

                    //cmd = "CREATE TABLE `" + Common.keysTBName + "` (Keys varchar(50));";
                    cmd = "create table " + Common.keysTBName + "(`Keys` varchar(255));";
                    ex = MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, cmd, null);
                    MessageBox.Show("注册成功/Registration success", "系统提示/STSTEM WARNING", MessageBoxButtons.OK, MessageBoxIcon.None);
               
            }
            else
            {
                MessageBox.Show("该用户名已存在，请重新输入/The username already exists. Please re-enter it", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbx_UserName.Text = "";
                tbx_Password.Text = "";
            }
        }

        private void skinTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        //void G_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        //{

        //    try
        //    {
        //        switch (e.Result.Text)
        //        {
        //            case "Yes":
        //                MessageBox.Show("识别chenggong");
        //                btn_Login_Click(sender,);
        //                break;
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("识别失败");
        //    }
        //}
    }
}
