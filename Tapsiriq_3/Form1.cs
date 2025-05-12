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
        public readonly ErrorProvider errorProvider = new ErrorProvider();
        public Form1()
        {
            InitializeComponent();
        }
        //Tam və ya kəsr ədədi  oxuyur ve doğruluğunu yoxlayır
        private bool TryParseInput(out double result)
        {
            string input = textBox1.Text.Trim();
            //Hərf daxil edilməsinin qarşısını alır 
            if (string.IsNullOrWhiteSpace(input))
            {
                errorProvider.SetError(textBox1, "Zəhmət olmasa ədədi daxil edin");
                result = 0;
                return false;
            }
            if (double.TryParse(input, out result))
            {
                errorProvider.SetError(textBox1, string.Empty);
                return false;
            }
            else
            {
                errorProvider.SetError(textBox1, "Zəhmət olmasa düzgün ədəd(tam və ya kəsr) daxil edin.");
                return false;
            }


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

        private void button3_Click(object sender, EventArgs e)
        {
            _3_veya_4_bolunme bolunme = new _3_veya_4_bolunme();
            bolunme.Show(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _4_veya_6_bolunme Bolunme = new _4_veya_6_bolunme(); 
            Bolunme.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Qiymete_uygun_herf qiymete_Uygun_Herf = new Qiymete_uygun_herf();
            qiymete_Uygun_Herf.Show();  
        }

        
    }
}
