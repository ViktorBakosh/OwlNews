using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace OwlNews.Models
{
    public class News
    {
		public string? title { get; set; }
		public DateTime time { get; set; }
		public string? info { get; set; }
		public string? link { get; set; }
		public string? image { get; set; }
    }
	public class Lviv : News
	{
		public int id { get; set; }
	}
	public class Kyiv : News
	{
		public int id { get; set; }
	}
	public class Ternopil : News
	{
		public int id { get; set; }
	}
	public class Zakarapattia : News
	{
		public int id { get; set; }
	}
	public class Ivano_Frankivsk : News
	{
		public int id { get; set; }
	}
	public class Sumy : News
	{
		public int id { get; set; }
	}
	public class Volyn : News
	{
		public int id { get; set; }
	}
	public class Cherkassy : News
	{
		public int id { get; set; }
	}
	public class Chernihiv : News
	{
		public int id { get; set; }
	}
	public class Chernvivtsi : News
	{
		public int id { get; set; }
	}
	public class Dnipro : News
	{
		public int id { get; set; }
	}
	public class Kharkiv : News
	{
		public int id { get; set; }
	}
	public class Kherson : News
	{
		public int id { get; set; }
	}
	public class Khmelnytskyi : News
	{
		public int id { get; set; }
	}
	public class Kirovohrad : News
	{
		public int id { get; set; }
	}
	public class Kryvyi_Rih : News
	{
		public int id { get; set; }
	}
	public class Luhansk : News
	{
		public int id { get; set; }
	}
	public class Mykolayiv : News
	{
		public int id { get; set; }
	}
	public class Rivne : News
	{
		public int id { get; set; }
	}
	public class Odesa : News
	{
		public int id { get; set; }
	}
    public class Poltava : News
    {
        public int id { get; set; }
    }
    public class Vinnytsia : News
    {
        public int id { get; set; }
    }
    public class Zaporizhzhia : News
    {
        public int id { get; set; }
    }
    public class Zhytomyr : News
    {
        public int id { get; set; }
    }
}