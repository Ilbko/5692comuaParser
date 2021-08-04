using _5692comuaParser.Model;
using HtmlAgilityPack;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;

namespace _5692comuaParser.ViewModel
{
    public class ViewWindowViewModel : INotifyPropertyChanged
    {
        private string headerString;
        public string HeaderString
        {
            get { return headerString; }
            set { headerString = value; OnPropertyChanged("HeaderString"); }
        }

        private byte[] imagePath;
        public byte[] ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; OnPropertyChanged("ImagePath"); }
        }

        private string bodyString;
        public string BodyString
        {
            get { return bodyString; }
            set { bodyString = value; OnPropertyChanged("BodyString"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public ViewWindowViewModel(string headerString, byte[] imagePath, string linkString)
        {
            this.ImagePath = imagePath;
            this.HeaderString = headerString;

            string content;
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                content = client.DownloadString(linkString);
            }

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(content);

            this.BodyString = document.DocumentNode.SelectSingleNode("//div[@class=\'article-text\']").InnerText;
        }
    }
}
