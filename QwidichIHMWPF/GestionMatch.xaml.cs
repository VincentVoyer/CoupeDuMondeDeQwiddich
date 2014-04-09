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
using System.Windows.Shapes;
using Entities;
using BL;

namespace QwidichIHMWPF
{
    /// <summary>
    /// Logique d'interaction pour GestionMatch.xaml
    /// </summary>
    public partial class GestionMatch : Window
    {

        public GestionMatch()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ViewModelMatchs vm = (ViewModelMatchs)DataContext;
            vm.SaveMatchs();
        }

    }
}
