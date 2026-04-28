namespace Asp.NetCore_Playlist.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        List<Employee> GetAllEmployees();

        Employee Update(Employee employee);

       

        //Employee Add(Employee employee);
    }
}
