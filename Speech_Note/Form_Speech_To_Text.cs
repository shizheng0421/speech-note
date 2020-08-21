using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;

namespace Speech_Note
{
    public partial class Form_Speech_To_Text : Skin_Mac
    {
        private SRecognition sr;
        private SpeechRecognitionEngine SRE = new SpeechRecognitionEngine();

        //SpRecognition sp = SpRecognition.instance();
        public Form_Speech_To_Text()
        {
            InitializeComponent();
            string[] fg = { "东方", "西方", "南方", "北方" };
            string[] fg_English = {"love","speak","china"};
            sr = new SRecognition(fg);
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sr.BeginRec(textBox1);
            //sp.BeginRec();
            button1.Enabled = false;
            button2.Enabled = true;
            btn_EnglishiRecognition.Enabled = false;
            button3.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sr.over();
            //sp.CloseRec();
            button1.Enabled = true;
            button2.Enabled = false;
            btn_EnglishiRecognition.Enabled = true;
            button3.Enabled = false;
        }

        private void btn_EnglishiRecognition_Click(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            SRE.SetInputToDefaultAudioDevice();     //默认的语音输入设备/Default voice input device

            GrammarBuilder GB = new GrammarBuilder();
            GB.Append(new Choices(Common.KeyWords));


            Grammar G = new Grammar(GB);
            G.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(G_SpeechRecognized);
            SRE.LoadGrammar(G);
            SRE.RecognizeAsync(RecognizeMode.Multiple);//异步调用识别引擎/Asynchronous call recognition engine

            button1.Enabled = false;
            button2.Enabled = false;
            btn_EnglishiRecognition.Enabled = false;
            button3.Enabled = true;
        }
        void G_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            textBox1.Text += e.Result.Text + " ";
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //SRE.RecognizeAsync(RecognizeMode.Single);
           
                SRE.RecognizeAsyncStop();
   
            button1.Enabled = true;
            button2.Enabled = false;
            btn_EnglishiRecognition.Enabled = true;
            button3.Enabled = false;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string filename = "D:/Temp/temp.txt";
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = "data";
                saveFileDialog.DefaultExt = ".txt";
                saveFileDialog.Filter = "txt files(*.txt)|*.txt|All files(*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    filename = saveFileDialog.FileName;
                }
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    sw.Write(textBox1.Text);
                }
            }
            catch
            {
                MessageBox.Show("非法路径请重新选择/Illegal path, please select again");
            }

        }

        private void btn_Redite_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = " 请选择您要导入的文件/Please select the file you want to import：";
            ofd.Filter = "TextDocument(*.txt)|*.txt";
            ofd.ShowDialog();
            System.IO.StreamReader sr = new System.IO.StreamReader(ofd.FileName, System.Text.Encoding.Default);
            textBox1.Text = sr.ReadToEnd();

        }

        private void Form_Speech_To_Text_Load(object sender, EventArgs e)
        {

        }
    }
}
