using System;
using System.Collections.Generic;
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
        public int Wykorzystane
        {
            get
            {
                int zmienna = 0;
                foreach (var item in test)
                {
                    zmienna += item.Value;
                }
                return zmienna;
            }
        }
        //public int Niewykorzystne
        //{
        //    get
        //    {
        //        return godzinaWykładu - Wykorzystane;
        //    }
        //}
        public MainWindow()
        {
            InitializeComponent();
            test = new Dictionary<string, int>();
            test.Add("Roman", 10);
            test.Add("Michał", 20);
            test.Add("Karol", 30);

        }
        Dictionary<string, int> test;
    }
}
