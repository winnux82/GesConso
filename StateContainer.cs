using GesConso.Entities;

namespace GesConso
{
    public class StateContainer
    {
        public List<Article> Articles { get; set; } = new();
        public List<Commande> Commandes { get; set; } = new();
    }
}
