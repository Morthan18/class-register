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
    public class GradesController : Controller
    {
        private readonly school_managementContext _context;

        public GradesController(school_managementContext context)
        {
            _context = context;
        }

        // GET: Grades
        public async Task<IActionResult> Index(int studentId, int subjectId, string dateFrom, string dateTo)
        {
            var newContext = await _context.Grade
                .Include(g => g.SchoolSubject)
                .Include(g => g.Student)
                .ToListAsync();
            ViewBag.allGrades = newContext;
            ViewBag.selectedDateFrom = "";
            ViewBag.selectedDateTo = "";
            if (studentId != 0)
            {
                newContext = newContext.FindAll(element =>element.Student.Id.Equals(studentId));
            }
            if (subjectId != 0)
            {
                newContext = newContext.FindAll(element => element.SchoolSubject.Id.Equals(subjectId));
            }

            if (dateFrom != null && dateTo != null)
            {
                ViewBag.selectedDateFrom = dateFrom;
                ViewBag.selectedDateTo = dateTo;
                var parsedDateFrom = DateTime.Parse(dateFrom);
                var parsedDateTo = DateTime.Parse(dateTo);
                newContext = newContext.FindAll(element => (
                element.ModifiedDate.CompareTo(parsedDateFrom) > 0
                && element.ModifiedDate.CompareTo(parsedDateTo.AddDays(1)) < 0
                ));

            }
            ViewBag.selectedStudentId = studentId;
            ViewBag.selectedSubjectId = subjectId;
            return View(newContext);
        }

        // GET: Grades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.Grade
                .Where(m => m.Id == id)
                .Include(s => s.SchoolSubject)
                .Include(s => s.Student)
                .FirstAsync();
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // GET: Grades/Create
        public IActionResult Create()
        {
            ViewBag.Students = _context.Student.ToList();
            ViewBag.SchoolSubjects = _context.SchoolSubject.ToList();

            return View();
        }

        // POST: Grades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int GradeNumber, string Description, int StudentId, int SchoolSubjectId)
        {
            var student = await _context.Student.FindAsync(StudentId);
            var schoolSubject = await _context.SchoolSubject.FindAsync(SchoolSubjectId);

            var grade = new Grade{ GradeNumber = GradeNumber, Description = Description, Student = student, SchoolSubject = schoolSubject, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now };

            await _context.Grade.AddAsync(grade);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        // GET: Grades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.Students = _context.Student.ToList();
            ViewBag.SchoolSubjects = _context.SchoolSubject.ToList();

            var grade = await _context.Grade
                .Where(m => m.Id == id)
                .Include(s => s.Student)
                .Include(s => s.SchoolSubject)
                .FirstAsync();
            if (grade == null)
            {
                return NotFound();
            }
            return View(grade);
        }

        // POST: Grades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, int GradeNumber, string Description, int StudentId, int SchoolSubjectId)
        {
            if (id == null)
            {
                return NotFound();
            }
            var grade = await _context.Grade
                .Where(s => s.Id == id)
                .Include(s => s.Student)
                .Include(s => s.SchoolSubject)
                .FirstAsync();

            if (grade == null)
            {
                return View();
            }

            var student = await _context.Student.FindAsync(StudentId);
            var schoolSubject = await _context.SchoolSubject.FindAsync(SchoolSubjectId);

            grade.GradeNumber = GradeNumber;
            grade.Description = Description;
            grade.Student = student;
            grade.SchoolSubject = schoolSubject;
            grade.ModifiedDate = DateTime.Now;

            _context.Update(grade);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Grades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.Grade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // POST: Grades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grade = await _context.Grade.FindAsync(id);
            _context.Grade.Remove(grade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradeExists(int id)
        {
            return _context.Grade.Any(e => e.Id == id);
        }
    }
}
