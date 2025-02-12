using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Deley : Form
    {
        public string DelayStart, DelayEnd;
    
        public Deley()
        {
            InitializeComponent();

        }

        private void fix_Load(object sender, EventArgs e)
        {
            label1.Text = Properties.Resources.starttime;
            label2.Text = Properties.Resources.endtime;
            label3.Text= Properties.Resources.second;
            label4.Text = Properties.Resources.second;
            this.Text = Properties.Resources.fix2;

        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            DelayStart = StartnumericUpDown.Value.ToString();
            DelayEnd = EndnumericUpDown.Value.ToString();


            this.Close();
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
