public record ForumData
{
    public string  CreatorIdJwt { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}

public record ForumToFront
{
    public string Creator { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? Created { get; set; }

}