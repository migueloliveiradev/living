using living_backend.DTOs.Request.Posts;
using living_backend.Models.Posts;
using living_backend.Shared.Extensions.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace living_backend.Controllers;
[ Route("/posts")]
public class PostController : Controller
{
    [HttpGet("timeline")]
    public IActionResult GetPostsTimeline()
    {
        return Ok();
    }
    [HttpGet("users/{username}")]
    public IActionResult GetPostsUser(string username)
    {
        return Ok();
    }
    [HttpGet("groups/{id}")]
    public IActionResult GetPostsGroup(string id)
    {
        return Ok();
    }
    [HttpGet("groups/{id}/user/{username}")]
    public IActionResult GetPostsGroupUser()
    {
        return Ok();
    }
    [HttpGet("{id}")]
    public IActionResult GetPost(int id)
    {
        return Ok();
    }

    [HttpPost("create")]
    public IActionResult CreatePost([FromBody] PostRequest postRequest)
    {
        Post post = postRequest.ToPost();
        post.UserId = User.GetId();
        return Ok(post);
    }
}
