using living_backend.Models.Posts;

namespace living_backend.DTOs.Request.Posts;

public class PostRequest
{
    public string Content { get; set; }
    public Access Access { get; set; }
    public List<IFormFile> Attachments { get; set; }

    public Post ToPost()
    {
        return new Post
        {
            Content = Content,
            Access = Access
        };
    }
}
