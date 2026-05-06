using Asp.NetCore_Playlist.ViewModels;

namespace Asp.NetCore_Playlist.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appdbcontext;
        public SQLEmployeeRepository(AppDbContext appDbContext)
        {
            _appdbcontext = appDbContext;
        }

        public Employee Delete(int id)
        {
            Employee employee = _appdbcontext.Employees.FirstOrDefault(s => s.Id == id);
            if (employee != null)
            {
                _appdbcontext.Employees.Remove(employee);
                _appdbcontext.SaveChanges();
            }
            return employee;
        }
        //public Employee Add(Employee employee)
        //{
        //    _appdbcontext.Employees.Add(employee);
        //    _appdbcontext.SaveChanges();
        //    return employee;
            
        //}

        public Employee Update(Employee employee)
        {
            var employees = _appdbcontext.Attach(employee);
            employees.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _appdbcontext.SaveChanges();
            return employee ;
        }
        public Employee GetEmployee(int id)
        {
            return _appdbcontext.Employees.FirstOrDefault(s => s.Id == id);
        }

        public List<Employee> GetAllEmployees()
        {
            return _appdbcontext.Employees.ToList();
        }

        public int UpdateFormData(EmployeeViewModel emp)
        {
            Employee obj = new Employee();
            obj.Address = emp.Address;
            obj.Name = emp.Name;
            obj.Email = emp.Email;
            obj.Department = emp.Department;
            obj.FilePath = "";
            obj.OrgName = emp.OrgName;
            _appdbcontext.Employees.Add(obj);
            _appdbcontext.SaveChanges();
            return obj.Id;
        }
        public bool UpdateEditData(EditEmployeeModel emp)
        {
            var data = _appdbcontext.Employees.Where(s => s.Id == emp.Id).ToList();
            data[0].Name = emp.Name;
            data[0].Address = emp.Address;
            data[0].Email = emp.Email;
            data[0].Department = emp.Department;
            _appdbcontext.SaveChanges();
            return true;
        }
    }
}
