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
            Parse1.lviv();
            await Task.Delay(2000);
            var news = this.context.lviv1.ToList().OrderByDescending(x => x.time).OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Львівська область";
            return View("News", news);
        }
        public async Task<IActionResult> Kyiv()
        {
            Parse1.kyiv();
            await Task.Delay(2000);
            var news = this.context.kyiv1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Київська область";
            return View("News",news);
        }
        public async Task<IActionResult> Ternopil()
        {
            Parse1.ternopil();
            await Task.Delay(2000);
            var news = this.context.ternopil1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Тернопільська область";
            return View("News",news);
        }
        public async Task<IActionResult> Zakarpattia()
        {
            Parse1.zakarpattia();
            await Task.Delay(2000);
            var news = this.context.zakarpattia1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Закарпатьська область";
            return View("News",news);
        }
        public async Task<IActionResult> Sumy()
        {
            Parse1.sumy();
            await Task.Delay(2000);
            var news = this.context.sumy1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Сумська область";
            return View("News",news);
        }
        public async Task<IActionResult> Volyn()
        {
            Parse1.volyn();
            await Task.Delay(2000);
            var news = this.context.volyn1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Волинська область";
            return View("News",news);
        }
        public async Task<IActionResult> Cherkassy()
        {
            Parse1.cherkassy();
            await Task.Delay(2000);
            var news = this.context.cherkassy1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Черкаська область";
            return View("News",news);
        }
        public async Task<IActionResult> Chernihiv()
        {
            Parse1.chernihiv();
            await Task.Delay(2000);
            var news = this.context.chernihiv1.ToList().OrderByDescending(x => x.time).OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Чернігівська область";
            return View("News", news);
        }
        public async Task<IActionResult> Chernivtsi()
        {
            Parse1.chernivtsi();
            await Task.Delay(2000);
            var news = this.context.chernivtsi1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Чернівецька область";
            return View("News",news);
        }
        public async Task<IActionResult> Dnipro()
        {
            Parse1.dnipropetrovsk();
            await Task.Delay(2000);
            var news = this.context.dnipropetrovsk1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Дніровська область";
            return View("News",news);
        }
        public async Task<IActionResult> Ivano_Frankivsk()
        {
            Parse1.ivano_frankivsk();
            await Task.Delay(2000);
            var news = this.context.ivano_frankivsk1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Івано-Франківська область";
            return View("News",news);
        }
        public async Task<IActionResult> Kharkiv()
        {
            Parse1.kharkiv();
            await Task.Delay(2000);
            var news = this.context.kharkiv1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Харківська область";
            return View("News",news);
        }
        public async Task<IActionResult> Kherson()
        {
            Parse1.kherson();
            await Task.Delay(2000);
            var news = this.context.kherson1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Херсонська область";
            return View("News",news);
        }
        public async Task<IActionResult> Khmelnytskyi()
        {
            Parse1.khmelnytskyi();
            await Task.Delay(2000);
            var news = this.context.khmelnytskyi1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Хмельницька область";
            return View("News",news);
        }
        public async Task<IActionResult> Kirovohrad()
        {
            Parse1.kirovohradsk();
            await Task.Delay(2000);
            var news = this.context.kirovohradsk1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Кіровоградська область";
            return View("News",news);
        }
        public async Task<IActionResult> Kryvyi_Rih()
        {
            Parse1.kryvyi_rih();
            await Task.Delay(2000);
            var news = this.context.kryvyi_rih1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Криворізька область";
            return View("News",news);
        }
        public async Task<IActionResult> Luhansk()
        {
            Parse1.luhansk();
            await Task.Delay(2000);
            var news = this.context.luhansk1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Луганська область";
            return View("News",news);
        }
        public async Task<IActionResult> Mykolayiv()
        {
            Parse1.mykolayiv();
            await Task.Delay(2000);
            var news = this.context.mykolayiv1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Миколаївська область";
            return View("News",news);
        }
        public async Task<IActionResult> Rivne()
        {
            Parse1.rivne();
            await Task.Delay(2000);
            var news = this.context.rivne1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Рівнеська область";
            return View("News",news);
        }
        public async Task<IActionResult> Odesa()
        {
            Parse1.odesa();
            await Task.Delay(2000);
            var news = this.context.odesa1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Одеська область";
            return View("News",news);
        }
        public async Task<IActionResult> Poltava()
        {
            Parse1.poltava();
            await Task.Delay(2000);
            var news = this.context.poltava1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Полтавська область";
            return View("News",news);
        }
        public async Task<IActionResult> Vinnytsia()
        {
            Parse1.vinnytsia();
            await Task.Delay(2000);
            var news = this.context.vinnytsia1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Вінницька область";
            return View("News",news);
        }
        public async Task<IActionResult> Zaporizhzhia()
        {
            Parse1.zaporizhzhia();
            await Task.Delay(2000);
            var news = this.context.zaporizhzhia1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Запорізька область";
            return View("News",news);
        }
        public async Task<IActionResult> Zhytomyr()
        {
            Parse1.zhytomyr();
            await Task.Delay(2000);
            var news = this.context.zhytomyr1.ToList().OrderByDescending(x => x.time);
            ViewData["Title"] = "News - Житомирська область";
            return View("News",news);
        }
    }
}