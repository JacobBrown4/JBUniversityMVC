using JBUniversity.Models;
using JBUniversity.Models.Student;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBUniversity.Services
{
    public interface IStudentService
    {
        Task<StudentSortViewModel> GetAllAsync(string time, string searchString);
        Task<StudentDetail> Details(int? id);

        Task<bool> Create(StudentCreate student);

        Task<StudentEdit> Edit(int? id);

        Task<bool> Edit(int id, StudentEdit student);

        Task<StudentDetail> Delete(int? id);

        Task<bool> DeleteConfirmed(int id);
    }
}
