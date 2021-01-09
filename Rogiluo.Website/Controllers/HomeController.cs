using Microsoft.AspNetCore.Mvc;
using Rogiluo.Website.Models;
using System.Diagnostics;

namespace Rogiluo.Website.Controllers
{
    /// <summary>
    /// 首頁控制器
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// 首頁
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 錯誤頁面
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
