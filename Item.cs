public abstract class Item
{
    public Inventario? Inventario { get; set; }
    public abstract string Descripcion { get;}
    public abstract int Usar(Personaje p);
}