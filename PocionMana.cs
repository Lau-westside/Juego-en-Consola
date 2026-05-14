public class PocionMana : Pocion
{
public override string Descripcion => "Pocion de Maná: Restaura una cantidad aleatoria de maná entre Min y Max.";
public override int Usar(Personaje p)
{
int recuperacion = rnd.Next(Min, Max + 1);

int nuevoMana = Math.Min(p.ManáMáximo, (int)p.ManáActual + recuperacion);
int recuperado = nuevoMana - (int)p.ManáActual;
p.ManáActual = nuevoMana;

return recuperado;
}

}
