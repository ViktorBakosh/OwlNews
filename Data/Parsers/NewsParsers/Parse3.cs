using HtmlAgilityPack;

namespace Parser_2022_
{
    internal class Parse3
    {


        /*
  _=====_                               _=====_
 / _____ \                             / _____ \
+.-'_____'-.---------------------------.-'_____'-.+
/   |     |  '.        S O N Y        .'  |  _  |   \
/ ___| /|\ |___ \                     / ___| /_\ |___ \
/ |      |      | ;  __           _   ; | _         _ | ;
| | <---   ---> | | |__|         |_:> | ||_|       (_)| |
| |___   |   ___| ;SELECT       START ; |___       ___| ;
|\    | \|/ |    /  _     ___      _   \    | (X) |    /|
| \   |_____|  .','" "', |___|  ,'" "', '.  |_____|  .' |
|  '-.______.-' /       \ANALOG/       \  '-._____.-'   |
|               |       |------|       |                |
|              /\       /      \       /\               |
|             /  '.___.'        '.___.'  \              |
|            /                            \             |
\          /                              \           /
\________/                                \_________/

 */
        /*

            Lviv done
            Ternopil done
            Ivano-Frankivsk done
            Volyn done
            Rivne done
            Khmelnytskyi done

            Chernivtsi done
            Zakarpattia done
            Zhytomyr done
            Kyiv done
            Sumy done
            Chernihiv done

            Vinnytsia done
            Kirovohradsk done
            Poltava done
            Cherkassy done
            Kryvyi Rih      https://tsn.ua/tags/%D0%BD%D0%BE%D0%B2%D0%B8%D0%BD%D0%B8%20%D0%9A%D1%80%D0%B8%D0%B2%D0%BE%D0%B3%D0%BE%20%D0%A0%D0%BE%D0%B3%D1%83
            Zaporizhzhia    https://tsn.ua/tags/%D0%BD%D0%BE%D0%B2%D0%B8%D0%BD%D0%B8%20%D0%B7%D0%B0%D0%BF%D0%BE%D1%80%D1%96%D0%B6%D0%B6%D1%8F

            Kherson https://tsn.ua/tags/%D0%A5%D0%B5%D1%80%D1%81%D0%BE%D0%BD
            Odesa   https://tsn.ua/tags/%D0%BD%D0%BE%D0%B2%D0%B8%D0%BD%D0%B8%20%D0%BE%D0%B4%D0%B5%D1%81%D0%B0
            Mykolayiv   https://tsn.ua/tags/%D0%BD%D0%BE%D0%B2%D0%B8%D0%BD%D0%B8%20%D0%9C%D0%B8%D0%BA%D0%BE%D0%BB%D0%B0%D1%94%D0%B2%D0%B0
            Kharkiv     https://tsn.ua/tags/%D1%85%D0%B0%D1%80%D0%BA%D1%96%D0%B2
            Dnipropetrovsk     https://tsn.ua/tags/%D0%BD%D0%BE%D0%B2%D0%B8%D0%BD%D0%B8%20%D0%94%D0%BD%D1%96%D0%BF%D1%80%D0%B0
            Luhansk     https://tsn.ua/tags/%D0%BB%D1%83%D0%B3%D0%B0%D0%BD%D1%81%D1%8C%D0%BA
         */
        private static string GetHtml(string url)
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
        private static HtmlNodeCollection Default_News(string url, string node)
        {
            HtmlDocument document = new();
            document.LoadHtml(GetHtml(url));
            HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes(node);
            return Nodes;
        }
        private static string Get_smthng_attribute(HtmlDocument document, string node,string exp, string attribute)
        {
            try
            {

                var Node = document.DocumentNode.SelectSingleNode(node);
                return Node.GetAttributeValue(attribute, exp);
            }
            catch { return ""; }
        }
        private static string Get_smthng_Inner(HtmlDocument document, string node)
        {
            try
            {
                var Node = document.DocumentNode.SelectSingleNode(node);
                return Node.InnerText;
            }
            catch { return ""; }
        }
        private async static void Default_Insert(List<Data> list, string Name)
        {
            if (list != null)
                foreach (var item in list)
                {
                    await DB.DATABASE_INSERT( item);
                }
        }

