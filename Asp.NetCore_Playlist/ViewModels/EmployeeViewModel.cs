namespace Asp.NetCore_Playlist.ViewModels
{
    public class EmployeeViewModel
    {
        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public string OrgName { get; set; }

        public List<IFormFile> Files { get; set; }
    }
}
