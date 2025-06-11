using Refit;
using RefitSampleAPITest.Models;

namespace RefitSampleAPITest.Services
{
    public interface IPostService
    {
        [Get("/posts")]
        Task<List<Post>> GetPostsAsync();
        
        [Get("/posts/{id}")]
        Task<Post> GetPostByIdAsync(int id);
        
        [Post("/posts")]
        Task<Post> CreatePostAsync([Body] Post post);
        
        [Put("/posts/{id}")]
        Task<Post> UpdatePostAsync(int id, [Body] Post post);
        
        [Delete("/posts/{id}")]
        Task DeletePostAsync(int id);
    }
}
