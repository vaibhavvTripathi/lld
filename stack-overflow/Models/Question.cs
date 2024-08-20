namespace Stack.Models;
public class Question
{

    private string Id;
    private string AuthorUserId;
    public string Title { get; }
    public string Content { get; }
    public List<string> Tags { get; } = [];
    public List<Vote> Votes { get; private set; } = [];
    public List<Answer> Answers { get; private set; } = [];
    public DateTime CreationDate { get; }
    public Question(string authorUserId, string title, string content)
    {
        this.Id = Guid.NewGuid().ToString();
        this.AuthorUserId = authorUserId;
        this.Title = title;
        this.Content = content;
        this.CreationDate = DateTime.UtcNow;
    }

    public void AddVote(string userId)
    {
        Votes.Add(new(userId));
    }
    public void AddTags(string tag)
    {
        Tags.Add(tag);
    }
}