        public static void lviv()
        {
            List<Data> list = new();
            string name = "lviv3";

            try
            {
                string url = "https://lviv.tsn.ua/";
                var Nodes = Default_News(url, "//a[@class='c-card__link']");
                foreach (var item in Nodes)
                {
                    Data tmp = new(25,12, "https://tsn.ua/static/pub/img/logo.svg?v=ca9");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = item.InnerText;
                    var info = Get_smthng_Inner(document, "//div[@class='c-article__body']");
                    var image = Get_smthng_attribute(document, "//img[@class='c-card__embed__img']", "https://tsn.ua/static/pub/img/logo-sm.svg?v=ca9", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]","", "datetime");

                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }

        public static void ternopil()
        {
            List<Data> list = new();
            string name = "ternopil3";

            try
            {
                string url = "https://terminovo.te.ua/";
                var Nodes = Default_News(url, "//h3[@class='penci__post-title entry-title']/a[@href]");
                foreach (var item in Nodes)
                {
                    Data tmp = new(26,18, "https://terminovo.te.ua/wp-content/uploads/2017/11/logo_2.png");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = item.InnerText;
                    var info = Get_smthng_Inner(document, "//div[@class='penci-entry-content entry-content']");
                    var image = Get_smthng_attribute(document, "//img[@class='attachment-penci-thumb-960-auto size-penci-thumb-960-auto wp-post-image']", "https://terminovo.te.ua/wp-content/uploads/2017/11/logo_2.png", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]","", "datetime");
                    List<string> DateSplit = time.Split(".").ToList();
                    time = DateSplit[1] + "." + DateSplit[0] + "." + DateSplit[2];


                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }

        public static void ivano_frankivsk()
        {
            List<Data> list = new();
            string name = "ivano_frankivsk3";

            try
            {
                string url = "https://zaxid.net/novini_ivanofrankivska_tag51205/";
                var Nodes = Default_News(url, "//div[@class='news-list archive-list  ']/ul[@class='list']/li/a[@href]");
                foreach (var item in Nodes)
                {
                    Data tmp = new(27,8, "https://upload.wikimedia.org/wikipedia/commons/8/8f/24_Group_Ukraine_03.png");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = Get_smthng_Inner(document, "//h1[@class='title']");
                    var info = Get_smthng_Inner(document, "//div[@id='newsSummary']");
                    var image = Get_smthng_attribute(document, "//span[@class='lazyload-holder']/img", "https://detector.media/doc/images/news/archive/2016/174831/ArticleImage_174831.jpg", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]","", "datetime");

                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }

        public static void volyn()
        {
            List<Data> list = new();
            string name = "volyn3";

            try
            {
                string url = "https://zaxid.net/novini_volini_tag51198/";
                var Nodes = Default_News(url, "//div[@class='news-list archive-list  ']/ul[@class='list']/li/a[@href]");
                foreach (var item in Nodes)
                {
                    Data tmp = new(28,2, "https://upload.wikimedia.org/wikipedia/commons/8/8f/24_Group_Ukraine_03.png");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = Get_smthng_Inner(document, "//h1[@class='title']");
                    var info = Get_smthng_Inner(document, "//div[@id='newsSummary']");
                    var image = Get_smthng_attribute(document, "//span[@class='lazyload-holder']/img", "https://detector.media/doc/images/news/archive/2016/174831/ArticleImage_174831.jpg", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]","", "datetime");

                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }

        public static void rivne()
        {
            List<Data> list = new();
            string name = "rivne3";

            try
            {
                string url = "https://zaxid.net/novini_rivnogo_tag51450/";
                var Nodes = Default_News(url, "//div[@class='news-list archive-list  ']/ul[@class='list']/li/a[@href]");
                foreach (var item in Nodes)
                {
                    Data tmp = new(29,16, "https://upload.wikimedia.org/wikipedia/commons/8/8f/24_Group_Ukraine_03.png");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = Get_smthng_Inner(document, "//h1[@class='title']");
                    var info = Get_smthng_Inner(document, "//div[@id='newsSummary']");
                    var image = Get_smthng_attribute(document, "//span[@class='lazyload-holder']/img", "https://detector.media/doc/images/news/archive/2016/174831/ArticleImage_174831.jpg", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]", "", "datetime");

                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }

        public static void khmelnytskyi()
        {
            List<Data> list = new();
            string name = "khmelnytskyi3";

            try
            {
                string url = "https://zaxid.net/novini_khmelnytskoho_tag53143/";
                var Nodes = Default_News(url, "//div[@class='news-list archive-list  ']/ul[@class='list']/li/a[@href]");
                foreach (var item in Nodes)
                {
                    Data tmp = new(30,21, "https://upload.wikimedia.org/wikipedia/commons/8/8f/24_Group_Ukraine_03.png");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = Get_smthng_Inner(document, "//h1[@class='title']");
                    var info = Get_smthng_Inner(document, "//div[@id='newsSummary']");
                    var image = Get_smthng_attribute(document, "//span[@class='lazyload-holder']/img", "https://detector.media/doc/images/news/archive/2016/174831/ArticleImage_174831.jpg", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]", "", "datetime");

                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }

        public static void chernivtsi()
        {
            List<Data> list = new();
            string name = "Chernivtsi3";

            try
            {
                string url = "https://tsn.ua/tags/%D0%A7%D0%B5%D1%80%D0%BD%D1%96%D0%B2%D1%86%D1%96";
                var Nodes = Default_News(url, "//h3[@class='c-card__title  ']/a[@href]");
                foreach (var item in Nodes)
                {
                    Data tmp = new(31,23, "https://tsn.ua/static/pub/img/logo.svg?v=ca9");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = item.InnerText;
                    var info = Get_smthng_Inner(document, "//div[@class='c-article__body']");
                    var image = Get_smthng_attribute(document, "//img[@class='c-card__embed__img']", "https://tsn.ua/static/pub/img/logo-sm.svg?v=ca9", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]", "", "datetime");

                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }

        public static void zakarpattia()
        {
            List<Data> list = new();
            string name = "zakarpattia3";

            try
            {
                string url = "https://zaxid.net/novini_zakarpattya_tag51212/";
                var Nodes = Default_News(url, "//div[@class='news-list archive-list  ']/ul[@class='list']/li/a[@href]");
                foreach (var item in Nodes)
                {
                    Data tmp = new(32,6, "https://upload.wikimedia.org/wikipedia/commons/8/8f/24_Group_Ukraine_03.png");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = Get_smthng_Inner(document, "//h1[@class='title']");
                    var info = Get_smthng_Inner(document, "//div[@id='newsSummary']");
                    var image = Get_smthng_attribute(document, "//span[@class='lazyload-holder']/img", "https://detector.media/doc/images/news/archive/2016/174831/ArticleImage_174831.jpg", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]", "", "datetime");

                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }

        public static void zhytomyr()
        {
            List<Data> list = new();
            string name = "zhytomyr3";

            try
            {
                string url = "https://zaxid.net/zhitomir_tag54216/";
                var Nodes = Default_News(url, "//div[@class='news-list archive-list no-popular ']/ul[@class='list']/li/a[@href]");
                foreach (var item in Nodes)
                {
                    Data tmp = new(33,5, "https://upload.wikimedia.org/wikipedia/commons/8/8f/24_Group_Ukraine_03.png");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = Get_smthng_Inner(document, "//h1[@class='title']");
                    var info = Get_smthng_Inner(document, "//div[@id='newsSummary']");
                    var image = Get_smthng_attribute(document, "//span[@class='lazyload-holder']/img", "https://detector.media/doc/images/news/archive/2016/174831/ArticleImage_174831.jpg", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]", "", "datetime");

                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }

        public static void kyiv()
        {
            List<Data> list = new();
            string name = "kyiv3";

            try
            { 
                string url = "https://kyiv.tsn.ua/";
                var Nodes = Default_News(url, "//a[@class='c-card__link']");
                foreach (var item in Nodes)
                {
                    Data tmp = new(34 , 9 , "https://tsn.ua/static/pub/img/logo.svg?v=ca9");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = item.InnerText;
                    var info = Get_smthng_Inner(document, "//div[@class='c-article__body']");
                    var image = Get_smthng_attribute(document, "//img[@class='c-card__embed__img']", "https://tsn.ua/static/pub/img/logo-sm.svg?v=ca9", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]", "", "datetime");

                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }
        public static void sumy()
        {
            List<Data> list = new();
            string name = "sumy3";

            try
            {
                string url = "https://tsn.ua/tags/%D0%A1%D1%83%D0%BC%D0%B8";
                var Nodes = Default_News(url, "//a[@class='c-card__link']");
                foreach (var item in Nodes)
                {
                    Data tmp = new(35,17, "https://tsn.ua/static/pub/img/logo.svg?v=ca9");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = item.InnerText;
                    var info = Get_smthng_Inner(document, "//div[@class='c-article__body']");
                    var image = Get_smthng_attribute(document, "//img[@class='c-card__embed__img']", "https://tsn.ua/static/pub/img/logo-sm.svg?v=ca9", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]", "", "datetime");

                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }

        public static void сhernihiv()
        {
            List<Data> list = new();
            string name = "сhernihiv3";

            try
            {
                string url = "https://tsn.ua/tags/%D1%87%D0%B5%D1%80%D0%BD%D1%96%D0%B3%D1%96%D0%B2";
                var Nodes = Default_News(url, "//a[@class='c-card__link']");
                foreach (var item in Nodes)
                {
                    Data tmp = new(36,24, "https://tsn.ua/static/pub/img/logo.svg?v=ca9");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = item.InnerText;
                    var info = Get_smthng_Inner(document, "//div[@class='c-article__body']");
                    var image = Get_smthng_attribute(document, "//img[@class='c-card__embed__img']", "https://tsn.ua/static/pub/img/logo-sm.svg?v=ca9", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]", "", "datetime");

                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }

        public static void vinnytsia()
        {
            List<Data> list = new();
            string name = "vinnytsia3";

            try
            {
                string url = "https://zaxid.net/vinnitsya_tag52640/";
                var Nodes = Default_News(url, "//div[@class='news-list archive-list no-popular ']/ul[@class='list']/li/a[@href]");
                foreach (var item in Nodes)
                {
                    Data tmp = new(37,1, "https://upload.wikimedia.org/wikipedia/commons/8/8f/24_Group_Ukraine_03.png");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = Get_smthng_Inner(document, "//h1[@class='title']");
                    var info = Get_smthng_Inner(document, "//div[@id='newsSummary']");
                    var image = Get_smthng_attribute(document, "//span[@class='lazyload-holder']/img", "https://detector.media/doc/images/news/archive/2016/174831/ArticleImage_174831.jpg", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]", "", "datetime");

                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }

        public static void kirovohradsk()
        {
            List<Data> list = new();
            string name = "kirovohradsk3";

            try
            {
                string url = "https://tsn.ua/tags/%D0%BA%D1%96%D1%80%D0%BE%D0%B2%D0%BE%D0%B3%D1%80%D0%B0%D0%B4%D1%89%D0%B8%D0%BD%D0%B0";
                var Nodes = Default_News(url, "//a[@class='c-card__link']");
                foreach (var item in Nodes)
                {
                    Data tmp = new(38,10, "https://tsn.ua/static/pub/img/logo.svg?v=ca9");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = item.InnerText;
                    var info = Get_smthng_Inner(document, "//div[@class='c-article__body']");
                    var image = Get_smthng_attribute(document, "//img[@class='c-card__embed__img']", "https://tsn.ua/static/pub/img/logo-sm.svg?v=ca9", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]", "", "datetime");

                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }

        public static void poltava()
        {
            List<Data> list = new();
            string name = "poltava3";

            try
            {
                string url = "https://tsn.ua/tags/%D0%BF%D0%BE%D0%BB%D1%82%D0%B0%D0%B2%D0%B0";
                var Nodes = Default_News(url, "//a[@class='c-card__link']");
                foreach (var item in Nodes)
                {
                    Data tmp = new(39,15, "https://tsn.ua/static/pub/img/logo.svg?v=ca9");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = item.InnerText;
                    var info = Get_smthng_Inner(document, "//div[@class='c-article__body']");
                    var image = Get_smthng_attribute(document, "//img[@class='c-card__embed__img']", "https://tsn.ua/static/pub/img/logo-sm.svg?v=ca9", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]", "", "datetime");

                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }

        public static void cherkassy()
        {
            List<Data> list = new();
            string name = "cherkassy3";

            try
            {
                string url = "https://tsn.ua/tags/%D0%A7%D0%B5%D1%80%D0%BA%D0%B0%D1%81%D0%B8";
                var Nodes = Default_News(url, "//a[@class='c-card__link']");
                foreach (var item in Nodes)
                {
                    Data tmp = new(40,22, "https://tsn.ua/static/pub/img/logo.svg?v=ca9");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = item.InnerText;
                    var info = Get_smthng_Inner(document, "//div[@class='c-article__body']");
                    var image = Get_smthng_attribute(document, "//img[@class='c-card__embed__img']", "https://tsn.ua/static/pub/img/logo-sm.svg?v=ca9", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]", "", "datetime");

                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }

        public static void kryvyi_rih()
        {
            List<Data> list = new();
            string name = "kryvyi_rih3";

            try
            {
                string url = "https://tsn.ua/tags/%D0%BD%D0%BE%D0%B2%D0%B8%D0%BD%D0%B8%20%D0%9A%D1%80%D0%B8%D0%B2%D0%BE%D0%B3%D0%BE%20%D0%A0%D0%BE%D0%B3%D1%83";
                var Nodes = Default_News(url, "//a[@class='c-card__link']");
                foreach (var item in Nodes)
                {
                    Data tmp = new(41,3, "https://tsn.ua/static/pub/img/logo.svg?v=ca9");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = item.InnerText;
                    var info = Get_smthng_Inner(document, "//div[@class='c-article__body']");
                    var image = Get_smthng_attribute(document, "//img[@class='c-card__embed__img']", "https://tsn.ua/static/pub/img/logo-sm.svg?v=ca9", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]", "", "datetime");

                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }
        public static void Kherson()
        {
            List<Data> list = new();
            string name = "Kherson3";

            try
            {
                string url = "https://tsn.ua/tags/%D0%A5%D0%B5%D1%80%D1%81%D0%BE%D0%BD";
                var Nodes = Default_News(url, "//a[@class='c-card__link']");
                foreach (var item in Nodes)
                {
                    Data tmp = new(42,20, "https://tsn.ua/static/pub/img/logo.svg?v=ca9");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = item.InnerText;
                    var info = Get_smthng_Inner(document, "//div[@class='c-article__body']");
                    var image = Get_smthng_attribute(document, "//img[@class='c-card__embed__img']", "https://tsn.ua/static/pub/img/logo-sm.svg?v=ca9", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]", "", "datetime");

                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }
        public static void zaporizhzhia()
        {
            List<Data> list = new();
            string name = "zaporizhzhia3";

            try
            {
                string url = "https://tsn.ua/tags/%D0%BD%D0%BE%D0%B2%D0%B8%D0%BD%D0%B8%20%D0%B7%D0%B0%D0%BF%D0%BE%D1%80%D1%96%D0%B6%D0%B6%D1%8F";
                var Nodes = Default_News(url, "//a[@class='c-card__link']");
                foreach (var item in Nodes)
                {
                    Data tmp = new(43,7, "https://tsn.ua/static/pub/img/logo.svg?v=ca9");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = item.InnerText;
                    var info = Get_smthng_Inner(document, "//div[@class='c-article__body']");
                    var image = Get_smthng_attribute(document, "//img[@class='c-card__embed__img']", "https://tsn.ua/static/pub/img/logo-sm.svg?v=ca9", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]", "", "datetime");

                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }

        public static void odesa()
        {
            List<Data> list = new();
            string name = "odesa3";

            try
            {
                string url = "https://tsn.ua/tags/%D0%BD%D0%BE%D0%B2%D0%B8%D0%BD%D0%B8%20%D0%BE%D0%B4%D0%B5%D1%81%D0%B0";
                var Nodes = Default_News(url, "//a[@class='c-card__link']");
                foreach (var item in Nodes)
                {
                    Data tmp = new(44,14, "https://tsn.ua/static/pub/img/logo.svg?v=ca9");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = item.InnerText;
                    var info = Get_smthng_Inner(document, "//div[@class='c-article__body']");
                    var image = Get_smthng_attribute(document, "//img[@class='c-card__embed__img']", "https://tsn.ua/static/pub/img/logo-sm.svg?v=ca9", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]", "", "datetime");

                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }
        public static void mykolayiv()
        {
            List<Data> list = new();
            string name = "mykolayiv3";

            try
            {
                string url = "https://tsn.ua/tags/%D0%BD%D0%BE%D0%B2%D0%B8%D0%BD%D0%B8%20%D0%9C%D0%B8%D0%BA%D0%BE%D0%BB%D0%B0%D1%94%D0%B2%D0%B0";
                var Nodes = Default_News(url, "//a[@class='c-card__link']");
                foreach (var item in Nodes)
                {
                    Data tmp = new(45,13, "https://tsn.ua/static/pub/img/logo.svg?v=ca9");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = item.InnerText;
                    var info = Get_smthng_Inner(document, "//div[@class='c-article__body']");
                    var image = Get_smthng_attribute(document, "//img[@class='c-card__embed__img']", "https://tsn.ua/static/pub/img/logo-sm.svg?v=ca9", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]", "", "datetime");

                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }
        public static void kharkiv()
        {
            List<Data> list = new();
            string name = "kharkiv3";

            try
            {
                string url = "https://tsn.ua/tags/%D1%85%D0%B0%D1%80%D0%BA%D1%96%D0%B2";
                var Nodes = Default_News(url, "//a[@class='c-card__link']");
                foreach (var item in Nodes)
                {
                    Data tmp = new(46,19, "https://tsn.ua/static/pub/img/logo.svg?v=ca9");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = item.InnerText;
                    var info = Get_smthng_Inner(document, "//div[@class='c-article__body']");
                    var image = Get_smthng_attribute(document, "//img[@class='c-card__embed__img']", "https://tsn.ua/static/pub/img/logo-sm.svg?v=ca9", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]", "", "datetime");

                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }
        public static void dnipropetrovsk()
        {
            List<Data> list = new();
            string name = "dnipropetrovsk3";

            try
            {
                string url = "https://tsn.ua/tags/%D0%BD%D0%BE%D0%B2%D0%B8%D0%BD%D0%B8%20%D0%94%D0%BD%D1%96%D0%BF%D1%80%D0%B0";
                var Nodes = Default_News(url, "//a[@class='c-card__link']");
                foreach (var item in Nodes)
                {
                    Data tmp = new(47,3, "https://tsn.ua/static/pub/img/logo.svg?v=ca9");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = item.InnerText;
                    var info = Get_smthng_Inner(document, "//div[@class='c-article__body']");
                    var image = Get_smthng_attribute(document, "//img[@class='c-card__embed__img']", "https://tsn.ua/static/pub/img/logo-sm.svg?v=ca9", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]", "", "datetime");

                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }
        public static void luhansk()
        {
            List<Data> list = new();
            string name = "luhansk3";

            try
            {
                string url = "https://tsn.ua/tags/%D0%BB%D1%83%D0%B3%D0%B0%D0%BD%D1%81%D1%8C%D0%BA";
                var Nodes = Default_News(url, "//a[@class='c-card__link']");
                foreach (var item in Nodes)
                {
                    Data tmp = new(48,11, "https://tsn.ua/static/pub/img/logo.svg?v=ca9");
                    HtmlDocument document = new();

                    var link = "" + item.Attributes["href"].Value;

                    document.LoadHtml(GetHtml(link));

                    var title = item.InnerText;
                    var info = Get_smthng_Inner(document, "//div[@class='c-article__body']");
                    var image = Get_smthng_attribute(document, "//img[@class='c-card__embed__img']", "https://tsn.ua/static/pub/img/logo-sm.svg?v=ca9", "src");
                    var time = Get_smthng_attribute(document, "//time[@datetime]", "", "datetime");

                    tmp.title = title;
                    tmp.info = info;
                    tmp.image = image;
                    tmp.link = link;
                    tmp.time = time;
                    if (DB.DATABASE_CHECK(tmp))
                    {
                        break;
                    }
                    list.Add(tmp);
                }
            }
            catch
            {
                Default_Insert(list, name);
                return;
            }
            Default_Insert(list, name);
        }











    }


}









