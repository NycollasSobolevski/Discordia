

namespace backend.Data;

public class LoginData
{
    public string Indentify { get; set; }
    public string Password { get; set; }
}

public class ReturnLoginData
{
    public int IdPerson { get; set; }
}

public class ReturnLoginStringData
{
    public string IdPerson { get; set; }
}