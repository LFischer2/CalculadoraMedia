namespace CalculadoraMedia
{
    public class CalculadoraRegras
    {
        public double CalcularMediaSemestral(double np1, double np2, double pim)
        {
            return (np1 * 0.4) + (np2 * 0.4) + (pim * 0.2);
        }

        public string DefinirStatusSemestral(double media)
        {
            return media >= 7 ? "APROVADO" : "EXAME";
        }

        public double CalcularMediaFinal(double semestral, double exame)
        {
            return (semestral + exame) / 2;
        }

        public string DefinirStatusFinal(double mediaFinal)
        {
            return mediaFinal >= 5 ? "APROVADO" : "REPROVADO";
        }

        public bool NotaValida(double nota)
        {
            return nota >= 0 && nota <= 10;
        }
    }
}