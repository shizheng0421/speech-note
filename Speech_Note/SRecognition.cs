using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Speech_Note
{
    public class SRecognition
    {
        public SpeechRecognitionEngine recognizer = null;//语音识别引擎/Speech recognition engine
        public DictationGrammar dictationGrammar = null; //自然语法/Natural grammar
        public System.Windows.Forms.Control cDisplay; //显示控件/Display control  

        public SRecognition(string[] fg) //创建关键词语列表/Create a list of key words
        {
            CultureInfo myCIintl = new CultureInfo("zh-CN");
            foreach (RecognizerInfo config in SpeechRecognitionEngine.InstalledRecognizers())//获取所有语音引擎/Get all voice engines  
            {
                if (config.Culture.Equals(myCIintl) && config.Id == "MS-2052-80-DESK")

                {
                    recognizer = new SpeechRecognitionEngine(config);
                    break;
                }//选择识别引擎/Select the recognition engine
            }
            if (recognizer != null)
            {
                InitializeSpeechRecognitionEngine(fg);//初始化语音识别引擎/Initialize the speech recognition engine  
                dictationGrammar = new DictationGrammar();
            }
            else
            {
                MessageBox.Show("创建语音识别失败/Failed to create voice recognition");
            }
        }
        public SRecognition(string[] fg,int i) //创建关键词语列表/Create a list of key words 
        {
            CultureInfo myCIintl = new CultureInfo("en-US");
            foreach (RecognizerInfo config in SpeechRecognitionEngine.InstalledRecognizers())//获取所有语音引擎/Get all voice engines  
            {
                if (config.Culture.Equals(myCIintl))
                {
                    recognizer = new SpeechRecognitionEngine(config);
                    break;
                }//选择识别引擎
            }
            if (recognizer != null)
            {
                InitializeSpeechRecognitionEngine(fg);//初始化语音识别引擎/Initialize the speech recognition engine   
                dictationGrammar = new DictationGrammar();
            }
            else
            {
                MessageBox.Show("创建语音识别失败/Failed to create voice recognition");
            }
        }

        private void InitializeSpeechRecognitionEngine(string[] fg)
        {
            recognizer.SetInputToDefaultAudioDevice();//选择默认的音频输入设备/ Select the default audio input device 
            Grammar customGrammar = CreateCustomGrammar(fg);
            //根据关键字数组建立语法/Create a syntax based on the array of keywords
            recognizer.UnloadAllGrammars();
            recognizer.LoadGrammar(customGrammar);
            //加载语法/Load syntax
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
            //recognizer.SpeechHypothesized += new EventHandler <SpeechHypothesizedEventArgs>(recognizer_SpeechHypothesized);  
        }
        public void BeginRec(Control tbResult)//关联窗口控件/Associated window controls  
        {
            TurnSpeechRecognitionOn();
            TurnDictationOn();
            cDisplay = tbResult;
        }
        public void over()//停止语音识别引擎/Stop speech recognition engine  
        {
            TurnSpeechRecognitionOff();
        }
        public virtual Grammar CreateCustomGrammar(string[] fg) //创造自定义语法/Create custom syntax  
        {
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append(new Choices(fg));
            return new Grammar(grammarBuilder);
        }
        private void TurnSpeechRecognitionOn()//启动语音识别函数/Start the speech recognition function  
        {
            if (recognizer != null)
            {
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
                //识别模式为连续识别/The recognition pattern is continuous recognition  
            }
            else
            {
                MessageBox.Show("创建语音识别失败/Failed to create voice recognition");
            }
        }
        private void TurnSpeechRecognitionOff()//关闭语音识别函数/Turn off the speech recognition function  
        {
            if (recognizer != null)
            {
                recognizer.RecognizeAsyncStop();
                TurnDictationOff();
            }
            else
            {
                MessageBox.Show("创建语音识别失败/Failed to create voice recognition");
            }
        }
        private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            TimeSpan ts= System.DateTime.Now.Subtract(System.DateTime.Now);
            //识别出完成的动作，传给某一个控件 
            //Identify the completion of the action and pass it to another control 
            if (Common.t.Equals(new DateTime(2000, 1, 1, 21, 21, 21)))
            {
                Common.t = System.DateTime.Now;
            }
            else
            {
                ts = System.DateTime.Now.Subtract(Common.t);
            }
            //MessageBox.Show(ts.TotalSeconds.ToString());
            string text = e.Result.Text;
            //根据时间填入相应的标点
            //Fill in the corresponding punctuation according to time
            if (ts.TotalSeconds < 5)
            {
                text += " ";
            }
            else if (ts.TotalSeconds < 10)
            {
                text += ", ";
            }
            else
            {
                text += ". ";
            }
            cDisplay.Text += text;
        }
        private void TurnDictationOn()
        {
            if (recognizer != null)
            {
                recognizer.LoadGrammar(dictationGrammar);
                //加载自然语法  
            }
            else
            {
                MessageBox.Show("创建语音识别失败/Failed to create voice recognition");
            }
        }
        private void TurnDictationOff()
        {
            if (dictationGrammar != null)
            {
                recognizer.UnloadGrammar(dictationGrammar);
                //卸载自然语法/Unload natural syntax  
            }
            else
            {
                MessageBox.Show("创建语音识别失败/Failed to create voice recognition");
            }
        }
    }
}
