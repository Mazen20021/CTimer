using System;
using System.Diagnostics;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text;
using static Vanara.PInvoke.FunctionHelper;
using System.Diagnostics.Metrics;
using System.Threading;
namespace CTimer
{
    public partial class Form1 : Form
    {
        bool isclicked = false;
        int seconds = 0;
        int minute = 0;
        int hours = 0;
        int counter = 5;
        bool is_shown;
        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetSuspendState(bool hibernate, bool forceCritical, bool disableWakeEvent);
        public Form1()
        {
            InitializeComponent();
            modebox.SelectedIndex = 0;
        }
        private void timer(bool st)
        {
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            if (st)
            {
                t.Interval = 1000;
                t.Tick += timechecker;
                t.Start();
            }
            else
            {
                t.Stop();
            }

        }

        int m, hs;
        private void start_Click(object sender, EventArgs e)
        {
            m = int.Parse(MLeft.Text);
            hs = int.Parse(Hleft.Text);
            seconds = int.Parse(Sleft.Text);
            minute = int.Parse(MLeft.Text) * 60;
            hours = int.Parse(Hleft.Text) * 3600;
            start.Enabled = false;
            isclicked = true;
            Hleft.Enabled = false;
            MLeft.Enabled = false;
            Sleft.Enabled = false;
            is_shown = false;
            timer(true);
        }
        private void timechecker(object o, EventArgs e)
        {
            if (isclicked)
            {
                if (int.Parse(Hleft.Text) < 0 || int.Parse(MLeft.Text) < 0 || int.Parse(Sleft.Text) < 0)
                {
                    if (int.Parse(Hleft.Text) < 0)
                    {
                        Hleft.Text = "0";
                    }
                    else if (int.Parse(MLeft.Text) < 0)
                    {
                        MLeft.Text = "0";
                    }
                    else if (int.Parse(Sleft.Text) < 0)
                    {
                        Sleft.Text = "0";
                    }
                }
                if (Hleft.Text == "0" && MLeft.Text == "0" && Sleft.Text == "0")
                {
                    isclicked = false;
                    start.Enabled = true;
                    setfunc(modebox.SelectedItem.ToString());
                }
                if (seconds == 0)
                {
                    if (minute == 0 && hours > 0)
                    {
                        hours--;
                        minute = 59;
                        MLeft.Text = minute.ToString();
                    }
                    else if (minute > 0)
                    {
                        minute--;
                        m = int.Parse(MLeft.Text);
                        MLeft.Text = (m - 1).ToString();
                        seconds = 59;
                    }

                }
                else if (seconds > 0)
                {
                    seconds--;
                    if (minute == 0 && hours > 0)
                    {
                        hours--;
                        minute = 59;
                        seconds = 59;
                        m = int.Parse(MLeft.Text);
                        MLeft.Text = minute.ToString();
                        hs = int.Parse(Hleft.Text);
                        Hleft.Text = (hs - 1).ToString();
                    }
                    else if (MLeft.Text == "0" && Hleft.Text != "0" && Sleft.Text == "0")
                    {
                        minute = 59;
                        seconds = 59;
                        m = int.Parse(MLeft.Text);
                        MLeft.Text = minute.ToString();
                        Hleft.Text = (int.Parse(Hleft.Text) - 1).ToString();
                    }
                }
                Sleft.Text = seconds.ToString();
                if (Hleft.Text == "0" && MLeft.Text == "0" && Sleft.Text == "0")
                {
                    isclicked = false;
                    start.Enabled = true;
                    setfunc(modebox.SelectedItem.ToString());
                }
            }
        }
        private void setfunc(string mode)
        {
            switch (mode)
            {
                case "Shutdown":
                    Hleft.Text = "0";
                    MLeft.Text = "0";
                    Sleft.Text = "0";
                    counter = 5;
                    hours = 0;
                    minute = 0;
                    seconds = 0;
                    is_shown = false;
                    Process.Start("shutdown", "/s /t 0");
                    break;
                case "Restart":
                    Hleft.Text = "0";
                    MLeft.Text = "0";
                    Sleft.Text = "0";
                    counter = 5;
                    hours = 0;
                    minute = 0;
                    seconds = 0;
                    is_shown = false;
                    Process.Start("shutdown", "/r /t 0");
                    break;
                case "Sleep":
                    Hleft.Text = "0";
                    MLeft.Text = "0";
                    Sleft.Text = "0";
                    counter = 5;
                    hours = 0;
                    minute = 0;
                    seconds = 0;
                    is_shown = false;
                    SetSuspendState(false, true, true);
                    break;
                default:
                    counter = 5;
                    hours = 0;
                    minute = 0;
                    seconds = 0;
                    is_shown = false;
                    break;
            };
        }

