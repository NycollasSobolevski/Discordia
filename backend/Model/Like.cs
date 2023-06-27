using System;
using System.Collections.Generic;

namespace backend.Model;

public partial class Like
{
    public int Id { get; set; }

    public bool Positive { get; set; }

    public int IdPerson { get; set; }

    public int IdPost { get; set; }

    public virtual Person IdPersonNavigation { get; set; }

    public virtual Post IdPostNavigation { get; set; }
}
