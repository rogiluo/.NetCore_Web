using Microsoft.EntityFrameworkCore;
using Rogiluo.Common.Models;

namespace Rogiluo.Common.DAL
{
    /// <summary>
    /// 資料載具
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// 資料檔
        /// </summary>
        public DbSet<Data> Data { get; set; }

        /// <summary>
        /// 建構子
        /// </summary>
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
