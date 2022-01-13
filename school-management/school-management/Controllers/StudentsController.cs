using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using school_management.Data;
using school_management.Models;
using school_management.ViewModels;

namespace school_management.Controllers
{
    public class StudentsController : Controller
    {
        private readonly school_managementContext _context;

        public StudentsController(school_managementContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(_context.Student.Include(c => c.Parent)
                .Include(s => s.@class)
                .Include(s => s.Teachers)
                .ToList()
                .Select(s => new StudentViewModel(s.Id, s.FirstName, s.LastName, s.BirthDate, s.Parent, s.@class, s.Teachers)));
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var s = await _context.Student
                .Where(m => m.Id == id)
                .Include(c => c.Parent).FirstAsync();

            if (s == null)
            {
                return NotFound();
            }

            return View( new StudentViewModel(s.Id, s.FirstName, s.LastName, s.BirthDate, s.Parent, s.@class, s.Teachers));
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewBag.Parents = _context.Parent
                .ToList()
                .Select(t => new ParentViewModel(t.Id, t.FirstName + " " + t.LastName));

            ViewBag.Classes = _context.Class
                .ToList();

            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string FirstName, string LastName, DateTime BirthDate, int ParentId, int? ClassId)
        {
            var parent = await _context.Parent.FindAsync(ParentId);
            var @class = await _context.Class.FindAsync(ClassId);
            
            var student = new Student { FirstName = FirstName, LastName  = LastName, BirthDate = BirthDate, Parent = parent, @class =  @class };
            
            await _context.Student.AddAsync(student);
            await _context.SaveChangesAsync();



            return RedirectToAction(nameof(Index));
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            ViewBag.Parents = _context.Parent
                .ToList()
                .Select(t => new ParentViewModel(t.Id, t.FirstName + " " + t.LastName));

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string FirstName, string LastName, DateTime BirthDate, int ParentId)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return View();
            }

            var parent = await _context.Parent.FindAsync(ParentId);

            student.FirstName= FirstName;
            student.LastName= LastName;
            student.BirthDate= BirthDate;
            student.Parent= parent;

            _context.Update(student);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
    }
}
