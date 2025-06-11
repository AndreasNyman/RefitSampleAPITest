using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RefitSampleAPITest.Models;
using RefitSampleAPITest.Services;

namespace RefitSampleAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            try
            {
                var posts = await _postService.GetPostsAsync();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving posts: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            try
            {
                var post = await _postService.GetPostByIdAsync(id);
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving post: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] Post post)
        {
            if (post == null)
            {
                return BadRequest("Post cannot be null");
            }
            try
            {
                var createdPost = await _postService.CreatePostAsync(post);
                return CreatedAtAction(nameof(GetPostById), new { id = createdPost.Id }, createdPost);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating post: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] Post post)
        {
            if (post == null || post.Id != id)
            {
                return BadRequest("Post data is invalid");
            }
            try
            {
                var updatedPost = await _postService.UpdatePostAsync(id, post);
                if (updatedPost == null)
                {
                    return NotFound();
                }
                return Ok(updatedPost);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating post: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await _postService.DeletePostAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting post: {ex.Message}");
            }
        }
    }
}
