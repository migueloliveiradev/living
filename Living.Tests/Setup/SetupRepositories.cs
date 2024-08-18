using Living.Domain.Features.Posts.Interface;
using Living.Domain.Features.Users.Interfaces;

namespace Living.Tests.Setup;

#pragma warning disable S101
#pragma warning disable MA0048

public partial class SetupWebAPI
{
    protected IUserRepository UserRepository => GetService<IUserRepository>();
    protected IPostRepository PostRepository => GetService<IPostRepository>();
}
