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
using System.Resources;
using System.Globalization;
//using GlobalStore.SerialPortManager.SerialPortManager;

namespace GlobalStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ResourceManager resourceManager;
        private SerialPortManager.SerialPortManager serialPortManager;
        WebInteraction webInteraction = new WebInteraction();
        Rect rect = new Rect();
        AcceptWindow acceptWindow = new AcceptWindow();
        Language language = new Language();
        Product thisProduct =  null;
        public bool InvokeRequired { get; private set; }

        public MainWindow()
        {
            language = Entity.Language.RO;
            InitializeComponent();
            resourceManager = new ResourceManager("GlobalStore.Localisation.Interface", typeof(MainWindow).Assembly);
            translateInterface(language);
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
             serialPortManager.StartListening();
          

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
            thisProduct = webInteraction.getProductByBarcode(barcode.Trim());
            refreshData(thisProduct,language);
            
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
            ResourceManager resourceManager = new ResourceManager("GlobalStore.Localisation.Interface", typeof(MainWindow).Assembly);
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo(language.ToString());

            this.txt_scan.Text = resourceManager.GetString("TXT_SCANNING", cultureInfo).ToString();
            this.txt_en.Text = resourceManager.GetString("TXT_EN", cultureInfo).ToString();
            this.txt_ro.Text = resourceManager.GetString("TXT_RO", cultureInfo).ToString();
            this.txt_ru.Text = resourceManager.GetString("TXT_RU", cultureInfo).ToString();
            this.listViewItem_txtleaveFbck.Text = resourceManager.GetString("TXT_LEAVE_FEEDBACK", cultureInfo).ToString();
            this.listViewItem_txtscan.Text = resourceManager.GetString("TXT_SCAN", cultureInfo).ToString();
            if (data !=null)
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

        private void listViewTranslateEn_Selected(object sender, RoutedEventArgs e)
        {
            translateInterface(Entity.Language.EN);
        }

        private void listViewItemScanning_Selected(object sender, RoutedEventArgs e)
        {
            this.mainGrid.Visibility = Visibility.Visible;
            this.feedbackGrid.Visibility = Visibility.Hidden;
        }

        private void listViewTranslateRo_Selected(object sender, RoutedEventArgs e)
        {
            translateInterface(Entity.Language.RO);
        }

        private void listViewTranslateRu_Selected(object sender, RoutedEventArgs e)
        {
            translateInterface(Entity.Language.RU);
        }

        private void listViewItemLeaveFeedback_Selected(object sender, RoutedEventArgs e)
        {
            this.mainGrid.Visibility = Visibility.Hidden;
            this.feedbackGrid.Visibility = Visibility.Visible;
        }
    }
}
