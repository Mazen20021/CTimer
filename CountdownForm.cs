using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTimer
{
    public partial class CountdownForm : Form
    {
        public CountdownForm(int count)
        {
            InitializeComponent();
        }
        public void UpdateCounterText(string text)
        {
            if (counter.InvokeRequired)
            {
                counter.Invoke((MethodInvoker)(() => counter.Text = text));
            }
            else
            {
                counter.Text = text;
            }
        }
        private void CountdownForm_Load(object sender, EventArgs e)
        {

        }
    }
}
