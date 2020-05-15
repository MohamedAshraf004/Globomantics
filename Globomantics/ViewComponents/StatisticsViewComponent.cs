using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Globomantics.Services;

namespace Globomantics.ViewComponents
{
    public class StatisticsViewComponent : ViewComponent
    {
        private readonly IConferenceService service;

        public StatisticsViewComponent(IConferenceService service)
        {
            this.service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(string statsCaption)
        {
            ViewBag.Caption = statsCaption;
            return View(await service.GetStatistics());
        }
    }
}
