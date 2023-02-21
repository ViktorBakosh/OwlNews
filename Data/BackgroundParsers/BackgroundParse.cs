using Parser_2022_;

namespace BackgroundParsers
{
    public class BackgroundParse : BackgroundService
    {
        private const int tenMin = 600000;
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Run(() => { Parse1.vinnytsia(); Parse2.vinnytsia2(); });
            await Task.Run(() => { Parse1.volyn(); Parse2.volyn2(); });
            await Task.Run(() => { Parse1.dnipropetrovsk(); Parse2.dnipropetrovsk2(); });
            await Task.Run(() => { Parse1.zhytomyr(); Parse2.zhytomyr2(); });
            await Task.Run(() => { Parse1.zakarpattia(); Parse2.zakarpattia2(); });
            await Task.Run(() => { Parse1.zaporizhzhia(); Parse2.zaporizhzhia2(); });
            await Task.Run(() => { Parse1.ivano_frankivsk(); Parse2.ivano_frankivsk2(); });
            await Task.Run(() => { Parse1.kyiv(); Parse2.kyiv2(); });
            await Task.Run(() => { Parse1.kirovohradsk(); Parse2.kirovohradsk2(); });
            await Task.Run(() => { Parse1.luhansk(); Parse2.luhansk2(); });
            await Task.Run(() => { Parse1.lviv(); Parse2.lviv2(); });
            await Task.Run(() => { Parse1.mykolayiv(); Parse2.mykolayiv2(); });
            await Task.Run(() => { Parse1.odesa(); Parse2.odesa2(); });
            await Task.Run(() => { Parse1.poltava(); Parse2.poltava2(); });
            await Task.Run(() => { Parse1.rivne(); Parse2.rivne2(); });
            await Task.Run(() => { Parse1.sumy(); Parse2.symu2(); });
            await Task.Run(() => { Parse1.ternopil(); Parse2.ternopil2(); });
            await Task.Run(() => { Parse1.kharkiv(); Parse2.kharkiv2(); });
            await Task.Run(() => { Parse1.kherson(); Parse2.kherson2(); });
            await Task.Run(() => { Parse1.khmelnytskyi(); Parse2.khmelnytskyi2(); });
            await Task.Run(() => { Parse1.cherkassy(); Parse2.cherkassy2(); });
            await Task.Run(() => { Parse1.chernivtsi(); Parse2.chernivtsi2(); });
            await Task.Run(() => { Parse1.chernihiv(); Parse2.chernihiv2(); });
            await Task.Delay(tenMin);
            await ExecuteAsync(stoppingToken);
        }
    }
}