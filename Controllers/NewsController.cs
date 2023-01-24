using Microsoft.AspNetCore.Mvc;
using OwlNews.Data;

namespace OwlNews.Controllers
{
    public class NewsController : Controller
    {
        private readonly AppDBContext context;
        public NewsController(AppDBContext context)
        {
            this.context = context;
        }
        public IActionResult Lviv()
        {
            Parse.lviv();
            var news = this.context.lviv.ToList();
            ViewData["Title"] = "News - Львівська область";
            return View(news);
        }
        public IActionResult Kyiv()
        {
            Parse.kyiv();
            var news = this.context.kyiv.ToList();
            ViewData["Title"] = "News - Київська область";
            return View(news);
        }
        public IActionResult Ternopil()
        {
            Parse.ternopil();
            var news = this.context.ternopil.ToList();
            ViewData["Title"] = "News - Тернопільська область";
            return View(news);
        }
        public IActionResult Zakarpattia()
        {
            Parse.zakarpattia();
            var news = this.context.zakarpattia.ToList();
            ViewData["Title"] = "News - Закарпатьська область";
            return View(news);
        }
        public IActionResult Sumy()
        {
            Parse.sumy();
            var news = this.context.sumy.ToList();
            ViewData["Title"] = "News - Сумська область";
            return View(news);
        }
        public IActionResult Volyn()
        {
            Parse.volyn();
            var news = this.context.volyn.ToList();
            ViewData["Title"] = "News - Волинська область";
            return View(news);
        }
        public IActionResult Cherkassy()
        {
            Parse.cherkassy();
            var news = this.context.cherkassy.ToList();
            ViewData["Title"] = "News - Черкаська область";
            return View(news);
        }
        public IActionResult Chernihiv()
        {
            Parse.chernihiv();
            var news = this.context.chernihiv.ToList();
            ViewData["Title"] = "News - Чернігівська область";
            return View(news);
        }
        public IActionResult Chernivtsi()
        {
            Parse.chernivtsi();
            var news = this.context.chernivtsi.ToList();
            ViewData["Title"] = "News - Чернівецька область";
            return View(news);
        }
        public IActionResult Dnipro()
        {
            Parse.dnipropetrovsk();
            var news = this.context.dnipropetrovsk.ToList();
            ViewData["Title"] = "News - Дніровська область";
            return View(news);
        }
        public IActionResult Ivano_Frankivsk()
        {
            Parse.ivano_frankivsk();
            var news = this.context.ivano_frankivsk.ToList();
            ViewData["Title"] = "News - Івано-Франківська область";
            return View(news);
        }
        public IActionResult Kharkiv()
        {
            Parse.kharkiv();
            var news = this.context.kharkiv.ToList();
            ViewData["Title"] = "News - Харківська область";
            return View(news);
        }
        public IActionResult Kherson()
        {
            Parse.kherson();
            var news = this.context.kherson.ToList();
            ViewData["Title"] = "News - Херсонська область";
            return View(news);
        }
        public IActionResult Khmelnytskyi()
        {
            Parse.khmelnytskyi();
            var news = this.context.khmelnytskyi.ToList();
            ViewData["Title"] = "News - Хмельницька область";
            return View(news);
        }
        public IActionResult Kirovohrad()
        {
            Parse.kirovohradsk();
            var news = this.context.kirovohradsk.ToList();
            ViewData["Title"] = "News - Кіровоградська область";
            return View(news);
        }
        public IActionResult Kryvyi_Rih()
        {
            Parse.kryvyi_rih();
            var news = this.context.kryvyi_rih.ToList();
            ViewData["Title"] = "News - Криворізька область";
            return View(news);
        }
        public IActionResult Luhansk()
        {
            Parse.luhansk();
            var news = this.context.luhansk.ToList();
            ViewData["Title"] = "News - Луганська область";
            return View(news);
        }
        public IActionResult Mykolayiv()
        {
            Parse.mykolayiv();
            var news = this.context.mykolayiv.ToList();
            ViewData["Title"] = "News - Миколаївська область";
            return View(news);
        }
        public IActionResult Rivne()
        {
            Parse.rivne();
            var news = this.context.rivne.ToList();
            ViewData["Title"] = "News - Рівнеська область";
            return View(news);
        }
        public IActionResult Odesa()
        {
            Parse.odesa();
            var news = this.context.odesa.ToList();
            ViewData["Title"] = "News - Одеська область";
            return View(news);
        }
        public IActionResult Poltava()
        {
            Parse.poltava();
            var news = this.context.poltava.ToList();
            ViewData["Title"] = "News - Полтавська область";
            return View(news);
        }
        public IActionResult Vinnytsia()
        {
            Parse.vinnytsia();
            var news = this.context.vinnytsia.ToList();
            ViewData["Title"] = "News - Вінницька область";
            return View(news);
        }
        public IActionResult Zaporizhzhia()
        {
            Parse.zaporizhzhia();
            var news = this.context.zaporizhzhia.ToList();
            ViewData["Title"] = "News - Запорізька область";
            return View(news);
        }
        public IActionResult Zhytomyr()
        {
            Parse.zhytomyr();
            var news = this.context.zhytomyr.ToList();
            ViewData["Title"] = "News - Житомирська область";
            return View(news);
        }
    }
}