        private void modebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mod_text.Text = modebox.SelectedItem.ToString();
        }

        private void Hleft_Click(object sender, EventArgs e)
        {
            if (int.Parse(Hleft.Text) >= 0 && int.Parse(Hleft.Text) < 24)
            {
                Hleft.Text = (int.Parse(Hleft.Text) + 1).ToString();
            }
            else if (int.Parse(Hleft.Text) == 24)
            {
                Hleft.Text = "0";
            }
        }

        private void MLeft_Click(object sender, EventArgs e)
        {
            if (int.Parse(MLeft.Text) >= 0 && int.Parse(MLeft.Text) <= 60)
            {
                MLeft.Text = (int.Parse(MLeft.Text) + 1).ToString();
            }
            else if (int.Parse(MLeft.Text) == 60)
            {
                MLeft.Text = "0";
            }
        }

        private void Sleft_Click(object sender, EventArgs e)
        {
            if (int.Parse(Sleft.Text) >= 0 && int.Parse(Sleft.Text) <= 60)
            {
                Sleft.Text = (int.Parse(Sleft.Text) + 1).ToString();
            }
            else if (int.Parse(Sleft.Text) == 60)
            {
                Sleft.Text = "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer(false);
            var x = MessageBox.Show("Are You Sure You Want To Reset The Timer ? ", "Stopping Time", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (x == DialogResult.Yes)
            {
                isclicked = false;
                start.Enabled = true;
                timer(false);
                Hleft.Text = "0";
                MLeft.Text = "0";
                Sleft.Text = "0";
                Hleft.Enabled = true;
                MLeft.Enabled = true;
                Sleft.Enabled = true;
            }
            else
            {
                isclicked = true;
                timer(true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer(false);
            var x = MessageBox.Show("Are You Sure You Want To " + modebox.SelectedItem.ToString(), "Force To " + modebox.SelectedItem.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (x == DialogResult.Yes)
            {
                switch (modebox.SelectedItem.ToString())
                {
                    case "Shutdown":
                        Hleft.Text = "0";
                        MLeft.Text = "0";
                        Sleft.Text = "0";
                        isclicked = false;
                        Process.Start("shutdown", "/s /t 0");
                        hours = 0;
                        minute = 0;
                        seconds = 0;
                        break;
                    case "Restart":
                        Hleft.Text = "0";
                        MLeft.Text = "0";
                        Sleft.Text = "0";
                        isclicked = false;
                        hours = 0;
                        minute = 0;
                        seconds = 0;
                        Process.Start("shutdown", "/r /t 0");
                        break;
                    case "Sleep":
                        Hleft.Text = "0";
                        MLeft.Text = "0";
                        Sleft.Text = "0";
                        isclicked = false;
                        hours = 0;
                        minute = 0;
                        seconds = 0;
                        SetSuspendState(false, true, true);
                        break;
                    default:
                        isclicked = false;
                        hours = 0;
                        minute = 0;
                        seconds = 0;
                        break;
                };
            }
            else
            {
                timer(true);
            }
        }
        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Current Version is 1.0", "Version 1.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void actions()
        {
            CountdownForm c = new CountdownForm();
            Application.Run(c);
        }
        private void actionByProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Thread t = new Thread(actions);
            t.SetApartmentState(ApartmentState.STA);
            t.IsBackground = false;
            t.Start();
        }
    }
}

    

