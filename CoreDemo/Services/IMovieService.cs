using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemo.Model;

namespace CoreDemo.Services
{
    //Service文件夹通常要建立一个接口


    //电影接口
    public interface IMovieService
    {
        //添加电影
        Task AddAsync(Movie movie);
        //根据电影院ID获取电影
        Task<IEnumerable<Movie>> GetByCinemaAsync(int cinemaId);
    }
}
