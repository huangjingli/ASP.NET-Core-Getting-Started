using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemo.Model;
using CoreDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class MovieController:Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICinemaService _cinemaService;

        public MovieController(IMovieService movieService,ICinemaService cinemaService)
        {
            _movieService = movieService;
            _cinemaService = cinemaService;
        }

        //按照电影院ID取电影列表
        public async Task<IActionResult> Index(int cinemaId)
        {
            var cinema = await _cinemaService.GetByIdAsync(cinemaId);
            ViewBag.Title = $"{cinema.Name}这个电影院上映的电影有:";
            ViewBag.CinemaId = cinemaId;
            return View(await _movieService.GetByCinemaAsync(cinemaId));
        }
        //跳转添加页面
        public IActionResult Add(int cinemaId)
        {
            ViewBag.Title = "添加电影";
            return View(new Movie {CinemaId = cinemaId});
        }

        //添加后台操作
        [HttpPost]
        public async Task<IActionResult> Add(Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _movieService.AddAsync(movie);
            }

            return RedirectToAction("Index", new {cinemaId = movie.CinemaId});
        }
        //编辑
        //编辑页面
        public IActionResult Edit(int movieId)
        {
            return RedirectToAction("Index");
        }

    }
}
