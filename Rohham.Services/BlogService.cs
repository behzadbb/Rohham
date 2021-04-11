using Rohham.Data.Repository;
using Rohham.Entities.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rohham.Services
{
    public interface IBlogService
    {
        void CreateArticle(Article article);
        void CreateCategory(Category category);
        Category GetCategory(int catId);
        Article GetArticle(int articleId);
        IList<Category> GetCategories();
        IList<Article> GetArticles();
    }

    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _repo;

        public BlogService(IBlogRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public void CreateArticle(Article article)
        {
            _repo.CreateArticle(article);
        }

        public void CreateCategory(Category category)
        {
            _repo.CreateCategory(category);
        }

        public Article GetArticle(int articleId)
        {
            return _repo.GetArticle(articleId);
        }

        public IList<Article> GetArticles()
        {
            return _repo.GetArticles();
        }

        public IList<Category> GetCategories()
        {
            return _repo.GetCategories();
        }

        public Category GetCategory(int catId)
        {
            throw new NotImplementedException();
        }
    }
}
