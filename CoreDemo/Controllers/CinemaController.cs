using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemo.Model;
using CoreDemo.Services;
using CoreDemo.Setrings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CoreDemo.Controllers
{
    public class CinemaController:Controller
    {
        private readonly ICinemaService _cinemaService;
        private readonly IOptions<ConnectionOptions> _options;

        public CinemaController(ICinemaService cinemaService, IOptions<ConnectionOptions> options)
        {
            _cinemaService = cinemaService;
            _options = options;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "电影院列表";
            return View(await _cinemaService.GetAllAsync());
        }

        //进去添加页面
        public IActionResult Add()
        {
            ViewBag.Title = "添加电影院";
            return View(new Cinema());
        }
        [HttpPost]
        public async Task<IActionResult> Add(Cinema cinema)
        {
            //页面验证
            if (ModelState.IsValid)
            {
                await _cinemaService.AddAsync(cinema);
                
            }
            return RedirectToAction("Index");
        }
        //编辑页面
        public async Task<IActionResult> Edit(int cinemaId)
        {
            var cinema = await _cinemaService.GetByIdAsync(cinemaId);
            return View(cinema);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int Id,Cinema cinema)
        {
            var vm = await _cinemaService.GetByIdAsync(Id);
            if (vm == null)
            {
                return RedirectToAction("Edit");
            }

            vm.Name = cinema.Name;
            vm.Location = cinema.Location;
            vm.Capacity = cinema.Capacity;
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int cinemaId)
        {
            await _cinemaService.DeleteByIdAsync(cinemaId);
            return RedirectToAction("Index");
        }
    }
}
