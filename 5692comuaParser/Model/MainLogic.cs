using _5692comuaParser.Model.Custom_Element;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _5692comuaParser.Model
{
    public static class MainLogic
    {
        public readonly static string folderName = "pictures";
        public static int count = 0;
        public static void ParseSite(ref StackPanel newsStackPanel)
        {
            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);

            string content = string.Empty;
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                content = client.DownloadString("https://www.5692.com.ua/news");
            }

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(content);

            List<HtmlNode> newsNodes = document.DocumentNode.SelectNodes("//div[@class=\'c-news-block\']").ToList();
            UIElementCollection newsCollection = newsStackPanel.Children;         

            //Цикл "for", поддерживающий параллельное выполнение итераций. (88 картинок: обычный "for" - 13 сек.; параллельный "for" - 9 сек.)
            Parallel.For(0, newsNodes.Count, i =>
            {
                //Выполнение итерации от имени диспетчера асинхронно (BeginInvoke)
                Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (ThreadStart)delegate() 
                    {
                        newsCollection.Add(new NewsControl
                            (
                                newsNodes[i].SelectNodes("//div[contains(@class, \'c-card-label\') and contains(@class, \'c-card-label--in-news\')]")[i].InnerText,
                                newsNodes[i].SelectNodes("//span[@class=\'c-article-info__when\']/span")[i].InnerText,
                                newsNodes[i].SelectNodes("//a[@class=\'c-news-block__title\']")[i].InnerText.Replace("&quot;", "\""),
                                newsNodes[i].SelectNodes("//div[@class=\'c-news-block__text\']")[i].InnerText.Replace("&quot;", "\""),
                                newsNodes[i].SelectNodes("//a[contains(@class, \'c-news-block__image\') and contains(@class, \'lazy-bg\')]")[i].Attributes["data-src"].Value
                            )
                        );
                   });
            });

            //Поскольку async/await, Task и Parallel не работают с ref, in и out, то сначала все элементы помещаются в созданный в методе список,
            //а затем помещаются в список параметра, передаваемого в метод
            foreach (UIElement item in newsCollection)
            {
                newsStackPanel.Children.Add(item);
            }

            //for (int i = 0; i < newsNodes.Count; i++)
            //{
            //    newsStackPanel.Children.Add(new NewsControl
            //        (
            //            newsNodes[i].SelectNodes("//div[contains(@class, \'c-card-label\') and contains(@class, \'c-card-label--in-news\')]")[i].InnerText,
            //            newsNodes[i].SelectNodes("//span[@class=\'c-article-info__when\']/span")[i].InnerText,
            //            newsNodes[i].SelectNodes("//a[@class=\'c-news-block__title\']")[i].InnerText.Replace("&quot;", "\""),
            //            newsNodes[i].SelectNodes("//div[@class=\'c-news-block__text\']")[i].InnerText.Replace("&quot;", "\""),
            //            newsNodes[i].SelectNodes("//a[contains(@class, \'c-news-block__image\') and contains(@class, \'lazy-bg\')]")[i].Attributes["data-src"].Value
            //        ));
            //}
        }
    }
}
