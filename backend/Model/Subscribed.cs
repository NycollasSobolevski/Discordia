using System;
using System.Collections.Generic;

namespace backend.Model;

public partial class Subscribed
{
    public int Id { get; set; }

    public int? IdPerson { get; set; }

    public int? IdPosition { get; set; }

    public int? IdForum { get; set; }

    public virtual Forum IdForumNavigation { get; set; }

    public virtual Person IdPersonNavigation { get; set; }

    public virtual Position IdPositionNavigation { get; set; }
}
