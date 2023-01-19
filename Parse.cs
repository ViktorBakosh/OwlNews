using HtmlAgilityPack;
using System.Net;
using System.Text;

#pragma warning disable 8602, 8600, SYSLIB0014 
namespace Parser_2022_
{

    class Parse
    {
        public Parse() { }

        public static void lviv()
        {// 5 site/link
            var NEWS = ReadLviv("https://city-adm.lviv.ua/news", "//ul[@class='tm-news uk-list uk-list-large']/li/a[@href]", System.Reflection.MethodBase.GetCurrentMethod().Name);

            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                    DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                    $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }
        }

        private static List<Data>? ReadLviv(string url, string node, string name)
        {
            List<Data> listRay = new();

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

                HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes(node);

                foreach (var item in htmlNodeCollection)
                {
                    Data tmp = new();

                    string Link = "https://city-adm.lviv.ua" + item.GetAttributeValue("href", "nothing");
                    HtmlDocument News = new();
                    News.LoadHtml(item.InnerHtml);
                    string HTML = webClient.DownloadString(Link);
                    News.LoadHtml(HTML);

                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//img[@itemprop='url']");
                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h1[@class='uk-article-title uk-margin-top uk-margin-medium-bottom']");
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//span[@class='uk-text-middle tm-text-icon']");
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//div[@class='tm-article uk-margin-medium-top']/p");
                    string img = "https://city-adm.lviv.ua" + ImgNode.GetAttributeValue("src", "nothing");
                    string title = TitleNode.InnerText.ToString();
                    string date = DateNode.InnerText;
                    string info = "";
                    foreach (var inf in InfoNodes)
                    {
                        info += inf.InnerText.ToString();
                    }
                    tmp.link = Link;
                    tmp.title = title;
                    tmp.image = img;
                    tmp.time = date.Replace(",", "");
                    tmp.info = info;
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return listRay;
                    }
                    listRay.Add(tmp);
                }
            }
            catch { return listRay; }
            return listRay;
        }
        public static void ternopil()
        {

            var NEWS = ReadTernopil("https://ternopilcity.gov.ua/news/", "//div[@class]/h4/a[@href]", System.Reflection.MethodBase.GetCurrentMethod().Name);

            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                    DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                    $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }
        }
        private static List<Data>? ReadTernopil(string url, string node, string name)
        {
            List<Data> list = new();
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

                HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes(node);

                foreach (var item in htmlNodeCollection)
                {
                    Data tmp = new();

                    string Link = "" + item.GetAttributeValue("href", "nothing");
                    HtmlDocument News = new();
                    News.LoadHtml(item.InnerHtml);
                    string HTML = web.DownloadString(Link);
                    News.LoadHtml(HTML);

                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//img[@style='float: left;']");
                    HtmlNode TitleNode = item;
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//time[@datetime]");
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//div[@class='post-body']");
                    string img = "" + ImgNode.GetAttributeValue("src", "nothing");
                    string title = TitleNode.InnerText.ToString();
                    string date = DateNode.GetAttributeValue("datetime", "unknown");
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
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }

            }
            catch { return list; }
            return list;
        }

        public static void ivano_frankivsk()
        {
            var NEWS = ReadIvano_Frankivsk("https://galka.if.ua/category/frankivski-novini/", "//div[@class='media-body']", System.Reflection.MethodBase.GetCurrentMethod().Name);

            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                    DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                    $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }
        }
        private static List<Data>? ReadIvano_Frankivsk(string url, string node, string name)
        {
            Console.Title = "Wait"; List<Data> list = new();

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

                HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes(node);

                foreach (var item in htmlNodeCollection)
                {
                    Data tmp = new();
                    var LinkNode = item.ChildNodes["a"];
                    string Link = "" + LinkNode.GetAttributeValue("href", "nothing");
                    HtmlDocument News = new();
                    News.LoadHtml(item.InnerHtml);
                    string HTML = web.DownloadString(Link);
                    News.LoadHtml(HTML);

                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//div[@class='page-thumbnail']/img[@src]");
                    HtmlNode TitleNode = item;
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//p[@class='single-date']");
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//div[@class='content']");
                    ImgNode ??= News.DocumentNode.SelectSingleNode("//picture/img[@src]");
                    string img = "" + ImgNode.GetAttributeValue("src", "nothing");
                    string title = TitleNode.InnerText.ToString();
                    string date = DateNode.InnerText;
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
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }
                return list;
            }
            catch { return list; }
        }

        public static void chernivtsi()
        {
            Console.Title = "Chernivtsi";
            var NEWS = ReadChernivtsi("https://city.cv.ua/", "//div[@class='content']//div[@class='item clearfix']", System.Reflection.MethodBase.GetCurrentMethod().Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                     DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                     $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }
        }
        private static List<Data>? ReadChernivtsi(string url, string node, string name)
        {
            Console.Title = "Wait"; List<Data> list = new();
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

                    Data tmp = new();
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
                        info += node3.InnerText;
                    }
                    /*Link*/
                    tmp.link = (href.GetAttributeValue("href", "nothing"));
                    /*Title*/
                    tmp.title = title.InnerText;
                    /*img*/
                    tmp.image = (img[2].GetAttributeValue("src", "nothing"));
                    /*date*/
                    tmp.time = Date.InnerText;
                    /*time*/
                    //tmp.Add(time.InnerText.Remove(0, 2));
                    /*main*/
                    tmp.info = info;
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }

                return list;
            }
            catch { return list; }
        }
        public static void zakarpattia()
        {
            Console.Title = "Zakarpattia";
            var NEWS = ReadZakarpattia("http://www.mukachevo.net/ua/news/index", "//div[@class='row news-index-list']//div[@class='col-sm-12 news-index-list-container']//div[@class='row']", System.Reflection.MethodBase.GetCurrentMethod().Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                      DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                      $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }
        }
        private static List<Data>? ReadZakarpattia(string url, string node, string name)
        {
            Console.Title = "Wait"; List<Data> list = new();
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
                    Data tmp = new();
                    HtmlDocument Doc = new(); Doc.LoadHtml(node2.InnerHtml);
                    HtmlNode Link = Doc.DocumentNode.SelectSingleNode("//a[@href]");
                    if (Link == null) { continue; }
                    string SiteHtml = web.DownloadString("http://www.mukachevo.net/" + Link.GetAttributeValue("href", "nothing"));
                    Doc.LoadHtml(SiteHtml);
                    HtmlNode TitleNode = Doc.DocumentNode.SelectSingleNode("//h1[@class='item-header news-header']");
                    HtmlNodeCollection ImgNode = Doc.DocumentNode.SelectNodes("//img[@src]");
                    HtmlNode DateNode = Doc.DocumentNode.SelectSingleNode("//span[@class='date' or @class='news-date']");
                    HtmlNodeCollection NewsBodyNode = Doc.DocumentNode.SelectNodes("//div[@class='item-body news-body']//p");
                    string NewsBody = "";
                    foreach (HtmlNode node3 in NewsBodyNode)
                    {
                        NewsBody += node3.InnerText;
                    }
                    /*Link*/
                    tmp.link = ("http://www.mukachevo.net" + Link.GetAttributeValue("href", "nothing"));
                    /*Title*/
                    tmp.title = TitleNode.InnerText;
                    /*img*/
                    tmp.image = ("http://www.mukachevo.net" + ImgNode[5].GetAttributeValue("src", "nothing"));
                    /*date*/
                    tmp.time = DateNode.GetAttributeValue("content", "unknown");
                    /*time*/
                    //tmp.Add(DateNode.InnerText.Substring(DateNode.InnerText.IndexOf("|") + 2, DateNode.InnerText.Length - DateNode.InnerText.IndexOf("|") - 2));
                    /*main*/
                    tmp.info = (NewsBody);
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return list;
                    }
                    list.Add(tmp);

                }

                return list;
            }
            catch { return list; }
        }
        public static void volyn()
        {
            Console.Title = "Volyn";
            var NEWS = ReadVolyn("https://www.volynnews.com/news/all/", "//div[@class='media-body']//h4//a[@href]", System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                    DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                    $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }
        }
        private static List<Data>? ReadVolyn(string url, string node, string name)
        {
            Console.Title = "Wait"; List<Data> list = new();
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
                    Data tmp = new();

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
                        NewsBody += node3.InnerText;
                    }



                    /*Link*/
                    tmp.link = ("https://www.volynnews.com" + Link);
                    /*Title*/
                    tmp.title = TitleNode.InnerText;
                    /*img*/
                    tmp.image = ("https://www.volynnews.com" + ImgNode.GetAttributeValue("src", "nothing"));
                    /*date*/
                    tmp.time = DateNode.InnerText;

                    /*time*/
                    //tmp.Add(DateNode.InnerText.Substring(DateNode.InnerText.IndexOf(" "), DateNode.InnerText.Length - DateNode.InnerText.IndexOf(" ")).("\n", "").("\t", ""));
                    /*main*/
                    tmp.info = (NewsBody);
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return list;
                    }
                    list.Add(tmp);

                }

                return list;
            }
            catch { return list; }
        }
        public static void rivne()
        {
            Console.Title = "Rivne";
            var NEWS = ReadRivne("https://rivnepost.rv.ua/category/region", "//div[@class='list-13--img']//a[@href]", System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                    DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                    $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }
        }
        private static List<Data>? ReadRivne(string url, string node, string name)
        {
            Console.Title = "Wait"; List<Data> list = new();
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

                    Data tmp = new();


                    string Link = "https://rivnepost.rv.ua" + item.GetAttributeValue("href", "nothing");


                    HtmlDocument News = new();
                    string HTML = web.DownloadString(Link);


                    News.LoadHtml(HTML);
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//img[@itemprop='image']");
                    string img = "https://rivnepost.rv.ua" + ImgNode.GetAttributeValue("src", "nothing");


                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h1[@itemprop='name']");
                    string Title = TitleNode.InnerText;


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//div[@class='article--pubdate']");
                    string Day = DATE.InnerText.Substring(0, DATE.InnerText.IndexOf(" "));
                    string Clock = DATE.InnerText.Remove(0, DATE.InnerText.IndexOf(" ") + 1).Substring(0, DATE.InnerText.Remove(0, DATE.InnerText.IndexOf(" ") + 1).IndexOf(" "));


                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//div[@class='view-news']");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText;
                    }

                    /*Link*/
                    tmp.link = Link;
                    /*Title*/
                    tmp.title = Title;
                    /*img*/
                    tmp.image = img;
                    /*date*/
                    tmp.time = Day + " " + Clock;
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.info = NewsInfo;
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }

        }
        public static void khmelnytskyi()
        {
            Console.Title = "Khmelnytskyi";
            var NEWS = ReadKhmelnytskyi("https://vsim.ua/allnews", "//div[@class='news-title']//a[@href]", System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                    DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                    $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }
        }
        private static List<Data>? ReadKhmelnytskyi(string url, string node, string name)
        {
            Console.Title = "Wait"; List<Data> list = new();
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

                    Data tmp = new();


                    string Link = "" + item.GetAttributeValue("href", "nothing");


                    HtmlDocument News = new();
                    string HTML = web.DownloadString(Link);


                    News.LoadHtml(HTML);
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//picture//img[@src]");
                    string img = "" + ImgNode.GetAttributeValue("data-src", "nothing");


                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//div[@class='page-long-head']//h1");
                    string Title = TitleNode.InnerText;


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//span[@class='js-auto-date']");
                    string Day = DATE.GetAttributeValue("data-date", "nothing").Substring(0, DATE.GetAttributeValue("data-date", "nothing").IndexOf(" "));
                    string Clock = DATE.GetAttributeValue("data-date", "nothing").Substring(DATE.GetAttributeValue("data-date", "nothing").IndexOf(" "), DATE.GetAttributeValue("data-date", "nothing").Length - DATE.GetAttributeValue("data-date", "nothing").IndexOf(" "));



                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//p[@class='ck_editor_p']");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText;
                    }

                    /*Link*/
                    tmp.link = Link;
                    /*Title*/
                    tmp.title = Title;
                    /*img*/
                    tmp.image = img;
                    /*date*/
                    tmp.time = Day+ Clock;
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.info = NewsInfo;
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }

        }
        public static void zhytomyr()
        {
            Console.Title = "Zhytomyr";
            List<Data> NEWS = ReadZhytomyr("https://zt-rada.gov.ua/news?newslabel=3", "//div[@class='nwslstitm']//a[@href]", System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                     DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                     $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }
        }
        private static List<Data> ReadZhytomyr(string url, string node, string name)
        {
            Console.Title = "Wait"; List<Data> list = new();
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

                    Data tmp = new();


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
                    string Title = TitleNode.InnerText;


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//div[@class='f-date']");
                    string Day = DATE.InnerText;
                    //string Clock = DATE.GetAttributeValue("data-date", "nothing").Substring(DATE.GetAttributeValue("data-date", "nothing").IndexOf(" "), DATE.GetAttributeValue("data-date", "nothing").Length - DATE.GetAttributeValue("data-date", "nothing").IndexOf(" "));



                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//p[@style='text-align:justify;']"); if (NewsNode == null) { NewsNode = News.DocumentNode.SelectNodes("//div[@style='text-align:justify;']"); NewsNode ??= News.DocumentNode.SelectNodes("//div[@class='desc']"); }
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText;
                    }

                    /*Link*/
                    tmp.link = Link;
                    /*Title*/
                    tmp.title = Title;
                    /*img*/
                    tmp.image = img;
                    /*date*/
                    tmp.time = Day;
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.info = NewsInfo;
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void chernihiv()
        {
            Console.Title = "Chernihiv";
            List<Data> NEWS = ReadChernihiv("https://newch.tv/category/novyny/", "//a[@class='vmagazine-lite-archive-more']", System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                    DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                    $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }
        }
        private static List<Data> ReadChernihiv(string url, string node, string name)
        {
            Console.Title = "Wait"; List<Data> list = new();
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

                    Data tmp = new();


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
                    string Title = TitleNode.InnerText;


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//span[@class='posted-on']");
                    string Day = DATE.InnerText;



                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//div[@class='entry-content clearfix']//p");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText;
                    }

                    /*Link*/
                    tmp.link = Link;
                    /*Title*/
                    tmp.title = Title;
                    /*img*/
                    tmp.image = img;
                    /*date*/
                    tmp.time = Day;
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.info = NewsInfo;
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void vinnytsia()
        {

            List<Data> NEWS = ReadVinnytsia("https://news.vn.ua", "//h2[@class='entry-title']//a[@href]", System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                     DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                     $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }
        }
        private static List<Data> ReadVinnytsia(string url, string node, string name)
        {
            Console.Title = "Wait"; List<Data> list = new();
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

                    Data tmp = new();


                    string Link = "" + item.GetAttributeValue("href", "nothing");


                    HtmlDocument News = new();
                    string HTML = web.DownloadString(Link);


                    News.LoadHtml(HTML);
                    string ImgString = "";
                    string img = "";
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//figure[@class='pk-lightbox-container pk-pin-it-container']//a[@href]");
                    if (ImgNode == null) { ImgNode = News.DocumentNode.SelectSingleNode("//div[@data-video]"); if (ImgNode == null) { img = "https://aesthetic-macaron-2d69dd.netlify.app/img/logo.png"; } else { img = ImgNode.GetAttributeValue("data-video", "nothing"); } }
                    else
                    {
                        img = ImgString + ImgNode.GetAttributeValue("href", "nothing");
                    }
                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h1[@class='entry-title']");
                    string Title = TitleNode.InnerText;

                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//li[@class='meta-date']//a[@rel]");
                    string Day = DATE.InnerText;


                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//section[@class='entry-content']");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText;
                    }

                    /*Link*/
                    tmp.link = Link;
                    /*Title*/
                    tmp.title = Title;
                    /*img*/
                    tmp.image = img;
                    /*date*/
                    tmp.time = Day;
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.info = NewsInfo;
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }
                return list;
            }
            catch { return list; }
        }
        public static void kyiv()
        {
            Console.Title = "Kyiv";
            List<Data> NEWS = ReadKyiv("https://kmr.gov.ua/", "//div[@class='field-link']//span[@class='field-content']//a[@href]", System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                    DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                    $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }

        }
        private static List<Data> ReadKyiv(string url, string node, string name)
        {
            Console.Title = "Wait"; List<Data> list = new();
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

                    Data tmp = new();


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
                    string Title = TitleNode.InnerText;

                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//div[@class='field field-name-post-date field-type-ds field-label-hidden view-mode-full']");
                    string Day = DATE.InnerText.Replace("  ", "");



                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//div[@class='field-item field-content even']//p[@style='text-align: justify;']");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText;
                    }

                    /*Link*/
                    tmp.link = Link;
                    /*Title*/
                    tmp.title = Title;
                    /*img*/
                    tmp.image = img;
                    /*date*/
                    tmp.time = Day;
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.info = NewsInfo;
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void kirovohradsk()
        {
            Console.Title = "Kirovohradsk";
            List<Data> NEWS = ReadKirovohradsk("https://kr-rada.gov.ua/news/", "//div[@class='col-md-4 col-xs-12 col-sm-6 col-lg-4']//div[@class='post']//a[@href]//div[@class='post-img']", System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                    DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                    $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }
        }
        private static List<Data>? ReadKirovohradsk(string url, string node, string name)
        {
            Console.Title = "Wait"; List<Data> list = new();
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

                    Data tmp = new();


                    string Link = "https://kr-rada.gov.ua" + item.ParentNode.GetAttributeValue("href", "nothing");


                    HtmlDocument News = new();
                    string HTML = web.DownloadString(Link);


                    News.LoadHtml(HTML);
                    string ImgString = "https:";
                    string img = "";
                    //HtmlNode ImgNode = .DocumentNode.SelectSingleNode("//img[@class='attachment-full size-full wp-post-image']");

                    img = ImgString + item.FirstChild.GetAttributeValue("src", "nothing");


                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h1[@class='page-title']");
                    string Title = TitleNode.InnerText;


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//div[@class='news-date']");
                    string Day = DATE.InnerText;




                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//span[@style='font-size:16px;']");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText;
                    }

                    /*Link*/
                    tmp.link = Link;
                    /*Title*/
                    tmp.title = Title;
                    /*img*/
                    tmp.image = img;
                    /*date*/
                    tmp.time = Day;
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.info = NewsInfo;
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void zaporizhzhia()
        {
            Console.Title = "Zaporizhzhia";
            List<Data> NEWS = ReadZaporizhzhia("https://zp.gov.ua/uk/articles/category/news/1", "//div[@class='simple-list-row']//a[@href]", System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                    DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                    $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }

        }
        private static List<Data> ReadZaporizhzhia(string url, string node, string name)
        {
            Console.Title = "Wait"; List<Data> list = new();
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

                    Data tmp = new();


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
                    string Title = TitleNode.InnerText;

                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//span[@class='date']");
                    string Day = DATE.InnerText;



                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//div[@class='page-content content-text']//p");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText;
                    }

                    /*Link*/
                    tmp.link = Link;
                    /*Title*/
                    tmp.title = Title;
                    /*img*/
                    tmp.image = img;
                    /*date*/
                    tmp.time = Day;
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.info = NewsInfo;
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void luhansk()
        {
            Console.Title = "Luhansk";
            List<Data> NEWS = ReadLuhansk("https://www.ukrinform.ua/tag-lugansina", "//section//h2//a[@href]", System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                    DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                    $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }

        }
        private static List<Data> ReadLuhansk(string url, string node, string name)
        {
            Console.Title = "Wait"; List<Data> list = new();
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

                    Data tmp = new();




                    string Link = "https://www.ukrinform.ua" + item.GetAttributeValue("href", "nothing");
                    HtmlDocument News = new();
                    News.LoadHtml(item.InnerHtml);
                    string HTML = web.DownloadString(Link);
                    News.LoadHtml(HTML);



                    string ImgString = "";
                    string img = "";
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//img[@class='newsImage']");
                    if (ImgNode == null)
                    {
                        continue;
                    }
                    else
                    {
                        img = ImgString + ImgNode.GetAttributeValue("src", "nothing");
                    }

                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h1[@class='newsTitle']");
                    string Title = TitleNode.InnerText;

                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//div[@class='newsDate']");
                    string Day = DATE.InnerText;



                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//div[@class='newsText']");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText;
                    }

                    /*Link*/
                    tmp.link = Link;
                    /*Title*/
                    tmp.title = Title;
                    /*img*/
                    tmp.image = img;
                    /*date*/
                    tmp.time = Day;
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.info = NewsInfo;
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void kharkiv()
        {
            Console.Title = "Kharkiv";
            List<Data> NEWS = ReadKharkiv("https://www.city.kharkov.ua/uk/novosti/ofczjno.html", "//div[@class='list_news col-md-9 col-sm-12 col-xs-12']//ul[@class='list']//div[@class='alignleft col-md-3 col-sm-3 col-xs-12']//a[@href]", System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                    DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                    $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }

        }
        private static List<Data> ReadKharkiv(string url, string node, string name)
        {
            Console.Title = "Wait"; List<Data> list = new();
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

                    Data tmp = new();




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
                    string Title = TitleNode.InnerText;

                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//div[@class='data_post']//em");
                    HtmlNode ClockNode = News.DocumentNode.SelectSingleNode("//div[@class='data_post']//span[@class='time']");

                    string Day = DATE.InnerText;
                    string Clock = ClockNode.InnerText;


                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//div[@class='justifyfull']");
                    NewsNode ??= News.DocumentNode.SelectNodes("//p[@class='justifyfull']");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText;
                    }

                    /*Link*/
                    tmp.link = Link;
                    /*Title*/
                    tmp.title = Title;
                    /*img*/
                    tmp.image = img;
                    /*date*/
                    tmp.time = Day + " " + Clock;
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.info = NewsInfo;
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void dnipropetrovsk()
        {
            Console.Title = "Dnipropetrovsk";
            List<Data> NEWS = ReadDnipropetrovsk("https://oblrada.dp.gov.ua/category/news/", "//div[@class='col-xs-12 col-sm-12 col-md-12 obl-news-post fix-padding']//div//div[2]//p[@class='genpost-entry-title']//a[@href]", System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                     DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                     $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }
        }
        private static List<Data>? ReadDnipropetrovsk(string url, string node, string name)
        {
            Console.Title = "Wait"; List<Data> list = new();
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

                    Data tmp = new();




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
                    string Title = TitleNode.InnerText;
                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//time[@class='entry-date published updated' or @class='entry-date published']");
                    //HtmlNode ClockNode = News.DocumentNode.SelectSingleNode("//");

                    string Day = DATE.InnerText;
                    //string Clock = ClockNode.InnerText;


                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//div[@class='entry-content']");
                    NewsNode ??= News.DocumentNode.SelectNodes("//");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText;
                    }

                    /*Link*/
                    tmp.link = Link;
                    /*Title*/
                    tmp.title = Title;
                    /*img*/
                    tmp.image = img;
                    /*date*/
                    tmp.time = Day;
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.info = NewsInfo;
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void sumy()
        {
            Console.Title = "Sumy";
            List<Data> NEWS = ReadSumy("https://www.0542.ua/news", "//div[@class='col-12 col-md-8 col-lg-9']//div[@class='c-news-card__head']//a[@href]", System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                    DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                    $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }
        }
        private static List<Data>? ReadSumy(string url, string node, string name)
        {
            Console.Title = "Wait"; List<Data> list = new();
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

                    Data tmp = new();




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
                    string Title = TitleNode.InnerText;


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//div[@class='article-details__date']");
                    //HtmlNode ClockNode = News.DocumentNode.SelectSingleNode("//");

                    string Day = DATE.InnerText;
                    //string Clock = ClockNode.InnerText;


                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//app-model-content//p");

                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText;
                    }
                    string[] DayArray = Day.Split(",");
                    /*Link*/
                    tmp.link = Link;
                    /*Title*/
                    tmp.title = Title;
                    /*img*/
                    tmp.image = img;
                    /*date*/
                    tmp.time = DayArray[1] + " " + DayArray[0];
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.info = NewsInfo;
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void kherson()
        {
            Console.Title = "Kherson";
            List<Data> NEWS = ReadKherson("https://miskrada.kherson.ua/news/", "//div[@class='w-post-elm post_image usg_post_image_1 has_ratio']//a[@href]", System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                    DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                    $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }
        }
        private static List<Data>? ReadKherson(string url, string node, string name)
        {
            Console.Title = "Wait"; List<Data> list = new();
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

                    Data tmp = new();




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
                    string Title = TitleNode.InnerText;


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//time[@class='w-post-elm post_date entry-date updated']");
                    //HtmlNode ClockNode = News.DocumentNode.SelectSingleNode("//");

                    string Day = DATE.InnerText;
                    //string Clock = ClockNode.InnerText;


                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//div[@class='w-post-elm post_content']");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText;
                    }

                    /*Link*/
                    tmp.link = Link;
                    /*Title*/
                    tmp.title = Title;
                    /*img*/
                    tmp.image = img;
                    /*date*/
                    tmp.time = Day;
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.info = NewsInfo;
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void poltava()
        {
            Console.Title = "Poltava";
            List<Data> NEWS = ReadPoltava("https://www.rada-poltava.gov.ua/", "//td[@class='leftcol news']//div//h1//a[@href]", System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                    DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                    $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }
        }
        private static List<Data>? ReadPoltava(string url, string node, string name)
        {
            Console.Title = "Wait"; List<Data> list = new();
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

                    Data tmp = new();




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
                    string Title = TitleNode.InnerText;


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//a[@id='daterange']");
                    //HtmlNode ClockNode = News.DocumentNode.SelectSingleNode("//");

                    string Day = DATE.InnerText.Replace(",", "");
                    //string Clock = ClockNode.InnerText;


                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//td[@class='leftcol news']//p");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText;
                    }

                    /*Link*/
                    tmp.link = Link;
                    /*Title*/
                    tmp.title = Title;
                    /*img*/
                    tmp.image = img;
                    /*date*/
                    tmp.time = Day;
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.info = NewsInfo;
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void kryvyi_rih()//warning
        {
            Console.Title = "";
            List<Data> NEWS = ReadKryvyi_Rih("https://post.kr.ua/", "//h2[@class='title']//a[@href]", System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                     DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                     $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }
        }
        private static List<Data>? ReadKryvyi_Rih(string url, string node, string name)//warning
        {
            Console.Title = "Wait"; List<Data> list = new();
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

                    Data tmp = new();




                    string Link = "" + item.GetAttributeValue("href", "nothing");
                    HtmlDocument News = new();
                    News.LoadHtml(item.InnerHtml);
                    string HTML = web.DownloadString(Link);
                    News.LoadHtml(HTML);


                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//span[@class='post-title']");
                    string Title = TitleNode.InnerText;


                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//div[@class='entry-content clearfix single-post-content']//p");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText;
                    }
                    string img = "https://aesthetic-macaron-2d69dd.netlify.app/img/logo.png";
                    /*Link*/
                    tmp.link = Link;
                    /*Title*/
                    tmp.title = Title;
                    /*Image*/
                    tmp.image = img;
                    /*time*/
                    tmp.time = DateTime.Now.ToString();
                    /*info*/
                    tmp.info = NewsInfo;
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void odesa()
        {
            Console.Title = "";
            List<Data> NEWS = ReadOdesa("https://www.ukrinform.ua/tag-odesa", "//section[@class='restList']//article[@data-id]//section//h2//a[@href]", System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                    DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                    $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }
        }
        private static List<Data>? ReadOdesa(string url, string node, string name)
        {
            Console.Title = "Wait"; List<Data> list = new();
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

                    Data tmp = new();




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
                    string Title = TitleNode.InnerText;


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//time[@datetime]");
                    //HtmlNode ClockNode = News.DocumentNode.SelectSingleNode("//");

                    string Day = DATE.InnerText;
                    //string Clock = ClockNode.InnerText;


                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//div[@class='newsText']");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText;
                    }

                    /*Link*/
                    tmp.link = Link;
                    /*Title*/
                    tmp.title = Title;
                    /*img*/
                    tmp.image = img;
                    /*date*/
                    tmp.time = Day;
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.info = NewsInfo;
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void mykolayiv()
        {
            Console.Title = "Mykolayiv";
            List<Data> NEWS = ReadMykolayiv("https://espreso.tv/mykolayiv", "//div[@class='title']//a[@href]", System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.Title = "Output  Mykolayiv";

            /*Link*/
            /*Title*/
            /*img*/
            /*date*/
            /*info*/
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                     DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                     $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }
        }
        private static List<Data>? ReadMykolayiv(string url, string node, string name)
        {
            Console.Title = "Wait"; List<Data> list = new();
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

                    Data tmp = new();




                    string Link = "" + item.GetAttributeValue("href", "nothing");
                    HtmlDocument News = new();
                    News.LoadHtml(item.InnerHtml);
                    string HTML = web.DownloadString(Link);
                    News.LoadHtml(HTML);



                    string ImgString = "";
                    string img = "";
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//picture//source[@srcset]");
                    if (ImgNode == null)
                    {
                        continue;
                    }
                    img = ImgString + ImgNode.GetAttributeValue("srcset", "nothing");


                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h1[@class='text-title']");
                    string Title = TitleNode.InnerText;


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//div[@class='news__author_date']");
                    //HtmlNode ClockNode = News.DocumentNode.SelectSingleNode("//");

                    string Day = DATE.InnerText;
                    //string Clock = ClockNode.InnerText;

                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//section[@class='content_current_article']");

                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText;
                    }

                    /*Link*/
                    tmp.link = Link;
                    /*Title*/
                    tmp.title = Title;
                    /*img*/
                    tmp.image = img;
                    /*date*/
                    tmp.time = Day;
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.info = NewsInfo;
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public static void cherkassy()
        {
            Console.Title = "Cherkassy";
            List<Data> NEWS = ReadCherkassy("https://18000.com.ua/novini/", "//article[@class='post post--horizontal post--horizontal-sm']//a[@href]", System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.Title = "Output";
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    DB.DATABASE_INSERT(System.Reflection.MethodBase.GetCurrentMethod().Name, $"CREATE TABLE IF NOT EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n(\r\n    id integer NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT \"{System.Reflection.MethodBase.GetCurrentMethod().Name}_pkey\" PRIMARY KEY (id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{System.Reflection.MethodBase.GetCurrentMethod().Name}\"\r\n    OWNER to postgres;",
                    DB.Connect, $"INSERT INTO {System.Reflection.MethodBase.GetCurrentMethod().Name}" +
                    $"(title,info,time,link,image,id ) VALUES (@title,@info,@time,@link,@image,@id)", item);
                }
        }
        private static List<Data>? ReadCherkassy(string url, string node, string name)
        {
            Console.Title = "Wait"; List<Data> list = new();
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

                    Data tmp = new();

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
                    if (TitleNode == null) { continue; }
                    string Title = TitleNode.InnerText;


                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//time[@class='time published']");
                    //HtmlNode ClockNode = News.DocumentNode.SelectSingleNode("//");

                    string Day = DATE.GetAttributeValue("datetime", "unknown");
                    //string Clock = ClockNode.InnerText;

                    HtmlNodeCollection NewsNode = News.DocumentNode.SelectNodes("//div[@class='single-body entry-content typography-copy']//p");
                    string NewsInfo = "";
                    foreach (var Block in NewsNode)
                    {
                        NewsInfo += Block.InnerText;
                    }

                    /*Link*/
                    tmp.link = Link;
                    /*Title*/
                    tmp.title = Title;
                    /*img*/
                    if (ImgNode != null)
                    {
                        img = ImgString + ImgNode.GetAttributeValue("src", "nothing");
                        tmp.image = img;

                    }
                    else { tmp.image = ("empty"); }
                    /*date*/
                    tmp.time = Day;
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.info = NewsInfo;
                    if (DB.DATABASE_CHECK(tmp.title, DB.Connect, name))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        /*
                                  ___-------___
                               _-~~             ~~-_
                           _-~                    /~-_
        /^\__/^\          /~  \                   /    \
      /|  O|| O|         /      \_______________/        \
     | |___||__|      /       /                \          \
     |          \    /      /                    \          \
     |   (_______) /______/                        \_________ \
     |         / /         \                      /            \
      \         \^\\         \                  /               \    /
       \         ||           \______________/      _-_       //\__//
         \       ||------_-~~-_ ------------- \ --/~   ~\    || __/
            ~-----||====/~     |==================|       |/~~~~~
             (_(__/  ./     /                    \_\      \.
                     (_(___/                      \_\_____)_)

         */


    }
}


