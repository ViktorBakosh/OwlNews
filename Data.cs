using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Parser_2022_
{
    internal class Data
    {
        public Data() 
        {
            Title = "";
            Image = "";
            Link = "";
            Time = "";
            Info = "";
        }

        public string title { get { return Title; } set {Title= System.Net.WebUtility.HtmlDecode(value).Replace("\r", "").Replace("\n\n", "").Replace("\t", "");} }
        public string image { get { return Image; } set { Image = value.Replace("\r", "").Replace("\n", "").Replace("\t", "");  } }
        public string link  { get { return Link; } set { Link = value.Replace("\r", "").Replace("\n", "").Replace("\t", ""); ; } }
        public string time  { get { return Time; } set { Time = DateFormat(value.Replace("\r", "").Replace("\n", "").Replace("\t", ""));} }
        public string info  { get { return Info; }   set { Info = System.Net.WebUtility.HtmlDecode(value).Replace("\r","").Replace("\n\n","").Replace("\t",""); } }

        private string Title;
        private string Image;
        private string Link;
        private string Time;
        private string Info;

        public override string ToString()
        {
            return $"{link}\n{title}\n{image}\n{time}\n{info}";
        }
        private string DateFormat(string value)
        {
            //if (value.Contains("Сь")||value.Contains("сь")) {
            //    if (value.Any(char.IsDigit)){ }//!!!!!!!!!!!!!!!!!!!!!!!!!!!!Recode
            //    else { return DateTime.Now.ToString("d.MM.yyy T"); }
            //}else if (value.Contains("Вч")||value.Contains("вч")) {
            //    if (value.Any(char.IsDigit)){ }
            //    else { return DateTime.Now.AddDays(-1).ToString("d.MM.yyy T");}
            //}else { 
            //    DateTime dateTime=new();
            //   if( DateTime.TryParse(value, out dateTime))
            //    {return }

            //}
            return value;
        }
    }
}
