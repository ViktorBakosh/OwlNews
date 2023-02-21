using HtmlAgilityPack;

namespace Parser_2022_
{
    internal class Parse2
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
        //Second parsers
        /*

        done    Lviv
        done    Ternopil
        done    Ivano-Frankivsk
        done    Volyn
        done    Rivne
        done    Khmelnytskyi

        done    Chernivtsi
        done    Zakarpattia
        done    Zhytomyr
        done    Kyiv
        done    Sumy
        done    Chernihiv//time

        done    Vinnytsia
        done    Kirovohradsk
        done    Poltava
        done    Cherkassy
        done    Kryvyi Rih
        done    Zaporizhzhia

        done    Kherson
        done    Odesa
        done    Mykolayiv
        done    Kharkiv
        done    Dnipropetrovsk
        done    Luhansk 
         */
        public async static void lviv2()
        {
            string Name = "lviv2";
            List<Data> NEWS = LvivRead("https://zaxid.net/novini_lvova_tag50956/", "//div[@class='news-list archive-list  ']//ul[@class='list']//li[@class]//a[@href]", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> LvivRead(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {

                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(58,12, "https://upload.wikimedia.org/wikipedia/commons/8/8f/24_Group_Ukraine_03.png");
                    string Link = item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));

                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//span[@class='lazyload-holder']//img[@src]");
                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h1[@class='title']");
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//time[@datetime]");
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//div[@id='newsSummary']//p");
                    string img = ImgNode.GetAttributeValue("src", "nothing");
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
                      if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch { return List; }
            return List;
        }
        public async static void ternopil2()
        {
            string Name = "ternopil2";
            List<Data> NEWS = TernopilRead("https://ternopoliany.te.ua/novunu", "//a[@class='newsblocklink']", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> TernopilRead(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {

                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(59,18, "https://ternopoliany.te.ua/templates/ternopol2019/img/logo.png");
                    string Link = "https://ternopoliany.te.ua/" + item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));

                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//span[@class='itemImage img-responsive ']//a");
                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h2[@class='itemTitle']");
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//span[@class='itemDateCreated']");
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//div[@class='itemFullText']//p");
                    string img = "https://ternopoliany.te.ua" + ImgNode.GetAttributeValue("href", "nothing");
                    string title = TitleNode.InnerText.ToString();
                    string date = DateNode.InnerText.ToString();
                    date = date.Substring(date.IndexOf(",") + 2, date.Length - date.IndexOf(",") - 2).Replace(" ",".");
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
                      if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch {  return List; }
            return List;
        }
        public async static void ivano_frankivsk2()
        {
            string Name = "ivano_frankivsk2";
            List<Data> NEWS = ivano_frankivsk2Read("https://versii.if.ua/category/novunu/", "//a[@class='post-url post-title']", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> ivano_frankivsk2Read(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {

                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(60,8, "https://versii.if.ua/wp-content/uploads/2022/04/new-logo-800x264.jpg");
                    string Link = item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));

                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//div[@class='entry-content clearfix single-post-content']//p//a[@href]");
                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//span[@class='post-title']");
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//time[@datetime]");
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//p[@class='align-left']");
                    InfoNodes ??= News.DocumentNode.SelectNodes("//div[@dir='auto']");
                    InfoNodes ??= News.DocumentNode.SelectNodes("//div[@class='entry-content clearfix single-post-content']//div//p");
                    InfoNodes ??= News.DocumentNode.SelectNodes("//div[@class='entry-content clearfix single-post-content']//p");
                    string img = ImgNode.GetAttributeValue("href", "nothing");
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
                      if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch { return List; }
            return List;
        }
        public async static void volyn2()
        {
            string Name = "volyn2";
            List<Data> NEWS = volynRead("https://www.volynpost.com/", "//div[@class='latest-news-item']//a[@href]", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> volynRead(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {

                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(61,2, "https://www.volynpost.com/img/layouts/logo/city-1.jpg");
                    string Link = item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));

                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//img[@class='main-image']");
                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//div[@class='news-view-wrapper']//h1");
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//div[@class='date']");
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//div[@class='description']");
                    string img = "https://www.volynpost.com" + ImgNode.GetAttributeValue("src", "nothing");
                    string title = TitleNode.InnerText.ToString();
                    string date = DateNode.InnerText.ToString();
                    if (!date.Contains("Сьогодні")) { date = date.Replace(",", $"{DateTime.Now.Year.ToString()}"); }
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
                    if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch {  return List; }
            return List;
        }
        public async static void khmelnytskyi2()
        {
            string Name = "khmelnytskyi2";
            List<Data> NEWS = khmelnytskyiRead("https://ngp-ua.info/", "//ul[@class='line_height2']//li//a[@href]", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> khmelnytskyiRead(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {

                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(62,21, "https://ngp-ua.info/wp-content/themes/ngp-ua.info-v4.0/images/logo_white.png");
                    string Link = item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));

                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//img[@loading='lazy']");
                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h2[@class='entry-title']");
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//span[@class='updated']");
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//div[@class='entry entry-content fixwidth-content']//p");
                    string img = "";
                    if (ImgNode == null) { img = "https://ngp-ua.info/wp-content/themes/ngp-ua.info-v4.0/images/logo_white.png"; } else { img = ImgNode.GetAttributeValue("src", "nothing"); }
                    string title = TitleNode.InnerText.ToString();
                    string date = DateNode.InnerText.ToString();
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
                    tmp.time = date;
                    tmp.info = info;
                      if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch {  return List; }
            return List;
        }
        public async static void rivne2()
        {
            string Name = "rivne2";
            List<Data> NEWS = rivneRead("https://www.rivnenews.com.ua/novyny/", "//div[@class='pld-post-content']//a[@href]", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> rivneRead(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {

                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(62,16, "https://www.rivnenews.com.ua/wp-content/uploads/2018/06/logo.png");
                    string Link = item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));

                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//div[@class='single-post-thumb']//img[@src]");
                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h1[@class='name post-title entry-title']//span");
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//p[@class='post-meta']//span[@class='tie-date']");
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//div[@class='post-inner']//p");
                    string img = "" + ImgNode.GetAttributeValue("src", "nothing");
                    string title = TitleNode.InnerText.ToString();
                    string date = DateNode.InnerText.ToString().Replace(",", "");
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
                    tmp.time = date;
                    tmp.info = info;
                      if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch {  return List; }
            return List;
        }
        public async static void chernivtsi2()
        {
            string Name = "chernivtsi2";
            List<Data> NEWS = chernivtsiRead("https://acc.cv.ua/news/chernivtsi/", "//div[@class='AllNewsItemWrap']//a[@href]", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> chernivtsiRead(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {

                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(63,23, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRnzOVOpZaQx-grKqy9a7yshmJV9-yM4cInamCo2SgU8g&s");
                    string Link = "https://acc.cv.ua/news/chernivtsi" + item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));

                    HtmlNode TitleNode = News.DocumentNode.SelectSingleNode("//h1[@class='News__title']");
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//div[@class='pull-left item-image']//img[@src]");
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//div[@class='PostInfo__item PostInfo__item_date']");
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//div[@class='article-main-text']");


                    string img = "https:" + ImgNode.GetAttributeValue("src", "nothing");
                    string title = TitleNode.InnerText.ToString();
                    string date = DateNode.InnerText.ToString().Replace(" ",".");
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
                    if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch {  return List; }
            return List;
        }
        public async static void zakarpattia2()
        {
            string Name = "zakarpattia2";
            List<Data> NEWS = zakarpattiaRead("https://transkarpatia.net/", "//div[@class='list']/div[@class='item']/a[@class='title']", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> zakarpattiaRead(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {

                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(64,6, "https://transkarpatia.net/templates/Gazeta/images/logo.png");
                    string Link = "" + item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));

                    HtmlNode TitleNode = item;
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//img[@data-src]");
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//div[@class='rp-date']");
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//div[@class='col-md-9 full-story']/text()");


                    string img = "https://transkarpatia.net" + ImgNode.GetAttributeValue("data-src", "nothing");
                    string title = TitleNode.InnerText.ToString();
                    string date = DateNode.InnerText.ToString().Replace("/",".");
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
                      if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch {  return List; }
            return List;

        }
        public async static void zhytomyr2()
        {
            string Name = "zhytomyr2";
            List<Data> NEWS = zhytomyrRead("https://www.zhitomir.info/", "//div[@class='news-title']//a[@href]", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> zhytomyrRead(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {

                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(65,5, "https://www.ua-region.com.ua/firms/logo/33732896.jpg?ver=1633934851");
                    string Link = "https://www.zhitomir.info" + item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));

                    HtmlNode TitleNode = item;
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//img[@class='main-image']");
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//div[@class='news-date-full']");
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//p[@style='text-align: justify;']");
                    InfoNodes ??= News.DocumentNode.SelectNodes("//div[@class='text']//p");

                    string img = "";
                    if (ImgNode != null)
                    {
                        img = ImgNode.GetAttributeValue("src", "nothing");
                    }
                    else
                    {
                        img = "LOGO";//logo
                    }
                    string title = TitleNode.InnerText.ToString();
                    string date = DateNode.InnerText.ToString();
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
                      if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch {  return List; }
            return List;
        }
        public async static void kyiv2()
        {
            string Name = "kyiv2";
            List<Data> NEWS = kyivRead("https://www.kyivpost.com/uk/category/ukraine-uk", "//div[@class='title']//a[@href]", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> kyivRead(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {

                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(66,9, "https://www.kyivpost.com/assets/images/Kyivpost_logo_Black.svg");
                    string Link = "" + item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));

                    HtmlNode TitleNode = item;
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//img[@class='figure-img img-fluid post-img lazyload']");
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//div[@class='post-info']");
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//p[@dir='ltr']");
                    InfoNodes ??= News.DocumentNode.SelectNodes("//p[@class='MsoNormal']//span[@lang='UK']");
                    InfoNodes ??= News.DocumentNode.SelectNodes("//section[@class='entry fr-view  text ']//p");

                    string img = "" + ImgNode.GetAttributeValue("src", "nothing");
                    string title = TitleNode.InnerText.ToString();
                    int start = DateNode.InnerText.ToString().IndexOf("|") + 1, end = DateNode.InnerText.ToString().Length - start;
                    string date = DateNode.InnerText.ToString().Substring(start, end);
                    date = date.Substring(0, date.IndexOf("|"));
                    string info = "";
                    if (InfoNodes != null)
                    {
                        foreach (var inf in InfoNodes)
                        {
                            info += inf.InnerText.ToString();
                        }
                    }
                    tmp.link = Link;
                    tmp.title = title;
                    tmp.image = img;
                    tmp.time = date.Replace(",",".");
                    tmp.info = info;
                      if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch {  return List; }
            return List;
        }
        public async static void symu2()
        {
            string Name = "symu2";
            List<Data> NEWS = symuRead("https://sumypost.com/", "//div[@class='ne-title']//a[@href]", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> symuRead(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {

                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(67,17, "https://sumypost.com/wp-content/themes/pt-sumy/img/name_u.png");
                    string Link = "" + item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));

                    HtmlNode TitleNode = item;
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//img[@class='attachment-large size-large wp-post-image']");
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//div[@class='ne-categry ni-cat left']//span");
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//div[@class='ni-content clearfix']/p");

                    string img = "" + ImgNode.GetAttributeValue("src", "nothing");
                    string title = TitleNode.InnerText.ToString();
                    string date = DateNode.InnerText.ToString();
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
                      if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch {  return List; }
            return List;
        }
        /*
              ██████████████████                                                  
            ██                  ██                                                
          ██                      ██                                              
        ██                          ██      ████████      ██████▓▓██              
        ██  ░░██████████████          ██████        ██████          ████          
      ██    ██░░░░░░░░░░░░░░██                                          ██        
    ████  ██░░░░░░░░░░░░░░░░░░██    ██                                    ██      
  ██░░░░██░░░░░░██░░░░██░░░░░░██  ██░░██▒▒                                  ██    
    ██████░░░░░░██░░░░██░░░░░░██  ██░░░░▒▒██                                  ██  
        ██░░░░░░░░░░░░░░░░░░░░██    ████▓▓                                      ██
      ██  ░░░░░░░░░░░░░░░░░░░░██                                                ██
      ██░░░░░░░░░░░░░░░░░░░░░░██                                                ██
    ██░░░░░░░░░░░░░░░░░░░░░░██                                                  ██
    ██░░▓▓▓▓▓▓▓▓░░░░░░░░░░██                                                    ██
    ██░░░░▓▓▓▓░░░░░░░░░░██      ░░                              ░░              ██
      ██░░░░░░░░▒▒░░▒▒██░░░░  ░░    ░░  ░░░░      ░░        ░░  ░░              ██
      ██░░░░░░░░▒▒░░▒▒██  ░░  ░░        ░░    ░░░░░░  ░░        ░░░░            ██
        ██████████▓▓▓▓░░░░░░  ░░    ░░  ░░      ░░░░  ░░        ░░░░            ██
                  ██▓▓░░                                                        ██
                  ██▓▓░░                                                        ██
                      ██░░                                                    ░░██
                      ██░░                            ░░                    ░░██  
                    ░░██░░░░                                            ░░░░░░██  
                        ██░░░░░░░░░░░░░░░░░░    ░░░░░░░░░░░░        ░░░░██████    
                          ██░░██░░░░░░██▓▓░░░░░░██████████░░░░░░░░██████░░██      
                            ██▒▒██████░░▒▒██████          ██████▓▓██  ██░░██      
                            ██░░██  ██░░░░██                ██▒▒▒▒██  ██░░██      
                            ██░░██  ██░░▒▒██                ██░░▒▒██  ██░░██      
                            ██░░██  ██░░░░██                ██░░▒▒██  ██░░██      
                            ██░░██  ██░░░░██                ██░░▒▒██  ██░░██      
                            ██████  ████████                ████▓▓██  ██████      
                            ██▒▒██  ██▒▒▒▒██                ██▒▒▒▒██  ██▒▒██      
                                                                                  
                                                                                  
                    ░░░░  ░░    ░░░░▒▒░░░░░░    ░░  ░░░░░░░░░░░░                
         */
        public async static void chernihiv2()
        {
            string Name = "chernihiv2";
            List<Data> NEWS = chernihivRead("https://newch.tv/", "//div[@class='align-self-center']/a[@href]", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> chernihivRead(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {
                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(68,24, "https://newch.tv/wp-content/uploads/2019/12/cropped-logo_telekanal_1.png");
                    string Link = "" + item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));

                    HtmlNode TitleNode = item;
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//div[@class='entry-thumb']/img[@src]");
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//span[@class='posted-on']");
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//div[@class='entry-content clearfix']/p");

                    string img = "" + ImgNode.GetAttributeValue("src", "nothing");
                    string title = TitleNode.InnerText.ToString();
                    string date = DateNode.InnerText.ToString();
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
                    tmp.time = date;
                    tmp.info = info;
                      if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch {  return List; }
            return List;
        }
        public async static void vinnytsia2()//time
        {
            string Name = "vinnytsia2";
            List<Data> NEWS = vinnytsiaRead("https://tsn.ua/", "//a[@class='c-card__link']", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> vinnytsiaRead(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {
                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(69,1, "https://tsn.ua/static/pub/img/logo.svg?v=ca9");
                    string Link = "" + item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));

                    HtmlNode TitleNode = item;
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//img[@class='c-card__embed__img']");
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//time[@datetime]");
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//div[@data-content='']");
                    InfoNodes ??= News.DocumentNode.SelectNodes("//div[@class='c-article__lead']");
                    string img = ""; try { img = ImgNode.GetAttributeValue("src", "nothing"); } catch { continue; }
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
                      if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch{  return List; }
            return List;
        }
        public async static void kirovohradsk2()//time
        {
            string Name = "kirovohradsk2";
            List<Data> NEWS = kirovohradskRead("https://dozor.kr.ua/allnews", "//div[@class='link']/a[@href]", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> kirovohradskRead(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {
                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(70,10, "https://dozor.kr.ua/imgs/dozor_logo.png");
                    string Link = "" + item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));

                    HtmlNode TitleNode = item;
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//div[@class='  img-stretched']/img[@src]");
                    ImgNode ??= News.DocumentNode.SelectSingleNode("//div[@class='  ']/img[@src]");
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//div[@class='date']");
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//p[@class='paragraph justify']");
                    string img = "" + ImgNode.GetAttributeValue("src", "nothing");
                    string title = TitleNode.InnerText.ToString();
                    string date = DateNode.InnerText.ToString();
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
                    tmp.time = date;
                    tmp.info = info;
                    if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch {  return List; }
            return List;
        }
        public async static void poltava2()
        {
            string Name = "poltava2";
            List<Data> NEWS = poltavaRead("https://poltava.to/", "//span[@class='row']/a[@href]", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> poltavaRead(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {
                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(71,15, "https://i1.poltava.to/news/63/6275/photo.jpg");
                    string Link = "https://poltava.to" + item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));

                    HtmlNode TitleNode = item;
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//figure[@class='image']//div[@class='top-media-container']//img[@src]");
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//time[@datetime]");
                    HtmlNode InfoNodes = News.DocumentNode.SelectSingleNode("//div[@class='content-padding']");
                    if (ImgNode == null && DateNode == null && InfoNodes == null) { continue; }
                    ImgNode ??= News.DocumentNode.SelectSingleNode("//img[@src]");
                    if (ImgNode == null) { continue; }
                    string img = "https:" + ImgNode.GetAttributeValue("src", "nothing");
                    string title = TitleNode.InnerText.ToString();
                    string? date = DateNode.GetAttributeValue("datetime", "nothing");
                    string info = InfoNodes.InnerText.ToString();
                    tmp.link = Link;
                    tmp.title = title;
                    tmp.image = img;
                    tmp.time = date;
                    tmp.info = info;
                      if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch {  return List; }
            return List;
        }
        public async static void cherkassy2()
        {
            string Name = "cherkassy2";
            List<Data> NEWS = cherkassyRead("https://chesno.ck.ua/category/novyny/novini-regionu/", "//h3[@class='entry-title td-module-title']//a[@href]", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> cherkassyRead(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {
                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(49,22, "https://chesno.ck.ua/wp-content/uploads/2021/01/1-54.jpg");
                    string Link = "" + item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));

                    HtmlNode TitleNode = item;
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//div[@class='td-post-featured-image']/a[@href]");
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//time[@datetime]");
                    HtmlNode InfoNodes = News.DocumentNode.SelectSingleNode("//div[@class='td-post-content']/p");
                    ImgNode ??= News.DocumentNode.SelectSingleNode("//figure/a[@href]");
                    if (InfoNodes == null)
                    {
                        continue;
                    }
                    string img = "" + ImgNode.GetAttributeValue("href", "nothing");
                    string title = TitleNode.InnerText.ToString();
                    string date = DateNode.GetAttributeValue("datetime", "nothing");
                    string info = InfoNodes.InnerText.ToString();
                    tmp.link = Link;
                    tmp.title = title;
                    tmp.image = img;
                    tmp.time = date;
                    tmp.info = info;
                      if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch {  return List; }
            return List;
        }
        public async static void kryvyi_rih2()
        {
            string Name = "kryvyi_rih2";
            List<Data> NEWS = kryvyi_rihRead("https://www.0564.ua/news", "//a[@class='c-news-block__title']", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> kryvyi_rihRead(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {
                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(50,3, "https://s.0564.ua/section/logo/upload/pers/12/logo.png");
                    string Link = "" + item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));

                    HtmlNode TitleNode = item;
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//div[@class='article-details__date']");
                    HtmlNode InfoNodes = News.DocumentNode.SelectSingleNode("//app-model-content");

                    string img = "https://s.0564.ua/section/logo/upload/pers/12/logo.png";
                    string title = TitleNode.InnerText.ToString();
                    string[] dateArray = DateNode.InnerText.ToString().Split(",");
                    string date = dateArray[1] + " " + dateArray[0];
                    string info = InfoNodes.InnerText.ToString();
                    tmp.link = Link;
                    tmp.title = title;
                    tmp.image = img;
                    tmp.time = date;
                    tmp.info = info;
                      if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch {  return List; }
            return List;
        }
        public async static void zaporizhzhia2()
        {
            string Name = "zaporizhzhia2";
            List<Data> NEWS = zaporizhzhiaRead("https://www.061.ua/news", "//a[@class='c-news-block__title']", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> zaporizhzhiaRead(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {
                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(51,7, "https://s.061.ua/section/logo/upload/pers/3/logo.png");
                    string Link = "" + item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));

                    HtmlNode TitleNode = item;
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//div[@class='article-details__poster-container']//img[@src]");
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//div[@class='article-details__date']");
                    HtmlNode InfoNodes = News.DocumentNode.SelectSingleNode("//app-model-content");

                    string img = "https://s.061.ua/section/logo/upload/pers/3/logo.png";
                    string title = TitleNode.InnerText.ToString();
                    string[] dateArray = DateNode.InnerText.ToString().Split(",");
                    string date = dateArray[1] + " " + dateArray[0];
                    string info = InfoNodes.InnerText.ToString();
                    tmp.link = Link;
                    tmp.title = title;
                    tmp.image = img;
                    tmp.time = date;
                    tmp.info = info;
                      if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch {  return List; }
            return List;
        }
        public async static void kherson2()
        {
            string Name = "kherson2";
            List<Data> NEWS = khersonRead("https://www.ukrinform.ua/tag-hersonsina", "//section//h2//a[@href]", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> khersonRead(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {
                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(52,20, "https://www.ukrinform.ua/img/logo_ukr.svg");
                    string Link = "https://www.ukrinform.ua" + item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));

                    HtmlNode TitleNode = item;
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//img[@class='newsImage']");
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//time[@datetime]");
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//div[@class='newsText']//div");

                    string img = ImgNode.GetAttributeValue("src", "nothing");
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
                      if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch {  return List; }
            return List;
        }
        public async static void odesa2()
        {
            string Name = "odesa2";
            List<Data> NEWS = odesaRead("https://www.unn.com.ua/uk/news/tag/odesa", "//div[@class='b-news-title']/h3/a[@href]", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> odesaRead(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {
                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(53,14, "https://www.unn.com.ua/images/unn.svg?v=3");
                    string Link = "https://www.unn.com.ua" + item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));

                    HtmlNode TitleNode = item;
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//div[@class='b-news-full-img']//img[@src]");
                    ImgNode ??= News.DocumentNode.SelectSingleNode("//div[@class='b-news-full-img gallery']/img[@src]");
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//span[@content]");
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//div[@class='b-news-text b-static-text']/p");

                    string img = "";
                    if (ImgNode == null) { img = "https://www.unn.com.ua/images/unn.svg?v=3"; }
                    else
                    {
                      img = "https://www.unn.com.ua" + ImgNode.GetAttributeValue("src", "nothing");
                    }
                    string title = TitleNode.InnerText.ToString();
                    string date = DateNode.GetAttributeValue("content", "nothing");
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
                      if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch {  return List; }
            return List;
        }

        public async static void mykolayiv2()
        {
            string Name = "mykolayiv2";
            List<Data> NEWS = mykolayivRead("https://lb.ua/tag/44_mikolaiv", "//div[@class='title']/a[@href]", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> mykolayivRead(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {
                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(54,13, "https://i.lb.ua/static/logo.480.jpg");
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
                      if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch {  return List; }
            return List;
        }
        public async static void kharkiv2()
        {
            string Name = "kharkiv2";
            List<Data> NEWS = kharkivRead("https://www.newsroom.kh.ua/ua", "//div[@class='post-title mb-10 text-limit-2-row']/a[@href]", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> kharkivRead(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {
                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(55,19, "https://www.newsroom.kh.ua/wp-content/uploads/logo.png.webp");
                    string Link = "" + item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));

                    HtmlNode TitleNode = item;
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//figure[@class='single-thumnail mb-30']/img[@src]");
                    if (ImgNode == null) { continue; }
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//div[@class='entry-main-content']/p");

                    string img = "" + ImgNode.GetAttributeValue("src", "nothing");
                    string title = TitleNode.InnerText.ToString();
                    string date = DateTime.Now.ToString("MM.dd.yyy HH:mm");

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
                      if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch {  return List; }
            return List;
        }

        public async static void dnipropetrovsk2()
        {
            string Name = "dnipropetrovsk2";
            List<Data> NEWS = dnipropetrovskRead("https://www.dniprotoday.com/dnipro", "//p[@class='p-b-5 right-news pl-0 pl-sm-10']/a[@href]", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> dnipropetrovskRead(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {
                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(56,3, "https://www.dniprotoday.com/xlogo2.png,qver=1.pagespeed.ic.WoXxvJEz30.webp");
                    string Link = "" + item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));

                    HtmlNode TitleNode = item;
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//time[@datetime]");
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//div[@class='e-content']");
                    string img = "https://www.dniprotoday.com/xlogo2.png,qver=1.pagespeed.ic.WoXxvJEz30.webp";
                    string title = TitleNode.InnerText.ToString();
                    string date = DateNode.GetAttributeValue("datetime", "nothing");
                    string info = "";
                    if (InfoNodes == null) { continue; }
                    foreach (var inf in InfoNodes)
                    {
                        info += inf.InnerText.ToString();
                    }
                    tmp.link = Link;
                    tmp.title = title;
                    tmp.image = img;
                    tmp.time = date;
                    tmp.info = info;
                      if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch {  return List; }
            return List;
        }
        public async static void luhansk2()
        {
            string Name = "luhansk2";
            List<Data> NEWS = luhanskRead("https://censor.net/ua/news/all", "//h2/a[@href]", Name);
            if (NEWS != null)
                foreach (var item in NEWS)
                {
                    await DB.DATABASE_INSERT( item);
                }
            
        }
        private static List<Data> luhanskRead(string url, string node, string name)
        {
            List<Data> List = new();
            try
            {
                HtmlDocument document = new();
                document.LoadHtml(GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
                foreach (var item in Nodes)
                {
                    Data tmp = new(57,11, "https://static.censor.net/censornet/images/logo/uk/logo.svg");
                    string Link = "" + item.GetAttributeValue("href", "nothing");

                    HtmlDocument News = new();
                    News.LoadHtml(GetHtml(Link));
                    string wt = "href";

                    HtmlNode TitleNode = item;
                    HtmlNode ImgNode = News.DocumentNode.SelectSingleNode("//figure[@class='news-text__main_img']/a[@href]");
                    ImgNode ??= News.DocumentNode.SelectSingleNode("//a[@class='top_img_loader']");
                    if (ImgNode == null)
                    {
                        ImgNode = News.DocumentNode.SelectSingleNode("//video[@poster]");
                        wt = "poster";
                    }
                    HtmlNode DateNode = News.DocumentNode.SelectSingleNode("//time[@datetime]");
                    HtmlNodeCollection InfoNodes = News.DocumentNode.SelectNodes("//div[@class='news-text']/p");
                    string img = "";
                    try
                    { 
                        img = ImgNode.GetAttributeValue(wt, "nothing");
                    }
                    catch { img= "https://static.censor.net/censornet/images/logo/uk/logo.svg"; }
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
                      if (DB.DATABASE_CHECK(tmp)){return List;} List.Add(tmp);
                }
            }
            catch {  return List; }
            return List;
        }

    }

}


