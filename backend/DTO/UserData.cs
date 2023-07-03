public record UserData
{
    string UserName { get; set; }
    string Email { get; set; }
    string Photo { get; set; }
    DateTime Birthday { get; set; }
} 

public record UserIdJwt
{
    public string JwT { get; set; }
}