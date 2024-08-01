using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sands_Of_Time.Window
{
    public partial class Setting_Window : Form
    {
        public Setting_Window()
        {
            InitializeComponent();
            try
            {
                string[] strings = File.ReadAllText("Config").Split(',');
                if (strings[0] == "False")
                {
                    uiCheckBox1.Checked = false;
                }

                uiTextBox1.Text = strings[1];
                mm = int.Parse(strings[1]);
            }
            catch { }
        }

        int mm = 5;
        private void uiButton3_Click(object sender, EventArgs e)
        {
            player.Play();
            try
            {
                mm = int.Parse(uiTextBox1.Text) + 1;
            }
            catch
            {
                MessageBox.Show("数值必须是整数哦!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                uiTextBox1.Text = mm.ToString();
            }
            uiTextBox1.Text = mm.ToString();
        }

        private SoundPlayer player;
        private void Setting_Window_Load(object sender, EventArgs e)
        {
            System.IO.UnmanagedMemoryStream soundStream = Properties.Resources.sand_place1;
            player = new SoundPlayer(soundStream);
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            player.Play();
            if(int.Parse(uiTextBox1.Text) < 1) {
                MessageBox.Show("数值必须是非负数哦!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    mm = int.Parse(uiTextBox1.Text) - 1;
                }
                catch
                {
                    MessageBox.Show("数值必须是整数哦!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    uiTextBox1.Text = mm.ToString();
                }
                uiTextBox1.Text = mm.ToString();
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            File.WriteAllText("Config",uiCheckBox1.Checked.ToString()+","+uiTextBox1.Text);
            Close();
        }
    }
}
