using API.Model;
using API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace API.Service
{

    public class PostService
    {
        private readonly PostRepository _postRepository;

        public PostService()
        {
            _postRepository = new PostRepository();
        }

        public List<BlogPost> GetAllPosts(int limit)
        {
            return  _postRepository.GetPosts(limit);
        }
        public void AddPost(BlogPost blogPost)
        {
            // Aquí puedes añadir lógica adicional antes de guardar el post
            _postRepository.Add(blogPost);
        }
    }
}
