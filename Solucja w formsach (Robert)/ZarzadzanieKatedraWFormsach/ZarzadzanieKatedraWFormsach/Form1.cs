using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZarzadzanieKatedraWFormsach
{
    public partial class Form1 : Form
    {
        ListaPrzedmiotowClass listaPrzedmiotow;
        ListaProwadzacychClass listaProwadzacych;

        public Form1()
        {
            InitializeComponent();
            listaPrzedmiotow = new ListaPrzedmiotowClass();
            listaProwadzacych = new ListaProwadzacychClass();
        }

        public void ZaladujStanowiska()
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                System.IO.StreamReader(openFileDialog1.FileName);
                Stanowiska.ZaladujStanowiska(sr);
            }
            else
            {
                MessageBox.Show("Nie wybrano pliku, lub wybrany plik nie jest poprawny");
            }

        }

        public void ZaladujPrzedmioty()
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                System.IO.StreamReader(openFileDialog1.FileName);
                listaPrzedmiotow.ZaladujPrzedmioty(sr);
            }
            else
            {
                MessageBox.Show("Nie wybrano pliku, lub wybrany plik nie jest poprawny");
            }

        }

        public void ZaladujProwadzacych()
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                System.IO.StreamReader(openFileDialog1.FileName);
                listaProwadzacych.ZaladujProwadzacych(sr);
            }
            else
            {
                MessageBox.Show("Nie wybrano pliku, lub wybrany plik nie jest poprawny");
            }

        }

        public void SprawdzIleOsobMozeUczycDanegoPrzedmiotu()
        {
            int temp;
            foreach (var przedmiot in listaPrzedmiotow.ListaPrzedmiotow)
            {
                temp = 0;
                foreach (var prowadzacy in listaProwadzacych.ListaProwadzacych)
                {
                    foreach (var przedmiotUczony in prowadzacy.przedmiotyKtorychMozeUczyc)
                    {
                        if (przedmiot.Nazwa == przedmiotUczony)
                        {
                            temp++;
                        }
                    }
                }
                przedmiot.LiczbaUczacych = temp;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ZaladujStanowiska();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ZaladujPrzedmioty();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //listaPrzedmiotow.SortujOdNajmniejszejLiczbyUczacych();
            foreach (var item in listaPrzedmiotow.ListaPrzedmiotow)
            {
                MessageBox.Show(item.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ZaladujProwadzacych();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SprawdzIleOsobMozeUczycDanegoPrzedmiotu();
        }
    }
}
