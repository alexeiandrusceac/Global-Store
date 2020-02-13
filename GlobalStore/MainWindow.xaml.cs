using GlobalStore.SerialPortManager;

using System;

using System.Text;

using System.Windows;
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
        private CultureInfo cultureInfo;
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

            if (e.Data != null)
            {
                this.LayoutRoot.Visibility = Visibility.Hidden;
                this.searchingGrid.Visibility = Visibility.Visible;
                
                string barcode = Encoding.ASCII.GetString(e.Data);
                thisProduct = webInteraction.getProductByBarcode(barcode.Trim());
                if (thisProduct != null)
                {
                    // this.searchResult.Text = resourceManager.GetString("TXT_NORESULT", cultureInfo).ToString();
                    this.searchingGrid.Visibility = Visibility.Hidden;
                    refreshData(thisProduct, language);
                }
                else
                {
                    this.searchResult.Text = resourceManager.GetString("TXT_NORESULT", cultureInfo).ToString();
                }
            }
            else
            {
                this.LayoutRoot.Visibility = Visibility.Visible;
            }

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
             cultureInfo = CultureInfo.GetCultureInfo(language.ToString());

            this.txt_scan.Text = resourceManager.GetString("TXT_SCANNING", cultureInfo).ToString();
            this.txt_en.Text = resourceManager.GetString("TXT_EN", cultureInfo).ToString();
            this.txt_ro.Text = resourceManager.GetString("TXT_RO", cultureInfo).ToString();
            this.txt_ru.Text = resourceManager.GetString("TXT_RU", cultureInfo).ToString();
            this.priceTitle.Text = resourceManager.GetString("TXT_TOTALPRICE", cultureInfo).ToString();
            this.listViewItem_txtleaveFbck.Text = resourceManager.GetString("TXT_LEAVE_FEEDBACK", cultureInfo).ToString();
            this.listViewItem_txtscan.Text = resourceManager.GetString("TXT_SCAN", cultureInfo).ToString();
            
            if (data !=null)
            {
                this.productTitle.Text = data.getTitle(language);
                this.productDescription.Text = data.getDescription(language);
                this.priceRetail.Text = string.Format(data.Price + " MDL");
                if (data.PricePromo > 0 && data.PricePromo < data.Price)
                {
                    this.priceRetail.TextDecorations = TextDecorations.Strikethrough;
                    this.priceRetail.FontSize = 24;
                    this.pricePromo.Visibility = Visibility.Visible;
                    
                }
                //this.productPrice.Text = string.Format( "{0} {1}",data.Price + data.PricePromo);

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
            Application.Current.Shutdown();
            Environment.Exit(0);

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
