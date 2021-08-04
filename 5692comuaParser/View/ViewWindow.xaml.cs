using _5692comuaParser.Model;
using _5692comuaParser.ViewModel;
using System.Windows;

namespace _5692comuaParser.View
{
    /// <summary>
    /// Логика взаимодействия для ViewWindow.xaml
    /// </summary>
    public partial class ViewWindow : Window
    {
        private ViewWindowViewModel viewWindowViewModel;
        public ViewWindow(string headerString, byte[] imagePath, string linkString)
        {
            InitializeComponent();
            this.DataContext = viewWindowViewModel = new ViewWindowViewModel(headerString, imagePath, linkString);
        }
    }
}
