using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataFacade.Models.Stories;

public class Story
{
    private string _id = string.Empty;
    [JsonRequired]
    public string Id
    {
        get => _id;
        set => _id = value ?? throw new ArgumentNullException(nameof(Id));
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
            _partitionKey = _publishedDate.Year.ToString();
        }
    }

    public string _encoding = "markdown";
    public string Encoding
    {
        get => _encoding;
        set => _encoding = value ?? throw new ArgumentNullException(nameof(Encoding));
    }

    private string _partitionKey = DateTime.UtcNow.Year.ToString();
    public string PartitionKey
    {
        get => _partitionKey;
        set => _partitionKey = value ?? throw new ArgumentNullException(nameof(PartitionKey));
    }
}
