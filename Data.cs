using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
        public string time  { get { return Time; } set { Time = DateFormat(value.Replace("\r", "").Replace("\n", "").Replace("\t", ""));Console.WriteLine(Time);} }
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

        //Крінж(в процесі)
        private string DateFormat(string value)
        {
            try
            {
                DateTime DT = DateTime.Now;

                if (value.Contains("Сь") || value.Contains("сь"))
                {
                    if (value.Any(char.IsDigit))
                    {
                        string Array = Regex.Replace(value, "[^0-9]", "");
                        return DateTime.Now.ToString($"d.MM.yyy {Array.Substring(0, 2)}:{Array.Substring(2, 2)}");
                    }
                    else
                    {
                        return DateTime.Now.ToString("d.MM.yyy T");
                    }
                }
                else if (value.Contains("Вч") || value.Contains("вч"))
                {
                    if (value.Any(char.IsDigit)) {
                        string Array = Regex.Replace(value, "[^0-9]", "");
                        return DateTime.Now.AddDays(-1).ToString($"d.MM.yyy {Array.Substring(0, 2)}:{Array.Substring(2, 2)}");
                    }
                    else { return DateTime.Now.AddDays(-1).ToString($"d.MM.yyy {DT.Hour}:{DT.Minute}") ; }
                }
                else
                {
                    DateTime dateTime = new();
                    if (DateTime.TryParse(value.Replace(".", "/"), out dateTime))
                    { return dateTime.ToString($"d.MM.yyy {DT.Hour.ToString()}:{DT.Minute.ToString()}"); }
                    else {
                        string Month_res=Months(value);
                        
                        if (!string.IsNullOrEmpty(Month_res)) { return Month_res; }
                        string UTC_res = UTC(value);
                        if (!string.IsNullOrEmpty(UTC_res)) { return UTC_res; }
                        if (!value.Contains(":")) { return value + $" {DT.Hour}:{DT.Minute}"; }

                        return value ; 
                    }

                }
            }
            catch { return value; }
        }
        private string? Months(string date)
        {
            string day, month, year, hour, minute;
            DateTime DT = DateTime.Now;

            switch (date) 
            {
                case var tmp when date.Contains("Січ")||date.Contains("січ"):
                    month = "01";
                    date = Regex.Replace(date, "[^0-9.]", "");

                    day = date.Substring(0, 2);
                    year = DT.Year.ToString();
                    if (date.Length > 6){
                        hour = date.Substring(6, 2);
                        minute= date.Substring(8, date.Length-8);
                    }
                    else
                    {
                        hour = DT.Hour.ToString();
                        minute = DT.Minute.ToString();
                    }
                    break;
                case var tmp when date.Contains("ютий") || date.Contains("ютого"): month = "02";
                    date = Regex.Replace(date, "[^0-9.]", ""); 
                    date = Regex.Replace(date, "[^0-9.]", "");
                    day = date.Substring(0, 2);
                    year = date.Substring(2, 4);
                    if (date.Length > 6)
                    {
                        hour = date.Substring(6, 2);
                        minute = date.Substring(8, date.Length - 8);
                    }
                    else
                    {
                        hour = DT.Hour.ToString();
                        minute = DT.Minute.ToString();
                    }
                    break;
                case var tmp when date.Contains("ерезень") || date.Contains("ерезня"):
                    month = "03"; date = Regex.Replace(date, "[^0-9.]", "");
                    date = Regex.Replace(date, "[^0-9.]", "");
                    day = date.Substring(0, 2);
                    year = date.Substring(2, 4);
                    if (date.Length > 6)
                    {
                        hour = date.Substring(6, 2);
                        minute = date.Substring(8, date.Length - 8);
                    }
                    else
                    {
                        hour = DT.Hour.ToString();
                        minute = DT.Minute.ToString();
                    }
                    break;
                case var tmp when date.Contains("ітень") || date.Contains("ітня"):
                    month = "04"; date = Regex.Replace(date, "[^0-9.]", "");
                    date = Regex.Replace(date, "[^0-9.]", "");
                    day = date.Substring(0, 2);
                    year = date.Substring(2, 4);
                    if (date.Length > 6)
                    {
                        hour = date.Substring(6, 2);
                        minute = date.Substring(8, date.Length - 8);
                    }
                    else
                    {
                        hour = DT.Hour.ToString();
                        minute = DT.Minute.ToString();
                    }
                    break;
                case var tmp when date.Contains("равень") || date.Contains("равня"):
                    month = "05"; date = Regex.Replace(date, "[^0-9.]", "");
                    date = Regex.Replace(date, "[^0-9.]", "");
                    day = date.Substring(0, 2);
                    year = date.Substring(2, 4);
                    if (date.Length > 6)
                    {
                        hour = date.Substring(6, 2);
                        minute = date.Substring(8, date.Length - 8);
                    }
                    else
                    {
                        hour = DT.Hour.ToString();
                        minute = DT.Minute.ToString();
                    }
                    break;
                case var tmp when date.Contains("ервень") || date.Contains("ервня"):
                    month = "06"; date = Regex.Replace(date, "[^0-9.]", "");
                    date = Regex.Replace(date, "[^0-9.]", "");
                    day = date.Substring(0, 2);
                    year = date.Substring(2, 4);
                    if (date.Length > 6)
                    {
                        hour = date.Substring(6, 2);
                        minute = date.Substring(8, date.Length - 8);
                    }
                    else
                    {
                        hour = DT.Hour.ToString();
                        minute = DT.Minute.ToString();
                    }
                    break;
                case var tmp when date.Contains("ипень") || date.Contains("ипня"):
                    month = "07"; date = Regex.Replace(date, "[^0-9.]", "");
                    date = Regex.Replace(date, "[^0-9.]", "");
                    day = date.Substring(0, 2);
                    year = date.Substring(2, 4);
                    if (date.Length > 6)
                    {
                        hour = date.Substring(6, 2);
                        minute = date.Substring(8, date.Length - 8);
                    }
                    else
                    {
                        hour = DT.Hour.ToString();
                        minute = DT.Minute.ToString();
                    }
                    break;
                case var tmp when date.Contains("ерпень") || date.Contains("ерпня"):
                    month = "08"; date = Regex.Replace(date, "[^0-9.]", "");
                    date = Regex.Replace(date, "[^0-9.]", "");
                    day = date.Substring(0, 2);
                    year = date.Substring(2, 4);
                    if (date.Length > 6)
                    {
                        hour = date.Substring(6, 2);
                        minute = date.Substring(8, date.Length - 8);
                    }
                    else
                    {
                        hour = DT.Hour.ToString();
                        minute = DT.Minute.ToString();
                    }
                    break;
                case var tmp when date.Contains("ересень") || date.Contains("ересня"):
                    month = "09"; date = Regex.Replace(date, "[^0-9.]", "");
                    date = Regex.Replace(date, "[^0-9.]", "");
                    day = date.Substring(0, 2);
                    year = date.Substring(2, 4);
                    if (date.Length > 6)
                    {
                        hour = date.Substring(6, 2);
                        minute = date.Substring(8, date.Length - 8);
                    }
                    else
                    {
                        hour = DT.Hour.ToString();
                        minute = DT.Minute.ToString();
                    }
                    break;
                case var tmp when date.Contains("овтень") || date.Contains("овтня"):
                    month = "10"; date = Regex.Replace(date, "[^0-9.]", "");
                    date = Regex.Replace(date, "[^0-9.]", "");
                    day = date.Substring(0, 2);
                    year = date.Substring(2, 4);
                    if (date.Length > 6)
                    {
                        hour = date.Substring(6, 2);
                        minute = date.Substring(8, date.Length - 8);
                    }
                    else
                    {
                        hour = DT.Hour.ToString();
                        minute = DT.Minute.ToString();
                    }
                    break;
                case var tmp when date.Contains("истопад") || date.Contains("истопада"):
                    month = "11"; date = Regex.Replace(date, "[^0-9.]", "");
                    date = Regex.Replace(date, "[^0-9.]", "");
                    day = date.Substring(0, 2);
                    year = date.Substring(2, 4);
                    if (date.Length > 6)
                    {
                        hour = date.Substring(6, 2);
                        minute = date.Substring(8, date.Length - 8);
                    }
                    else
                    {
                        hour = DT.Hour.ToString();
                        minute = DT.Minute.ToString();
                    }
                    break;
                case var tmp when date.Contains("рудень") || date.Contains("удня"):
                    month = "12"; date = Regex.Replace(date, "[^0-9.]", "");
                    date = Regex.Replace(date, "[^0-9.]", "");
                    day = date.Substring(0, 2);
                    year = date.Substring(2, 4);
                    if (date.Length > 6)
                    {
                        hour = date.Substring(6, 2);
                        minute = date.Substring(8, date.Length - 8);
                    }
                    else 
                    {
                        hour = DT.Hour.ToString();
                        minute= DT.Minute.ToString();
                    }
                    break;


                default: return "";
            }
            return $"{day}.{month}.{year} {hour}:{minute}";
        }
        private string? UTC(string date)
        {
            try
            {
                DateTime convertedDate = DateTime.Parse(date);
                var kind = convertedDate.Kind;
                convertedDate = DateTime.SpecifyKind(
                DateTime.Parse(date),
                DateTimeKind.Utc);

                kind = convertedDate.Kind;
                DateTime dt = convertedDate.ToLocalTime();
                return $"{dt.Day}.{dt.Month}.{dt.Year} {dt.Hour}:{dt.Minute}";

            }
            catch { return null; }
         }
    }
}
