public record PostData
{
    public string CreatorIdJwt { get; set; }
    public string ForumTitle { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public bool? Attachment { get; set; }
    public DateTime? Created { get; set; }
}

public record GetPostData 
{
    public string Jwt { get; set; }
    public int Page { get; set; }
    public int Quantity { get; set; }
}