using Microsoft.EntityFrameworkCore;
using Rogiluo.Common.DAL;
using Rogiluo.Common.Models;
using System.Collections.Generic;
using System.Linq;

namespace Rogiluo.Common.BLL
{
    /// <summary>
    /// 資料Service
    /// </summary>
    public class DataService
    {
        /// <summary>
        /// 資料載具
        /// </summary>
        private DataContext DataContext { get; set; }

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="options"></param>
        public DataService(DbContextOptions<DataContext> options)
        {
            DataContext = new DataContext(options);
        }

        /// <summary>
        /// 取得單筆資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataViewModel GetData(int id)
        {
            var entity = DataContext.Data.FirstOrDefault(x => x.Id == id);
            var result = entity == null ? null : new DataViewModel() { Id = entity.Id, Name = entity.Name, Gender = entity.Gender };

            return result;
        }

        /// <summary>
        /// 取得全部資料
        /// </summary>
        /// <returns></returns>
        public List<DataViewModel> GetDatas()
        {
            var entities = DataContext.Data.ToList();
            var result = new List<DataViewModel>();

            entities.ForEach(entity => result.Add(new DataViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Gender = entity.Gender == "M" ? "男" : "女",
            }));

            return result;
        }

        /// <summary>
        /// 存取資料
        /// </summary>
        /// <param name="dto"></param>
        public void Access(DataDTO dto)
        {
            Data entity = null;
            switch (dto.AccessType)
            {
                case "Create":
                    DataContext.Data.Add(new Data() { Name = dto.Name, Gender = dto.Gender });
                    break;

                case "Update":
                    entity = DataContext.Data.FirstOrDefault(x => x.Id == dto.Id);
                    entity.Name = dto.Name;
                    entity.Gender = dto.Gender;                    
                    break;

                case "Delete":
                    entity = DataContext.Data.FirstOrDefault(x => x.Id == dto.Id);
                    DataContext.Data.Remove(entity);
                    break;
            }

            DataContext.SaveChanges();
        }
    }
}
