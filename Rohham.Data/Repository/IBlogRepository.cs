using Rohham.Entities.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rohham.Data.Repository
{
    public interface IBlogRepository
    {
        void CreateArticle(Article article);
        void CreateCategory(Category category);
        Category GetCategory(int catId);
        Article GetArticle(int articleId);
        IList<Category> GetCategories();
        IList<Article> GetArticles();
    }
}
