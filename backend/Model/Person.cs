using System;
using System.Collections.Generic;

namespace backend.Model;

public partial class Person
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime Birth { get; set; }

    public string Email { get; set; }

    public string Photo { get; set; }

    public string Password { get; set; }

    public string Salt { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Forum> Forums { get; set; } = new List<Forum>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Subscribed> Subscribeds { get; set; } = new List<Subscribed>();
}
