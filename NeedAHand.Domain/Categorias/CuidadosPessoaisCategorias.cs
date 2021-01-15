namespace NeedAHand.Domain
{
    public class CuidadosPessoaisCategorias : ICategorias
    {
        public Category Categoria =>
            Category.CuidadosPessoais;
        public enum SubCategorias
        {
            AcompanhanteIdoso = 0,
            Acupuntura = 1,
            Estética = 2,
            Unhas = 3,
            Fisioterapia = 4,
            TerapiasAlternativas = 5,
            Cabelo = 6,
            Maquiagem = 7,
            Massoterapia = 8,
            AcompanhantePCD = 9,
            Nutricionista = 10
        }
    }   

}