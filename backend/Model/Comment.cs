using System;
using System.Collections.Generic;

namespace backend.Model;

public partial class Comment
{
    public int Id { get; set; }

    public string Comment1 { get; set; }

    public int IdPerson { get; set; }

    public int IdPost { get; set; }

    public virtual Person IdPersonNavigation { get; set; }

    public virtual Post IdPostNavigation { get; set; }
}
