using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ZarzadzanieKatedra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new WindowView();
        }

        private void MenuWczytajPracownikow_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Baza danych (*.csv)|*.csv";
            open.FileName = "baza.csv";
            open.CheckFileExists = true;
            open.CheckPathExists = true;
            try
            {
                if ((bool)open.ShowDialog())
                {
                    (this.DataContext as WindowView).WczytywanieProwadzacych.Execute(open.FileName);
                    MessageBox.Show("Poprawnie wczytano bazę");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd programu");
            }

        }

        private void MenuZapiszPracownikow_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "Pracownicy (*.csv)|*.csv";
            save.FileName = "pracownicy.csv";
            save.CheckFileExists = false;
            save.CheckPathExists = true;
            try
            {
                if ((bool)save.ShowDialog())
                {
                    (this.DataContext as WindowView).ZapisProwadzacych.Execute(save.FileName);
                    MessageBox.Show("Poprawnie zapisano bazę");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd programu");
            }
        }

        private void MenuWczytajPrzedmioty_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Baza danych (*.csv)|*.csv";
            open.FileName = "baza.csv";
            open.CheckFileExists = true;
            open.CheckPathExists = true;
            try
            {
                if ((bool)open.ShowDialog())
                {
                    (this.DataContext as WindowView).WczytywaniePrzedmiotow.Execute(open.FileName);
                    MessageBox.Show("Poprawnie wczytano bazę");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd programu");
            }
        }

        private void butUsun_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz usunąć tego pracownika?", "Zarządzanie katedrą", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    (this.DataContext as WindowView).UsunProwadzacego.Execute((Prowadzacy)(sender as Button).Tag);
                    break;
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Cancel:
                    break;
            }

        }

        private void MenuSymulacja_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as WindowView).Symulacja.Execute(null);
        }

        private void txtSzukajProwadzących_TextChanged(object sender, TextChangedEventArgs e)
        {
            (this.DataContext as WindowView).SzukanieProwadzących.Execute(txtSzukajProwadzących.Text);
        }

        private void txtSzukajPrzedmiotow_TextChanged(object sender, TextChangedEventArgs e)
        {
            (this.DataContext as WindowView).SzukaniePrzedmiotów.Execute(txtSzukajPrzedmiotow.Text);
        }

        private void MenuStanowiska_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Stanowiska (*.csv)|*.csv";
            open.FileName = "stanowiska.csv";
            open.CheckFileExists = true;
            open.CheckPathExists = true;
            try
            {
                if ((bool)open.ShowDialog())
                {
                    Stanowiska.ZaladujStanowiska(open.FileName);
                    MessageBox.Show("Poprawnie wczytano bazę");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd programu");
            }
        }


        private void MenuTypyPracowników_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Typy Pracowników (*.csv)|*.csv";
            open.FileName = "typy.csv";
            open.CheckFileExists = true;
            open.CheckPathExists = true;
            try
            {
                if ((bool)open.ShowDialog())
                {
                    TypyPracownikow.ZaladujStanowiska(open.FileName);
                    MessageBox.Show("Poprawnie wczytano bazę");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd programu");
            }
        }

    }
    class WindowView : ViewModelBase
    {
        string frazaProwadzący = String.Empty;
        string frazaPrzedmioty = String.Empty;
        Symulacja symulacja;
        ListaProwadzacych listaProwadzacych { get; set; }
        ListaPrzedmiotow listaPrzedmiotow { get; set; }
        public WindowView()
        {
            WczytywanieProwadzacych = new RelayCommand<string>(WczytajProwadzacych);
            WczytywaniePrzedmiotow = new RelayCommand<string>(WczytajPrzedmioty);
            ZapisProwadzacych = new RelayCommand<string>(Zapisz);
            UsunProwadzacego = new RelayCommand<Prowadzacy>(UsuńProwadzącego);
            Symulacja = new RelayCommand(WykonajSymulację);
            SzukanieProwadzących = new RelayCommand<string>(SzukajProwadzącego);
            SzukaniePrzedmiotów = new RelayCommand<string>(SzukajPrzedmioty);
        }

        #region RelayCommand
        public RelayCommand<string> WczytywanieProwadzacych { get; private set; }
        public RelayCommand<string> WczytywaniePrzedmiotow { get; private set; }
        public RelayCommand<string> ZapisProwadzacych { get; private set; }
        public RelayCommand<Prowadzacy> UsunProwadzacego { get; private set; }
        public RelayCommand Symulacja { get; private set; }
        public RelayCommand<string> SzukaniePrzedmiotów { get; private set; }
        public RelayCommand<string> SzukanieProwadzących { get; private set; }
        #endregion

        #region Properities
        public ObservableCollection<Prowadzacy> ListOfLectures
        {
            get
            {
                ObservableCollection<Prowadzacy> Result = new ObservableCollection<Prowadzacy>();
                if (listaProwadzacych != null)
                {
                    if (frazaProwadzący == String.Empty)
                    {
                        foreach (Prowadzacy item in listaProwadzacych)
                        {
                            Result.Add(item);
                        }
                    }
                    else
                    {
                        List<Prowadzacy> listaPomocnicza = listaProwadzacych.SzukajProwadzacych(frazaProwadzący);
                        if (listaPomocnicza != null)
                        {
                            foreach (Prowadzacy item in listaPomocnicza)
                            {
                                Result.Add(item);
                            }
                        }
                    }
                }
                return Result;
            }
        }
        public ObservableCollection<Przedmiot> ListOfClasses
        {
            get
            {
                ObservableCollection<Przedmiot> Result = new ObservableCollection<Przedmiot>();
                if (listaPrzedmiotow != null)
                {
                    if (frazaPrzedmioty == String.Empty)
                    {
                        foreach (Przedmiot item in listaPrzedmiotow)
                        {
                            Result.Add(item);
                        }
                    }
                    else
                    {
                        List<Przedmiot> listaPomocnicza = listaPrzedmiotow.SzukajPrzedmiotów(frazaPrzedmioty);
                        if (listaPomocnicza != null)
                        {
                            foreach (Przedmiot item in listaPomocnicza)
                            {
                                Result.Add(item);
                            }
                        }
                    }
                }
                return Result;
            }
        }
        public Visibility VisibilityOfSimulation
        {
            get
            {
                if (listaPrzedmiotow != null && listaProwadzacych != null) return Visibility.Visible;
                return Visibility.Collapsed;
            }
        }
        public Visibility VisibilityOfViewer
        {
            get
            {
                if (listaPrzedmiotow != null || listaProwadzacych != null) return Visibility.Visible;
                return Visibility.Collapsed;
            }
        }
        public Visibility VisibilityOfLectures
        {
            get
            {
                if (listaProwadzacych != null) return Visibility.Visible;
                return Visibility.Collapsed;
            }
        }
        public Visibility VisibilityOfClasses
        {
            get
            {
                if (listaPrzedmiotow != null) return Visibility.Visible;
                return Visibility.Collapsed;
            }
        }
        public int SelectedTabIndex
        {
            get
            {
                if (listaPrzedmiotow != null) return 1;
                return 0;
            }
            set
            {

            }
        }
        #endregion

        #region Methods
        private void WczytajProwadzacych(string path)
        {
            listaProwadzacych = new ListaProwadzacych();
            listaProwadzacych.ZaladujProwadzacych(path);
            RaisePropertyChanged("ListOfLectures");
            RaisePropertyChanged("VisibilityOfLectures");
            RaisePropertyChanged("VisibilityOfViewer");
            RaisePropertyChanged("VisibilityOfSimulation");
            RaisePropertyChanged("SelectedTabIndex");
        }
        private void WczytajPrzedmioty(string path)
        {
            listaPrzedmiotow = new ListaPrzedmiotow();
            listaPrzedmiotow.ZaladujPrzedmioty(path);
            RaisePropertyChanged("VisibilityOfViewer");
            RaisePropertyChanged("ListOfClasses");
            RaisePropertyChanged("VisibilityOfClasses");
            RaisePropertyChanged("VisibilityOfSimulation");
            RaisePropertyChanged("SelectedTabIndex");
        }
        private void UsuńProwadzącego(Prowadzacy prowadzący)
        {
            this.listaProwadzacych.Remove(prowadzący);
            RaisePropertyChanged("ListOfLectures");
            RaisePropertyChanged("VisibilityOfLectures");
            RaisePropertyChanged("VisibilityOfSimulation");
            RaisePropertyChanged("VisibilityOfViewer");
            RaisePropertyChanged("SelectedTabIndex");
        }
        private void SzukajProwadzącego(string tekst)
        {
            if (listaProwadzacych != null)
            {
                frazaProwadzący = tekst;
                RaisePropertyChanged("ListOfLectures");
                RaisePropertyChanged("VisibilityOfLectures");
                RaisePropertyChanged("VisibilityOfViewer");
                RaisePropertyChanged("SelectedTabIndex");
            }
        }
        private void SzukajPrzedmioty(string tekst)
        {
            if (listaPrzedmiotow != null)
            {
                frazaPrzedmioty = tekst;
                RaisePropertyChanged("ListOfClasses");
                RaisePropertyChanged("VisibilityOfClasses");
                RaisePropertyChanged("VisibilityOfViewer");
                RaisePropertyChanged("SelectedTabIndex");
            }
        }
        private void WykonajSymulację()
        {
            if (listaProwadzacych == null || listaPrzedmiotow == null) return;
            symulacja = new Symulacja(listaPrzedmiotow, listaProwadzacych);
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
            RaisePropertyChanged("ListOfLectures");
            RaisePropertyChanged("VisibilityOfLectures");
            RaisePropertyChanged("ListOfClasses");
            RaisePropertyChanged("VisibilityOfClasses");
            RaisePropertyChanged("VisibilityOfSimulation");
            RaisePropertyChanged("VisibilityOfViewer");
            RaisePropertyChanged("SelectedTabIndex");
        }

        private void Zapisz(string path)
        {
            if (listaProwadzacych != null)
                this.listaProwadzacych.ZapiszListeProwadzacych(path);
        }
        #endregion
    }
}
