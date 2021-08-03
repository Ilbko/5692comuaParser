using _5692comuaParser.Model;
using _5692comuaParser.ViewModel;
using System.IO;
using System.Windows;
using System.Linq;
using System;
using System.Threading;

namespace _5692comuaParser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel(ref this.newsStackPanel);
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            //GC.Collect();
            //Thread.Sleep(4000);

            //Directory.GetFiles(MainLogic.folderName).ToList().ForEach(x => File.Delete(x));

            for (int i = 1; i <= MainLogic.count; i++)
            {
                File.Delete($"{MainLogic.folderName}\\{i}.jpg");
            }
        }
    }
}
