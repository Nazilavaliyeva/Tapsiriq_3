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
    public partial class musbet_ve_menfi : Form
    {
        public readonly ErrorProvider errorProvider = new ErrorProvider();
        public musbet_ve_menfi()
        {
            InitializeComponent();
        }
        //Tam ve ya kəsr ədədi oxuyur və doğruluğunu yoxlayırş

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
                if (TryParseInput(out double number))
                {
                    string result = number > 0 ? "Müsbət ədəddir"
                                 : number < 0 ? "Mənfi ədəddir"
                                 : "Sıfırdır";

                    label1.Text = result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
