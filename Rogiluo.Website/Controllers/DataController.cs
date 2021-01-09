using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rogiluo.Common.BLL;
using Rogiluo.Common.DAL;
using Rogiluo.Common.Models;

namespace Rogiluo.Website.Controllers
{
    /// <summary>
    /// 資料控制器
    /// </summary>
    public class DataController : Controller
    {
        /// <summary>
        /// 資料Service
        /// </summary>
        private DataService DataService { get; set; }

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="options"></param>
        public DataController(DbContextOptions<DataContext> options)
        {
            DataService = new DataService(options);
        }

        /// <summary>
        /// 查詢頁面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var vm = DataService.GetDatas();
            return View(vm);
        }

        /// <summary>
        /// 新增頁面
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 編輯頁面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var vm = DataService.GetData(id);
            return View(vm);
        }

        /// <summary>
        /// 存取資料
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Access(DataDTO dto)
        {
            DataService.Access(dto);
            return RedirectToAction("Index");
        }
    }
}