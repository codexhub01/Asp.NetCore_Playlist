namespace Asp.NetCore_Playlist.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _emplist;
        public MockEmployeeRepository()
        {
            _emplist = new List<Employee>()
            {
                new Employee() {Id = 1 , Name="roy" , Department ="cse" , Email="roy@gmail.com"},
                new Employee() {Id = 1 , Name="omk" , Department ="civi" , Email="omkar@gmail.com"},
                new Employee() {Id = 1 , Name="shivayee" , Department ="ca" , Email="shivaye@gmail.com"},

            };
        }
        public Employee GetEmployee(int id)
        {
            return _emplist.FirstOrDefault(s=>s.Id == id);
        }

        public List<Employee> GetAllEmployees()
        {
            return _emplist.ToList();
        }

        public Employee Delete(int id)
        {
            Employee employee = _emplist.FirstOrDefault(s=>s.Id ==id);  
            if(employee!=null)
            {
                _emplist.Remove(employee);
            }
            return employee;
        }
        public Employee Update(Employee employee)
        {
            Employee _employee = _emplist.FirstOrDefault(s => s.Id == employee.Id);
            if (employee != null)
            {
                _employee.Name = employee.Name;
                _employee.Department = employee.Department;
                _employee.Email = employee.Email;
            }
            return _employee;
        }
    }
}
