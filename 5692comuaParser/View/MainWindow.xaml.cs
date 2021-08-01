using _5692comuaParser.ViewModel;
using System.Windows;

namespace _5692comuaParser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = new MainViewModel();
            InitializeComponent();
        }
    }
}
