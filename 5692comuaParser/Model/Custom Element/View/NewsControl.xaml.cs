using _5692comuaParser.Model.Custom_Element.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _5692comuaParser.Model.Custom_Element
{
    /// <summary>
    /// Логика взаимодействия для NewsControl.xaml
    /// </summary>
    public partial class NewsControl : UserControl
    {
        public NewsControl()
        {
            this.DataContext = new NewsViewModel();
            InitializeComponent();
        }

        private void headerTextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as TextBlock).TextDecorations = TextDecorations.Underline;
        }
    }
}
