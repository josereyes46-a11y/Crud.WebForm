namespace Crud.DataLayer

{
    public class Producto
    {
        public int ClaveProducto { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad {get; set ; }
        public bool Estado { get; set; }
    }
}
