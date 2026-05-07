public class Inventario 
{
    public Personaje Personaje { get; set; }
    public List<Item> Items { get; set; } = new();

    public void AgregarItem(Item item)
    {
        Items.Add(item);
        item.Inventario = this;
    } 

    public void quitarItem(Item item)
    {
        Items.Remove(item);
        item.Inventario = null;
    }
}