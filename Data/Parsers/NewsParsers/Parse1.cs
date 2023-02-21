using HtmlAgilityPack;
using System.Net;
using System.Text;
#pragma warning disable 8602, 8600, SYSLIB0014 
namespace Parser_2022_
{

    class Parse1
    {
        public Parse1() { }
        public async static void lviv()
        {// 5 site/link
            string Name = "lviv1";
            var NEWS = ReadLviv("https://city-adm.lviv.ua/news", "//ul[@class='tm-news uk-list uk-list-large']/li/a[@href]", Name);

            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
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
                    Data tmp = new(1,12, "https://city-adm.lviv.ua/app/img/logo.svg");

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
                    string[] DateSplit = date.Split(".");
                    date = DateSplit[1] + "." + DateSplit[0] + "." + DateSplit[2];
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
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        return listRay;
                    }
                    listRay.Add(tmp);
                }
            }
            catch { return listRay; }
            return listRay;
        }
        public async static void ternopil()
        {
            string Name = "ternopil1";

            var NEWS = ReadTernopil("https://ternopilcity.gov.ua/news/", "//div[@class]/h4/a[@href]", Name);

            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
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
                    Data tmp = new(2,18, "https://ternopilcity.gov.ua/images/logo_ua.png");
                    string Link = "" + item.GetAttributeValue("href", "nothing");
                    HtmlDocument News = new();
                    News.LoadHtml(item.InnerHtml);
                    string HTML = web.DownloadString(Link);
                    News.LoadHtml(HTML);

                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//img[@style='float: left;']");
                    HtmlNode TitleNode = item;
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//time[@datetime]");
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//div[@class='post-body']");
                    string img = "";
                    if (ImgNode != null)
                    {
                        img = "" + ImgNode.GetAttributeValue("src", "nothing");
                    }
                    else { img = "https://ternopilcity.gov.ua/images/logo_ua.png"; }
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
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }

            }
            catch { return list; }
            return list;
        }

        public async static void ivano_frankivsk()
        {
            string Name = "ivano_frankivsk1";
            var NEWS = ReadIvano_Frankivsk("https://galka.if.ua/category/frankivski-novini/", "//div[@class='media-body']", Name);

            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data>? ReadIvano_Frankivsk(string url, string node, string name)
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
                    Data tmp = new(3,8, "https://galka.if.ua/app/themes/gl_theme/images/logo.png");
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
                    string img = "" + ImgNode.GetAttributeValue("data-lazy-src", "nothing");
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
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }
                return list;
            }
            catch { return list; }
        }

        public async static void chernivtsi()
        {

            string Name = "chernivtsi1";

            var NEWS = ReadChernivtsi("https://city.cv.ua/", "//div[@class='content']//div[@class='item clearfix']", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data>? ReadChernivtsi(string url, string node, string name)
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

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode node2 in nodes)
                {

                    Data tmp = new(4,23, "https://city.cv.ua/img/header_logo.svg");
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
                    tmp.time = DateTime.Now.ToString("M.dd.yyyy HH:mm");
                    /*time*/
                    //tmp.Add(time.InnerText.Remove(0, 2));
                    /*main*/
                    tmp.info = info;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }

                return list;
            }
            catch { return list; }
        }
        public async static void zakarpattia()
        {
            string Name = "zakarpattia1";
            var NEWS = ReadZakarpattia("http://www.mukachevo.net/ua/news/index/1", "//div[@class='row news-index-list']//div[@class='col-sm-12 news-index-list-container']//div[@class='row']", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data>? ReadZakarpattia(string url, string node, string name)
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

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode node2 in nodes)
                {
                    Data tmp = new(5,6, "http://www.mukachevo.net/images/logo.png");
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
                    string Date = DateNode.InnerText;
                    Date = Date.Substring(Date.IndexOf(",") + 2).Replace("|", " ");
                    string[] DateSplit = Date.Split(".");
                    Date = DateSplit[1] + "." + DateSplit[0] + "." + DateSplit[2];
                    /*Link*/
                    tmp.link = ("http://www.mukachevo.net" + Link.GetAttributeValue("href", "nothing"));
                    /*Title*/
                    tmp.title = TitleNode.InnerText;
                    /*img*/
                    tmp.image = ("http://www.mukachevo.net" + ImgNode[5].GetAttributeValue("src", "nothing"));
                    /*date*/
                    tmp.time = Date;

                    /*time*/
                    //tmp.Add(DateNode.InnerText.Substring(DateNode.InnerText.IndexOf("|") + 2, DateNode.InnerText.Length - DateNode.InnerText.IndexOf("|") - 2));
                    /*main*/
                    tmp.info = (NewsBody);
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        return list;
                    }
                    list.Add(tmp);

                }

                return list;
            }
            catch { return list; }
        }
        public async static void volyn()
        {
            string Name = "volyn1";
            var NEWS = ReadVolyn("https://www.volynnews.com/news/all/", "//div[@class='media-body']//h4//a[@href]", Name);
             
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data>? ReadVolyn(string url, string node, string name)
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

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode node2 in nodes)
                {
                    Data tmp = new(6,2, "https://www.volynnews.com/public/images/logo1.png");

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
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        return list;
                    }
                    list.Add(tmp);

                }

                return list;
            }
            catch { return list; }
        }
        public async static void rivne()
        {
            string Name = "rivne1";
            var NEWS = ReadRivne("https://rivnepost.rv.ua/category/region", "//div[@class='list-13--img']//a[@href]", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data>? ReadRivne(string url, string node, string name)
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

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    Data tmp = new(7,16, "https://rivnepost.rv.ua/images/logo-company.png");


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
                    Day += " " + Clock;
                    string[] DateSplit = Day.Split(".");
                    Day = DateSplit[1] + "." + DateSplit[0] + "." + DateSplit[2];

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
                    tmp.time = Day;
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.info = NewsInfo;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }

        }
        public async static void khmelnytskyi()
        {
            string Name = "khmelnytskyi1";
            var NEWS = ReadKhmelnytskyi("https://vsim.ua/allnews", "//div[@class='news-title']//a[@href]", Name);
             
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data>? ReadKhmelnytskyi(string url, string node, string name)
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

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    Data tmp = new(8,21, "https://vsim.ua/img/Logo_new_vsim_v8.png");


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

                    Day += Clock;
                    //string[] DateSplit = Day.Replace("-",".").Split(".");
                    //Day = DateSplit[1] + "." + DateSplit[0] + "." + DateSplit[2];

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
                    tmp.time = Day;
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.info = NewsInfo;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }

        }
        public async static void zhytomyr()
        {
            string Name = "zhytomyr1";
            List<Data> NEWS = ReadZhytomyr("https://zt-rada.gov.ua/news?newslabel=3", "//div[@class='nwslstitm']//a[@href]", Name);
             
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> ReadZhytomyr(string url, string node, string name)
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

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    Data tmp = new(9,5, "https://zt-rada.gov.ua/files/css/logo2.png");


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
                    string[] DateSplit = Day.Split(".");
                    Day = DateSplit[1] + "." + DateSplit[0] + "." + DateSplit[2];


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
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public async static void chernihiv()
        {
            string Name = "chernihiv1";
            List<Data> NEWS = ReadChernihiv("https://newch.tv/category/novyny/", "//a[@class='vmagazine-lite-archive-more']", Name);
             
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> ReadChernihiv(string url, string node, string name)
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

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    Data tmp = new(10,24, "https://newch.tv/wp-content/uploads/2019/12/cropped-logo_telekanal_1.png");


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
                    string[] DateSplit = Day.Split(".");
                    Day = DateSplit[1] + "." + DateSplit[0] + "." + DateSplit[2];


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
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public async static void vinnytsia()
        {
            string Name = "vinnytsia1";
            List<Data> NEWS = ReadVinnytsia("https://news.vn.ua", "//h2[@class='entry-title']//a[@href]", Name);
             
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> ReadVinnytsia(string url, string node, string name)
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

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    Data tmp = new(11,1, "https://www.news.vn.ua/wp-content/uploads/2019/10/vnlogo-2x.png");


                    string Link = "" + item.GetAttributeValue("href", "nothing");


                    HtmlDocument News = new();
                    string HTML = web.DownloadString(Link);


                    News.LoadHtml(HTML);
                    string ImgString = "";
                    string img = "";
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//figure[@class='pk-lightbox-container pk-pin-it-container']//a[@href]");
                    if (ImgNode == null) { ImgNode = News.DocumentNode.SelectSingleNode("//div[@data-video]"); if (ImgNode == null) { img = "https://www.news.vn.ua/wp-content/uploads/2019/10/vnlogo-2x.png"; } else { img = ImgNode.GetAttributeValue("data-video", "nothing"); } }
                    else
                    {
                        img = ImgString + ImgNode.GetAttributeValue("href", "nothing");
                    }
                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h1[@class='entry-title']");
                    string Title = TitleNode.InnerText;

                    HtmlNode DATE = News.DocumentNode.SelectSingleNode("//li[@class='meta-date']//a[@rel]");
                    string Day = DATE.InnerText;
                    string[] DateSplit = Day.Split(".");
                    Day = DateSplit[1] + "." + DateSplit[0] + "." + DateSplit[2];

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
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }
                return list;
            }
            catch { return list; }
        }
        public async static void kyiv()
        {
            string Name = "kyiv1";
            List<Data> NEWS = ReadKyiv("https://kmr.gov.ua/", "//div[@class='field-link']//span[@class='field-content']//a[@href]", Name);
             
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }

            
        }
        private static List<Data> ReadKyiv(string url, string node, string name)
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

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    Data tmp = new(12,9, "https://kmr.gov.ua/sites/default/files/logo_0.png");


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
                    string[] DateSplit = Day.Split(".");
                    Day = DateSplit[1] + "." + DateSplit[0] + "." + DateSplit[2];


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
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public async static void kirovohradsk()
        {
            string Name = "kirovohradsk1";
            List<Data> NEWS = ReadKirovohradsk("https://kr-rada.gov.ua/news/", "//div[@class='col-md-4 col-xs-12 col-sm-6 col-lg-4']//div[@class='post']//a[@href]//div[@class='post-img']", Name);
             
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data>? ReadKirovohradsk(string url, string node, string name)
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

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    Data tmp = new(13,10, "https://upload.wikimedia.org/wikipedia/commons/2/21/Coat_of_Arms_of_Kropyvnytskyi.png");


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
                    string Day = DATE.InnerText.Substring(DATE.InnerText.IndexOf(",")+2,DATE.InnerLength - DATE.InnerText.IndexOf(",")-2);
                   



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
                    tmp.time = Day.Replace(" ",".");
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.info = NewsInfo;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public async static void zaporizhzhia()
        {
            string Name = "zaporizhzhia1";
            List<Data> NEWS = ReadZaporizhzhia("https://zp.gov.ua/uk/articles/category/news/1", "//div[@class='simple-list-row']//a[@href]", Name);
             
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }

            
        }
        private static List<Data> ReadZaporizhzhia(string url, string node, string name)
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

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    Data tmp = new(14,7, "https://zp.gov.ua/upload/cms_logo/o_1bl85joqu142dj9i19ls1eip1uoro.svg");


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
                    string[] DateSplit = Day.Split(".");
                    Day = DateSplit[1] + "." + DateSplit[0] + "." + DateSplit[2];


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
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public async static void luhansk()//check
        {
            string Name = "luhansk1";
            List<Data> NEWS = ReadLuhansk("https://www.ukrinform.ua/tag-lugansina", "//section//h2//a[@href]", Name);
             
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }

            
        }
        private static List<Data> ReadLuhansk(string url, string node, string name)
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

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    Data tmp = new(15,11, "https://www.ukrinform.ua/img/logo_ukr.svg");




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
                    string[] DateSplit = Day.Split(".");
                    Day = DateSplit[1] + "." + DateSplit[0] + "." + DateSplit[2];


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
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public async static void kharkiv()
        {
            string Name = "kharkiv1";
            List<Data> NEWS = ReadKharkiv("https://www.city.kharkov.ua/uk/novosti/ofczjno.html", "//div[@class='list_news col-md-9 col-sm-12 col-xs-12']//ul[@class='list']//div[@class='alignleft col-md-3 col-sm-3 col-xs-12']//a[@href]", Name);
             
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> ReadKharkiv(string url, string node, string name)
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

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    Data tmp = new(16,19, "https://www.city.kharkov.ua/images/logo-ru.png");




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

                    string Day = DATE.InnerText.Replace("  ",".");
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
                    tmp.time = Day + "." + Clock;
                    /*time*/
                    //tmp.Add(Clock);
                    /*main*/
                    tmp.info = NewsInfo;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public async static void dnipropetrovsk()
        {
            string Name = "dnipropetrovsk1";
            List<Data> NEWS = ReadDnipropetrovsk("https://oblrada.dp.gov.ua/category/news/", "//div[@class='col-xs-12 col-sm-12 col-md-12 obl-news-post fix-padding']//div//div[2]//p[@class='genpost-entry-title']//a[@href]", Name);
             
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data>? ReadDnipropetrovsk(string url, string node, string name)
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

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    Data tmp = new(17,3, "https://oblrada.dp.gov.ua/wp-content/uploads/2018/04/gerb.png");




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
                    string[] DateSplit = Day.Split(".");
                    Day = DateSplit[1] + "." + DateSplit[0] + "." + DateSplit[2];
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
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public async static void sumy()
        {
            string Name = "sumy1";
            List<Data> NEWS = ReadSumy("https://www.0542.ua/news", "//div[@class='col-12 col-md-8 col-lg-9']//div[@class='c-news-card__head']//a[@href]", Name);
             
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data>? ReadSumy(string url, string node, string name)
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

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    Data tmp = new(18,17, "https://s.0542.ua/section/logo/upload/pers/44/logo.png");




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
                        img = "https://s.0542.ua/section/logo/upload/pers/44/logo.png";
                    }
                    else
                    {
                        img = ImgString + ImgNode.GetAttributeValue("src", "nothing");
                    }

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
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public async static void kherson()
        {
            string Name = "kherson1";
            List<Data> NEWS = ReadKherson("https://miskrada.kherson.ua/news/", "//div[@class='w-post-elm post_image usg_post_image_1 has_ratio']//a[@href]", Name);
             
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data>? ReadKherson(string url, string node, string name)
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

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    Data tmp = new(19,20, "https://miskrada.kherson.ua/wp-content/uploads/2018/04/logo_miskrada_2022.png");




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

                    string Day = DATE.GetAttributeValue("datetime", "nothing");
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
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public async static void poltava()
        {
            string Name = "poltava1";
            List<Data> NEWS = ReadPoltava("https://www.rada-poltava.gov.ua/", "//td[@class='leftcol news']//div//h1//a[@href]", Name);
             
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data>? ReadPoltava(string url, string node, string name)
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

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    Data tmp = new(20,15, "https://www.rada-poltava.gov.ua/pic/logo_poltava.gif");




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
                    string[] DateSplit = Day.Split(".");
                    Day = DateSplit[1] + "." + DateSplit[0] + "." + DateSplit[2];

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
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public async static void kryvyi_rih()//warning
        {
            string Name = "kryvyi_rih1";
            List<Data> NEWS = ReadKryvyi_Rih("https://post.kr.ua/", "//h2[@class='title']//a[@href]", Name);
             
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data>? ReadKryvyi_Rih(string url, string node, string name)//warning
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

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    Data tmp = new(21,3, "https://post.kr.ua/wp-content/webp-express/webp-images/uploads/2021/05/bez-ymeny-1.png.webp");




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
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public async static void odesa()
        {
            string Name = "odesa1";
            List<Data> NEWS = ReadOdesa("https://www.ukrinform.ua/tag-odesa", "//section[@class='restList']//article[@data-id]//section//h2//a[@href]", Name);
             
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data>? ReadOdesa(string url, string node, string name)
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

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    Data tmp = new(22,14, "https://www.ukrinform.ua/img/logo_ukr.svg");




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

                    string Day = DATE.GetAttributeValue("datetime","Unknown");
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
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public async static void mykolayiv()
        {
            string Name = "mykolayiv1";
            List<Data> NEWS = ReadMykolayiv("https://espreso.tv/mykolayiv", "//div[@class='title' or @class='main_news_article__item pos-r']//a[@href]", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data>? ReadMykolayiv(string url, string node, string name)
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

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    Data tmp = new(23,13, "https://espreso.tv/svg/logo-desktop.svg");




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

                    string Day = DATE.InnerText.Replace(",",".").Replace("\n\n\n",".");

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
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        return list;
                    }
                    list.Add(tmp);
                }


                return list;
            }
            catch { return list; }
        }
        public async static void cherkassy()
        {
            string Name = "cherkassy1";
            List<Data> NEWS = ReadCherkassy("https://18000.com.ua/novini/", "//article[@class='post post--horizontal post--horizontal-sm']//a[@href]", Name);
             
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data>? ReadCherkassy(string url, string node, string name)
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

                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(node);
                foreach (HtmlNode item in nodes)
                {

                    Data tmp = new(24,22, "https://18000.com.ua/wp-content/uploads/2019/03/Logo_Header.svg");

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

                    string Day = DATE.GetAttributeValue("datetime", "unknown").Replace(" ",".");
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
                    if (DB.DATABASE_CHECK(tmp))
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


