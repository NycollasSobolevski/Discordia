using backend.Model;
public record ForumData
{
    public string CreatorIdJwt { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}

public record ForumToFront
{
    public string Creator { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? Created { get; set; }

    public virtual int followers { get; set; } = 0;
    public virtual int posts { get; set; } = 0;

}

public record ForumWithPosts
{
    public string Creator { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? Created { get; set; }
    public List<PostData> Posts { get; set; } = new List<PostData>();
}