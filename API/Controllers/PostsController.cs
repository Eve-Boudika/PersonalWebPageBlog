using API.Model;
using API.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        private readonly PostService _postService;

        // Constructor que recibe el servicio por inyección de dependencias
        public PostsController(PostService postService)
        {
            _postService = postService;
        }
        // GET: api/<PostsController>
        [HttpGet]
        public async Task<ActionResult<List<BlogPost>>> GetPosts(int limit = 10)
        {
            return Ok(_postService.GetAllPosts(limit));
        }


        // POST api/<PostsController>
        [HttpPost]
        public IActionResult Post([FromBody] BlogPost blogPost)
        {
            if (blogPost is null)
                return BadRequest("BlogPost is null");

            PostService postservice = new PostService();
            postservice.AddPost(blogPost);
            return Ok();
        }
    }


}

