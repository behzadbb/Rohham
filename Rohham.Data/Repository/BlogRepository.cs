﻿using Rohham.Data.Context;
using Rohham.Entities.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.Sql;



namespace Rohham.Data.Repository
{
    public class BlogRepository : IBlogRepository
    {
        public ApplicationDbContext _db;
        public ApplicationDbContext Db
        {
            get
            {
                if (_db == null)
                {
                    var factory = new ApplicationDbContextFactory();
                    _db = factory.CreateDbContext(new string[] { });
                }
                return _db;
            }
            set
            {
                _db = value;
            }
        }

        public void CreateArticle(Article article)
        {
            Db.Articles.Add(article);
            Db.SaveChanges();
        }

        public void CreateCategory(Category category)
        {
            Db.Categories.Add(category);
            Db.SaveChanges();
        }

        public Article GetArticle(int articleId)
        {
            return Db.Articles.Where(x=>x.Id==articleId).Include("User").FirstOrDefault();
        }

        public IList<Article> GetArticles()
        {
            return Db.Articles.Include("User").ToList();
        }

        public IList<Category> GetCategories()
        {
            return Db.Categories.ToList();
        }

        public Category GetCategory(int catId)
        {
            return Db.Categories.Find(catId);
        }
    }
}
