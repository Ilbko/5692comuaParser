using _5692comuaParser.Model.Custom_Element;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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
            //UIElementCollection newsCollection = newsStackPanel.Children;

            //var tasks = new List<Task>();

            for (int i = 0; i < newsNodes.Count; i++)
            {
                newsStackPanel.Children.Add(new NewsControl
                    (
                        newsNodes[i].SelectNodes("//div[contains(@class, \'c-card-label\') and contains(@class, \'c-card-label--in-news\')]")[i].InnerText,
                        newsNodes[i].SelectNodes("//span[@class=\'c-article-info__when\']/span")[i].InnerText,
                        newsNodes[i].SelectNodes("//a[@class=\'c-news-block__title\']")[i].InnerText.Replace("&quot;", "\""),
                        newsNodes[i].SelectNodes("//div[@class=\'c-news-block__text\']")[i].InnerText.Replace("&quot;", "\""),
                        newsNodes[i].SelectNodes("//a[contains(@class, \'c-news-block__image\') and contains(@class, \'lazy-bg\')]")[i].Attributes["data-src"].Value
                    ));

                //try
                //{
                //    Task.Run(() => newsCollection.Add(new NewsControl
                //        (
                //            newsNodes[i].SelectNodes("//div[contains(@class, \'c-card-label\') and contains(@class, \'c-card-label--in-news\')]")[i].InnerText,
                //            newsNodes[i].SelectNodes("//span[@class=\'c-article-info__when\']/span")[i].InnerText,
                //            newsNodes[i].SelectNodes("//a[@class=\'c-news-block__title\']")[i].InnerText.Replace("&quot;", "\""),
                //            newsNodes[i].SelectNodes("//div[@class=\'c-news-block__text\']")[i].InnerText.Replace("&quot;", "\""),
                //            newsNodes[i].SelectNodes("//a[contains(@class, \'c-news-block__image\') and contains(@class, \'lazy-bg\')]")[i].Attributes["data-src"].Value
                //        )));
                //} catch (System.ArgumentOutOfRangeException e) { }

                //    try
                //    {
                //        int index = i;

                //        tasks.Add(Task.Factory.StartNew(() => Application.Current.Dispatcher.Invoke(() => newsCollection.Add(new NewsControl
                //               (
                //                   newsNodes[index].SelectNodes("//div[contains(@class, \'c-card-label\') and contains(@class, \'c-card-label--in-news\')]")[index].InnerText,
                //                   newsNodes[index].SelectNodes("//span[@class=\'c-article-info__when\']/span")[index].InnerText,
                //                   newsNodes[index].SelectNodes("//a[@class=\'c-news-block__title\']")[index].InnerText.Replace("&quot;", "\""),
                //                   newsNodes[index].SelectNodes("//div[@class=\'c-news-block__text\']")[index].InnerText.Replace("&quot;", "\""),
                //                   newsNodes[index].SelectNodes("//a[contains(@class, \'c-news-block__image\') and contains(@class, \'lazy-bg\')]")[index].Attributes["data-src"].Value
                //               )))));
                //    } catch (System.ArgumentOutOfRangeException e) { } 
                //}

                //Task.WaitAll(tasks.ToArray());

                //foreach (UIElement item in newsCollection)
                //{
                //    newsStackPanel.Children.Add(item);
                //}
            }
        }
    }
}
