using System;
using System.Collections.Generic;

namespace backend.Model;

public partial class Permission
{
    public int Id { get; set; }

    public int? IdFuncs { get; set; }

    public int? IdPosition { get; set; }

    public virtual Func IdFuncsNavigation { get; set; }

    public virtual Position IdPositionNavigation { get; set; }
}
