using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sands_Of_Time.Window
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            System.IO.UnmanagedMemoryStream startStream = Properties.Resources.start_button_interact;

            start = new SoundPlayer(startStream);
        }
        private SoundPlayer start;
        private void uiButton1_Click(object sender, EventArgs e)
        {
            start.Play();
            Close();
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://space.bilibili.com/1527364468");
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MinecraftYJQ/Sands-Of-Time");

        }
    }
}
