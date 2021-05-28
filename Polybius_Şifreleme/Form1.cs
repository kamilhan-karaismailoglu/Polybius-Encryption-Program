using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polybius_Şifreleme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            CıktıTextBox.Enabled = true;
            string cıktı = "";
            int satır, sütun,i;
            string metin = textBox1.Text.ToLower();
            for (i = 0; i < metin.Length; i++)
            {
                if (metin[i] == ' ') // boşluk karakteri bulma
                {
                    cıktı = cıktı.Substring(0, cıktı.Length - 1);
                    cıktı += " ";

                    continue;
                }
                satır = (int)Math.Floor((metin[i] - 'a') / 5.0) + 1; // satır sırası bulma

                sütun = (int)((metin[i] - 'a') % 5) + 1; // sütun sırası bulma

                if (metin[i] == 'k') // karakterin k harfi olma durumu
                {
                    satır = satır - 1;
                    sütun = 6 - sütun;
                }
                else if (metin[i] >= 'j') // karakterin j den büyük olma durumu
                {
                    if (sütun == 1)
                    {
                        sütun = 6;
                        satır = satır - 1;
                    }
                    sütun = sütun - 1;
                }
                string Ssatır = Convert.ToString(satır);
                string Ssütun = Convert.ToString(sütun);
                cıktı += Ssatır + Ssütun+"-";
            }
            CıktıTextBox.Text = cıktı.Substring(0, cıktı.Length - 1);
        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                        && !char.IsSeparator(e.KeyChar);
        }
    }
}
