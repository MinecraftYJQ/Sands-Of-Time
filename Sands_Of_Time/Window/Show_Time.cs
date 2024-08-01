using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace Sands_Of_Time.Window
{
    public partial class Show_Time : Form
    {
        private WaveOutEvent player;
        private SoundPlayer shortSoundPlayer;
        int sss;
        System.IO.UnmanagedMemoryStream soundStream = Properties.Resources.Sands_Of_Time;
        System.IO.UnmanagedMemoryStream shortSoundStream = Properties.Resources.sandtimer_30sec;

        public Show_Time(int ss, bool players)
        {
            sss = ss;
            player = new WaveOutEvent();
            player.Init(new WaveFileReader(soundStream));
            shortSoundPlayer = new SoundPlayer(shortSoundStream);
            InitializeComponent();
            label1.Text = sss.ToString() + " S";
            if (players)
            {
                player.Play();
            }
        }

        private void Show_Time_Load(object sender, EventArgs e)
        {
            Location = new Point(this.Location.X, 0);
        }

        private void Show_Time_FormClosing(object sender, FormClosingEventArgs e)
        {
            player.Stop();
            player.Dispose();
            shortSoundPlayer.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int jd = int.Parse(label1.Text.Replace(" S", "")) - 1;
            label1.Text = jd.ToString() + " S";
            if (jd == 30)
            {
                shortSoundPlayer.Play();
            }
            else if (jd == 20)
            {
                System.IO.UnmanagedMemoryStream shortSoundStream1 = Properties.Resources.sandtimer_20sec;
                shortSoundPlayer = new SoundPlayer(shortSoundStream1);
                shortSoundPlayer.Play();
            }
            else if (jd <= 10&&jd>0)
            {
                System.IO.UnmanagedMemoryStream shortSoundStream2 = Properties.Resources.sandtimer_10sec;
                shortSoundPlayer = new SoundPlayer(shortSoundStream2);
                shortSoundPlayer.Play();
            }
            else if(jd==0)
            {
                timer1.Enabled = false;
                Program.GL.UIButton.Text = "启动时之沙";
                this.Close();
            }
        }
    }
}