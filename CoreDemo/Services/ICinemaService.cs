using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemo.Model;

namespace CoreDemo.Services
{
    //电影院接口     之后要建立实现类
   public interface ICinemaService
   {
       //获取所有的电影院
       Task<IEnumerable<Cinema>> GetAllAsync();

       //按ID返回电影院
       Task<Cinema> GetByIdAsync(int id);

       //获取销售数据
     //  Task<Sales> GetSalesAsync();

       //添加电影院
       Task AddAsync(Cinema model);

        //删除电影院

        Task DeleteByIdAsync(int id);

   }
}
