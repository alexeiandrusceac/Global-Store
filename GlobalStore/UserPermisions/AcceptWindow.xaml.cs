using System.Windows;

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
