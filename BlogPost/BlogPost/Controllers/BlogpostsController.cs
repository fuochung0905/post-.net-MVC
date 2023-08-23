using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogPost.DataContext;
using BlogPost.Models;
using AutoMapper;
using BlogPost.Service;

namespace BlogPost.Controllers
{
    public class BlogpostsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public BlogpostsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: Blogposts
        public async Task<IActionResult> Index()
        {
         
        }

        // GET: Blogposts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Blogposts == null)
            {
                return NotFound();
            }

            var blogpost = await _context.Blogposts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogpost == null)
            {
                return NotFound();
            }

            return View(blogpost);
        }

        // GET: Blogposts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blogposts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Heading,Pagetitle,Content,Shortdescription,Featuredimage,Urlhandle,Publisheddate,Author,Visible")] Blogpost blogpost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogpost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogpost);
        }

        // GET: Blogposts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Blogposts == null)
            {
                return NotFound();
            }

            var blogpost = await _context.Blogposts.FindAsync(id);
            if (blogpost == null)
            {
                return NotFound();
            }
            return View(blogpost);
        }

        // POST: Blogposts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Heading,Pagetitle,Content,Shortdescription,Featuredimage,Urlhandle,Publisheddate,Author,Visible")] Blogpost blogpost)
        {
            if (id != blogpost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogpost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogpostExists(blogpost.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blogpost);
        }

        // GET: Blogposts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Blogposts == null)
            {
                return NotFound();
            }

            var blogpost = await _context.Blogposts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogpost == null)
            {
                return NotFound();
            }

            return View(blogpost);
        }

        // POST: Blogposts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Blogposts == null)
            {
                return Problem("Entity set 'BlogpostContext.Blogposts'  is null.");
            }
            var blogpost = await _context.Blogposts.FindAsync(id);
            if (blogpost != null)
            {
                _context.Blogposts.Remove(blogpost);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogpostExists(int id)
        {
          return (_context.Blogposts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
