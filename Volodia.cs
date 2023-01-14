using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser_2022_
{
    internal class Volodia
    {
        public static string GetHtml(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())//new client
                {
                    using (HttpResponseMessage response = client.GetAsync(url).Result)//responce from web
                    {
                        using (HttpContent content = response.Content)
                        {
                            return content.ReadAsStringAsync().Result;//HTML
                        }
                    }
                }
            }
            catch { return ""; }
        }

        public static void mykolayiv2()
        {
            for (int i = 1; i <= 57; ++i)
            {
                List<Data> NEWS = mykolayivRead($"https://lb.ua/tag/44_mikolaiv?page={i}", "//div[@class='title']/a[@href]");
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                    DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                    $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }
            }
        }
        private static List<Data> mykolayivRead(string url, string node)
        {
            List<Data> List = new();
            try
            {
                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new();
                    string Link = "" + item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));

                    HtmlNode TitleNode = item;
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//div[@class='image']/img[@src]");
                    ImgNode ??= News.DocumentNode.SelectSingleNode("//div[@class='photo-item-image']/img[@src]");
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//time[@datetime]");
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//div[@itemprop='articleBody']/p");

                    string img = "" + ImgNode.GetAttributeValue("src", "nothing");
                    string title = TitleNode.InnerText.ToString();
                    string date = DateNode.GetAttributeValue("datetime", "nothing");
                    string info = "";
                    foreach (var inf in InfoNodes)
                    {
                        info += inf.InnerText.ToString();
                    }
                    tmp.link = Link;
                    tmp.title = title;
                    tmp.image = img;
                    tmp.time = date;
                    tmp.info = info;
                    List.Add(tmp);
                }
            }
            catch (Exception exp) { Console.WriteLine(exp.Message); return List; }
            return List;
        }
    }
}
