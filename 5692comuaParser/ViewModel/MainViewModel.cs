using _5692comuaParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
