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
    public partial class Qiymete_uygun_herf : Form
    {
        public readonly ErrorProvider errorProvider = new ErrorProvider();
        public Qiymete_uygun_herf()
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

        //Bal daxil edərək qiymət hərfini göstərir 
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TryParseInput(out double score) && score % 1 == 0)
                {
                    int bal = Convert.ToInt32(score);

                    if (bal >= 0 && bal <= 100)
                    {
                        string grade = "";

                        if (bal <= 50) grade = "F";
                        else if (bal <= 60) grade = "E";
                        else if (bal <= 70) grade = "D";
                        else if (bal <= 80) grade = "C";
                        else if (bal <= 90) grade = "B";
                        else grade = "A";

                        label1.Text = $"Qiymət: {grade}";
                    }
                    else
                    {
                        MessageBox.Show("Bal 0 ilə 100 arasında olmalıdır.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Zəhmət olmasa tam bal dəyəri daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
