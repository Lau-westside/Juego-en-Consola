class Program
{
static void Main()
{
Personaje p1 = CrearPersonaje("Jugador 1");
Personaje p2 = CrearPersonaje("Jugador 2");

bool jugando = true;

while (jugando)
{
MostrarEstado(p1, p2);

Console.WriteLine("1. Cambiar color");
Console.WriteLine("2. Recibir daño");
Console.WriteLine("3. Atacar");
Console.WriteLine("4. Usar poción");
Console.WriteLine("0. Salir");

int opcion = int.Parse(Console.ReadLine());

switch (opcion)
{
case 1:
Console.Write("Nuevo color: ");
string color = Console.ReadLine();
p1.CambiarColor(color);
break;

case 2:
Console.Write("Cantidad de daño: ");
int danio = int.Parse(Console.ReadLine());
p1.RecibirDanio(danio);
break;

case 3:
p1.Atacar(p2);
break;

case 4:
UsarPocion(p1, p2);
break;

case 0:
jugando = false;
break;
}

if (p1.VidaActual <= 0)
{
Console.WriteLine("Jugador 1, derrotado");
Console.WriteLine("1. Reiniciar");
Console.WriteLine("2. Salir");

int opcio = int.Parse(Console.ReadLine());

if (opcio == 1)
{
p1 = CrearPersonaje("Jugador 1");
p2 = CrearPersonaje("Jugador 2");
}
else
{
jugando = false;
}

} 

}

}

static Personaje CrearPersonaje(string titulo)
{
Personaje p = new Personaje();

Console.Clear();
Console.WriteLine($"˖˖˖˖˖˖˖˖˖˖—》{titulo}《—˖˖˖˖˖˖˖˖˖˖˖");
Console.Write("Nombre: ");
p.Nombre = Console.ReadLine();

Console.Write("Vida máxima: ");
p.VidaMáxima = int.Parse(Console.ReadLine());
p.VidaActual = p.VidaMáxima;

Console.Write("Mana máximo: ");
p.ManáMáximo = int.Parse(Console.ReadLine());
p.ManáActual = p.ManáMáximo;

Console.Write("Fuerza: ");
p.Fuerza = int.Parse(Console.ReadLine());

Console.Write("Defensa: ");
p.Defensa = int.Parse(Console.ReadLine());

Console.Write("Color: ");
p.Color = Console.ReadLine();

return p;
}

static void MostrarEstado(Personaje p1, Personaje p2)
{
Console.Clear();
p1.Mostrar();
p2.Mostrar();
}

static void UsarPocion(Personaje p1, Personaje p2)
{
Console.WriteLine("Selecciona el personaje, para aplicar la poción:");
Console.WriteLine("1. Jugador 1");
Console.WriteLine("2. Jugador 2");

int target = int.Parse(Console.ReadLine());
Personaje elegido = target == 1 ? p1 : p2;

Console.WriteLine("Tipo de poción:");
Console.WriteLine("1. Vida");
Console.WriteLine("2. Mana");

int tipo = int.Parse(Console.ReadLine());

Pocion pocion;

if (tipo == 1)
pocion = new PocionVida { Min = 10, Max = 50 };
else
pocion = new PocionMana { Min = 10, Max = 50 };

int recuperado = elegido.TomarPocion(pocion);

Console.WriteLine($"Se recuperó: {recuperado}");
Console.ReadKey();
}
}