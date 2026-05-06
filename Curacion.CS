public class PocionVida : Pocion
{
public override int Usar(Personaje p)
{
double curacion = rnd.Next(Min, Max + 1);

double nuevaVida = Math.Min(p.VidaMáxima, p.VidaActual + curacion);
double recuperado = nuevaVida - p.VidaActual;
p.VidaActual = nuevaVida;

return (int)recuperado;
}
}