using Living.Application.UseCases.Posts.Create;

namespace Living.Tests;

public class UnitTest1 : SetupWebAPI
{
    [Theory, AutoData]
    public async Task Test1(CreatePostCommand command)
    {
        var response = await client.PostAsync("/api/posts", command.AsJsonContent());

        response.Content.Should().NotBeNull();
        var content = await response.Content.DeserializeContent<BaseResponse<Guid>>();

    }
}