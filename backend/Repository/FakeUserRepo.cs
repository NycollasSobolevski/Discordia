

namespace backend;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Model;

public class FakeUserRepo : IRepository<Person>
{
    private List<Person> fakeData = new List<Person>()
    {
        new Person() 
        { 
            Id = 1,
            Name =  "Nycollas",
            Birth = DateTime.Now,
            Email = "nycollas@email.com",
            Photo = "",
            Password = "123456", // vai virar HASH
            Salt = "123456"      // vai ser gerado aleatorio
        },
        new Person(){
            Id = 2,
            Name =  "Irineu",
            Birth = DateTime.Now,
            Email = "irineu@email.com",
            Photo = "",
            Password = "123456", // vai virar HASH
            Salt = "123456"      // vai ser gerado aleatorio
        }
    };

    public void add(Person obj)
        => fakeData.Add(obj);

    public void Delete(Person obj)
        => fakeData.Remove(obj);

    public Task<List<Person>> Filter(Expression<Func<Person, bool>> exp)
    {
        throw new NotImplementedException();
    }

    public void Update(Person obj)
    {
        var old = fakeData
            .FirstOrDefault(m => m.Id == obj.Id);

        if (obj is null)
            return;

        fakeData.Remove(old);
        fakeData.Add(obj);
    }
}