using System;
using System.Diagnostics;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using CTimer.Updates;
using System.Runtime.InteropServices;
using System.Text;
using System.Runtime.InteropServices;
namespace CTimer
{
    public partial class Form1 : Form
    {
        Hub h = new Hub();

        bool found = false;
        bool isclicked = false;
        bool started = false;
        int seconds = 0;
        int minute = 0;
        int hours = 0;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        private const uint GW_HWNDNEXT = 2;

        [DllImport("user32.dll")]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int processId);
        [DllImport("Powrprof.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetSuspendState(bool hibernate, bool forceCritical, bool disableWakeEvent);

        public Form1()
        {
            InitializeComponent();
            h.CheckForUpdates();
            getproceS();
        }
        private void getproceS()
        {
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += getprocess;
            t.Start();
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
        private void getprocess(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();
            List<string> existingItems = new List<string>(processbox.Items.Cast<string>());

            foreach (var process in processes)
            {
                if (string.IsNullOrEmpty(process.MainWindowTitle))
                    continue;

                if (!existingItems.Contains(process.MainWindowTitle))
                {
                    processbox.Items.Add(process.MainWindowTitle);
                }
            }

            foreach (string item in existingItems)
            {
                foreach (var process in processes)
                {
                    if (string.IsNullOrEmpty(process.MainWindowTitle))
                        continue;

                    if (item.Contains(process.MainWindowTitle))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    processbox.TabIndex = processbox.Items.Count - 1;
                    processbox.Items.Remove(item);
                }
                found = false;
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
            timer(true);
        }
        private void timechecker(object o, EventArgs e)
        {
            if (isclicked)
            {
                if (seconds == 0)
                {
                    if (minute == 0 && hours > 0)
                    {
                        hours--;
                        minute = 60;
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
                    if (minute == 0 && hours > 0 && seconds == 0)
                    {
                        hours--;
                        minute = 59;
                        seconds = 59;
                        hs = int.Parse(Hleft.Text);
                        Hleft.Text = (hs - 1).ToString();
                    }
                }
                Sleft.Text = seconds.ToString();
                if (seconds == 0 && minute == 0 && hours == 0)
                {
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
                    isclicked = false;
                    MessageBox.Show("Shutdown Process ...\n");
                    // Process.Start("shutdown", "/s /t 0");
                    hours = 0;
                    minute = 0;
                    seconds = 0;
                    break;
                case "Restart":
                    Hleft.Text = "0";
                    MLeft.Text = "0";
                    Sleft.Text = "0";
                    isclicked = false;
                    MessageBox.Show("Restart Process ...\n");
                    hours = 0;
                    minute = 0;
                    seconds = 0;
                    //Process.Start("shutdown", "/r /t 0");
                    break;
                case "Sleep":
                    Hleft.Text = "0";
                    MLeft.Text = "0";
                    Sleft.Text = "0";
                    isclicked = false;
                    Console.WriteLine("Sleep Process ...\n");
                    hours = 0;
                    minute = 0;
                    seconds = 0;
                    //SetSuspendState(false, true, true);
                    break;
                default:
                    isclicked = false;
                    MessageBox.Show("no Process ...\n");
                    hours = 0;
                    minute = 0;
                    seconds = 0;
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
            var x = MessageBox.Show("Are You Sure You Want To "+modebox.SelectedItem.ToString(), "Force To "+ modebox.SelectedItem.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (x == DialogResult.Yes)
            {
                switch (modebox.SelectedItem.ToString())
                {
                    case "Shutdown":
                        Hleft.Text = "0";
                        MLeft.Text = "0";
                        Sleft.Text = "0";
                        isclicked = false;
                        MessageBox.Show("Shutdown Process ...\n");
                        // Process.Start("shutdown", "/s /t 0");
                        hours = 0;
                        minute = 0;
                        seconds = 0;
                        break;
                    case "Restart":
                        Hleft.Text = "0";
                        MLeft.Text = "0";
                        Sleft.Text = "0";
                        isclicked = false;
                        MessageBox.Show("Restart Process ...\n");
                        hours = 0;
                        minute = 0;
                        seconds = 0;
                        //Process.Start("shutdown", "/r /t 0");
                        break;
                    case "Sleep":
                        Hleft.Text = "0";
                        MLeft.Text = "0";
                        Sleft.Text = "0";
                        isclicked = false;
                        Console.WriteLine("Sleep Process ...\n");
                        hours = 0;
                        minute = 0;
                        seconds = 0;
                        //SetSuspendState(false, true, true);
                        break;
                    default:
                        isclicked = false;
                        MessageBox.Show("no Process ...\n");
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
    }
}
