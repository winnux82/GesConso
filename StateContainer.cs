using GesConso.Entities;

namespace GesConso
{
    public class StateContainer
    {
        private List<Article> articles = new();
        private List<Commande> commandes = new();
        private List<CommandeArticle> commandeArticles = new();

        public List<Article> Articles
        {
            get => articles;
            set
            {
                articles = value;
                NotifyArticlesUpdated();
            }
        }

        public List<Commande> Commandes
        {
            get => commandes;
            set
            {
                commandes = value;
                NotifyCommandesUpdated();
            }
        }

        public List<CommandeArticle> CommandeArticles
        {
            get => commandeArticles;
            set
            {
                commandeArticles = value;
                NotifyCommandeArticlesUpdated();
            }
        }

        public event Action? OnArticlesUpdated;
        public event Action? OnCommandesUpdated;
        public event Action? OnCommandeArticlesUpdated;

        public void NotifyArticlesUpdated() => OnArticlesUpdated?.Invoke();
        public void NotifyCommandesUpdated() => OnCommandesUpdated?.Invoke();
        public void NotifyCommandeArticlesUpdated() => OnCommandeArticlesUpdated?.Invoke();
    }
}
