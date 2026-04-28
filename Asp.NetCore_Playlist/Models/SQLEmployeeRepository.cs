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
    }
}
