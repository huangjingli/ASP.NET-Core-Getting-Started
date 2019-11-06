using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemo.Model;

namespace CoreDemo.Services
{
    //电影院接口实现类
    public class CinemaMemoryService:ICinemaService
    {
        private  readonly  List<Cinema> _cinemas=new List<Cinema>();
        public CinemaMemoryService()
        {
            _cinemas.Add(new Cinema()
            {
                Id = 1,
                Name = "City Cinema",
                Location = "Road ABC,No.123",
                Capacity = 1000
            });
            _cinemas.Add(new Cinema()
            {
                Id = 2,
                Name = "Fly Cinema",
                Location = "Road Hell,No.1024",
                Capacity = 500
            });
        }
        public Task<IEnumerable<Cinema>> GetAllAsync()
        {
           return Task.Run(()=>_cinemas.AsEnumerable());
        }

        public Task<Cinema> GetByIdAsync(int id)
        {
            return Task.Run(()=>_cinemas.FirstOrDefault(x=>x.Id==id));
        }

        //public Task<Sales> GetSalesAsync()
        //{
        //    throw new NotImplementedException();
        //}

        public Task AddAsync(Cinema model)
        {
            var maxId = _cinemas.Max(x => x.Id);
            model.Id = maxId + 1;
            _cinemas.Add(model);
            return Task.CompletedTask;
        }

        public Task DeleteByIdAsync(int id)
        {
           // var user = new Cinema {Id = id};
            var user =_cinemas.FirstOrDefault(x => x.Id == id);
            _cinemas.Remove(user);
            return Task.CompletedTask;
        }
    }
}
