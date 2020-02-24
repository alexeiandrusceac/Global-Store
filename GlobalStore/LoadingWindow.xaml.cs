using System.Windows;


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
          //  onshown();
        }

        void onshown()
        {
            
            /*Thread newWindowThread = new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(2000);
                MainWindow mainWindow = new MainWindow();

                mainWindow.Loaded += (sender, args) =>
                {
                    Application.Current.Dispatcher.Invoke(new Action(() => { this.Close() ; }));
                };

                // When the window closes, shut down the dispatcher
                mainWindow.Closed += (s, e) =>
                   Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);

                mainWindow.Show();
                // Start the Dispatcher Processing
                Dispatcher.Run();
            }));

            newWindowThread.SetApartmentState(ApartmentState.STA);
            // Make the thread a background thread
            newWindowThread.IsBackground = false;
            // Start the thread
            newWindowThread.Start();*/
        }
            
       
    }
}
