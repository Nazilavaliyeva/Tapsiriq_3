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
    public partial class _4_veya_6_bolunme : Form
    {
        public readonly ErrorProvider errorProvider = new ErrorProvider();
        public _4_veya_6_bolunme()
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TryParseInput(out double number) && number % 1 == 0)
                {
                    int num = Convert.ToInt32(number);
                    string result = "";

                    if (num % 4 == 0 && num % 6 == 0)
                        result = "4-ə və 6-ya bölünür";
                    else if (num % 4 == 0)
                        result = "4-ə bölünür";
                    else if (num % 6 == 0)
                        result = "6-ya bölünür";
                    else
                        MessageBox.Show("Heç birinə bölünmür", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    label1.Text = result;
                }
                else
                {
                    MessageBox.Show("Bu əməliyyat yalnız tam ədədlərlə yerinə yetirilə bilər.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
