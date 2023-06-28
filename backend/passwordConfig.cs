using System.Text;

namespace backend.Password;

public static class passwordConfig{
    public static string getStringSalt(int qtd)
    {
        Random rnd = new Random();
        byte[] saltBytes = new byte[qtd];
        rnd.NextBytes(saltBytes);
        string salt = Encoding.Default.GetString(saltBytes);
        return salt;
    }

    public static byte[] getSaltBytesByString(string salt)
        =>  Encoding.Default.GetBytes(salt);
}