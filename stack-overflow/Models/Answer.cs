public class Answer(string content, string authorUserId, string associatedQuestionId)
{
    private readonly string Id = Guid.NewGuid().ToString();
    public string Content { get; } = content;
    public string AuthorUserId { get; } = authorUserId;
    public string AssociatedQuestionId { get; } = associatedQuestionId;
    public List<Vote> Votes { get; private set; } = []; //
    public List<string> Tags { get; private set; } = []; //
    public DateTime Date { get; } = DateTime.UtcNow;

    public void AddVote(string userId)
    {
        Votes.Add(new(userId));
    }

    public void AddTags(string tag)
    {
        Tags.Add(tag);
    }


}
