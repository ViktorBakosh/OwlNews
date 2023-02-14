using Microsoft.AspNetCore.Mvc;
using OwlNews.Data;
using Parser_2022_;

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
            Parse1.lviv();
            var news = this.context.lviv1.ToList().OrderByDescending(x => x.time).OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Львівська область";
            return View("News",news);
        }
        public IActionResult Kyiv()
        {
            Parse1.kyiv();
            var news = this.context.kyiv1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Київська область";
            return View("News",news);
        }
        public IActionResult Ternopil()
        {
            Parse1.ternopil();
            var news = this.context.ternopil1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Тернопільська область";
            return View("News",news);
        }
        public IActionResult Zakarpattia()
        {
            Parse1.zakarpattia();
            var news = this.context.zakarpattia1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Закарпатьська область";
            return View("News",news);
        }
        public IActionResult Sumy()
        {
            Parse1.sumy();
            var news = this.context.sumy1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Сумська область";
            return View("News",news);
        }
        public IActionResult Volyn()
        {
            Parse1.volyn();
            var news = this.context.volyn1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Волинська область";
            return View("News",news);
        }
        public IActionResult Cherkassy()
        {
            Parse1.cherkassy();
            var news = this.context.cherkassy1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Черкаська область";
            return View("News",news);
        }
        public IActionResult Chernihiv()
        {
            Parse1.chernihiv();
            var news = this.context.chernihiv1.ToList().OrderByDescending(x => x.time).OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Чернігівська область";
            return View("News", news);
        }
        public IActionResult Chernivtsi()
        {
            Parse1.chernivtsi();
            var news = this.context.chernivtsi1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Чернівецька область";
            return View("News",news);
        }
        public IActionResult Dnipro()
        {
            Parse1.dnipropetrovsk();
            var news = this.context.dnipropetrovsk1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Дніровська область";
            return View("News",news);
        }
        public IActionResult Ivano_Frankivsk()
        {
            Parse1.ivano_frankivsk();
            var news = this.context.ivano_frankivsk1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Івано-Франківська область";
            return View("News",news);
        }
        public IActionResult Kharkiv()
        {
            Parse1.kharkiv();
            var news = this.context.kharkiv1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Харківська область";
            return View("News",news);
        }
        public IActionResult Kherson()
        {
            Parse1.kherson();
            var news = this.context.kherson1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Херсонська область";
            return View("News",news);
        }
        public IActionResult Khmelnytskyi()
        {
            Parse1.khmelnytskyi();
            var news = this.context.khmelnytskyi1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Хмельницька область";
            return View("News",news);
        }
        public IActionResult Kirovohrad()
        {
            Parse1.kirovohradsk();
            var news = this.context.kirovohradsk1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Кіровоградська область";
            return View("News",news);
        }
        public IActionResult Kryvyi_Rih()
        {
            Parse1.kryvyi_rih();
            var news = this.context.kryvyi_rih1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Криворізька область";
            return View("News",news);
        }
        public IActionResult Luhansk()
        {
            Parse1.luhansk();
            var news = this.context.luhansk1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Луганська область";
            return View("News",news);
        }
        public IActionResult Mykolayiv()
        {
            Parse1.mykolayiv();
            var news = this.context.mykolayiv1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Миколаївська область";
            return View("News",news);
        }
        public IActionResult Rivne()
        {
            Parse1.rivne();
            var news = this.context.rivne1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Рівнеська область";
            return View("News",news);
        }
        public IActionResult Odesa()
        {
            Parse1.odesa();
            var news = this.context.odesa1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Одеська область";
            return View("News",news);
        }
        public IActionResult Poltava()
        {
            Parse1.poltava();
            var news = this.context.poltava1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Полтавська область";
            return View("News",news);
        }
        public IActionResult Vinnytsia()
        {
            Parse1.vinnytsia();
            var news = this.context.vinnytsia1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Вінницька область";
            return View("News",news);
        }
        public IActionResult Zaporizhzhia()
        {
            Parse1.zaporizhzhia();
            var news = this.context.zaporizhzhia1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Запорізька область";
            return View("News",news);
        }
        public IActionResult Zhytomyr()
        {
            Parse1.zhytomyr();
            var news = this.context.zhytomyr1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Житомирська область";
            return View("News",news);
        }
    }
}