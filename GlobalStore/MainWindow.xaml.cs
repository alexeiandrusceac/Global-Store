using GlobalStore.SerialPortManager;
using GlobalStore;
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
using GlobalStore.Entity;
using GlobalStore.UserPermisions;
//using GlobalStore.SerialPortManager.SerialPortManager;

namespace GlobalStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SerialPortManager.SerialPortManager serialPortManager;
        WebInteraction webInteraction = new WebInteraction();
        Rect rect = new Rect();
        AcceptWindow acceptWindow = new AcceptWindow();
        Language language = new Language();
        Product thisProduct = new Product();
        public bool InvokeRequired { get; private set; }

        public MainWindow()
        {
            language = Entity.Language.RO;
            populateData();
        }
        private void translateInterface(Language lang)
        {
            switch (lang)
            {
                case Entity.Language.RO:
                    refreshData(thisProduct, lang);
                    break;
                case Entity.Language.RU:
                    refreshData(thisProduct, lang);
                    break;
                case Entity.Language.EN:
                    refreshData(thisProduct, lang);
                    break;
            }
           
        }

        void populateData()
        {
            serialPortManager = new SerialPortManager.SerialPortManager();
            SerialSettings mySerialSettings = serialPortManager.CurrentSerialSettings;
            serialPortManager.NewSerialDataRecieved += new EventHandler<SerialDataEventArgs>(serialPortManager_NewSerialDataRecieved);
            //if (((SerialSettings)serialPortManager.CurrentSerialSettings).PortName != null)
           // {
                serialPortManager.StartListening();
          //  }

        }
        private Rect GetWindowSize()
        {
            Window myWindow = Application.Current.MainWindow;
            Rect myRect = new Rect();
            myRect.Height = myWindow.Height;
            myRect.Width = myWindow.Width;

            return myRect;
        }

        void serialPortManager_NewSerialDataRecieved(object sender, SerialDataEventArgs e)
        {
            if (this.InvokeRequired)
            {
                return;
            }

            string barcode = Encoding.ASCII.GetString(e.Data);

            refreshData( thisProduct.convertToProductFromObj(
                webInteraction.getProductByBarcode(barcode.Trim())),language);
            
        }
        private void StartProcess(object sender, RoutedEventArgs e)
        {
            //show BusyIndicator
            busyIndicator.IsBusy = true;

            //long running process
            for (int i = 0; i < 100; i++)
            {
                System.Threading.Thread.Sleep(50);
            }
            //hide BusyIndicator
            busyIndicator.IsBusy = false;
        }

        private void refreshData(Product data, Language language)
        {
            if (data != null)
            {
                this.productTitle.Text = data.getTitle(language);
                this.productDescription.Text = data.getDescription(language);
               // this.productPrice.Text = string.Format( "{0} {1}",data.Price + data.PricePromo);

            }
           
        }

        private void ButtonMaximize_Click(object sender,RoutedEventArgs e)
        {
            Window thisWindow = Application.Current.MainWindow;
            if (thisWindow.WindowState == WindowState.Maximized)
            {
                thisWindow.WindowState = WindowState.Normal;
                thisWindow.Height = rect.Height;
                thisWindow.Width = rect.Width;
            }
            else{
                rect = GetWindowSize();
                thisWindow.WindowState = WindowState.Maximized;
            }
        }
        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Window thisWindow = Application.Current.MainWindow;
            thisWindow.WindowState = WindowState.Minimized;
           
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            AcceptWindow acceptWindow = new AcceptWindow();

        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            /*ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;*/
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
           /* ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;*/
        }

        private void listViewItem1_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void listViewItemLeaveFeedback_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.feedbackGrid.Visibility = Visibility.Visible;
            this.scannerGrid.Visibility = Visibility.Hidden;
        }

        private void listViewTranslateEn_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            translateInterface(Entity.Language.EN);

        }

        private void listViewTranslateRo_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            translateInterface(Entity.Language.RO);
        }

        private void listViewTranslateRu_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            translateInterface(Entity.Language.RU);
        }

        private void listViewItemScanning_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.feedbackGrid.Visibility = Visibility.Hidden;
            this.scannerGrid.Visibility = Visibility.Visible;
        }
    }
}
