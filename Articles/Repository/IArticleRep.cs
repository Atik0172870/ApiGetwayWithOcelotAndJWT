using Articles.Models;

namespace Articles.Repository
{
    public interface IArticleRep
    {
        Article AddArticle(Article article);
        bool RemoveArticle(int id);
        IEnumerable<Article> GetArticles();
    }
}
