using _5692comuaParser.Model;
using System.Windows.Controls;

namespace _5692comuaParser.ViewModel
{
    public class MainViewModel
    {
        public MainViewModel(ref StackPanel newsStackPanel)
        {
            MainLogic.ParseSite(ref newsStackPanel);
        }
    }
}
