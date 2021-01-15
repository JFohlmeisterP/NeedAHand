namespace NeedAHand.Domain
{
    public class LimpezaCategorias : ICategorias
    {
        public Category Categoria =>
            Category.Limpeza;
        public enum SubCategorias
        {
            Casa = 0,
            Piscina = 1,
            Jardim = 2,
            EstabelecimentoComercial = 3,
            Prédio = 4,
            Automóvel = 5
        }
    }

}