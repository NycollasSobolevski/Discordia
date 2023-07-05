public record PostData
{
    public string CreatorIdJwt { get; set; }
    public string ForumTitle { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public bool? Attachment { get; set; }
}