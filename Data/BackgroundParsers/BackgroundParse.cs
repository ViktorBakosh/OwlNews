using Parser_2022_;

namespace BackgroundParsers
{
    public class BackgroundParse : BackgroundService
    {
        private const int tenMin = 600000;
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Run(() => { Parse1.vinnytsia(); Parse2.vinnytsia2();Parse3.vinnytsia(); });
            await Task.Run(() => { Parse1.volyn(); Parse2.volyn2(); Parse3.volyn(); });
            await Task.Run(() => { Parse1.dnipropetrovsk(); Parse2.dnipropetrovsk2(); Parse3.dnipropetrovsk(); });
            await Task.Run(() => { Parse1.zhytomyr(); Parse2.zhytomyr2(); Parse3.zhytomyr(); });
            await Task.Run(() => { Parse1.zakarpattia(); Parse2.zakarpattia2(); Parse3.zakarpattia(); });
            await Task.Run(() => { Parse1.zaporizhzhia(); Parse2.zaporizhzhia2(); Parse3.zaporizhzhia(); });
            await Task.Run(() => { Parse1.ivano_frankivsk(); Parse2.ivano_frankivsk2(); Parse3.ivano_frankivsk(); });
            await Task.Run(() => { Parse1.kyiv(); Parse2.kyiv2(); Parse3.kyiv(); });
            await Task.Run(() => { Parse1.kirovohradsk(); Parse2.kirovohradsk2(); Parse3.kirovohradsk(); });
            await Task.Run(() => { Parse1.luhansk(); Parse2.luhansk2(); Parse3.luhansk(); });
            await Task.Run(() => { Parse1.lviv(); Parse2.lviv2(); Parse3.lviv(); });
            await Task.Run(() => { Parse1.mykolayiv(); Parse2.mykolayiv2(); Parse3.mykolayiv(); });
            await Task.Run(() => { Parse1.odesa(); Parse2.odesa2(); Parse3.odesa(); });
            await Task.Run(() => { Parse1.poltava(); Parse2.poltava2(); Parse3.poltava(); });
            await Task.Run(() => { Parse1.rivne(); Parse2.rivne2(); Parse3.rivne(); });
            await Task.Run(() => { Parse1.sumy(); Parse2.symu2(); Parse3.sumy(); });
            await Task.Run(() => { Parse1.ternopil(); Parse2.ternopil2(); Parse3.ternopil(); });
            await Task.Run(() => { Parse1.kharkiv(); Parse2.kharkiv2(); Parse3.kharkiv(); });
            await Task.Run(() => { Parse1.kherson(); Parse2.kherson2(); Parse3.Kherson(); });
            await Task.Run(() => { Parse1.khmelnytskyi(); Parse2.khmelnytskyi2(); Parse3.khmelnytskyi(); });
            await Task.Run(() => { Parse1.cherkassy(); Parse2.cherkassy2(); Parse3.cherkassy(); });
            await Task.Run(() => { Parse1.chernivtsi(); Parse2.chernivtsi2(); Parse3.chernivtsi(); });
            await Task.Run(() => { Parse1.chernihiv(); Parse2.chernihiv2(); });
            await Task.Delay(tenMin);
            await ExecuteAsync(stoppingToken);
        }
    }
}