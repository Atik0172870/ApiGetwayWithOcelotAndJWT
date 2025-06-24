using Articles.Models;

namespace Articles.Repository
{
    public static class ArticleData
    {
        public static List<Article> Articles { get; set; } =
        [
            new () { Id = 1, Name = "Article 1" },
            new () { Id = 2, Name = "Article 2" },
            new () { Id = 3, Name = "Article 3" },
            new () { Id = 4, Name = "Article 4" },
            new () { Id = 5, Name = "Article 5" }
        ];
    }
    public class ArticleRep : IArticleRep
    {
        public Article AddArticle(Article article)
        {
            ArticleData.Articles.Add(article);
            return article;
        }

        public IEnumerable<Article> GetArticles()
        {
          return  ArticleData.Articles;
        }

        public bool RemoveArticle(int id)
        {
            var item = ArticleData.Articles.FirstOrDefault(x => x.Id == id);
            if(item == null)
            {
                return false;
            }
            ArticleData.Articles.Remove(item);
            return true;
        }
    }
}
