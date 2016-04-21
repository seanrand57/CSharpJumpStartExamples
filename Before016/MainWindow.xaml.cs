namespace Before016
{
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
            for (int i = 0; i < 10; i++)
            {
                this.CountOutput.Text = "Count: " + i;
                Thread.Sleep(500);
            }
        }
    }
}