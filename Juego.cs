using System;

public class Juego
{
    public Personaje? p1;
    public Personaje? p2;

        public void Iniciar()
        {
            p1 = CrearPersonaje("Jugador 1");
            p2 = CrearPersonaje("Jugador 2");

            LoopJuego();
        }

        private void LoopJuego()
        {
            while (true)
            {
                Console.Clear();
                p1!.Mostrar();
                p2!.Mostrar();

                Console.WriteLine("\n1. Cambiar color");
                Console.WriteLine("2. Recibir daño");
                Console.WriteLine("3. Atacar");
                Console.WriteLine("4. Usar poción");

                if (!int.TryParse(Console.ReadLine(), out int opcion))
                    continue;

                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        Console.Write("Color: ");
                        string? colorInput = Console.ReadLine();
                        if (colorInput != null)
                            p1!.CambiarColor(colorInput);
                        break;

                    case 2:
                        Console.Write("Daño: ");
                        if (int.TryParse(Console.ReadLine(), out int danio))
                            p1!.RecibirDanio(danio);
                        break;

                    case 3:
                        p1!.Atacar(p2!);
                        break;

                    case 4:
                        UsarPocion();
                        break;
                    default:
                        break;
                }

                if (p1!.VidaActual <= 0)
                {
                    Console.WriteLine("Jugador 1 derrotado");
                    Console.WriteLine("1. Reiniciar | 2. Salir");

                    if (int.TryParse(Console.ReadLine(), out int op))
                    {
                        if (op == 1) Iniciar();
                        else break;
                    }
                    else break;
                }

                Console.ReadKey();
            }
        }

        private void UsarPocion()
        {
            Console.WriteLine("1. Jugador 1\n2. Jugador 2");
            if (!int.TryParse(Console.ReadLine(), out int obj)) return;

            Console.WriteLine("1. Vida\n2. Maná");
            if (!int.TryParse(Console.ReadLine(), out int tipo)) return;

            Pocion pocion = tipo == 1 ? new PocionVida() : new PocionMana();

            if (obj == 1)
                p1!.TomarPocion(pocion);
            else
                p2!.TomarPocion(pocion);
        }

        private Personaje CrearPersonaje(string label)
        {
            Console.WriteLine($"--- {label} ---");

            var p = new Personaje();

            Console.Write("Nombre: ");
            string? nombre = Console.ReadLine();
            p.Nombre = nombre ?? "Sin nombre";

            Console.Write("Vida: ");
            if (int.TryParse(Console.ReadLine(), out int vida))
                p.VidaMáxima = vida;
            p.VidaActual = p.VidaMáxima;

            Console.Write("Maná: ");
            if (int.TryParse(Console.ReadLine(), out int mana))
                p.ManáMáximo = mana;
            p.ManáActual = p.ManáMáximo;

            Console.Write("Fuerza: ");
            if (int.TryParse(Console.ReadLine(), out int fuerza))
                p.Fuerza = fuerza;

            Console.Write("Defensa: ");
            if (int.TryParse(Console.ReadLine(), out int defensa))
                p.Defensa = defensa;

            Console.Write("Color: ");
            string? color = Console.ReadLine();
            p.Color = color ?? "White";

            return p;
        }
    }
