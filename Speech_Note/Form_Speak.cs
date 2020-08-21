using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.IO;
using System.Speech;
using System.Speech.Recognition;
using CCWin;

namespace Speech_Note
{
    public partial class Form_Speak : Skin_Mac
    {
        SpeechSynthesizer speaker;

        public Form_Speak()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            speaker = new SpeechSynthesizer();
            speaker.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 2, System.Globalization.CultureInfo.CurrentCulture);
            speaker.Rate = Convert.ToInt16(textBox2.Text);
            speaker.Volume = Convert.ToInt16(textBox1.Text);
            speaker.SpeakAsync(richTextBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            speaker.Pause();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                speaker = new SpeechSynthesizer();
                speaker.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 2, System.Globalization.CultureInfo.CurrentCulture);
                speaker.Rate = Convert.ToInt16(textBox2.Text);
                speaker.Volume = Convert.ToInt16(textBox1.Text);
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                speaker.SpeakAsync(richTextBox1.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = textBox3.Text;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = saveFileDialog1.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                MessageBox.Show("Please select a location to save the file.", "File not defined", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    speaker.Rate = Convert.ToInt16(textBox2.Text);
                    speaker.Volume = Convert.ToInt16(textBox1.Text);
                    speaker.SetOutputToWaveFile(textBox3.Text);
                    speaker.Speak(richTextBox1.Text);
                    speaker.SetOutputToDefaultAudioDevice();
                    MessageBox.Show("File written successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error writing the file.\n" + ex.Message, "File error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form_Speak_Load(object sender, EventArgs e)
        {

        }
    }
}
