public class Personaje 
{
   public string? Nombre {get; set;}
   public int VidaMáxima {get; set;} 
   public double VidaActual {get; set;} 
   public int ManáMáximo {get; set;} 
   public double ManaActual {get; set;}
   public int Fuerza  {get; set;}
   public int Defensa {get; set;}
   public string? Color {get; set;}
   public Inventario Inventario { get; set; } = new Inventario(); 


public void RecibirDanio(int cantidad)
{
int danioReal = Math.Max(0, cantidad - Defensa);
VidaActual -= danioReal;
if (VidaActual < 0) VidaActual = 0;

Console.WriteLine($"{Nombre} recibió {danioReal} de daño.");
}

public void CambiarColor(string nuevoColor)
{
Color = nuevoColor;
}

public void Atacar(Personaje enemigo)
{
Console.WriteLine($"{Nombre} ataca a {enemigo.Nombre}");
enemigo.RecibirDanio(Fuerza);   
}

public int TomarPocion(Pocion pocion)
{
return pocion.Usar(this);
}


public void Mostrar()
{
Console.WriteLine($"-{Nombre} ---");
Console.WriteLine($"Vida: {VidaActual}/{VidaMáxima}");
Console.WriteLine($"Mana: {ManaActual}/{ManáMáximo}");
Console.WriteLine($"Fuerza: {Fuerza}");
Console.WriteLine($"Defensa: {Defensa}");
Console.WriteLine($"Color: {Color}");
Console.WriteLine();
} 

}

