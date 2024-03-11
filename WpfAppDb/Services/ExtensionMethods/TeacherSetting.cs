using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfAppDb.Models;

namespace WpfAppDb.Services.ExtensionMethods
{
    internal static class TeacherSetting
    {
        internal static Teacher SetAddress(this Teacher teacher, string address)
        {
            teacher.Address = address;
            return teacher;
        }

        internal static Teacher SetEmail(this Teacher teacher, string email)
        {
            teacher.Email = email;
            return teacher;
        }

        internal static Teacher SetName(this Teacher teacher, string name)
        {
            teacher.Name = name;
            return teacher;
        }

        internal static Teacher SetSalary(this Teacher teacher, decimal salary)
        {
            teacher.Salary = salary;
            return teacher;
        }
    }
}
