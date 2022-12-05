using HtmlAgilityPack;
using Newtonsoft.Json.Bson;
using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Parser_2022_
{
    class Parse
    {
        public Parse() { }
        public static void Lviv()
        {// 5 site/link
            var NEWS = ReadLviv("https://city-adm.lviv.ua/news", "ul[@class='tm-news uk-list uk-list-large']/li");
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    item.Add(ReadLvivNews($"https://city-adm.lviv.ua{item[4]}", "//div[@class='tm-article uk-margin-medium-top']/p"));
                }


            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
                    Console.WriteLine("\n\n\n");
                }
            
            Console.Clear();
        }
        private static string? ReadLvivNews(string url, string node)
        {
            string result = "";
            try
            {
                WebClient webClient = new();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                foreach (HtmlNode row in htmlDocument.DocumentNode.SelectNodes(node))
                {
                    result += row.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ");
                }
            }
            catch { return " "; }
            return result;
        }
        private static List<List<string>>? ReadLviv(string url, string node)
        {
            List<List<string>> listRay = new();

            try
            {
                if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(node))
                    throw new Exception();

                WebClient webClient = new();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();

                htmlDocument.LoadHtml(html);
                if (htmlDocument == null)
                    throw new Exception();

                HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes("//" + node);

                if (htmlNodeCollection != null && htmlNodeCollection.Count > 0)
                {
                    for (int i = 0; i < htmlNodeCollection.Count; ++i)
                    {
                        List<string> list = new();
                        string[] SplitBlocks = htmlNodeCollection[i].InnerHtml.Split("\"");//  1 посилання    13 фото шлях
                        string[] SplitInnerText = htmlNodeCollection[i].InnerText.Split(" ");//42 type   56 main 

                        if (SplitBlocks.Length > 0 && SplitInnerText.Length > 0)//10
                        {
                            string Type = "";
                            for (int j = 11; SplitInnerText[j] != ""; ++j) { Type += SplitInnerText[j] + ' '; }

                            int istart = 2;
                            int iend = SplitBlocks[56].IndexOf("<");
                            string main = SplitBlocks[56].Substring(istart, SplitBlocks[56].IndexOf("<") - istart);
                            istart = url.IndexOf("news"); iend = url.IndexOf("news") + "news".Length - 1;
                            string img = url.Remove(istart, iend - istart) + SplitBlocks[13];
                            list.Add(Type.Replace("і", "i"));//                 Type
                            list.Add(main.Replace("і", "i"));//                  main
                            list.Add(SplitInnerText[6].Replace(",", " "));//   day
                            list.Add(SplitInnerText[7]);//   time
                            list.Add(SplitBlocks[1]);//      site/link
                            list.Add(img);//     img/link
                            listRay.Add(list);
                        }
                    }
                    return listRay;
                }
                else { throw new Exception(); }


            }
            catch{ return listRay; }
            return null;
        }
        public static void Ternopil()
        {
            //
            var NEWS = ReadTernopil("https://ternopilcity.gov.ua/news/", "//div[@class='profile-header section-bottom-25']");
            foreach (var item in NEWS)
            {
                item.Add(ReadTernopilNews($"{item[1]}", "//div[@class='post-body']"));
            }

            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
                    Console.WriteLine("\n\n\n");
                }
            
            Console.Clear();
        }
        private static List<List<string>>? ReadTernopil(string url, string node)
        {
            List<List<string>> list = new();
            try
            {
                
                WebClient web = new();
                web.Encoding = Encoding.UTF8;
                string html = web.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                foreach (HtmlNode row in htmlDocument.DocumentNode.SelectNodes(node))
                {
                    List<string> list2 = new();
                    string Title = row.InnerHtml.Substring(row.InnerHtml.IndexOf("html\">") + "html\">".Length, row.InnerHtml.IndexOf("</a></h4>")
                        - (row.InnerHtml.IndexOf("html\">") + "html\">".Length)).Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ");
                    string Link = row.InnerHtml.Substring(row.InnerHtml.IndexOf("<h4><a href=\"") + "<h4><a href=\"".Length, row.InnerHtml.IndexOf("html\">")
                        - (row.InnerHtml.IndexOf("<h4><a href=\"") + "<h4><a href=\"".Length)).Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ") + "html";

                    string Time = row.InnerHtml.Substring(row.InnerHtml.IndexOf("<time datetime=\"") + "<time datetime=\"".Length, row.InnerHtml.IndexOf("</time>")
                        - (row.InnerHtml.IndexOf("<time datetime=\"") + "<time datetime=\"".Length)).Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ");
                    string[] DayTime = Time.Split(" ");
                    string Day = DayTime[0].Replace("-", ".");
                    string Clock = DayTime[1].Substring(0, DayTime[1].IndexOf("\">"));
                    int start = row.InnerHtml.IndexOf("<img src=\"") + "<img src=\"".Length, end = row.InnerHtml.IndexOf(".jpg\"") + ".jpg".Length - start; if (end < 0) { end = row.InnerHtml.IndexOf(".png\"") + ".png".Length - start; if (end < 0) { end = row.InnerHtml.IndexOf(".jpeg\"") + ".jpeg".Length - start; } }
                    string img = row.InnerHtml.Substring(start, end).Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ");
                    start = row.InnerHtml.IndexOf("</a></h4>") + "</a></h4>".Length; end = row.InnerHtml.IndexOf("<div class=\"post-meta\">") - start;
                    string Info = row.InnerHtml.Substring(start, end).Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ");
                    list2.Add(Title);// Title
                    list2.Add(Link); //Site/link
                    list2.Add(Day);// Date
                    list2.Add(Clock);// Time
                    list2.Add(img);// image
                    list2.Add(Info.Replace("\n", "").Replace("\t", ""));// subtitle
                    list.Add(list2);
                }
                return list;

            }
            catch { return null; }
        }
        private static string ReadTernopilNews(string url, string node)
        {
            string result = "";
            try
            {
                WebClient webClient = new();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                foreach (HtmlNode row in htmlDocument.DocumentNode.SelectNodes(node))
                {
                    result += row.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ");
                }
            }
            catch { return ""; }
            return result;

        }
        public static void Ivano_Frankivsk()
        {
            var NEWS = ReadIvano_Frankivsk("https://galka.if.ua/category/frankivski-novini/", "//div[@class='media archive-item']");

            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
                    Console.WriteLine("\n\n\n");
                }
            
            Console.Clear();
        }
        private static List<List<string>>? ReadIvano_Frankivsk(string url, string node)
        {
            Console.Title = "Wait";List<List<string>> list = new();
            
            try
            {
                
                WebClient web = new();
                web.Encoding = Encoding.UTF8;
                string html = web.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                HtmlNodeCollection Title = htmlDocument.DocumentNode.SelectNodes(node + "/div[2]/a[1]");
                HtmlNodeCollection imgRes = htmlDocument.DocumentNode.SelectNodes(node + "//div[1]//a//img");
                HtmlNodeCollection LinkHref = htmlDocument.DocumentNode.SelectNodes(node + "//div[1]//a");

                HtmlNodeCollection Date = htmlDocument.DocumentNode.SelectNodes(node + "//div[2]//p//span");

                for (int i = 0; i < Date.Count; ++i)
                    if (string.IsNullOrEmpty(Date[i].InnerHtml))
                        Date.Remove(Date[i]);

                for (int i = 0; i < Title.Count; ++i)
                {
                    Console.Title = "ReadIvano_Frankivsk";
                    List<string> tmp = new();
                    string Link = LinkHref[i].GetAttributeValue("href", "");
                    //Title[i].OuterHtml.Substring(Title[0].OuterHtml.IndexOf("\"") + "\"".Length, Title[0].OuterHtml.IndexOf("\">") - (Title[0].OuterHtml.IndexOf("\"") + "\"".Length));
                    string Tit = Title[i].InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"");
                    string DATEFinal = Date[i].InnerText.Replace("\n", "").Replace(" ", "");
                    string Clock = DATEFinal.Substring(0, DATEFinal.IndexOf(","));//Clock
                    string Day = DATEFinal.Substring(DATEFinal.IndexOf(",") + 1, DATEFinal.Length - DATEFinal.IndexOf(",") - 1);//Day
                    string img = imgRes[i].GetAttributeValue("src", "nothing");//img
                    string News = ReadIvano_FrankivskNews(Link, "//div[@class='content']//p");//main
                    tmp.Add(Link);
                    tmp.Add(Tit);
                    tmp.Add(Clock);
                    tmp.Add(Day);
                    tmp.Add(img);
                    tmp.Add(News);

                    list.Add(tmp);
                }
                return list;
            }
            catch { return list; }
            return null;
        }
        private static string ReadIvano_FrankivskNews(string url, string node)
        {
            Console.Title = "ReadIvano_FrankivskNews";
            string result = "";
            try
            {
                WebClient webClient = new();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                foreach (HtmlNode row in htmlDocument.DocumentNode.SelectNodes(node))
                {
                    result += row.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n\n", "");
                }
            }
            catch { Console.WriteLine("Error"); return ""; }
            return result;
        }
        public static void Chernivtsi()
        {
            Console.Title = "Chernivtsi";
            var NEWS = ReadChernivtsi("https://city.cv.ua/", "//div[@class='content']//div[@class='item clearfix']");
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
                    Console.WriteLine("\n\n\n");
                }
            
            Console.Clear();
        }
        private static List<List<string>>? ReadChernivtsi(string url, string node)
        {
            Console.Title = "Wait";List<List<string>> list = new();
            try
            {
                
                WebClient web = new();
                web.Encoding = Encoding.UTF8;
                string html = web.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode node2 in nodes)
                {

                    List<string> tmp = new();
                    HtmlDocument Doc = new(); Doc.LoadHtml(node2.OuterHtml);
                    HtmlNode href = Doc.DocumentNode.SelectSingleNode("//a[@href]");
                    HtmlNode time = Doc.DocumentNode.SelectSingleNode("//span[@class='time']");
                    HtmlNode Date = Doc.DocumentNode.SelectSingleNode("//span[@class='date']");
                    WebClient Site = new();
                    web.Encoding = Encoding.UTF8;
                    string Link = Site.DownloadString(href.GetAttributeValue("href", "nothing"));
                    HtmlDocument News = new(); News.LoadHtml(Link);
                    HtmlNodeCollection SiteInfo = News.DocumentNode.SelectNodes("//article");
                    HtmlNodeCollection img = News.DocumentNode.SelectNodes("//img[@src]");
                    HtmlNode title = News.DocumentNode.SelectSingleNode("//h1[@class='title-article']");
                    string info = "";
                    foreach (HtmlNode node3 in SiteInfo)
                    {
                        info += node3.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n\n", "");

                    }
                    /*Link*/
                    tmp.Add(href.GetAttributeValue("href", "nothing"));
                    /*Title*/
                    tmp.Add(title.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("    ", ""));
                    /*img*/
                    tmp.Add(img[2].GetAttributeValue("src", "nothing"));
                    /*date*/
                    tmp.Add(Date.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n\n", ""));
                    /*time*/
                    tmp.Add(time.InnerText.Remove(0, 2));
                    /*main*/
                    tmp.Add(info);

                    list.Add(tmp);
                }

                return list;
            }
            catch { return list; }
            return null;
        }
        public static void Zakarpattia()
        {
            Console.Title = "Zakarpattia";
            var NEWS = ReadZakarpattia("http://www.mukachevo.net/ua/news/index", "//div[@class='row news-index-list']//div[@class='col-sm-12 news-index-list-container']//div[@class='row']");
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
                    Console.WriteLine("\n\n\n");
                }
            
            Console.Clear();
        }
        private static List<List<string>>? ReadZakarpattia(string url, string node)
        {
            Console.Title = "Wait";List<List<string>> list = new();
            try
            {
                
                WebClient web = new();
                web.Encoding = Encoding.UTF8;
                string html = web.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode node2 in nodes)
                {
                    List<string> tmp = new();
                    HtmlDocument Doc = new(); Doc.LoadHtml(node2.InnerHtml);
                    HtmlNode Link = Doc.DocumentNode.SelectSingleNode("//a[@href]");
                    if (Link==null) { continue; }
                    string SiteHtml = web.DownloadString("http://www.mukachevo.net/" + Link.GetAttributeValue("href", "nothing"));
                    Doc.LoadHtml(SiteHtml);
                    HtmlNode TitleNode = Doc.DocumentNode.SelectSingleNode("//h1[@class='item-header news-header']");
                    HtmlNodeCollection ImgNode = Doc.DocumentNode.SelectNodes("//img[@src]");
                    HtmlNode DateNode = Doc.DocumentNode.SelectSingleNode("//span[@class='news-date']");
                    HtmlNodeCollection NewsBodyNode = Doc.DocumentNode.SelectNodes("//div[@class='item-body news-body']//p");
                    string NewsBody = "";
                    foreach (HtmlNode node3 in NewsBodyNode)
                    {
                        NewsBody += node3.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n\n", "");
                    }
                    /*Link*/
                    tmp.Add("http://www.mukachevo.net" + Link.GetAttributeValue("href", "nothing"));
                    /*Title*/
                    tmp.Add(TitleNode.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n\n", ""));
                    /*img*/
                    tmp.Add("http://www.mukachevo.net" + ImgNode[5].GetAttributeValue("src", "nothing"));
                    /*date*/
                    tmp.Add(DateNode.GetAttributeValue("content", "unknown"));
                    /*time*/
                    tmp.Add(DateNode.InnerText.Substring(DateNode.InnerText.IndexOf("|") + 2, DateNode.InnerText.Length - DateNode.InnerText.IndexOf("|") - 2));
                    /*main*/
                    tmp.Add(NewsBody);

                    list.Add(tmp);

                }

                return list;
            }
            catch { return list; }
        }
        public static void Volyn()
        {
            Console.Title = "Volyn";
            var NEWS = ReadVolyn("https://www.volynnews.com/news/all/", "//div[@class='media-body']//h4//a[@href]");
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
                    Console.WriteLine("\n\n\n");
                }
            
            Console.Clear();
        }
        private static List<List<string>>? ReadVolyn(string url, string node)
        {
            Console.Title = "Wait";List<List<string>> list = new();
            try
            {
                
                WebClient web = new();
                web.Encoding = Encoding.UTF8;
                string html = web.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode node2 in nodes)
                {
                    List<string> tmp = new();

                    string Link = node2.GetAttributeValue("href", "nothing");
                    if (Link.Contains("Telegram")) { continue; }
                    string SiteHtml = web.DownloadString("https://www.volynnews.com/" + Link);
                    HtmlDocument Doc = new();
                    Doc.LoadHtml(SiteHtml);
                    HtmlNode TitleNode = Doc.DocumentNode.SelectSingleNode("//div[@class='title_news_video']//h1");
                    HtmlNode ImgNode = Doc.DocumentNode.SelectSingleNode("//img[@class='lozad pull-left img_video_news2 news_image']");
                    HtmlNode DateNode = Doc.DocumentNode.SelectSingleNode("//div[@class='date_news_block1 time_news_top_v pull-left ']");
                    HtmlNodeCollection NewsBodyNode = Doc.DocumentNode.SelectNodes("//div[@class='text_video_news2']");
                    string NewsBody = "";

                    foreach (HtmlNode node3 in NewsBodyNode)
                    {
                        NewsBody += node3.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n\n", "");
                    }



                    /*Link*/
                    tmp.Add("https://www.volynnews.com" + Link);
                    /*Title*/
                    tmp.Add(TitleNode.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n\n", ""));
                    /*img*/
                    tmp.Add("https://www.volynnews.com" + ImgNode.GetAttributeValue("src", "nothing"));
                    /*date*/
                    tmp.Add(DateNode.InnerText.Replace("і", "i").Replace("\n", "").Replace("\t", ""));
                    /*time*/
                    //tmp.Add(DateNode.InnerText.Substring(DateNode.InnerText.IndexOf(" "), DateNode.InnerText.Length - DateNode.InnerText.IndexOf(" ")).Replace("\n", "").Replace("\t", ""));
                    /*main*/
                    tmp.Add(NewsBody);

                    list.Add(tmp);

                }

                return list;
            }
            catch { return list; }
        }
        public static void Rivne()
        {
            Console.Title = "Rivne";
            var NEWS = ReadRivne("https://rivnepost.rv.ua/category/region", "//div[@class='list-13--img']//a[@href]");
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
                    Console.WriteLine("\n\n\n");
                }
            
            Console.Clear();
        }
        private static List<List<string>>? ReadRivne(string url, string node)
        {
            Console.Title = "Wait";List<List<string>> list = new();
            try
            {
                
                WebClient web = new();
                web.Encoding = Encoding.UTF8;
                string html = web.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    List<string> tmp = new();


                    string Link = "https://rivnepost.rv.ua" + item.GetAttributeValue("href", "nothing");


                    HtmlDocument News = new();
                    string HTML = web.DownloadString(Link);


                    News.LoadHtml(HTML);
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//img[@itemprop='image']");
                    string img = "https://rivnepost.rv.ua" + ImgNode.GetAttributeValue("src", "nothing");


                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h1[@itemprop='name']");
                    string Title = TitleNode.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n\n", "");


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//div[@class='article--pubdate']");
                    string Day = DATE.InnerText.Substring(0, DATE.InnerText.IndexOf(" "));
                    string Clock = DATE.InnerText.Remove(0, DATE.InnerText.IndexOf(" ") + 1).Substring(0, DATE.InnerText.Remove(0, DATE.InnerText.IndexOf(" ") + 1).IndexOf(" "));


                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//div[@class='view-news']");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "");
                    }

                    /*Link*/
                    tmp.Add(Link);
                    /*Title*/
                    tmp.Add(Title);
                    /*img*/
                    tmp.Add(img);
                    /*date*/
                    tmp.Add(Day);
                    /*time*/
                    tmp.Add(Clock);
                    /*main*/
                    tmp.Add(NewsInfo);

                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }

        }
        public static void Khmelnytskyi()
        {
            Console.Title = "Khmelnytskyi";
            var NEWS = ReadKhmelnytskyi("https://vsim.ua/allnews", "//div[@class='news-title']//a[@href]");
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
                    Console.WriteLine("\n\n\n");
                }
            
            Console.Clear();
        }
        private static List<List<string>>? ReadKhmelnytskyi(string url, string node)
        {
            Console.Title = "Wait";List<List<string>> list = new();
            try
            {
                
                WebClient web = new();
                web.Encoding = Encoding.UTF8;
                string html = web.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    List<string> tmp = new();


                    string Link = "" + item.GetAttributeValue("href", "nothing");


                    HtmlDocument News = new();
                    string HTML = web.DownloadString(Link);


                    News.LoadHtml(HTML);
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//picture//img[@src]");
                    string img = "" + ImgNode.GetAttributeValue("data-src", "nothing");


                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//div[@class='page-long-head']//h1");
                    string Title = TitleNode.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n\n", "");


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//span[@class='js-auto-date']");
                    string Day = DATE.GetAttributeValue("data-date", "nothing").Substring(0, DATE.GetAttributeValue("data-date", "nothing").IndexOf(" "));
                    string Clock = DATE.GetAttributeValue("data-date", "nothing").Substring(DATE.GetAttributeValue("data-date", "nothing").IndexOf(" "), DATE.GetAttributeValue("data-date", "nothing").Length - DATE.GetAttributeValue("data-date", "nothing").IndexOf(" "));



                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//p[@class='ck_editor_p']");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "");
                    }

                    /*Link*/
                    tmp.Add(Link);
                    /*Title*/
                    tmp.Add(Title);
                    /*img*/
                    tmp.Add(img);
                    /*date*/
                    tmp.Add(Day);
                    /*time*/
                    tmp.Add(Clock);
                    /*main*/
                    tmp.Add(NewsInfo);

                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }

        }
        public static void Zhytomyr()
        {
            Console.Title = "Zhytomyr";
            List<List<string>> NEWS = ReadZhytomyr("https://zt-rada.gov.ua/news?newslabel=3", "//div[@class='nwslstitm']//a[@href]");
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
                    Console.WriteLine("\n\n\n");
                }
            
            Console.Clear();
        }
        private static List<List<string>>? ReadZhytomyr(string url, string node)
        {
            Console.Title = "Wait";List<List<string>> list = new();
            try
            {
                
                WebClient web = new();
                web.Encoding = Encoding.UTF8;
                string html = web.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    List<string> tmp = new();


                    string Link = "https://zt-rada.gov.ua" + item.GetAttributeValue("href", "nothing");


                    HtmlDocument News = new();
                    string HTML = web.DownloadString(Link);


                    News.LoadHtml(HTML);
                    string ImgString = "https://zt-rada.gov.ua/";
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//div[@class='mainimg']//img[@src]");
                    if (ImgNode == null)
                    {
                        HtmlDocument NewsIF = new();
                        string HTMLIF = web.DownloadString(Link);
                        NewsIF.LoadHtml(HTMLIF);
                        ImgString = "https://zt-rada.gov.ua";
                        ImgNode = NewsIF.DocumentNode.SelectSingleNode("//a[@href]//img[@src]");

                    }
                    string img = ImgString + ImgNode.GetAttributeValue("src", "nothing");


                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h1[@class='bb']");
                    string Title = TitleNode.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n\n", "");


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//div[@class='f-date']");
                    string Day = DATE.InnerText;
                    //string Clock = DATE.GetAttributeValue("data-date", "nothing").Substring(DATE.GetAttributeValue("data-date", "nothing").IndexOf(" "), DATE.GetAttributeValue("data-date", "nothing").Length - DATE.GetAttributeValue("data-date", "nothing").IndexOf(" "));



                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//p[@style='text-align:justify;']"); if (NewsNode == null) { NewsNode = News.DocumentNode.SelectNodes("//div[@style='text-align:justify;']"); if (NewsNode == null) { NewsNode = News.DocumentNode.SelectNodes("//div[@class='desc']"); } }
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "");
                    }

                    /*Link*/
                    tmp.Add(Link);
                    /*Title*/
                    tmp.Add(Title);
                    /*img*/
                    tmp.Add(img);
                    /*date*/
                    tmp.Add(Day);
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.Add(NewsInfo);

                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void Chernihiv()
        {
            Console.Title = "Chernihiv";
            List<List<string>> NEWS = ReadChernihiv("https://newch.tv/category/novyny/", "//a[@class='vmagazine-lite-archive-more']");
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
                    Console.WriteLine("\n\n\n");
                }
            
            Console.Clear();
        }
        private static List<List<string>>? ReadChernihiv(string url, string node)
        {
            Console.Title = "Wait";List<List<string>> list = new();
            try
            {
                
                WebClient web = new();
                web.Encoding = Encoding.UTF8;
                string html = web.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    List<string> tmp = new();


                    string Link = "" + item.GetAttributeValue("href", "nothing");


                    HtmlDocument News = new();
                    string HTML = web.DownloadString(Link);


                    News.LoadHtml(HTML);
                    string ImgString = "";
                    string img = "";
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//img[@class='attachment-full size-full wp-post-image']");
                    if (ImgNode == null)
                    {
                        continue;
                    }
                    else
                    {
                        img = ImgString + ImgNode.GetAttributeValue("src", "nothing");
                    }

                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h1[@class='entry-title']");
                    string Title = TitleNode.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n\n", "");


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//span[@class='posted-on']");
                    string Day = DATE.InnerText;
                    //string Clock = DATE.GetAttributeValue("data-date", "nothing").Substring(DATE.GetAttributeValue("data-date", "nothing").IndexOf(" "), DATE.GetAttributeValue("data-date", "nothing").Length - DATE.GetAttributeValue("data-date", "nothing").IndexOf(" "));



                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//div[@class='entry-content clearfix']//p");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "");
                    }

                    /*Link*/
                    tmp.Add(Link);
                    /*Title*/
                    tmp.Add(Title);
                    /*img*/
                    tmp.Add(img);
                    /*date*/
                    tmp.Add(Day);
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.Add(NewsInfo);

                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void Vinnytsia()
        {
            Console.Title = "Vinnytsia";
            List<List<string>> NEWS = ReadVinnytsia("https://www.vmr.gov.ua/novyny-mista", "//a[@style='text-decoration: none;']");
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
                    Console.WriteLine("\n\n\n");
                }
            
            Console.Clear();
        }
        private static List<List<string>>? ReadVinnytsia(string url, string node)
        {
            Console.Title = "Wait";List<List<string>> list = new();
            try
            {
                
                WebClient web = new();
                web.Encoding = Encoding.UTF8;
                string html = web.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    List<string> tmp = new();


                    string Link = "https://www.vmr.gov.ua" + item.GetAttributeValue("href", "nothing");


                    HtmlDocument News = new();
                    string HTML = web.DownloadString(Link);


                    News.LoadHtml(HTML);
                    string ImgString = "https://www.vmr.gov.ua";
                    string img = "";
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//img[@style='margin-top: 40px; width:100%']"); 
                    img = ImgString + ImgNode.GetAttributeValue("src", "nothing");//.decode!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h1[@class='title-main--big']");
                    string Title = TitleNode.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n\n", "");


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//div[@class='public-data']");
                    string Day = DATE.InnerText.Substring(0,DATE.InnerText.IndexOf(","));
                    string Clock = DATE.InnerText.Remove(0, DATE.InnerText.IndexOf(",")+1);


                    HtmlNode FirstNode = News.DocumentNode.SelectSingleNode("//div[@class='main-content-inner']");
                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//div[@class='main-content-inner second']//p");
                    string NewsInfo = FirstNode.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "");
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "");
                    }
                    
                    /*Link*/
                    tmp.Add(Link);
                    /*Title*/
                    tmp.Add(Title);
                    /*img*/
                    tmp.Add(img);
                    /*date*/
                    tmp.Add(Day);
                    /*time*/
                    tmp.Add(Clock);
                    /*main*/
                    tmp.Add(NewsInfo);

                    list.Add(tmp);
                }
                return list;
            }
            catch { return list; }
        }
        public static void Kyiv()
        {
            Console.Title = "Kyiv";
            List<List<string>> NEWS = ReadKyiv("https://kmr.gov.ua/", "//div[@class='field-link']//span[@class='field-content']//a[@href]");
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
                    Console.WriteLine("\n\n\n");
                }
            
            Console.Clear();

        }
        private static List<List<string>> ReadKyiv(string url, string node)
        {
            Console.Title = "Wait";List<List<string>> list = new();
            try
            {
                
                WebClient web = new();
                web.Encoding = Encoding.UTF8;
                string html = web.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    List<string> tmp = new();


                    string Link = "https://kmr.gov.ua" + item.GetAttributeValue("href", "nothing");


                    HtmlDocument News = new();
                    string HTML = web.DownloadString(Link);


                    News.LoadHtml(HTML);
                    string ImgString = "";
                    string img = "";
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//img[@typeof='foaf:Image']");
                    if (ImgNode == null)
                    {
                        continue;
                    }
                    else
                    {
                        img = ImgString + ImgNode.GetAttributeValue("src", "nothing");
                    }

                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h1[@class='title field-content']");
                    string Title = TitleNode.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("\r","");


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//div[@class='field field-name-post-date field-type-ds field-label-hidden view-mode-full']");
                    string Day = DATE.InnerText.Replace("\n","").Replace("   ","");
                    //string Clock = DATE.GetAttributeValue("data-date", "nothing").Substring(DATE.GetAttributeValue("data-date", "nothing").IndexOf(" "), DATE.GetAttributeValue("data-date", "nothing").Length - DATE.GetAttributeValue("data-date", "nothing").IndexOf(" "));



                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//div[@class='field-item field-content even']//p[@style='text-align: justify;']");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "");
                    }

                    /*Link*/
                    tmp.Add(Link);
                    /*Title*/
                    tmp.Add(Title);
                    /*img*/
                    tmp.Add(img);
                    /*date*/
                    tmp.Add(Day);
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.Add(NewsInfo);

                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void Kirovohradsk()
        {
            Console.Title = "Kirovohradsk";
            List<List<string>> NEWS = ReadKirovohradsk("https://kr-rada.gov.ua/news/", "//div[@class='col-md-4 col-xs-12 col-sm-6 col-lg-4']//div[@class='post']//a[@href]//div[@class='post-img']");
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
                    Console.WriteLine("\n\n\n");
                }
            
            Console.Clear();
        }
        private static List<List<string>>? ReadKirovohradsk(string url, string node)
        {
            Console.Title = "Wait";List<List<string>> list = new();
            try
            {
                
                WebClient web = new();
                web.Encoding = Encoding.UTF8;
                string html = web.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    List<string> tmp = new();


                    string Link = "https://kr-rada.gov.ua" + item.ParentNode.GetAttributeValue("href", "nothing");


                    HtmlDocument News = new();
                    string HTML = web.DownloadString(Link);


                    News.LoadHtml(HTML);
                    string ImgString = "https:";
                    string img = "";
                    //HtmlNode ImgNode = .DocumentNode.SelectSingleNode("//img[@class='attachment-full size-full wp-post-image']");
                   
                    img = ImgString + item.FirstChild.GetAttributeValue("src", "nothing");
                    

                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h1[@class='page-title']");
                    string Title = TitleNode.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n\n", "");


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//div[@class='news-date']");
                    string Day = DATE.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n\n", "");
                    
                    //string Clock = DATE.GetAttributeValue("data-date", "nothing").Substring(DATE.GetAttributeValue("data-date", "nothing").IndexOf(" "), DATE.GetAttributeValue("data-date", "nothing").Length - DATE.GetAttributeValue("data-date", "nothing").IndexOf(" "));



                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//span[@style='font-size:16px;']");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("   ", "").Replace("&bull;", "•");
                    }

                    /*Link*/
                    tmp.Add(Link);
                    /*Title*/
                    tmp.Add(Title);
                    /*img*/
                    tmp.Add(img);
                    /*date*/
                    tmp.Add(Day);
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.Add(NewsInfo);

                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void Zaporizhzhia()
        {
            Console.Title = "Zaporizhzhia";
            List<List<string>> NEWS = ReadZaporizhzhia("https://zp.gov.ua/uk/articles/category/news/1", "//div[@class='simple-list-row']//a[@href]");
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
                    Console.WriteLine("\n\n\n");
                }
            
            Console.Clear();

        }
        private static List<List<string>> ReadZaporizhzhia(string url, string node)
        {
            Console.Title = "Wait";List<List<string>> list = new();
            try
            {
                
                WebClient web = new();
                web.Encoding = Encoding.UTF8;
                string html = web.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    List<string> tmp = new();


                    string Link = "https://zp.gov.ua/" + item.GetAttributeValue("href", "nothing");


                    HtmlDocument News = new();
                    string HTML = web.DownloadString(Link);


                    News.LoadHtml(HTML);
                    string ImgString = "";
                    string img = "";
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//div[@class='cms-post-img']//img[@src]");
                    if (ImgNode == null)
                    {
                        continue;
                    }
                    else
                    {
                        img = ImgString + ImgNode.GetAttributeValue("src", "nothing");
                    }

                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h1[@class='title']");
                    string Title = TitleNode.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("\r", "");


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//span[@class='date']");
                    string Day = DATE.InnerText.Substring(0,DATE.InnerText.IndexOf(" "));
                    //string Clock = DATE.InnerText.Substring(DATE.InnerText.IndexOf(" "),DATE.InnerText.Length-DATE.InnerText.IndexOf(" "));



                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//div[@class='page-content content-text']//p");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "");
                    }

                    /*Link*/
                    tmp.Add(Link);
                    /*Title*/
                    tmp.Add(Title);
                    /*img*/
                    tmp.Add(img);
                    /*date*/
                    tmp.Add(Day);
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.Add(NewsInfo);

                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void Luhansk()
        {
            Console.Title = "Luhansk";
            List<List<string>> NEWS = ReadLuhansk("http://loga.gov.ua/oda/press/news", "//div[@class='news_lbk_url']//a[@href]");
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
                    Console.WriteLine("\n\n\n");
                }
            
            Console.Clear();

        }
        private static List<List<string>> ReadLuhansk(string url, string node)
        {
            Console.Title = "Wait";List<List<string>> list = new();
            try
            {
                
                WebClient web = new();
                web.Encoding = Encoding.UTF8;
                string html = web.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    List<string> tmp = new();

                    
                     
                   
                    string Link = "http://loga.gov.ua" + item.GetAttributeValue("href", "nothing");
                    HtmlDocument News = new();
                    News.LoadHtml(item.InnerHtml);
                    string HTML = web.DownloadString(Link);
                    News.LoadHtml(HTML);



                    string ImgString = "";
                    string img = "";
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//img[@typeof='foaf:Image']");
                    if (ImgNode == null)
                    {
                        continue;
                    }
                    else
                    {
                        img = ImgString + ImgNode.GetAttributeValue("src", "nothing");
                    }

                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h1[@class='page-header']");
                    string Title = TitleNode.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("\r", "");


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//span[@class='nlf_date']");
                    string Day = DATE.InnerText;
                    //string Clock = DATE.InnerText.Substring(DATE.InnerText.IndexOf(" "),DATE.InnerText.Length-DATE.InnerText.IndexOf(" "));



                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//div[@class='field-item even']//p");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "");
                    }

                    /*Link*/
                    tmp.Add(Link);
                    /*Title*/
                    tmp.Add(Title);
                    /*img*/
                    tmp.Add(img);
                    /*date*/
                    tmp.Add(Day);
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.Add(NewsInfo);

                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void Kharkiv()
        {
            Console.Title = "Kharkiv";
            List<List<string>> NEWS = ReadKharkiv("https://www.city.kharkov.ua/uk/novosti/ofczjno.html", "//div[@class='list_news col-md-9 col-sm-12 col-xs-12']//ul[@class='list']//div[@class='alignleft col-md-3 col-sm-3 col-xs-12']//a[@href]");
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
                    Console.WriteLine("\n\n\n");
                }
            
            Console.Clear();

        }
        private static List<List<string>> ReadKharkiv(string url, string node)
        {
            Console.Title = "Wait";List<List<string>> list = new();
            try
            {
                
                WebClient web = new();
                web.Encoding = Encoding.UTF8;
                string html = web.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    List<string> tmp = new();




                    string Link = "https://www.city.kharkov.ua" + item.GetAttributeValue("href", "nothing");
                    HtmlDocument News = new();
                    News.LoadHtml(item.InnerHtml);
                    string HTML = web.DownloadString(Link);
                    News.LoadHtml(HTML);



                    string ImgString = "https://www.city.kharkov.ua/";
                    string img = "";
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//div[@class='block_post col-md-8 col-sm-8 col-xs-12']//img[@src]");
                    if (ImgNode == null)
                    {
                        continue;
                    }
                     img = ImgString + ImgNode.GetAttributeValue("src", "nothing");


                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//span[@class='heading_name']");
                    string Title = TitleNode.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("\r", "");


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//div[@class='data_post']//em");
                    HtmlNode ClockNode = News.DocumentNode.SelectSingleNode("//div[@class='data_post']//span[@class='time']");

                    string Day = DATE.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "");
                    string Clock = ClockNode.InnerText;


                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//div[@class='justifyfull']");
                    if (NewsNode == null)
                    {
                        NewsNode = News.DocumentNode.SelectNodes("//p[@class='justifyfull']");
                    }
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "");
                    }

                    /*Link*/
                    tmp.Add(Link);
                    /*Title*/
                    tmp.Add(Title);
                    /*img*/
                    tmp.Add(img);
                    /*date*/
                    tmp.Add(Day);
                    /*time*/
                    tmp.Add(Clock);
                    /*main*/
                    tmp.Add(NewsInfo);

                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void Dnipropetrovsk()
        {
            Console.Title = "Dnipropetrovsk";
            List<List<string>> NEWS = ReadDnipropetrovsk("https://oblrada.dp.gov.ua/category/news/", "//div[@class='col-xs-12 col-sm-12 col-md-12 obl-news-post fix-padding']//div//div[2]//p[@class='genpost-entry-title']//a[@href]");
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
                    Console.WriteLine("\n\n\n");
                }
            
            Console.Clear();
        }
        private static List<List<string>>? ReadDnipropetrovsk(string url, string node)
        {
            Console.Title = "Wait";List<List<string>> list = new();
            try
            {
                
                WebClient web = new();
                web.Encoding = Encoding.UTF8;
                string html = web.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    List<string> tmp = new();




                    string Link = "" + item.GetAttributeValue("href", "nothing");
                    HtmlDocument News = new();
                    News.LoadHtml(item.InnerHtml);
                    string HTML = web.DownloadString(Link);
                    News.LoadHtml(HTML);



                    string ImgString = "";
                    string img = "";
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//div[@class='article-featured-image']//img[@src]");
                    if (ImgNode == null)
                    {
                        continue;
                    }
                    img = ImgString + ImgNode.GetAttributeValue("src", "nothing");


                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h1[@class='news-entry-title']");
                    string Title = TitleNode.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("\r", "");


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//time[@class='entry-date published updated' or @class='entry-date published']");
                    //HtmlNode ClockNode = News.DocumentNode.SelectSingleNode("//");

                    string Day = DATE.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "");
                    //string Clock = ClockNode.InnerText;


                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//div[@class='entry-content']");
                    if (NewsNode == null)
                    {
                        NewsNode = News.DocumentNode.SelectNodes("//");
                    }
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "");
                    }

                    /*Link*/
                    tmp.Add(Link);
                    /*Title*/
                    tmp.Add(Title);
                    /*img*/
                    tmp.Add(img);
                    /*date*/
                    tmp.Add(Day);
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.Add(NewsInfo);

                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void Sumy()
        {
            Console.Title = "Sumy";
            List<List<string>> NEWS = ReadSumy("https://www.0542.ua/news", "//div[@class='col-12 col-md-8 col-lg-9']//div[@class='c-news-card__head']//a[@href]");
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
                    Console.WriteLine("\n\n\n");
                }
            
            Console.Clear();
        }
        private static List<List<string>>? ReadSumy(string url, string node)
        {
            Console.Title = "Wait";List<List<string>> list = new();
            try
            {
                
                WebClient web = new();
                web.Encoding = Encoding.UTF8;
                string html = web.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    List<string> tmp = new();




                    string Link = "" + item.GetAttributeValue("href", "nothing");
                    HtmlDocument News = new();
                    News.LoadHtml(item.InnerHtml);
                    string HTML = web.DownloadString(Link);
                    News.LoadHtml(HTML);



                    string ImgString = "";
                    string img = "";
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//strong//img[@src]");
                    if (ImgNode == null)
                    {
                        continue;
                    }
                    img = ImgString + ImgNode.GetAttributeValue("src", "nothing");


                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//div[@class='article-details__title-container']");
                    string Title = TitleNode.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("\r", "");


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//div[@class='article-details__date']");
                    //HtmlNode ClockNode = News.DocumentNode.SelectSingleNode("//");

                    string Day = DATE.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "");
                    //string Clock = ClockNode.InnerText;


                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//app-model-content//p");
                    
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "");
                    }

                    /*Link*/
                    tmp.Add(Link);
                    /*Title*/
                    tmp.Add(Title);
                    /*img*/
                    tmp.Add(img);
                    /*date*/
                    tmp.Add(Day);
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.Add(NewsInfo);

                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void Kherson()
        {
            Console.Title = "Kherson";
            List<List<string>> NEWS = ReadKherson("https://miskrada.kherson.ua/news/", "//div[@class='w-post-elm post_image usg_post_image_1 has_ratio']//a[@href]");
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
        Console.WriteLine("\n\n\n");
                }
        
        Console.Clear();
        }
        private static List<List<string>>? ReadKherson(string url, string node)
{
    Console.Title = "Wait";List<List<string>> list = new();
    try
    {
        
        WebClient web = new();
        web.Encoding = Encoding.UTF8;
        string html = web.DownloadString(url);

        if (string.IsNullOrEmpty(html))
            throw new Exception();

        HtmlDocument htmlDocument = new();
        htmlDocument.LoadHtml(html);

        if (htmlDocument == null)
            throw new Exception();

        HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
        foreach (HtmlNode item in nodes)
         {

              List<string> tmp = new();




             string Link = "" + item.GetAttributeValue("href", "nothing");
             HtmlDocument News = new();
             News.LoadHtml(item.InnerHtml);
             string HTML = web.DownloadString(Link);
             News.LoadHtml(HTML);



             string ImgString = "";
             string img = "";
             HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//div[@class='w-post-elm post_image stretched']//img[@src]");
             if (ImgNode == null)
             {
                continue;
             }
                    img = ImgString + ImgNode.GetAttributeValue("data-lazy-src", "nothing");


             HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h1[@class='w-post-elm post_title us_custom_d6eca3b4 entry-title color_link_inherit']");
             string Title = TitleNode.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("\r", "");


             HtmlNode DATE = News.DocumentNode.SelectSingleNode("//time[@class='w-post-elm post_date entry-date updated']");
             //HtmlNode ClockNode = News.DocumentNode.SelectSingleNode("//");

                string Day = DATE.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "");
                //string Clock = ClockNode.InnerText;


              HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//div[@class='w-post-elm post_content']");
              if (NewsNode == null)
               {
                   NewsNode = News.DocumentNode.SelectNodes("//");
               }
              string NewsInfo = "";
              foreach (var Block in NewsNode)
              {
                 NewsInfo += Block.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "");
              }

                /*Link*/
                tmp.Add(Link);
               /*Title*/
               tmp.Add(Title);
               /*img*/
               tmp.Add(img);
               /*date*/
              tmp.Add(Day);
               /*time*/
               //tmp.Add(Clock);
               /*main*/
                tmp.Add(NewsInfo);

               list.Add(tmp);
         }


         return list;
        }
        catch { return list; }
    }
        public static void Poltava()
        {
            Console.Title = "Poltava";
            List<List<string>> NEWS = ReadPoltava("https://www.rada-poltava.gov.ua/", "//td[@class='leftcol news']//div//h1//a[@href]");
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
            Console.WriteLine("\n\n\n");
                }
            
            Console.Clear();
        }
        private static List<List<string>>? ReadPoltava(string url, string node)
{
    Console.Title = "Wait";List<List<string>> list = new();
    try
    {
        
        WebClient web = new();
        web.Encoding = Encoding.UTF8;
        string html = web.DownloadString(url);

        if (string.IsNullOrEmpty(html))
            throw new Exception();

        HtmlDocument htmlDocument = new();
        htmlDocument.LoadHtml(html);

        if (htmlDocument == null)
            throw new Exception();

        HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
        foreach (HtmlNode item in nodes)
        {

            List<string> tmp = new();




            string Link = "https://www.rada-poltava.gov.ua" + item.GetAttributeValue("href", "nothing");
            HtmlDocument News = new();
            News.LoadHtml(item.InnerHtml);
            string HTML = web.DownloadString(Link);
            News.LoadHtml(HTML);



            string ImgString = "https://www.rada-poltava.gov.ua";
            string img = "";
            HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//img[@class='gallery']");
            if (ImgNode == null)
            {
                continue;
            }
            img = ImgString + ImgNode.GetAttributeValue("src", "nothing");


            HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//td[@class='leftcol news']//h1");
            string Title = TitleNode.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("\r", "");


            HtmlNode DATE = News.DocumentNode.SelectSingleNode("//a[@id='daterange']");
            //HtmlNode ClockNode = News.DocumentNode.SelectSingleNode("//");

            string Day = DATE.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "");
            //string Clock = ClockNode.InnerText;


            HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//td[@class='leftcol news']//p");
            string NewsInfo = "";
            foreach (var Block in NewsNode)
            {
                NewsInfo += Block.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "");
            }

            /*Link*/
            tmp.Add(Link);
            /*Title*/
            tmp.Add(Title);
            /*img*/
            tmp.Add(img);
            /*date*/
            tmp.Add(Day);
            /*time*/
            //tmp.Add(Clock);
            /*main*/
            tmp.Add(NewsInfo);

            list.Add(tmp);
        }


        return list;
    }
    catch { return list; }
}
        public static void Kryvyi_Rih()
        {
                                    Console.Title = "";
                                    List<List<string>> NEWS = ReadKryvyi_Rih("https://post.kr.ua/", "//h2[@class='title']//a[@href]");
                Console.Title = "Output";
                                    if (NEWS != null)
                                        foreach (var item in NEWS)
                                        {
                                            foreach (var item2 in item)
                                            {
                                                Console.WriteLine(item2);
                                            }
             Console.WriteLine("\n\n\n");
                                        }
             
             Console.Clear();
        }
        private static List<List<string>>? ReadKryvyi_Rih(string url, string node)
        {
            Console.Title = "Wait";List<List<string>> list = new();
            try
            {
                
                WebClient web = new();
                web.Encoding = Encoding.UTF8;
                string html = web.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    List<string> tmp = new();




                    string Link = "" + item.GetAttributeValue("href", "nothing");
                    HtmlDocument News = new();
                    News.LoadHtml(item.InnerHtml);
                    string HTML = web.DownloadString(Link);
                    News.LoadHtml(HTML);


                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//span[@class='post-title']");
                    string Title = TitleNode.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("\r", "");


                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//div[@class='entry-content clearfix single-post-content']//p");
                    if (NewsNode == null)
                    {
                        NewsNode = News.DocumentNode.SelectNodes("//");
                    }
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "");
                    }
                    /*Link*/
                    tmp.Add(Link);
                    /*Title*/
                    tmp.Add(Title);
                    /*main*/
                    tmp.Add(NewsInfo);

                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void Odesa()
        {
            Console.Title = "";
            List<List<string>> NEWS = ReadOdesa("https://www.ukrinform.ua/tag-odesa", "//section[@class='restList']//article[@data-id]//section//h2//a[@href]");
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
                    Console.WriteLine("\n\n\n");
                }
            
            Console.Clear();
        }
        private static List<List<string>>? ReadOdesa(string url, string node)
        {
            Console.Title = "Wait";List<List<string>> list = new();
            try
            {
                
                WebClient web = new();
                web.Encoding = Encoding.UTF8;
                string html = web.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    List<string> tmp = new();




                    string Link = "https://www.ukrinform.ua" + item.GetAttributeValue("href", "nothing");
                    HtmlDocument News = new();
                    News.LoadHtml(item.InnerHtml);
                    string HTML = web.DownloadString(Link);
                    News.LoadHtml(HTML);



                    string ImgString = "";
                    string img = "";
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//img[@class='newsImage']");
                    img = ImgString + ImgNode.GetAttributeValue("src", "nothing");


                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h1[@class='newsTitle']");
                    string Title = TitleNode.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("\r", "").Replace("&#039;","'");


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//time[@datetime]");
                    //HtmlNode ClockNode = News.DocumentNode.SelectSingleNode("//");

                    string Day = DATE.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "");
                    //string Clock = ClockNode.InnerText;


                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//div[@class='newsText']");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "").Replace("&#039;", "'");
                    }

                    /*Link*/
                    tmp.Add(Link);
                    /*Title*/
                    tmp.Add(Title);
                    /*img*/
                    tmp.Add(img);
                    /*date*/
                    tmp.Add(Day);
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.Add(NewsInfo);

                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void Mykolayiv()
        {
            Console.Title = "Mykolayiv";
            List<List<string>> NEWS = ReadMykolayiv("https://espreso.tv/mykolayiv", "//div[@class='title']//a[@href]");
            Console.Title = "Output  Mykolayiv";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
                    Console.WriteLine("\n\n\n");
                }
            
            Console.Clear();
        }
        private static List<List<string>>? ReadMykolayiv(string url, string node)
        {
            Console.Title = "Wait";List<List<string>> list = new();
            try
            {
                
                WebClient web = new();
                web.Encoding = Encoding.UTF8;
                string html = web.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    List<string> tmp = new();




                    string Link = "" + item.GetAttributeValue("href", "nothing");
                    HtmlDocument News = new();
                    News.LoadHtml(item.InnerHtml);
                    string HTML = web.DownloadString(Link);
                    News.LoadHtml(HTML);



                    string ImgString = "";
                    string img = "";
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//picture//img[@src]");
                    if (ImgNode == null)
                    {
                        continue;
                    }
                    img = ImgString + ImgNode.GetAttributeValue("data-src", "nothing");


                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h1[@class='text-title']");
                    string Title = TitleNode.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("\r", "");


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//div[@class='news__author_date']");
                    //HtmlNode ClockNode = News.DocumentNode.SelectSingleNode("//");

                    string Day = DATE.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "").Replace("&#039;", "'");
                    //string Clock = ClockNode.InnerText;

                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//section[@class='content_current_article']");
                    if (NewsNode == null)
                    {
                        NewsNode = News.DocumentNode.SelectNodes("//");
                    }
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "").Replace("&#039;", "'");
                    }

                    /*Link*/
                    tmp.Add(Link);
                    /*Title*/
                    tmp.Add(Title);
                    /*img*/
                    tmp.Add(img);
                    /*date*/
                    tmp.Add(Day);
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.Add(NewsInfo);

                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void Cherkassy()
        {
            Console.Title = "Cherkassy";
            List<List<string>> NEWS = ReadCherkassy("https://18000.com.ua/novini/", "//article[@class='post post--horizontal post--horizontal-sm']//a[@href]");
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
                    Console.WriteLine("\n\n\n");
                }
            
            Console.Clear();
        }
        private static List<List<string>>? ReadCherkassy(string url, string node)
        {
            Console.Title = "Wait";List<List<string>> list = new();
            try
            {
                
                WebClient web = new();
                web.Encoding = Encoding.UTF8;
                string html = web.DownloadString(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception();

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);

                if (htmlDocument == null)
                    throw new Exception();

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    List<string> tmp = new();

                    string Link = "" + item.GetAttributeValue("href", "nothing");
                    HtmlDocument News = new();
                    News.LoadHtml(item.InnerHtml);
                    string HTML = web.DownloadString(Link);
                    News.LoadHtml(HTML);



                    string ImgString = "";
                    string img = "";
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//div[@class='wp-caption aligncenter']//img[@src]");
                    if (ImgNode == null)
                    {
                        ImgNode = News.DocumentNode.SelectSingleNode("//div[@class='single-body entry-content typography-copy']//p//img[@src]");
                    }
                    

                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h1[@class='entry-title']");
                    string Title = TitleNode.InnerText.Replace("і", "i").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("\r", "");


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//time[@class='time published']");
                    //HtmlNode ClockNode = News.DocumentNode.SelectSingleNode("//");

                    string Day = DATE.GetAttributeValue("datetime","unknown").Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "");
                    //string Clock = ClockNode.InnerText;

                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//div[@class='single-body entry-content typography-copy']//p");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText.Replace("і", "i").Replace("&mdash;", "").Replace("&quot;", "\"").Replace("&laquo;", "<<").Replace("&raquo;", ">>").Replace("&ndash;", "-").Replace("&rsquo;", "'").Replace("acute;", "").Replace("І", "I").Replace("&hellip;", "...").Replace("&middot;", "·").Replace("&nbsp;", " ").Replace("&#8221;", "\"").Replace("&#8211;", "–").Replace("&#8220;", "\"").Replace("\t", "").Replace("\n", "").Replace("   ", "");
                    }

                    /*Link*/
                    tmp.Add(Link);
                    /*Title*/
                    tmp.Add(Title);
                    /*img*/
                    if (ImgNode != null)
                    {
                        img = ImgString + ImgNode.GetAttributeValue("src", "nothing").Replace("і", "i").Replace("І","I");
                        tmp.Add(img);

                    }
                    /*date*/
                    tmp.Add(Day);
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.Add(NewsInfo);

                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }

    }
}
