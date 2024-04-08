using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using static System.Windows.Forms.Design.AxImporter;
namespace CTimer
{
    public partial class CountdownForm : Form
    {
        string p;
        bool started = false;
        public CountdownForm()
        {
            InitializeComponent();
            modbox.SelectedIndex = 0;
            button2.Enabled = false;
            settimer();
        }
        private void settimer()
        {
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += getprocess;
            t.Start();
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
                if (process.ProcessName.Equals("explorer", StringComparison.OrdinalIgnoreCase) &&
                   IsExplorerCopyingOrMovingFiles(process))
                {
                    processbox.Items.Add(process.MainWindowTitle);
                }
            }

            foreach (string item in existingItems)
            {
                bool found = false;

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
                    processbox.Items.Remove(item);
                }
            }
        }
        private void CountdownForm_Load(object sender, EventArgs e)
        {
        }
        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetSuspendState(bool hibernate, bool forceCritical, bool disableWakeEvent);
        [DllImport("user32.dll")]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int processId);
        private static bool IsExplorerCopyingOrMovingFiles(Process process)
        {
            // Get the main window title of the Explorer process
            string mainWindowTitle = GetMainWindowTitle(process);

            // Check if the title contains specific phrases indicating file operations
            return mainWindowTitle.Contains("Copying") ||
                   mainWindowTitle.Contains("Moving") ||
                   mainWindowTitle.Contains("Preparing to copy") ||
                   mainWindowTitle.Contains("Preparing to move");
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);
        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        private const uint GW_HWNDNEXT = 2;
        private static string GetMainWindowTitle(Process process)
        {
            IntPtr mainWindowHandle = IntPtr.Zero;
            StringBuilder titleBuilder = new StringBuilder(256);

            // Enumerate windows to find the main window of the process
            EnumWindows((hWnd, lParam) =>
            {
                if (process.Id == GetWindowProcessId(hWnd))
                {
                    GetWindowText(hWnd, titleBuilder, titleBuilder.Capacity);
                    if (titleBuilder.Length > 0)
                    {
                        mainWindowHandle = hWnd;
                        return false; // Stop enumerating
                    }
                }
                return true; // Continue enumerating
            }, IntPtr.Zero);

            return titleBuilder.ToString();
        }
        private static int GetWindowProcessId(IntPtr hWnd)
        {
            int processId;
            GetWindowThreadProcessId(hWnd, out processId);
            return processId;
        }
        private void mains()
        {
            Form1 f = new Form1();
            Application.Run(f);
        }
        private void actionByTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(started)
            {
                var x = MessageBox.Show("Are You Sure You Want To Change Timer Mode You are Currently Running Timer", "Timer Running All Ready !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == x)
                {
                    Close();
                    Thread t = new Thread(mains);
                    t.SetApartmentState(ApartmentState.STA);
                    t.IsBackground = false;
                    t.Start();

                }
            }
            else
            {
                Close();
                Thread t = new Thread(mains);
                t.SetApartmentState(ApartmentState.STA);
                t.IsBackground = false;
                t.Start();
            }

        }
        private void setfunc(string mode)
        {
            switch (mode)
            {
                case "Shutdown":
                    Process.Start("shutdown", "/s /t 0");
                    started = false;
                    break;
                case "Restart":
                    Process.Start("shutdown", "/r /t 0");
                    started = false;
                    break;
                case "Sleep":
                    SetSuspendState(false, true, true);
                    started = false;
                    break;
                default:
                    MessageBox.Show("Nothing");
                    started = false;
                    break;
            };
        }
        private void checkprocess(object o, EventArgs e)
        {
            if (!processbox.Items.Contains(p) && started)
            {
                setfunc(modbox.SelectedItem.ToString());
            }
        }
        private void start_Click(object sender, EventArgs e)
        {
            if(processbox.SelectedItem !=  null)
            {
                start.Enabled = false;
                button2.Enabled = true;
                p = processbox.SelectedItem.ToString();
                started = true;
                System.Windows.Forms.Timer ts = new System.Windows.Forms.Timer();
                ts.Interval = 1000;
                ts.Tick += checkprocess;
                ts.Start();
            }
            else
            {
                MessageBox.Show("Please Choose A Process", "No Process is selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            start.Enabled = true;
            button2.Enabled = false;
            started = false;
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Current Version is 1.0", "Version 1.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
