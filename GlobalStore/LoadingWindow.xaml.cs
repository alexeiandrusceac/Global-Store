using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GlobalStore
{
    /// <summary>
    /// Interaction logic for LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        
        public LoadingWindow()
        {
            InitializeComponent();
            onshown();
        }

        void onshown()
        {
            Thread newWindowThread = new Thread(new ThreadStart(() =>
            {
                MainWindow mainWindow = new MainWindow();

                mainWindow.Loaded += (sender, args) =>
                {
                    Application.Current.Dispatcher.Invoke(new Action(() => { this.Close(); }));
                };

                // When the window closes, shut down the dispatcher
                mainWindow.Closed += (s, e) =>
                   Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);

                mainWindow.Show();
                // Start the Dispatcher Processing
                System.Windows.Threading.Dispatcher.Run();
            }));

            newWindowThread.SetApartmentState(ApartmentState.STA);
            // Make the thread a background thread
            newWindowThread.IsBackground = false;
            // Start the thread
            newWindowThread.Start();
        }
            
       
    }
}
