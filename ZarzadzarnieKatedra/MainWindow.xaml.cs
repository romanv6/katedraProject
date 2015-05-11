using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

namespace ZarzadzarnieKatedra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Prowadzacy> Listaprowadzacych { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            Listaprowadzacych = new ObservableCollection<Prowadzacy>();
            Listaprowadzacych.Add(new Prowadzacy("Michał", "Saleta", "9876543", "mgr", "Chuj"));
            Listaprowadzacych.Add(new Prowadzacy("Marek", "Saleta", "9876543", "mgr", "Coś"));
            Listaprowadzacych.Add(new Prowadzacy("Karol", "Kondrad", "9876543", "mgr", "Profesor"));
            Listaprowadzacych.Add(new Prowadzacy("Witek", "Małż", "9876543", "mgr", "Mon"));
            Listaprowadzacych.Add(new Prowadzacy("Franek", "Piętka", "9876543", "mgr", "Tor"));
            Listaprowadzacych.Add(new Prowadzacy("Bartek", "Rowicki", "9876543", "mgr", "Dsafg"));
        }
    }
}
