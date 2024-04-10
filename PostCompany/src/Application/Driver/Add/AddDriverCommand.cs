using Common.Application;
using Common.Domain.ValueObjects;

namespace Application.Driver.Add;
public class AddDriverCommand : IBaseCommand
{
    public PhoneNumber PhoneNumber { get; set; }
    public string FullName { get; set; }
}