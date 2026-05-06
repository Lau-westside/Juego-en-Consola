public abstract class Pocion
{
public int Min{ get; set; }
public int Max { get; set; }

protected Random rnd = new Random();

public abstract int Usar(Personaje p);
}