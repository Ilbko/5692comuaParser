using _5692comuaParser.Model.Custom_Element.ViewModel;
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _5692comuaParser.Model.Custom_Element
{
    /// <summary>
    /// Логика взаимодействия для NewsControl.xaml
    /// </summary>
    public partial class NewsControl : UserControl
    {
        public NewsControl(string categoryString, string dateTimeString, string headerString, string bodyString, string imagePath)
        {
            InitializeComponent();

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(imagePath, $"{MainLogic.folderName}\\{++MainLogic.count}.jpg");
            }

            ImageSource imageSource = null;
            //убрать, использует файл
            try
            {
                imageSource = new ImageSourceConverter().ConvertFromString($"{MainLogic.folderName}\\{MainLogic.count}.jpg") as ImageSource;
            }
            catch (System.Exception e) { }

            this.DataContext = new NewsViewModel()
            {
                CategoryString = categoryString,
                DateTimeString = dateTimeString,
                HeaderString = headerString,
                BodyString = bodyString,
                ImagePath = imageSource
            };
        }

        private void headerTextBlock_MouseEnter(object sender, MouseEventArgs e) => (sender as TextBlock).TextDecorations = TextDecorations.Underline;
        private void headerTextBlock_MouseLeave(object sender, MouseEventArgs e) => (sender as TextBlock).TextDecorations = null;
    }
}
