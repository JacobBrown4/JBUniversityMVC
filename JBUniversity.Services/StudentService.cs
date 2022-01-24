using JBUniversity.Data;
using JBUniversity.Data.Data;
using JBUniversity.Models;
using JBUniversity.Models.Student;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JBUniversity.Services
{
    public class StudentService : IStudentService
    {
        private readonly JBUniversityContext _context;

        public StudentService(JBUniversityContext context)
        {
            _context = context;
        }


        public async Task<StudentSortViewModel> GetAllAsync(string time, string searchString)
        {


            // Use LINQ to get list of genres.
            IQueryable<StudentType> typeQuery = _context.Students.OrderBy(s => s.TypeOfStudent).Select(s => ((StudentType)s.TypeOfStudent));
            // IQueryable<string> typeQuery = from m in _context.Students
            //orderby m.TypeOfStudent
            //select m.TypeOfStudent;

            var students = from m in _context.Students
                           select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => (s.FirstName + " " + s.LastName!).Contains(searchString));
            }

            if (!string.IsNullOrEmpty(time))
            {
                students = students.Where(x => ((StudentType)x.TypeOfStudent).ToString() == time);
            }

            var studentSortVM = new StudentSortViewModel
            {
                Type = new SelectList(await typeQuery.Distinct().ToListAsync()),
                Students = await students.Select(s => new StudentDisplay
                {
                    FullName = s.FirstName + " " + s.LastName,
                    StudentId = s.Id,
                    StudentType = (StudentType)s.TypeOfStudent,
                }).ToListAsync()
            };

            return studentSortVM;

        }


        public async Task<StudentDetail> Details(int? id)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);

            return new StudentDetail
            {
                FullName = student.FirstName + " " + student.LastName,
                StudentId = student.Id,
            };
        }

        public async Task<bool> Create(StudentCreate studentCreate)
        {
            var student = new Student
            {
                FirstName = studentCreate.FirstName,
                LastName = studentCreate.LastName,
                TypeOfStudent = (int)studentCreate.TypeOfStudent,
            };
            _context.Add(student);
            return await _context.SaveChangesAsync() == 1;
        }

        // Double check I don't need to add a null check here
        public async Task<StudentEdit> Edit(int? id)
        {
            var student = await _context.Students.FindAsync(id);

            return new StudentEdit
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                StudentId = student.Id,
                TypeOfStudent = (StudentType)student.TypeOfStudent,
            };
        }

        public async Task<bool> Edit(int id, StudentEdit studentEdit)
        {
            var student = new Student
            {
                Id = id,
                FirstName = studentEdit.FirstName,
                LastName = studentEdit.LastName,
                TypeOfStudent = (int)studentEdit.TypeOfStudent,
            };


            try
            {
                _context.Update(student);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(studentEdit.StudentId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;

        }

        // GET: Students/Delete/5
        public async Task<StudentDetail> Delete(int? id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
            var studentDetail = new StudentDetail
            {
                FullName = student.FirstName + " " + student.LastName,
                StudentId = student.Id,
            };

            return studentDetail;
        }

        public async Task<bool> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            return await _context.SaveChangesAsync() == 1;
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }

    }
}