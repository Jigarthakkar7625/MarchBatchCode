using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyFirstCoreWebSite.Models;
using ServiceLayer.IServices;
using System.Diagnostics;
using System.Runtime;

namespace MyFirstCoreWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppSettingData _settingData;

        private readonly IConfiguration _configuration;
        public readonly IWebHostEnvironment _env;


        public readonly ITransient _transientService1;
        public readonly ITransient _transientService2;


        public readonly IScope _scopeService1;
        public readonly IScope _scopeService2;

        public readonly ISingleton _singletonService1;
        public readonly ISingleton _singletonService2;


        //.NET framework >> need to install Package 
        // .NET core >> DI inbuilt

        //private readonly TestDbmajwtContext _testDbmajwtContext;
        //public HomeController(ILogger<HomeController> logger, IOptions<AppSettingData> settings)
        //{
        //    _logger = logger;
        //    //_settingData = settings.Value;
        //}

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IWebHostEnvironment env, ITransient transientService2, ITransient transientService1, IScope scopeService1, IScope scopeService2, ISingleton singletonService1, ISingleton singletonService2)
        {
            _logger = logger;
            _configuration = configuration;
            _env = env;
            _transientService2 = transientService2;
            _transientService1 = transientService1;

            _scopeService1 = scopeService1;
            _scopeService2 = scopeService2;

            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
            // _testDbmajwtContext = testDbmajwtContext;
            //_settingData = settings.Value;
        }

        public IActionResult Index()
        {

            //var getData = _testDbmajwtContext.Users.ToList();

            ViewBag.transient1 = _transientService1.GetOperationId().ToString();
            ViewBag.transient2 = _transientService2.GetOperationId().ToString();

            ViewBag.scoped1 = _scopeService1.GetOperationId().ToString();
            ViewBag.scoped2 = _scopeService2.GetOperationId().ToString();

            ViewBag.singleton1 = _singletonService1.GetOperationId().ToString();
            ViewBag.singleton2 = _singletonService2.GetOperationId().ToString();

            //string settingKey = _configuration["AppSettingData:SettingKey"];
            //var Timeout = _configuration["AppSettingData:Timeout"];

            //var info = new
            //{
            //    env = _env.EnvironmentName,
            //    conrp = _env.ContentRootPath,
            //    webrootPath = _env.WebRootPath,
            //    currentD = Directory.GetCurrentDirectory(),
            //    os = Environment.OSVersion.ToString(),
            //    machineName = Environment.MachineName,
            //    userName = Environment.UserName


            //};


            return View();
        }

        public IActionResult Download()
        {
            var directory = Directory.GetCurrentDirectory();

            string path = Path.Combine(directory, "wwwroot", "upload", "jigar.txt");

            if (!System.IO.File.Exists(path))
            {
                return NotFound();
            }

            var mimeType = "text/plain";
            var fileByte = System.IO.File.ReadAllBytes(path);
            return File(fileByte, mimeType, "jigar.txt");

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