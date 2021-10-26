using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BloggerContext _dbContext;

        public PostRepository(BloggerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Post Add(Post post)
        {
            post.Created = DateTime.UtcNow;
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();

            return post;
        }

        public void Delete(Post post)
        {
            _dbContext.Posts.Remove(post);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Post> GetAll()
        {
            return _dbContext.Posts;
        }

        public Post GetById(int id)
        {
            return _dbContext.Posts.SingleOrDefault(x => x.Id == id);
        }

        public void Update(Post post)
        {
            post.LastModified = DateTime.UtcNow;
            _dbContext.Posts.Update(post);
            _dbContext.SaveChanges();
        }
    }
}
