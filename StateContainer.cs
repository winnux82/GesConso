using GesConso.Entities;

namespace GesConso
{
    public class StateContainer
    {
        private List<Article> articles = new();
        private List<Commande> commandes = new();
        private List<CommandeArticle> commandeArticles = new();
        private Article? selectedArticle = null;
        private Commande? selectedCommande = null;
        private CommandeArticle? selectedCommandeArticle = null;

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
                NotifyCommandeArticleUpdated();
            }
        }

        public Article? SelectedArticle
        {
            get => selectedArticle;
            set
            {
                selectedArticle = value;
                OnArticleSelected?.Invoke();
            }
        }

        public Commande? SelectedCommande
        {
            get => selectedCommande;
            set
            {
                selectedCommande = value;
                OnCommandeSelected?.Invoke();
            }
        }

        public CommandeArticle? SelectedCommandeArticle
        {
            get => selectedCommandeArticle;
            set
            {
                selectedCommandeArticle = value;
                OnCommandeArticleSelected?.Invoke();
            }
        }

        public event Action? OnArticleUpdated;
        public event Action? OnCommandeUpdated;
        public event Action? OnCommandeArticleUpdated;
        public event Action? OnArticleSelected;
        public event Action? OnCommandeSelected;
        public event Action? OnCommandeArticleSelected;

        public void NotifyArticlesUpdated() => OnArticleUpdated?.Invoke();
        public void NotifyCommandesUpdated() => OnCommandeUpdated?.Invoke();
        public void NotifyCommandeArticleUpdated() => OnCommandeArticleUpdated?.Invoke();
    }
}
