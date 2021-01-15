namespace NeedAHand.Domain
{
    public class EventosCategorias : ICategorias
    {
        public Category Categoria =>
            Category.Eventos;
        public enum SubCategorias
        {
            Animadores = 0,
            Churrasqueiro = 1,
            Decoração = 2,
            Fotógrafo = 3,
            Garçom = 4,
            Barman = 5,
            Segurança = 6,
            Doces = 7,
            Salgados = 8,
            Buffet = 9,
            Cerimonialista = 10,
            Música = 11
        }
    }

}