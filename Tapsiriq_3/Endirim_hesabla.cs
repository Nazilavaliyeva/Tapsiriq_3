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
    public partial class Endirim_hesabla : Form
    {
        public readonly ErrorProvider errorProvider = new ErrorProvider();

        public Endirim_hesabla()
        {
            InitializeComponent();
        }
        // Endirim hesabı üçün istifadəçi tərəfindən daxil edilən dəyəri yoxlayır   
        private bool TryParseInput(out double result)
        {
            string input = textBox1.Text.Trim();

            // Hərf daxil edilməsinin qarşısını alır
            if (string.IsNullOrWhiteSpace(input))
            {
                errorProvider.SetError(textBox1, "Zəhmət olmasa dəyər daxil edin.");
                result = 0;
                return false;
            }

            if (double.TryParse(input, out result))
            {
                errorProvider.SetError(textBox1, string.Empty);
                return true;
            }
            else
            {
                errorProvider.SetError(textBox1, "Zəhmət olmasa düzgün ədəd (tam və ya kəsr) daxil edin.");
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TryParseInput(out double esas))
                {
                    if (esas < 0)
                    {
                        MessageBox.Show("Əsas məbləğ mənfi ola bilməz.", " Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    double ferq = 0.0;
                    if (esas < 300)
                        ferq = esas * 0.10;
                    else if (esas <= 500)
                        ferq = esas * 0.10;
                    else if (esas <= 700)
                        ferq = esas * 0.15;
                    else
                        ferq = esas * 0.20;
                    double ode = esas - ferq;
                    label1.Text = $"Ödəniləcək məbləğ;{ode:F2} AZN";
                }
            }
            catch
            { 
                MessageBox.Show($"Xəta baş verdi;", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }

        }
    }
}
