using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tapsiriq_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void musbet_Click(object sender, EventArgs e)
        {
            musbet_ve_menfi musbet_Ve_Menfi = new musbet_ve_menfi();
            musbet_Ve_Menfi.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cut_ve_tek cut = new Cut_ve_tek();
            cut.Show();
        }
    }
}
