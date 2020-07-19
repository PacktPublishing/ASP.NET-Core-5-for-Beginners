using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Chapter_03_QuickStart.DataManager;
using Chapter_03_QuickStart.Models;
using System.Diagnostics;
using System.Collections.Generic;

namespace Chapter_03_QuickStart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMusicManager _musicManager;
        private readonly InstrumentalMusicManager _insMusicManager;
        public HomeController(ILogger<HomeController> logger,
                              IMusicManager musicManager,
                              InstrumentalMusicManager insMusicManager)
        {
            _logger = logger;
            _musicManager = musicManager;
            _insMusicManager = insMusicManager;
        }

        ////Dealing With Multiple Service Implementations Example
        //private readonly IEnumerable<IMusicManager> _musicManagers;
        //public HomeController(IEnumerable<IMusicManager> musicManagers)
        //{
        //    _musicManagers = musicManagers;
        //}

        public IActionResult Index()
        {
            //DEPENDENCY LIFETIME EXAMPLE
            var musicManagerReqId = _musicManager.RequestId;
            var insMusicManagerReqId = _insMusicManager.RequestId;

            //CONSTRUCTOR INJECTION EXAMPLE
            //var songs = _musicManager.GetAllMusic();

            //METHOD INJECTION EXAMPLE
            //var songs = _musicManager.GetAllMusicThenNotify(new Notifier());

            //PROPERTY INJECTION EXAMPLE
            _musicManager.Notify = new Notifier();
            var songs = _musicManager.GetAllMusicThenNotify();
            return View(songs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


