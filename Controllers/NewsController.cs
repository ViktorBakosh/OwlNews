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
        public async Task<IActionResult> Lviv()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 12);
            ViewData["Title"] = "News - Львівська область";
            return View("News", news);
        }
        public async Task<IActionResult> Kyiv()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 9);
            ViewData["Title"] = "News - Київська область";
            return View("News", news);
        }
        public async Task<IActionResult> Ternopil()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 18);
            ViewData["Title"] = "News - Тернопільська область";
            return View("News", news);
        }
        public async Task<IActionResult> Zakarpattia()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 6);
            ViewData["Title"] = "News - Закарпатьська область";
            return View("News", news);
        }
        public async Task<IActionResult> Sumy()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 17);
            ViewData["Title"] = "News - Сумська область";
            return View("News", news);
        }
        public async Task<IActionResult> Volyn()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 2);
            ViewData["Title"] = "News - Волинська область";
            return View("News", news);
        }
        public async Task<IActionResult> Cherkassy()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 22);
            ViewData["Title"] = "News - Черкаська область";
            return View("News", news);
        }
        public async Task<IActionResult> Chernihiv()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 24);
            ViewData["Title"] = "News - Чернігівська область";
            return View("News", news);
        }
        public async Task<IActionResult> Chernivtsi()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 23);
            ViewData["Title"] = "News - Чернівецька область";
            return View("News", news);
        }
        public async Task<IActionResult> Dnipro()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 3);
            ViewData["Title"] = "News - Дніровська область";
            return View("News", news);
        }
        public async Task<IActionResult> Ivano_Frankivsk()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 8);
            ViewData["Title"] = "News - Івано-Франківська область";
            return View("News", news);
        }
        public async Task<IActionResult> Kharkiv()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 19);
            ViewData["Title"] = "News - Харківська область";
            return View("News", news);
        }
        public async Task<IActionResult> Kherson()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 20);
            ViewData["Title"] = "News - Херсонська область";
            return View("News", news);
        }
        public async Task<IActionResult> Khmelnytskyi()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 21);
            ViewData["Title"] = "News - Хмельницька область";
            return View("News", news);
        }
        public async Task<IActionResult> Kirovohrad()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 10);
            ViewData["Title"] = "News - Кіровоградська область";
            return View("News", news);
        }
        public async Task<IActionResult> Kryvyi_Rih()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 3);
            ViewData["Title"] = "News - Криворізька область";
            return View("News", news);
        }
        public async Task<IActionResult> Luhansk()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 11);
            ViewData["Title"] = "News - Луганська область";
            return View("News", news);
        }
        public async Task<IActionResult> Mykolayiv()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 13);
            ViewData["Title"] = "News - Миколаївська область";
            return View("News", news);
        }
        public async Task<IActionResult> Rivne()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 16);
            ViewData["Title"] = "News - Рівнеська область";
            return View("News", news);
        }
        public async Task<IActionResult> Odesa()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 14);
            ViewData["Title"] = "News - Одеська область";
            return View("News", news);
        }
        public async Task<IActionResult> Poltava()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 15);
            ViewData["Title"] = "News - Полтавська область";
            return View("News", news);
        }
        public async Task<IActionResult> Vinnytsia()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 1);
            ViewData["Title"] = "News - Вінницька область";
            return View("News", news);
        }
        public async Task<IActionResult> Zaporizhzhia()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 7);
            ViewData["Title"] = "News - Запорізька область";
            return View("News", news);
        }
        public async Task<IActionResult> Zhytomyr()
        {
            await Task.Delay(1);
            var news = this.context.all_news.ToList().OrderByDescending(x => x.time).Where(x => x.region_id == 5);
            ViewData["Title"] = "News - Житомирська область";
            return View("News",news);
        }
    }
}