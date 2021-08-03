using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media;

namespace _5692comuaParser.Model.Custom_Element.ViewModel
{
    public class NewsViewModel : INotifyPropertyChanged
    {
        private string categoryString;
        public string CategoryString
        {
            get { return categoryString; }
            set { categoryString = value; OnPropertyChanged("CategoryString"); }
        }

        private string dateTimeString;
        public string DateTimeString
        {
            get { return dateTimeString; }
            set { dateTimeString = value; OnPropertyChanged("DateTimeString"); }
        }

        private string headerString;
        public string HeaderString
        {
            get { return headerString; }
            set { headerString = value; OnPropertyChanged("HeaderString"); }
        }

        private string bodyString;
        public string BodyString
        {
            get { return bodyString; }
            set { bodyString = value; OnPropertyChanged("BodyString"); }
        }

        private ImageSource imagePath;
        public ImageSource ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; OnPropertyChanged("ImagePath"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = " ")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
