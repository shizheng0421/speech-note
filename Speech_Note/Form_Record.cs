using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESBasic;
using Oraycn.MCapture;
using Oraycn.MFile;
using CCWin;


namespace Speech_Note
{
    public partial class Form_Record : Skin_Mac
    {       
        private IMicrophoneCapturer microphoneCapturer;       
        private ICameraCapturer cameraCapturer;       
        private VideoFileMaker videoFileMaker;
        private AudioFileMaker audioFileMaker;
        private SilenceVideoFileMaker silenceVideoFileMaker;
        private int frameRate = 10; // 采集视频的帧频
        private bool sizeRevised = false;// 是否需要将图像帧的长宽裁剪为4的整数倍
        private bool isRecording = false;
        private bool isParsing = false;
        private Timer timer;
        private int seconds = 0;
        private bool justRecordVideo = false;
        private bool justRecordAudio = false;

        public Form_Record()
        {
            InitializeComponent();
            Oraycn.MCapture.GlobalUtil.SetAuthorizedUser("FreeUser", "");
            Oraycn.MFile.GlobalUtil.SetAuthorizedUser("FreeUser", "");

            this.timer = new Timer();
            this.timer.Interval = 1000;
            this.timer.Tick += new EventHandler(timer_Tick);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (this.isRecording && !this.isParsing)
            {
                var ts = new TimeSpan(0, 0, ++seconds);
                this.label_time.Text = ts.Hours.ToString("00") + ":" + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
            }
        }



        private void Form_Record_Load(object sender, EventArgs e)
        {

        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                int audioSampleRate = 16000;
                int channelCount = 1;
                seconds = 0;

                System.Drawing.Size videoSize = Screen.PrimaryScreen.Bounds.Size;
                this.justRecordAudio = this.radioButton_justAudio.Checked;

                if (this.justRecordAudio && !this.checkBox_micro.Checked )
                {
                    MessageBox.Show("一定要选择一个声音的采集源！");
                    return;
                }

               if (this.radioButton_camera.Checked)
                {
                    //摄像头采集器
                    videoSize = new System.Drawing.Size(int.Parse(this.textBox_width.Text), int.Parse(this.textBox_height.Text));
                    this.cameraCapturer = CapturerFactory.CreateCameraCapturer(0, videoSize, frameRate);
                    this.cameraCapturer.ImageCaptured += new CbGeneric<Bitmap>(this.Form1_ImageCaptured);
                }

                if (this.checkBox_micro.Checked)
                {
                    //麦克风采集器
                    this.microphoneCapturer = CapturerFactory.CreateMicrophoneCapturer(0);
                    this.microphoneCapturer.CaptureError += new CbGeneric<Exception>(this.CaptureError);
                }

                if (this.checkBox_micro.Checked)
                {
                    this.microphoneCapturer.AudioCaptured += audioMixter_AudioMixed;
                }
                     
                if (this.checkBox_micro.Checked)
                {
                    this.microphoneCapturer.Start();
                }
               
                if (this.radioButton_camera.Checked)
                {
                    this.cameraCapturer.Start();
                }
                


                
                if (this.justRecordAudio)
                {
                    //只录制声音
                    this.audioFileMaker = new AudioFileMaker();
                    this.audioFileMaker.Initialize("test.mp3", audioSampleRate, channelCount);
                }
                else
                {
                    this.sizeRevised = (videoSize.Width % 4 != 0) || (videoSize.Height % 4 != 0);
                    if (this.sizeRevised)
                    {
                        videoSize = new System.Drawing.Size(videoSize.Width / 4 * 4, videoSize.Height / 4 * 4);
                    }

                    else
                    {
                        // 录制声音和图像
                        this.justRecordVideo = false;
                        this.videoFileMaker = new VideoFileMaker();
                        this.videoFileMaker.Initialize("test.mp4", VideoCodecType.H264, videoSize.Width, videoSize.Height, frameRate, VideoQuality.High, AudioCodecType.AAC, audioSampleRate, channelCount, true);

                    }
                }
               



                this.isRecording = true;
                this.isParsing = false;

                this.timer.Start();

                this.checkBox_micro.Enabled = false;
                this.radioButton_camera.Enabled = false;
                this.radioButton_justAudio.Enabled = false;

                this.btn_start.Enabled = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        
        void CaptureError(Exception obj)
        {

        }
       

       
        private int imageCount = 0;
        //采集到的视频或桌面图像

        void Form1_ImageCaptured(Bitmap img)
        {
            if (this.isRecording && !this.isParsing)
            {
                //这里要裁剪
                Bitmap imgRecorded = img;
                if (this.sizeRevised) // 对图像进行裁剪，  MFile要求录制的视频帧的长和宽必须是4的整数倍。
                {
                    imgRecorded = ESBasic.Helpers.ImageHelper.RoundSizeByNumber(img, 4);
                    img.Dispose();
                }
                if (!this.justRecordVideo)
                {
                    this.videoFileMaker.AddVideoFrame(imgRecorded);
                }
                else
                {
                    this.silenceVideoFileMaker.AddVideoFrame(imgRecorded);
                }
            }
        }
       

        
        void audioMixter_AudioMixed(byte[] audioData)
        {
            if (this.isRecording && !this.isParsing)
            {
                if (this.justRecordAudio)
                {
                    this.audioFileMaker.AddAudioFrame(audioData);
                }
                else
                {
                    if (!this.justRecordVideo)
                    {
                        this.videoFileMaker.AddAudioFrame(audioData);
                    }
                }

            }
        }

        private void btn_parse_Click(object sender, EventArgs e)
        {
            if (this.isParsing)
            {
                this.isParsing = false;
            }
            else
            {
                this.isParsing = true;
            }
            this.btn_parse.Text = (!this.isParsing ? "parse" : "recover");

        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            this.checkBox_micro.Enabled = true;
            this.radioButton_camera.Enabled = true;
            this.radioButton_justAudio.Enabled = true;

            this.btn_start.Enabled = true;
            this.btn_parse.Text = "parse";

            if (this.checkBox_micro.Checked) // 麦克风
            {
                this.microphoneCapturer.Stop();
            }
            if (this.radioButton_camera.Checked)
            {
                this.cameraCapturer.Stop();
            }
            if (this.justRecordAudio)
            {
                this.audioFileMaker.Close(true);
            }
            else
            {
                if (!this.justRecordVideo)
                {
                    this.videoFileMaker.Close(true);
                }
                else
                {
                    this.silenceVideoFileMaker.Close(true);
                }
            }

            this.isRecording = false;
            MessageBox.Show("Complete！");
        }
        private void Form_Record_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.isRecording)
            {
                MessageBox.Show("正在录制中，退出前请先停止录制！");
                e.Cancel = true;
                return;
            }

            e.Cancel = false;
        }
        
    }

}
