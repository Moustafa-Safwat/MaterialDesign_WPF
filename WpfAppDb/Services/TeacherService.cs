using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppDb.Models;
using WpfAppDb.Services.Interfaces;
using WpfAppDb.Services.ExtensionMethods;

namespace WpfAppDb.Services
{
    internal class TeacherService : ITeacherService
    {
        #region private fields
        private static List<Teacher> _teachers = new List<Teacher>();
        #endregion

        #region Constructor
        public TeacherService()
        {

        }
        #endregion

        #region Methods

        /// <summary>
        /// Add new Teacher in the List
        /// </summary>
        /// <param name="teacher">The new teacher to be added</param>
        public void Add(Teacher teacher)
        {
            if (teacher is null)
                return;
            int newId = default;
            if (newId < 0 || _teachers.Count == 0)
                newId = 1;
            else
                newId = _teachers.Max(teacher => teacher.Id) + 1;
            // if the id is negative convert it to 1
            teacher!.Id = newId;
            _teachers.Add(teacher);
        }

        /// <summary>
        /// Delete the teacher from the list based on the id of the teacher
        /// </summary>
        /// <param name="teachedId">The id of the teacher to be deleted</param>
        /// <returns>if the delete process is done succeffully it will return true, otherwise it return false</returns>
        public bool Delete(int teachedId)
        {
            // check if the list is null or empty
            bool isTeacherNullOrEmpty = _teachers.Count == 0 || _teachers is { };
            if (isTeacherNullOrEmpty)
                return false;
            // get the teacher based on the id
            Teacher? teacherFromList = _teachers?.FirstOrDefault(teacher => teacher.Id == teachedId);
            // Check the teacher located in the list
            if (teacherFromList is null)
                return false;
            // Remove the teacher from the list
            _teachers?.Remove(teacherFromList);
            return true;
        }

        /// <summary>
        /// Get all teacher stored in the list
        /// </summary>
        /// <returns>return the list of the teachers</returns>
        public IEnumerable<Teacher> GetAll()
        {
            return _teachers;
        }

        /// <summary>
        /// Get the teacher by the id
        /// </summary>
        /// <param name="teachedId">the id of the teacher to get the teacher by it</param>
        /// <returns>return the teacher id exists if not return null</returns>
        public Teacher? GetById(int teachedId)
        {
            bool isTeacherNullOrEmpty = _teachers.Count == 0 || _teachers is { };
            if (isTeacherNullOrEmpty)
                return null;
            // get the teach based on the id
            Teacher? teacherFromList = _teachers?.FirstOrDefault(teacher => teacher.Id == teachedId);
            // Check the teacher located in the list
            if (teacherFromList is null)
                return null;
            return teacherFromList;
        }

        /// <summary>
        /// Update the teacher in the list based on the id and the teacher object
        /// </summary>
        /// <param name="teacher">the teach to be updated</param>
        /// <param name="teachedId">the id of the teacher to be updated</param>
        /// <returns>if the updated process is done succeffully it will return true, otherwise it return false</returns>
        public bool Update(Teacher teacher, int teachedId)
        {
            // check if the list is null or empty
            bool isTeacherNullOrEmpty = _teachers.Count == 0 || _teachers is { };
            if (isTeacherNullOrEmpty)
                return false;
            // get the teach based on the id
            Teacher? teacherFromList = _teachers?.FirstOrDefault(teacher => teacher.Id == teachedId);
            // Check the teacher located in the list
            if (teacherFromList is null)
                return false;
            // Update the teacher from the list
            teacherFromList
                .SetEmail(teacher.Email)
                .SetAddress(teacher.Address)
                .SetName(teacher.Name)
                .SetSalary(teacher.Salary);
            return true;
        }

        #endregion
    }
}
