namespace NeedAHand.Domain
{
    public class TransportesCategorias : ICategorias
    {
        public Category Categoria =>
            Category.Transportes;
        public enum SubCategorias
        {
            Frete = 0,
            Motoboy = 1,
            Motorista = 2,
            AuxiliarCarga = 3
        }
    }

}