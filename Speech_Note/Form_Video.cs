using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;

namespace Speech_Note
{
    public partial class Form_Video : Skin_Mac
    {
        string path;

        public Form_Video()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                path = textBox1.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            System.Media.SoundPlayer player = new System.Media.SoundPlayer(path);
            player.Play();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            System.Media.SoundPlayer player = new System.Media.SoundPlayer(path);
            player.Stop();
        }

        private void Form_Video_Load(object sender, EventArgs e)
        {

        }
    }
}
