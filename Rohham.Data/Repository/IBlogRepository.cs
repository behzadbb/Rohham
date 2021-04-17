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
        Category GetCategoryByName(string name);
        Article GetArticle(int articleId);
        IList<Article> GetArticlesByCatName(string catName);
        IList<Category> GetCategories();
        IList<Article> GetArticles();
    }
}
