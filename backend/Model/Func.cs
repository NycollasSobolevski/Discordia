using System;
using System.Collections.Generic;

namespace backend.Model;

public partial class Func
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
