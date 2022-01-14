using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using school_management.Data;
using school_management.Models;

namespace school_management.Controllers
{
    public class SchoolSubjectsController : Controller
    {
        private readonly school_managementContext _context;

        public SchoolSubjectsController(school_managementContext context)
        {
            _context = context;
        }

        // GET: SchoolSubjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.SchoolSubject
                .Include(s => s.Teacher)
                .ToListAsync());
        }

        // GET: SchoolSubjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolSubject = await _context.SchoolSubject
                .Where(m => m.Id == id)
                .Include(s => s.Teacher)
                .FirstAsync();

            if (schoolSubject == null)
            {
                return NotFound();
            }

            return View(schoolSubject);
        }

        // GET: SchoolSubjects/Create
        public IActionResult Create()
        {
            ViewBag.Teachers = _context.Teacher.ToList();

            return View();
        }

        // POST: SchoolSubjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Name, string SubjectContent, int TeacherId)
        {
            var teacher = await _context.Teacher.FindAsync(TeacherId);

            var schoolSubject = new SchoolSubject { Name = Name, SubjectContent = SubjectContent, Teacher = teacher};

            await _context.SchoolSubject.AddAsync(schoolSubject);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        // GET: SchoolSubjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.Teachers = _context.Teacher.ToList();

            var schoolSubject = await _context.SchoolSubject
                .Where(m => m.Id == id)
                .Include(s => s.Teacher)
                .FirstAsync();

            if (schoolSubject == null)
            {
                return NotFound();
            }
            return View(schoolSubject);
        }

        // POST: SchoolSubjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string Name, string SubjectContent, int TeacherId)
        {
            if (id == null)
            {
                return NotFound();
            }
            var schoolSubject = await _context.SchoolSubject
                .Where(s => s.Id == id)
                .Include(s => s.Teacher)
                .FirstAsync();

            if (schoolSubject == null)
            {
                return View();
            }

            var teacher = await _context.Teacher.FindAsync(TeacherId);

            schoolSubject.Name = Name;
            schoolSubject.SubjectContent= SubjectContent;
            schoolSubject.Teacher= teacher;

            _context.Update(schoolSubject);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: SchoolSubjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolSubject = await _context.SchoolSubject
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolSubject == null)
            {
                return NotFound();
            }

            return View(schoolSubject);
        }

        // POST: SchoolSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schoolSubject = await _context.SchoolSubject.FindAsync(id);
            _context.SchoolSubject.Remove(schoolSubject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolSubjectExists(int id)
        {
            return _context.SchoolSubject.Any(e => e.Id == id);
        }
    }
}
