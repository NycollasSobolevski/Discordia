using System;
using System.Collections.Generic;

namespace backend.Model;

public partial class Position
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? IdForum { get; set; }

    public virtual Forum IdForumNavigation { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    public virtual ICollection<Subscribed> Subscribeds { get; set; } = new List<Subscribed>();
}
