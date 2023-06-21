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
                NotifyCommandeArticlesUpdated();
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
        public event Action? OnCommandesUpdated;
        public event Action? OnCommandeArticlesUpdated;
        public event Action? OnArticleSelected;
        public event Action? OnCommandeSelected;
        public event Action? OnCommandeArticleSelected;

        public void NotifyArticlesUpdated() => OnArticleUpdated?.Invoke();
        public void NotifyCommandesUpdated() => OnCommandesUpdated?.Invoke();
        public void NotifyCommandeArticlesUpdated() => OnCommandeArticlesUpdated?.Invoke();


        //public void AddArticle(Article article)
        //{
        //    articles.Add(article);
        //    NotifyArticlesUpdated();
        //}

        //public void RemoveArticle(Article article)
        //{
        //    articles.Remove(article);
        //    NotifyArticlesUpdated();
        //}

        //public void AddCommande(Commande commande)
        //{
        //    commandes.Add(commande);
        //    NotifyCommandesUpdated();
        //}

        //public void RemoveCommande(Commande commande)
        //{
        //    commandes.Remove(commande);
        //    NotifyCommandesUpdated();
        //}

        //public void AddCommandeArticle(CommandeArticle commandeArticle)
        //{
        //    commandeArticles.Add(commandeArticle);
        //    NotifyCommandeArticlesUpdated();
        //}

        //public void RemoveCommandeArticle(CommandeArticle commandeArticle)
        //{
        //    commandeArticles.Remove(commandeArticle);
        //    NotifyCommandeArticlesUpdated();
        //}
    }
}
