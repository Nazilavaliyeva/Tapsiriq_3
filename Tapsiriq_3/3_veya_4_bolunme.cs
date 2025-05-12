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
    public partial class _3_veya_4_bolunme : Form
    {
        public readonly ErrorProvider errorProvider = new ErrorProvider();
        public _3_veya_4_bolunme()
        {
            InitializeComponent();
        }
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
                if (TryParseInput(out double number) && number % 1 == 0)
                {
                    int num = Convert.ToInt32(number);
                    string result = (num % 3 == 0 || num % 4 == 0) ? "Bölünür" : "Bölünmür";
                    label1.Text = result;
                }
                else
                {
                    MessageBox.Show("Yalnız tam ədədlərlə işləyir.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
