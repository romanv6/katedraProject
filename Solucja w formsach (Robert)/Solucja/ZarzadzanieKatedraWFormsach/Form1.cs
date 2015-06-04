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
        Symulacja symulacja;

        public Form1()
        {
            InitializeComponent();
            listaPrzedmiotow = new ListaPrzedmiotowClass();
            listaProwadzacych = new ListaProwadzacychClass();
        }




        #region Nie ruszać!!!
        /// <summary>
        /// ladowanie stanowisk z pliku do listy
        /// </summary>
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

        /// <summary>
        /// ladowanie typy pracownikow z pliku do listy
        /// </summary>
        public void ZaladujTypyPracownikow()
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                System.IO.StreamReader(openFileDialog1.FileName);
                TypyPracownikow.ZaladujStanowiska(sr);
            }
            else
            {
                MessageBox.Show("Nie wybrano pliku, lub wybrany plik nie jest poprawny");
            }

        }

        /// <summary>
        /// wczytywanie przedmiotow z listy do pliku
        /// </summary>
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

        /// <summary>
        /// wczytywanie prowadzacych z listy do pliku
        /// </summary>
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

        /// <summary>
        /// ta metoda musi być w formularzu, bo wykonujemy równoczesnie operacje na 4rech klasach
        /// </summary>
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

        /// <summary>
        /// metoda wykonuje symulacje
        /// </summary>
        public void WykonajSymulacje()
        {
            symulacja = new Symulacja(listaPrzedmiotow,listaProwadzacych);
            
            if (symulacja.WykonajSymulacje()) //jak symulacja się uda, zostanie zwrócona wartość true
            {
                MessageBox.Show("Symulacja udana");
            }
            else
            {
                MessageBox.Show("Symulacja nieudana");
            }

            listaPrzedmiotow = symulacja.ZwrocListePrzedmiotowPoSymulacji();
            listaProwadzacych = symulacja.ZwrocListeProwadzacychPoSymulacji();
            /*po symulacji klasa symulacja, ma listy, które zostały zedytowane.
             * Musisz te listy przechwytywać, za pomocą dwóch metod dostępnych w klasie symulacja */
        }

        #endregion




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
            listBox1.Items.Clear();
            listaPrzedmiotow.SortujOdNajmniejszejLiczbyUczacych();
            foreach (var item in listaPrzedmiotow.ListaPrzedmiotow)
            {
                listBox1.Items.Add(item.ToString());
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

        private void button6_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listaProwadzacych.SortujOdNajmniejszejLiczbyUczonychPrzedmiotow();
            foreach (var item in listaProwadzacych.ListaProwadzacych)
            {
                listBox2.Items.Add(item.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            WykonajSymulacje();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ZaladujTypyPracownikow();
        }
    }
}
