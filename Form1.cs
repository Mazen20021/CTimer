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
        int times = 0;

        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetSuspendState(bool hibernate, bool forceCritical, bool disableWakeEvent);
        public Form1()
        {
            InitializeComponent();
            mBox.Visible = false;
            SBox.Visible = false;
            HBox.Visible = false;
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


        private void start_Click(object sender, EventArgs e)
        {
            mBox.Visible = false;
            SBox.Visible = false;
            HBox.Visible = false;
            start.Enabled = false;
            isclicked = true;
            Hleft.Enabled = false;
            MLeft.Enabled = false;
            Sleft.Enabled = false;
            times = (int.Parse(Hleft.Text) * 3600 + int.Parse(MLeft.Text) * 60 + int.Parse(Sleft.Text));
            Tseconds.Text = times.ToString();
            timer(true);
        }
        private void timechecker(object o, EventArgs e)
        {
            if (isclicked)
            {
                if (times == 0)
                {
                    times = 0;
                    setfunc(modebox.SelectedItem.ToString());
                }
                else if (times > 0)
                {
                    Tseconds.Text = times.ToString();
                    times--;
                }
                else
                {
                    times = 0;
                    Tseconds.Text = times.ToString();
                }
            }
            else
            {
                Hleft.Enabled = true;
                MLeft.Enabled = true;
                Sleft.Enabled = true;
                start.Enabled = true;
                timer(false);
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
                    isclicked = false;
                    Process.Start("shutdown", "/s /t 0");
                    break;
                case "Restart":
                    Hleft.Text = "0";
                    MLeft.Text = "0";
                    Sleft.Text = "0";

                    isclicked = false;
                    Process.Start("shutdown", "/r /t 0");
                    break;
                case "Sleep":
                    Hleft.Text = "0";
                    MLeft.Text = "0";
                    Sleft.Text = "0";
                    isclicked = false;
                    SetSuspendState(false, true, true);
                    break;
                default:
                    MessageBox.Show("No Process");
                    isclicked = false;
                    break;
            };
        }

        private void modebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mod_text.Text = modebox.SelectedItem.ToString();
        }

        private void Hleft_Click(object sender, EventArgs e)
        {
            if (HBox.Visible)
            {
                HBox.Visible = false;
            }
            else
            {
                HBox.Visible = true;
            }
        }

        private void MLeft_Click(object sender, EventArgs e)
        {
            if (mBox.Visible)
            {
                mBox.Visible = false;
            }
            else
            {
                mBox.Visible = true;
            }
        }

        private void Sleft_Click(object sender, EventArgs e)
        {
            if (SBox.Visible)
            {
                SBox.Visible = false;
            }
            else
            {
                SBox.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var x = MessageBox.Show("Are You Sure You Want To Reset The Timer ? ", "Stopping Time", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (x == DialogResult.Yes)
            {
                times = -1;
                Tseconds.Text = "0";
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
                        break;
                    case "Restart":
                        Hleft.Text = "0";
                        MLeft.Text = "0";
                        Sleft.Text = "0";
                        isclicked = false;
                        Process.Start("shutdown", "/r /t 0");
                        break;
                    case "Sleep":
                        Hleft.Text = "0";
                        MLeft.Text = "0";
                        Sleft.Text = "0";
                        isclicked = false;
                        SetSuspendState(false, true, true);
                        break;
                    default:
                        isclicked = false;
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
            if (isclicked)
            {
                var x = MessageBox.Show("Are You Sure You Want To Change Timer Mode You are Currently Running Timer", "Timer Running All Ready !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == x)
                {
                    Close();
                    Thread t = new Thread(actions);
                    t.SetApartmentState(ApartmentState.STA);
                    t.IsBackground = false;
                    t.Start();

                }
            }
            else
            {
                Close();
                Thread t = new Thread(actions);
                t.SetApartmentState(ApartmentState.STA);
                t.IsBackground = false;
                t.Start();
            }

        }

        private void HBox_TextChanged(object sender, EventArgs e)
        {
            Hleft.Text = HBox.Text;
        }

        private void mBox_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(mBox.Text) <= 60 && mBox.Text != "")
            {
                MLeft.Text = mBox.Text;
            }
            else
            {
                mBox.Text = "60";
                MessageBox.Show("Minutes Limited 60", "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SBox_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(SBox.Text) <= 60 && SBox.Text != "")
            {
                Sleft.Text = SBox.Text;
            }
            else
            {
                SBox.Text = "60";
                MessageBox.Show("Seconds Limited 60", "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

    

