namespace Asp.NetCore_Playlist.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        List<Employee> GetAllEmployees();

        Employee Update(Employee employee);

        public bool UpdateFormData(Employee emp);

        //Employee Add(Employee employee);
    }
}
