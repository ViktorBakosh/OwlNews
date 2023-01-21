using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Parser_2022_
{
    internal class Dead_r
    {
        public static string statistics()//Стата по русні
        {
            string res="";
            try
            {
                string url= "https://zaxid.net/vtrati_rosiyan_u_viyni_proti_ukrayini_n1537635";
                HtmlDocument document = new();
                document.LoadHtml(Parse2.GetHtml(url));
                HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes("//div[@id='newsSummary']/ul/li");
                foreach (var item in Nodes)
                {
                    res += item.InnerText;
                }
            }
            catch{ return res; }
            return res;
        }
    }
}
