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
    public partial class Form1 : Skin_Mac
    {

        string[] KeyWords;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_SearchFiles_Click(object sender, EventArgs e)
        {
            if (tbx_content.Text != "")
            {
                string cmd = "SELECT * FROM `filetb` WHERE `filename` LIKE '%" + tbx_content.Text + "%'";
                dataGridView1.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, cmd, null).Tables[0].DefaultView;
                int ex = MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, cmd, null);
            }
            else
            {
                MessageBox.Show("载入所有文件路径/Load all file paths");
                dataGridView1.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from filetb", null).Tables[0].DefaultView;
            }

        }

        private void btn_KeysDataBase_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ParameterizedThreadStart(delegate { Application.Run(new Form_Vocabulary_Bank()); }));
            t.ApartmentState = ApartmentState.STA;
            t.Start();
            //this.Close();
        }

        private void btn_Recognition_Click(object sender, EventArgs e)
        {

            Control.CheckForIllegalCrossThreadCalls = false;
            //SRecognition sr;
            //string[] fg = KeyWords;
            //sr = new SRecognition(fg);
            //sr.BeginRec(tbx_content);// 开始，textBox1输出结果
            SpeechRecognitionEngine SRE = new SpeechRecognitionEngine();
            SRE.SetInputToDefaultAudioDevice();
            GrammarBuilder GB = new GrammarBuilder();
            GB.Append(new Choices(KeyWords));
            Grammar G = new Grammar(GB);

            G.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(G_SpeechRecognized);
            SRE.LoadGrammar(G);
            SRE.RecognizeAsync(RecognizeMode.Single);
            //btn_Recognition.Enabled = false;
            btn_Recognition.Text = "正在辨识中/Under recognition";
        }
        void G_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            tbx_content.Text = e.Result.Text;
            btn_Recognition.Enabled = true;
            btn_Recognition.Text = "语音辨识/Speech recognition";

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try {
                //加载系统初始化文件
                //Load system initialization file
                Common.GetDataBaseInfo();
                //失效所有按钮，加载数据库
                //Fail all buttons and load the database
                enable(false);
                this.Text = "Speech Note 正在加载文件库/Loading file library";
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//datagridview 选中一整行

                //初始化文件夹中的文件信息
                //Initialize the file information in the folder
                string[] files = Common.GetFiles();
                string cmd = "DELETE FROM `filetb`";
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, cmd, null);
                int n = 1;
                foreach (string x in files)
                {
                    cmd = "INSERT INTO `filetb` (`ID`,`filename`,`address`) VALUES ('" + n + "','" + Common.GetFileName(x) + "','" + x.Replace("\\", "\\\\") + "')";
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, cmd, null);
                    n++;
                }
                dataGridView1.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from filetb", null).Tables[0].DefaultView;
                //加载语音识别关键词库
                //Load the speech recognition keyword library
                this.Text = "Speech Note 正在加载语音识别关键词库/The speech recognition keyword library is being loaded";
                DataTable dt = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from keystb", null).Tables[0];
                KeyWords = new string[dt.Rows.Count];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    KeyWords[i] = dt.Rows[i][0].ToString();
                }
                
                enable(true);
                this.Text = "Speech Note";

                Common.getKeys();
            }
            catch
            {
                MessageBox.Show("系统初始化配置错误，请重新配置/System initialization configuration error, please reconfigure");
            }
        }

        private void enable(bool b)
        {
            btn_KeysDataBase.Enabled = b;
            btn_Recognition.Enabled = b;
            btn_SearchFiles.Enabled = b;
            tbx_content.Enabled = b;
            dataGridView1.Enabled = b;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("notepad.exe", dataGridView1.SelectedCells[2].Value.ToString());
            }
            catch
            {
                MessageBox.Show("打开文件失败/Fail to open the file");

            }

        }

        private void btn_init_Click(object sender, EventArgs e)
        {
            Form_Visitors fv = new Form_Visitors();
            fv.Show();
        }

        private void btn_speak_Click(object sender, EventArgs e)
        {
            Form_Speak fs = new Form_Speak();
            fs.Show();
        }

        private void btn_video_Click(object sender, EventArgs e)
        {
            Form_Video fvi = new Form_Video();
            fvi.Show();
        }

        private void btn_record_Click(object sender, EventArgs e)
        {
            Form_Record fre = new Form_Record();
            fre.Show();
        }

        private void btn_re_Click(object sender, EventArgs e)
        {
            Form_Speech_To_Text f_stt = new Form_Speech_To_Text();
            f_stt.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
