using Microsoft.EntityFrameworkCore;
using OwlNews.Models;

namespace OwlNews.Data
{
	public class AppDBContext : DbContext
	{
		public DbSet<Kyiv> kyiv { get; set; }
		public DbSet<Lviv> lviv { get; set; }
		public DbSet<Ternopil> ternopil { get; set; }
		public DbSet<Zakarapattia> zakarpattia { get; set; }
		public DbSet<Zaporizhzhia> zaporizhzhia { get; set; }
		public DbSet<Zhytomyr> zhytomyr { get; set; }
		public DbSet<Rivne> rivne { get; set; }
		public DbSet<Kryvyi_Rih> kryvyi_rih { get; set; }
		public DbSet<Sumy> sumy { get; set; }
		public DbSet<Ivano_Frankivsk> ivano_frankivsk { get; set; }
		public DbSet<Luhansk> luhansk { get; set; }
		public DbSet<Volyn> volyn { get; set; }
		public DbSet<Cherkassy> cherkassy { get; set; }
		public DbSet<Chernihiv> chernihiv { get; set; }
		public DbSet<Chernvivtsi> chernivtsi { get; set; }
		public DbSet<Khmelnytskyi> khmelnytskyi { get; set; }
		public DbSet<Dnipro> dnipropetrovsk { get; set; }
		public DbSet<Kherson> kherson { get; set; }
		public DbSet<Mykolayiv> mykolayiv { get; set; }
		public DbSet<Odesa> odesa { get; set; }
		public DbSet<Poltava> poltava { get; set; }
		public DbSet<Vinnytsia> vinnytsia { get; set; }
		public DbSet<Kirovohrad> kirovohradsk { get; set; }
		public DbSet<Kharkiv> kharkiv { get; set; }
		public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
		{
		}
		public AppDBContext()
		{
		}
	}
}
