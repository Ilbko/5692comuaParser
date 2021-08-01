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
        public NewsControl(string categoryString, string dateTimeString, string headerString, string bodyString)
        {
            this.DataContext = new NewsViewModel() 
            { 
                CategoryString = categoryString, 
                DateTimeString = dateTimeString, 
                HeaderString = headerString, 
                BodyString = bodyString 
            };
            InitializeComponent();
        }

        private void headerTextBlock_MouseEnter(object sender, MouseEventArgs e) => (sender as TextBlock).TextDecorations = TextDecorations.Underline;

        private void headerTextBlock_MouseLeave(object sender, MouseEventArgs e) => (sender as TextBlock).TextDecorations = null;
    }
}
