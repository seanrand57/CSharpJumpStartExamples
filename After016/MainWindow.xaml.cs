namespace After016
{
    using System.ComponentModel;
    using System.Threading;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var worker = new BackgroundWorker();

            worker.DoWork += (s, a) =>
                {
                    for (int i = 0; i < 20; i++)
                    {
                        this.Dispatcher.Invoke(
                            () =>
                                { this.CountOutput.Text = "Count: " + i; });
                        Thread.Sleep(500);
                    }
                };

            worker.RunWorkerAsync();
        }
    }
}