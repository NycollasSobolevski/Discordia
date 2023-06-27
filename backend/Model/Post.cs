using System;
using System.Collections.Generic;

namespace backend.Model;

public partial class Post
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? Attachment { get; set; }

    public int? IdForum { get; set; }

    public int? IdCreator { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Person IdCreatorNavigation { get; set; }

    public virtual Forum IdForumNavigation { get; set; }

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
}
