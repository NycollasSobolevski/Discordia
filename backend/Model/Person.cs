using System;
using System.Collections.Generic;

namespace backend.Model;

public partial class Person
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Birth { get; set; }

    public string Email { get; set; } = null!;

    public string Photo { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public virtual ICollection<Forum> Forums { get; set; } = new List<Forum>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
