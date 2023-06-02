using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace HW_WPF_Petrol_Station_MVC_
{
   
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller controller;
        DispatcherTimer timer;
        bool FlagTimer = true;
        public MainWindow()
        {
            InitializeComponent();
            controller = new Controller();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += Timer_Tick;
            timer.Start();
            txtDate.Text = DateTime.Now.ToShortDateString();
            txtDate.IsEnabled = false;
            DayOfWeek.Text = DateTime.Now.DayOfWeek.ToString();
            DayOfWeek.IsEnabled = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(FlagTimer)
            { 
                txtDate.Text = DateTime.Now.ToShortTimeString(); FlagTimer=false; 
            }
            else
            {
                txtDate.Text = DateTime.Now.ToShortDateString(); FlagTimer = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AddcbxPetrolList();
            cbxPetrol.SelectedIndex = 0;
            txtblPricePetrol.IsEnabled = false;
            txtblctotalPetrolSumm.IsEnabled = false;
            txtHotDogPrice.Text = controller.GetPricePositionIndex(0).ToString("N2");
            txtGamburgerPrice.Text = controller.GetPricePositionIndex(1).ToString("N2"); ;
            txtPotatoPrice.Text = controller.GetPricePositionIndex(2).ToString("N2");
            txtColaPrice.Text = controller.GetPricePositionIndex(3).ToString("N2"); ;
            
            rbtnCount.IsChecked = true;
            txtHotDogAmount.Text = "0";
            txtBurgerAmount.Text = "0";
            txtPotatoAmount.Text = "0";
            txtColaAmount.Text = "0";
            txtHotDogAmount.IsEnabled = false;
            txtBurgerAmount.IsEnabled = false;
            txtPotatoAmount.IsEnabled = false;
            txtColaAmount.IsEnabled = false;
            txtTotalCafe.IsEnabled = false;
            txtTotalSumm.Text = "00,00";

           

            

        }



        private void AddcbxPetrolList()
        {
            foreach (var el in controller.GetPetrolCollection())
            {
                cbxPetrol.Items.Add(el.Kind);

            }
           
        }

        private void cbxPetrol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbxPetrol.SelectedIndex)
            {
                case 0: txtblPricePetrol.Text = controller.GetPricePositionIndex(0).ToString("N2"); break;
                case 1: txtblPricePetrol.Text = controller.GetPricePositionIndex(1).ToString("N2");  break;
                case 2: txtblPricePetrol.Text = controller.GetPricePositionIndex(2).ToString("N2");  break;
                case 3: txtblPricePetrol.Text = controller.GetPricePositionIndex(3).ToString("N2"); break;
                case 4: txtblPricePetrol.Text = controller.GetPricePositionIndex(4).ToString("N2"); break;

            }
        }

        private void rbtn_Checked(object sender, RoutedEventArgs e)
        {
            if (rbtnCount.IsChecked == true)
            {
                txtcSummPetrol.IsReadOnly = true;
                txtbxAmountPetrol.IsReadOnly = false;
                txtbxAmountPetrol.Text = 10.ToString("N2");
                txtcSummPetrol.Text = Payment_Petrol().ToString("N2");
            }
            if (rbtnSumm.IsChecked == true)
            {
                txtcSummPetrol.IsReadOnly = false;
                txtbxAmountPetrol.IsReadOnly = true;

                txtcSummPetrol.Text = 100.ToString("N2");
                txtbxAmountPetrol.Text = (Payment_Petrol() / double.Parse(txtblPricePetrol.Text)).ToString("N2");

            }
            txtblctotalPetrolSumm.Text = txtcSummPetrol.Text;

        }
        private double Payment_Petrol()
        {
            double res = 0;
            if (rbtnCount.IsChecked == true && !string.IsNullOrEmpty(txtbxAmountPetrol.Text))
            {
                res = double.Parse(txtblPricePetrol.Text) * double.Parse(txtbxAmountPetrol.Text);
            }
            if (rbtnSumm.IsChecked == true)
            {
                res = double.Parse(txtcSummPetrol.Text);


            }


            return res;
        }

        private void txtbxAmountPetrol_TextChanged(object sender, TextChangedEventArgs e)
       {
            if (!string.IsNullOrEmpty(txtbxAmountPetrol.Text))
            {
                txtcSummPetrol.Text = Payment_Petrol().ToString("N2");
            }
            txtblctotalPetrolSumm.Text = txtcSummPetrol.Text;
        }
        private void txtblPricePetrol_TextChanged(object sender, TextChangedEventArgs e)
        {
            rbtn_Checked(sender, (RoutedEventArgs)e);

        }
        private void txtcSummPetrol_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtcSummPetrol.Text) && rbtnSumm.IsChecked == true)
            {
                
                txtbxAmountPetrol.Text = (Payment_Petrol() / double.Parse(txtblPricePetrol.Text)).ToString("N2");
            }
            txtblctotalPetrolSumm.Text = txtcSummPetrol.Text;
           // txtcSummPetrol.Select(txtcSummPetrol.Text.Length, 0); //PROBLEM!!

        }

        private void chbxHotDog_Checked(object sender, RoutedEventArgs e)
        {
            if (chbxHotDog.IsChecked == false)
            {
                txtHotDogAmount.Text = "0";
                txtHotDogAmount.IsEnabled = false;
            }
            if (chbxHotDog.IsChecked == true)
            {
                txtHotDogAmount.Text = "1";
                txtHotDogAmount.IsEnabled = true;
            }

        }

        private void chbxGamburger_Checked(object sender, RoutedEventArgs e)
        {
            if (chbxGamburger.IsChecked == false)
            {
                txtBurgerAmount.Text = "0";
                txtBurgerAmount.IsEnabled = false;
            }
            if (chbxGamburger.IsChecked == true)
            {
                txtBurgerAmount.Text = "1";
                txtBurgerAmount.IsEnabled = true;
            }

        }

        private void chbxPotato_Checked(object sender, RoutedEventArgs e)
        {
            if (chbxPotato.IsChecked == false)
            {
                txtPotatoAmount.Text = "0";
                txtPotatoAmount.IsEnabled = false;
            }
            if (chbxPotato.IsChecked == true)
            {
                txtPotatoAmount.Text = "1";
                txtPotatoAmount.IsEnabled = true;
            }
        }

        private void chbxCola_Checked(object sender, RoutedEventArgs e)
        {
            if (chbxCola.IsChecked == false)
            {
                txtColaAmount.Text = "0";
                txtColaAmount.IsEnabled = false;
            }
            if (chbxCola.IsChecked == true)
            {
                txtColaAmount.Text = "1";
                txtColaAmount.IsEnabled = true;
            }
        }
        private double TotalSumCafe()
        {
            double res = 0;

            res = double.Parse(txtColaAmount.Text) * double.Parse(txtColaPrice.Text) +
                double.Parse(txtHotDogAmount.Text) * double.Parse(txtHotDogPrice.Text) +
                double.Parse(txtBurgerAmount.Text) * double.Parse(txtGamburgerPrice.Text)
                + double.Parse(txtPotatoAmount.Text) * double.Parse(txtPotatoPrice.Text);


            return res;
        }

        private void txtHotDogAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(TxtCheckEmpty()) txtTotalCafe.Text = TotalSumCafe().ToString();
            if (txtHotDogAmount.Text == string.Empty)
                txtHotDogAmount.Text = "0";

        }

        private void txtBurgerAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxtCheckEmpty()) txtTotalCafe.Text = TotalSumCafe().ToString();
            if (txtBurgerAmount.Text == string.Empty)
                txtBurgerAmount.Text = "0";
        }

        private void txtPotatoAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxtCheckEmpty()) txtTotalCafe.Text = TotalSumCafe().ToString();
            if (txtPotatoAmount.Text == string.Empty)
                txtPotatoAmount.Text = "0";
        }

        private void txtColaAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxtCheckEmpty()) txtTotalCafe.Text = TotalSumCafe().ToString();
            if (txtColaAmount.Text == string.Empty)
                txtColaAmount.Text = "0";

        }
        private bool TxtCheckEmpty()
        {
            if (txtHotDogAmount.Text != string.Empty &&
           txtBurgerAmount.Text != string.Empty &&
           txtPotatoAmount.Text != string.Empty &&
           txtColaAmount.Text != string.Empty)
                return true;
            return false;
        }

        private void btnTotalSumm_Click(object sender, RoutedEventArgs e)
        {

            txtTotalSumm.Text = (double.Parse(txtTotalCafe.Text) + double.Parse(txtcSummPetrol.Text)).ToString("N2");
        }

        private void txtblctotalPetrolSumm_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtcSummPetrol.Text) && rbtnSumm.IsChecked == true)
            {
                txtbxAmountPetrol.Text = (Payment_Petrol() / double.Parse(txtblPricePetrol.Text)).ToString("N2");
            }
            txtblctotalPetrolSumm.Text = txtcSummPetrol.Text;
        }

        private void txtcSummPetrol_GotFocus(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Window_Loaded(sender , e);
            chbxPotato.IsChecked = false;
            chbxCola.IsChecked = false;
            chbxGamburger.IsChecked = false;
            chbxHotDog.IsChecked=false;


        }

        private void btnClearPetrol_Click(object sender, RoutedEventArgs e)
        {
            AddcbxPetrolList();
            cbxPetrol.SelectedIndex = 0;
            txtblPricePetrol.IsEnabled = false;
            txtblctotalPetrolSumm.IsEnabled = false;
            rbtnCount.IsChecked = true;
        }

        private void btnClearCafe_Click(object sender, RoutedEventArgs e)
        {
            txtHotDogPrice.Text = controller.GetPricePositionIndex(0).ToString("N2");
            txtGamburgerPrice.Text = controller.GetPricePositionIndex(1).ToString("N2"); ;
            txtPotatoPrice.Text = controller.GetPricePositionIndex(2).ToString("N2");
            txtColaPrice.Text = controller.GetPricePositionIndex(3).ToString("N2"); ;

         
            txtHotDogAmount.Text = "0";
            txtBurgerAmount.Text = "0";
            txtPotatoAmount.Text = "0";
            txtColaAmount.Text = "0";
            txtHotDogAmount.IsEnabled = false;
            txtBurgerAmount.IsEnabled = false;
            txtPotatoAmount.IsEnabled = false;
            txtColaAmount.IsEnabled = false;
            txtTotalCafe.IsEnabled = false;
            chbxPotato.IsChecked = false;
            chbxCola.IsChecked = false;
            chbxGamburger.IsChecked = false;
            chbxHotDog.IsChecked = false;


        }

        private void btnFakeClient_Click(object sender, RoutedEventArgs e)
        {
            txtTotalSumm.Text = (double.Parse(txtTotalSumm.Text) * 0.1 + double.Parse(txtTotalSumm.Text)) .ToString("N2");
        }

        private void btnDiscaunt_Click(object sender, RoutedEventArgs e)
        {
            txtTotalSumm.Text=(double.Parse(txtTotalSumm.Text)-double.Parse(txtTotalSumm.Text) * 0.05).ToString("N2");
        }

        private void btnDarkTheme_Click(object sender, RoutedEventArgs e)
        {
          Background = new SolidColorBrush(Colors.DarkGray);
          Foreground = new SolidColorBrush(Colors.Blue);
          BorderBrush = new SolidColorBrush(Colors.LightBlue);
            
        }

        private void btnLightTheme_Click(object sender, RoutedEventArgs e)
        {
            Background = new SolidColorBrush(Colors.White);
            Foreground = new SolidColorBrush(Colors.Black);
            BorderBrush = new SolidColorBrush(Colors.LightBlue);
        }
    }
}
