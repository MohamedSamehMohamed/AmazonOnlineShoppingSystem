using System.ComponentModel.DataAnnotations;

namespace Domain.Users;

public class Common
{
    [Key] public string UserId { get; set; } = Guid.NewGuid().ToString();
    public string AuthenticationId { get; set; }
    public string Name { get; set; }
}