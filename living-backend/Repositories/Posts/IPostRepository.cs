using living_backend.Models.Posts;

namespace living_backend.Repositories.Posts;

public interface IPostRepository
{
    Post? GetById(int id);
    Post? GetByIdWithUser(int id);
    Post? GetByIdWithAttachments(int id);
    Post? GetByIdWithLikes(int id);
    Post? GetByIdWithUserAndLikes(int id);
    Post? GetByIdWithUserAndAttachments(int id);
    Post? GetByIdWithUserAndAttachmentsAndLikes(int id);
    Post Create(Post post);
    Post Update(Post post);
    void Delete(int id);
    void AddAttachments(Post post, params Attachment[] attachment);
    void RemoveAttachments(Post post, params Attachment[] attachment);
    void ModifyAccess(int id, Access access);
}
