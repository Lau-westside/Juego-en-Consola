using System;
using SistemaCombate.Entidades;
using SistemaCombate.Pociones;

namespace SistemaCombate.Servicios
{
    public class Juego
    {
        private Personaje p1;
        private Personaje p2;

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
                p1.Mostrar();
                p2.Mostrar();

                Console.WriteLine("\n1. Cambiar color");
                Console.WriteLine("2. Recibir daño");
                Console.WriteLine("3. Atacar");
                Console.WriteLine("4. Usar poción");

                int opcion = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        Console.Write("Color (0-15): ");
                        p1.CambiarColor((ConsoleColor)int.Parse(Console.ReadLine()));
                        break;

                    case 2:
                        Console.Write("Daño: ");
                        p1.RecibirDanio(int.Parse(Console.ReadLine()));
                        break;

                    case 3:
                        p1.Atacar(p2);
                        break;

                    case 4:
                        UsarPocion();
                        break;
                }

                if (p1.VidaActual <= 0)
                {
                    Console.WriteLine("Jugador 1 derrotado");
                    Console.WriteLine("1. Reiniciar | 2. Salir");

                    int op = int.Parse(Console.ReadLine());
                    if (op == 1) Iniciar();
                    else break;
                }

                Console.ReadKey();
            }
        }

        private void UsarPocion()
        {
            Console.WriteLine("1. Jugador 1\n2. Jugador 2");
            int obj = int.Parse(Console.ReadLine());

            Console.WriteLine("1. Vida\n2. Maná");
            int tipo = int.Parse(Console.ReadLine());

            Pocion pocion = tipo == 1 ? new PocionVida() : new PocionMana();

            if (obj == 1)
                pocion.Aplicar(p1);
            else
                pocion.Aplicar(p2);
        }

        private Personaje CrearPersonaje(string label)
        {
            Console.WriteLine($"--- {label} ---");

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Vida: ");
            int vida = int.Parse(Console.ReadLine());

            Console.Write("Maná: ");
            int mana = int.Parse(Console.ReadLine());

            Console.Write("Fuerza: ");
            int fuerza = int.Parse(Console.ReadLine());

            Console.Write("Defensa: ");
            int defensa = int.Parse(Console.ReadLine());

            Console.Write("Color (0-15): ");
            ConsoleColor color = (ConsoleColor)int.Parse(Console.ReadLine());

            return new Personaje(nombre, vida, mana, fuerza, defensa, color);
        }
    }
}