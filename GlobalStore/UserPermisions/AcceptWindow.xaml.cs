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

namespace GlobalStore.UserPermisions
{
    /// <summary>
    /// Interaction logic for AcceptWindow.xaml
    /// </summary>
    public partial class AcceptWindow : Window
    {
        WebInteraction wbInteraction = null ;
        public AcceptWindow()
        {
           InitializeComponent();
           wbInteraction = new WebInteraction();
        }
        private void buttonAccept_Click(object sender, RoutedEventArgs e)
        {

            if (wbInteraction.getStatus(this.adminPassword.Text))
            {
                Application.Current.Shutdown();
            }
            else
            {
                MessageBox.Show("Accesul este interzis!!!"); 
            }
        }
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
