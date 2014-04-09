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
using BL;
using Entities;

namespace QwidichIHMWPF
{
    /// <summary>
    /// Logique d'interaction pour GestionJoueurs.xaml
    /// </summary>
    public partial class GestionJoueurs : Window
    {
        public GestionJoueurs()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ViewModelEquipes teams = DataContext as ViewModelEquipes;
            if(teams != null)
            {
                teams.SaveJoueur();
            }
        }
    }
}
