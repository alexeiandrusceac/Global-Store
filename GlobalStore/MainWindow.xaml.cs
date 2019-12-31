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

        public bool InvokeRequired { get; private set; }

        public MainWindow()
        {
            language = Entity.Language.RO;
            populateData();
        }
        private void translateInterface(Language lang)
        {
            refreshData(lang);
        }

        private void refreshData(Language lang)
        {
            switch (lang)
            {
                case Entity.Language.RO:
                break;
            }
        }

        void populateData()
        {
           /* serialPortManager = new SerialPortManager.SerialPortManager();
            SerialSettings mySerialSettings = serialPortManager.CurrentSerialSettings;
            serialPortManager.NewSerialDataRecieved += new EventHandler<SerialDataEventArgs>(serialPortManager_NewSerialDataRecieved);
            serialPortManager.StartListening();*/

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
                //this.BeginInvoke(new EventHandler<SerialDataEventArgs>(serialPortManager_NewSerialDataRecieved), new object[] { sender, e });
                return;
            }

            string barcode = Encoding.ASCII.GetString(e.Data);

            fillData( new Product().convertToProductFromObj(
                webInteraction.getProductByBarcode(barcode.Trim())),language);
            
                       
            /* myUserControl.descriptionLabel.Text = rm.GetString("description",ci);
             myUserControl.productTitle.Text = productData.getName(_language);
             myUserControl.descriptionValue.Text = productData.getDescription(_language);
             myUserControl.priceLabelValue.Text = string.Format(rm.GetString("price",ci) + productData.Price + " MDL");*/

        }
        private void fillData(Product data, Language language)
        {

            this.productTitle.Text = data.getTitle(language);
            this.productDescription.Text = data.getDescription(language);
            //this.productDescription.Text = data.TitleRO;
            
            /*DescriptionProduct.Text = productData.DescriptionRO;
            Price.Text = productData.Price.ToString();*/

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

        }
    }
}
