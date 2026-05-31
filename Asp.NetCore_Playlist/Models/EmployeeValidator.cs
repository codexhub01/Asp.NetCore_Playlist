using FluentValidation;

namespace Asp.NetCore_Playlist.Models
{
    public class EmployeeValidator :AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(s => s.Email).NotEmpty().EmailAddress();
        }
    }
}
