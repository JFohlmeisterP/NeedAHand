namespace NeedAHand.Domain
{
    public class ConsertosCategorias : ICategorias
    {
        public Category Categoria =>
            Category.Consertos;
        public enum SubCategorias
        {
            Chaveiro = 0,
            Telhados = 1,
            Vidros = 2,
            Jardim = 3,
            Eletricista = 4,
            Encanador = 5,
            Eletros = 6,
            Lavanderia = 7,
            Pedreiro = 8,
            Piscina = 9,
            RedesProtecao = 10,
            Informatica = 11,
            Alarme = 12

        }
    }

}