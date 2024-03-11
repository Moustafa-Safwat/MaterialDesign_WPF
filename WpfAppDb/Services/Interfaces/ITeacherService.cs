using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppDb.Models;

namespace WpfAppDb.Services.Interfaces
{
    internal interface ITeacherService
    {
        #region CURD Methods
        public IEnumerable<Teacher> GetAll();
        public Teacher? GetById(int id);
        public void Add(Teacher teacher);
        public bool Update(Teacher teacher, int teachedId);
        public bool Delete(int teachedId); 
        #endregion
    }
}
