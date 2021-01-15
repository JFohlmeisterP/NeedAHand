namespace NeedAHand.Domain
{
    public class AulasCategorias : ICategorias
    {
        public Category Categoria =>
            Category.Aulas;
        public enum SubCategorias
        {
            Acadêmicos = 0,
            Línguas = 1,
            Música = 2,
            Computação = 3,
            Culinária = 4,
            Esportes = 5

        }
    }

}