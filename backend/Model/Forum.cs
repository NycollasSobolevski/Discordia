using System;
using System.Collections.Generic;

namespace backend.Model;

public partial class Forum
{
    public int Id { get; set; }

    public int CreatorId { get; set; }

    public string Title { get; set; }

    public DateTime? Created { get; set; }

    public string Description { get; set; }

    public virtual Person Creator { get; set; }

    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Subscribed> Subscribeds { get; set; } = new List<Subscribed>();
}
