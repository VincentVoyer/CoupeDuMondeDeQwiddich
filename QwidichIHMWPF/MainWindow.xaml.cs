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
using System.IO;
using System.Xml.Serialization;
using BL;

namespace QwidichIHMWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Param myParam = null;

        private CoupeManager cm = new CoupeManager();

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                loadWindow();
            }
            catch { }
        }

        private void loadWindow()
        {
            StringBuilder path = new StringBuilder();
            path.Append(System.IO.Path.GetTempPath())
                .Append("configQwidditchAccueil.qwd");

            if(File.Exists(path.ToString()))
            {
                StreamReader mFile = new StreamReader(path.ToString());
                XmlSerializer deserializer = new XmlSerializer(typeof(Param));

                myParam = deserializer.Deserialize(mFile) as Param;

                mFile.Close();

                if(myParam != null)
                {
                    Width = myParam.Width;
                    Height = myParam.Height;
                    Top = myParam.YPos;
                    Left = myParam.XPos;
                }  
            }
            else
            {
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            }
         
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StringBuilder path = new StringBuilder();
            path.Append(System.IO.Path.GetTempPath())
                .Append("configQwidditchAccueil.qwd");

            if (myParam != null)
            {
                StreamWriter mFile = new StreamWriter(path.ToString());
                XmlSerializer serializer = new XmlSerializer(typeof(Param));

                serializer.Serialize(mFile, myParam);

                mFile.Close();
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if(myParam == null)
            {
                myParam = new Param();
            }

            myParam.Height = Height;
            myParam.Width = Width;
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            if (myParam == null)
            {
                myParam = new Param();
            }

            myParam.XPos = Left;
            myParam.YPos = Top;
        }



        private void cups_Click(object sender, RoutedEventArgs e)
        {
            Window w = new GestionCoupes();
            ViewModelBase vm = new ViewModelCoupes();
            w.DataContext = vm;
            show(w);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window w = new GestionEquipes();
            ViewModelBase vm = new ViewModelEquipes();
            w.DataContext = vm;
            show(w);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window w = new GestionJoueurs();
            ViewModelBase vm = new ViewModelEquipes();
            w.DataContext = vm;
            show(w);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window w = new GestionStades();
            ViewModelBase vm = new ViewModelStades(cm.GetListStade().ToList());
            w.DataContext = vm;
            show(w);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window w = new GestionMatch();
            ViewModelBase vm = new ViewModelMatchs();
            w.DataContext = vm;
            show(w);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ViewModelBase reservs = new ViewModelReservations(cm.GetListReservation());
            Window w = new GestionReservation();
            w.DataContext = reservs;
            show(w);
        }

        private void show(Window w)
        {
            w.ShowDialog();
        }


    }
}
