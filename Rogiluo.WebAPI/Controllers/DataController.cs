using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rogiluo.Common.BLL;
using Rogiluo.Common.DAL;
using Rogiluo.Common.Models;

namespace Rogiluo.WebAPI.Controllers
{
    /// <summary>
    /// 資料控制器
    /// </summary>
    [Route("api")]
    [ApiController]
    public class DataController : ControllerBase
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
        /// 取得-單筆資料
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Data")]        
        public IActionResult GetData(int id)
        {
            var vm = DataService.GetData(id);
            return Ok(vm);
        }

        /// <summary>
        /// 取得-全部資料
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Datas")]
        public IActionResult GetDatas()
        {
            var vm = DataService.GetDatas();
            return Ok(vm);
        }

        /// <summary>
        /// 新增-單筆資料
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Data")]
        public IActionResult CreateData(DataDTO dto)
        {
            dto.AccessType = "Create";
            DataService.Access(dto);

            return Ok();
        }

        /// <summary>
        /// 更新-單筆資料
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Data")]
        public IActionResult UpdateData(DataDTO dto)
        {
            dto.AccessType = "Update";
            DataService.Access(dto);

            return Ok();
        }

        /// <summary>
        /// 刪除-單筆資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Data")]
        public IActionResult DeleteData(int id)
        {
            var dto = new DataDTO() { Id = id, AccessType = "Delete" };
            DataService.Access(dto);

            return Ok();
        }
    }
}