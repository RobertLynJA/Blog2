namespace API.Models.Stories;

public class Story
{
    private string _id = string.Empty;
    public string ID
    {
        get => _id;
        set => _id = value ?? throw new ArgumentNullException(nameof(ID));
    }

    private string _title = string.Empty;
    public string Title
    {
        get => _title;
        set => _title = value ?? throw new ArgumentNullException(nameof(Title));
    }

    private string _content = string.Empty;
    public string Content
    {
        get => _content;
        set => _content = value ?? throw new ArgumentNullException(nameof(Content));
    }

    private DateTime _publishedDate = DateTime.UtcNow;
    public DateTime PublishedDate
    {
        get => _publishedDate;
        set
        {
            _publishedDate = value;
        }
    }

    public string _encoding = "markdown";
    public string Encoding
    {
        get => _encoding;
        set => _encoding = value ?? throw new ArgumentNullException(nameof(Encoding));
    }

    static public Story FromDAO(DataFacade.Models.Stories.Story story)
    {
        return new Story
        {
            ID = story.ID,
            Title = story.Title,
            Content = story.Content,
            PublishedDate = story.PublishedDate
        };
    }
}
