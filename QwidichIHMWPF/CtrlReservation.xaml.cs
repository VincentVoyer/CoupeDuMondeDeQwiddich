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
using Entities;
using BL;

namespace QwidichIHMWPF
{
    /// <summary>
    /// Logique d'interaction pour CtrlReservation.xaml
    /// </summary>
    public partial class CtrlReservation : UserControl
    {
        
        public Reservation Reservation
        {
            get;
            set;
        }

        public CtrlReservation()
        {
            CoupeManager cm = new CoupeManager();
            InitializeComponent();
            cbCup.ItemsSource = cm.GetListCoupes();
        }

        private void cbCup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if(cb != null)
            {
                Coupe cup = cb.SelectedItem as Coupe;
                if(cup != null)
                {
                    CoupeManager cm = new CoupeManager();
                    cbMatch.ItemsSource = cm.GetListMatch(cup);
                }
            }
        }
    }
}
