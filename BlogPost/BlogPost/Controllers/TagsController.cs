using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogPost.DataContext;
using BlogPost.Models;
using BlogPost.Service;
using AutoMapper;
using BlogPost.Dto;

namespace BlogPost.Controllers
{
    public class TagsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public TagsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
           _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: Tags
        public ActionResult Index()
        {
            var tag = _unitOfWork.Tag.GetAll();
            var tagdto = _mapper.Map<List<tagDto>>(tag);
            return View(tagdto);
        }

        // GET: Tags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
           

            return View();
        }

        // GET: Tags/Create
        public ActionResult Create()
        {
            return View();
        }
        

        // POST: Tags/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tagDto tagdto)
        {
            try
            {
                var tag = _mapper.Map<Tag>(tagdto);
                _unitOfWork.Tag.Insert(tag);
                _unitOfWork.Save();

                return RedirectToAction("Index", "Tags");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tags/Delete/5
        public ActionResult Detail(int id)
        {
            var tag = _unitOfWork.Tag.GetById(id);
            var dto=_mapper.Map<tagDto>(tag);
            return View(dto);
        }

        // GET: Tags/Edit/5
        public ActionResult Edit(int id)
        {
            var tag = _unitOfWork.Tag.GetById(id);
            var dto = _mapper.Map<tagDto>(tag);
            return View(dto);
        }
        // POST: Tags/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tagDto tagdto)
        {
            try
            {
                var tag = _mapper.Map<Tag>(tagdto);
                _unitOfWork.Tag.Update(tag);
                _unitOfWork.Save();

                return RedirectToAction("Index", "Tags");
            }
            catch
            {
                return View();
            }

        }
        //Get Tags/Delete/5
        public ActionResult Delete(int id)
        {
            var tag = _unitOfWork.Tag.GetById(id);
            var dto = _mapper.Map<tagDto>(tag);
            return View(dto);
        }
        // POST: Tags/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(tagDto tagdto)
        {
            try
            {
                var tag = _mapper.Map<Tag>(tagdto);
                _unitOfWork.Tag.Delete(tag);
                _unitOfWork.Save();

                return RedirectToAction("Index", "Tags");
            }
            catch
            {
                return View();
            }

        }












    }
}
