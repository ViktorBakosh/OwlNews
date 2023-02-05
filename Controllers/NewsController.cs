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
            var news = this.context.lviv.ToList().OrderByDescending(x => x.time).OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Львівська область";
            return View("News",news);
        }
        public IActionResult Kyiv()
        {
            Parse.kyiv();
            var news = this.context.kyiv.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Київська область";
            return View("News",news);
        }
        public IActionResult Ternopil()
        {
            Parse.ternopil();
            var news = this.context.ternopil.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Тернопільська область";
            return View("News",news);
        }
        public IActionResult Zakarpattia()
        {
            Parse.zakarpattia();
            var news = this.context.zakarpattia.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Закарпатьська область";
            return View("News",news);
        }
        public IActionResult Sumy()
        {
            Parse.sumy();
            var news = this.context.sumy.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Сумська область";
            return View("News",news);
        }
        public IActionResult Volyn()
        {
            Parse.volyn();
            var news = this.context.volyn.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Волинська область";
            return View("News",news);
        }
        public IActionResult Cherkassy()
        {
            Parse.cherkassy();
            var news = this.context.cherkassy.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Черкаська область";
            return View("News",news);
        }
        public IActionResult Chernihiv()
        {
            Parse.chernihiv();
            var news = this.context.chernihiv.ToList().OrderByDescending(x => x.time).OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Чернігівська область";
            return View("News", news);
        }
        public IActionResult Chernivtsi()
        {
            Parse.chernivtsi();
            var news = this.context.chernivtsi.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Чернівецька область";
            return View("News",news);
        }
        public IActionResult Dnipro()
        {
            Parse.dnipropetrovsk();
            var news = this.context.dnipropetrovsk.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Дніровська область";
            return View("News",news);
        }
        public IActionResult Ivano_Frankivsk()
        {
            Parse.ivano_frankivsk();
            var news = this.context.ivano_frankivsk.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Івано-Франківська область";
            return View("News",news);
        }
        public IActionResult Kharkiv()
        {
            Parse.kharkiv();
            var news = this.context.kharkiv.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Харківська область";
            return View("News",news);
        }
        public IActionResult Kherson()
        {
            Parse.kherson();
            var news = this.context.kherson.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Херсонська область";
            return View("News",news);
        }
        public IActionResult Khmelnytskyi()
        {
            Parse.khmelnytskyi();
            var news = this.context.khmelnytskyi.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Хмельницька область";
            return View("News",news);
        }
        public IActionResult Kirovohrad()
        {
            Parse.kirovohradsk();
            var news = this.context.kirovohradsk.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Кіровоградська область";
            return View("News",news);
        }
        public IActionResult Kryvyi_Rih()
        {
            Parse.kryvyi_rih();
            var news = this.context.kryvyi_rih.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Криворізька область";
            return View("News",news);
        }
        public IActionResult Luhansk()
        {
            Parse.luhansk();
            var news = this.context.luhansk.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Луганська область";
            return View("News",news);
        }
        public IActionResult Mykolayiv()
        {
            Parse.mykolayiv();
            var news = this.context.mykolayiv.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Миколаївська область";
            return View("News",news);
        }
        public IActionResult Rivne()
        {
            Parse.rivne();
            var news = this.context.rivne.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Рівнеська область";
            return View("News",news);
        }
        public IActionResult Odesa()
        {
            Parse.odesa();
            var news = this.context.odesa.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Одеська область";
            return View("News",news);
        }
        public IActionResult Poltava()
        {
            Parse.poltava();
            var news = this.context.poltava.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Полтавська область";
            return View("News",news);
        }
        public IActionResult Vinnytsia()
        {
            Parse.vinnytsia();
            var news = this.context.vinnytsia.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Вінницька область";
            return View("News",news);
        }
        public IActionResult Zaporizhzhia()
        {
            Parse.zaporizhzhia();
            var news = this.context.zaporizhzhia.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Запорізька область";
            return View("News",news);
        }
        public IActionResult Zhytomyr()
        {
            Parse.zhytomyr();
            var news = this.context.zhytomyr.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Житомирська область";
            return View("News",news);
        }
    }
}