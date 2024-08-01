using NAudio.Wave;
using Sands_Of_Time.Window;
using Sunny.UI;
using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sands_Of_Time
{
    public partial class Form1 : Form
    {
        private SoundPlayer start;
        private Bitmap[] backgroundImages;
        public Form1()
        {
            InitializeComponent();
            // Load sound once
            
            System.IO.UnmanagedMemoryStream startStream = Properties.Resources.start_button_interact;
            
            start = new SoundPlayer(startStream);
            //player.PlayLooping();

            // Load background images once
            backgroundImages = new Bitmap[]
            {
                global::Sands_Of_Time.Properties.Resources._1,
                global::Sands_Of_Time.Properties.Resources._2,
                global::Sands_Of_Time.Properties.Resources._3,
                global::Sands_Of_Time.Properties.Resources._4
            };

            try
            {
                string[] strings = File.ReadAllText("Config").Split(',');
                ss = int.Parse(strings[1]) * 60;
            }
            catch { ss = 5 * 60; }
            Program.GL.UIButton = uiButton1;
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    for (int i = 0; i < backgroundImages.Length; i++)
                    {
                        this.Invoke(new Action(() =>
                        {
                            BackgroundImage = backgroundImages[i];
                            Text = "时之沙 - 作者：B站 Minecraft一角钱";
                        }));
                        await Task.Delay(3000); // Use Task.Delay instead of Thread.Sleep
                    }
                }
            });
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            start.Play();
            Thread.Sleep(800);
            start.Stop();
            start.Dispose();
            foreach (var image in backgroundImages)
            {
                image.Dispose();
            }
            Environment.Exit(0);
        }

        public static Show_Time show_Time;
        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (uiButton1.Text == "启动时之沙")
            {
                Task.Run(() =>
                {
                    start.Play();
                    Thread.Sleep(800);
                });
                uiButton1.Text = "关闭时之沙";
                show_Time = new Show_Time(ss,players);
                show_Time.Show();
            }
            else
            {
                Task.Run(() =>
                {
                    start.Play();
                    Thread.Sleep(800);
                });
                uiButton1.Text = "启动时之沙";
                show_Time.Close();
            }
        }

        int ss;
        bool players = true;
        private void uiButton2_Click(object sender, EventArgs e)
        {
            uiButton1.Text = "启动时之沙";
            try
            {
                show_Time.Close();
            }
            catch { }
            start.Play();
            Setting_Window setting_Window  = new Setting_Window();
            setting_Window.ShowDialog();
            string[] strings = File.ReadAllText("Config").Split(',');
            if (strings[0] == "False")
            {
                players= false;
            }
            else
            {
                players = true;
            }

            ss = int.Parse(strings[1])*60;
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            try
            {
                show_Time.Close();
            }
            catch { }
            uiButton1.Text = "启动时之沙";
            start.Play();
            About about = new About();
            about.ShowDialog();
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            try
            {
                show_Time.Close();
            }
            catch { }
            uiButton1.Text = "启动时之沙";
            start.Play();
            Visible =false;
        }

        private void Bar_Icon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Visible = true;
            }
        }
    }
}