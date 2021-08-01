using _5692comuaParser.Model.Custom_Element;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Controls;

namespace _5692comuaParser.Model
{
    public static class MainLogic
    {
        public static void ParseSite(ref StackPanel newsStackPanel)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string content = client.DownloadString("https://www.5692.com.ua/news");
            client.Dispose();

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(content);

            //брать всё, кроме первого и последнего
            //List<HtmlNode> newsNodes = document.DocumentNode.SelectNodes("//div[contains(@class, \'container-fluid\') and contains(@class, \'js-page-content\')]/div[@class=\'row\']").ToList();
            
            List<HtmlNode> newsNodes = document.DocumentNode.SelectNodes("//div[@class=\'c-news-block\']").ToList();

            for (int i = 0; i < newsNodes.Count; i++)
            {
                newsStackPanel.Children.Add(new NewsControl
                    (
                        //newsNodes[i].SelectNodes("//div[@class=\'c-news-block\']/div[contains(@class, \'c-card-label\') and contains(@class, \'c-card-label--in-news\')]")[i].InnerText,
                        //newsNodes[i].SelectNodes("//div[@class=\'c-news-block\']/span[@class=\'c-article-info__when\']")[i].InnerText,
                        //newsNodes[i].SelectNodes("//div[@class=\'c-news-block\']/a[@class=\'c-news-block__title\']")[i].InnerText,
                        //newsNodes[i].SelectNodes("//div[@class=\'c-news-block\']/div[@class=\'c-news-block__text\']")[i].InnerText

                        newsNodes[i].SelectNodes("//div[contains(@class, \'c-card-label\') and contains(@class, \'c-card-label--in-news\')]")[i].InnerText, 
                        newsNodes[i].SelectNodes("//span[@class=\'c-article-info__when\']/span")[i].InnerText,
                        newsNodes[i].SelectNodes("//a[@class=\'c-news-block__title\']")[i].InnerText.Replace("&quot;", "\""),
                        newsNodes[i].SelectNodes("//div[@class=\'c-news-block__text\']")[i].InnerText.Replace("&quot;", "\"")
                    ));
            }
        }
    }
}
