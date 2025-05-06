using System;

namespace Neo
{
    public class SiecNeuronowa
    {
        private int[] warstwy;
        private double[][][] wagi;
        private double[][] wyjscia;
        private double[][] sumy;
        private double beta;
        private double wspUcz;

        public SiecNeuronowa(int[] warstwy, double beta, double wspUcz)
        {
            this.warstwy = warstwy;
            this.beta = beta;
            this.wspUcz = wspUcz;

            // Inicjalizacja struktur danych
            wyjscia = new double[warstwy.Length][];
            sumy = new double[warstwy.Length][];
            for (int i = 0; i < warstwy.Length; i++)
            {
                wyjscia[i] = new double[warstwy[i]];
                sumy[i] = new double[warstwy[i]];
            }
        }

        public double[] PobierzWyjscia()
        {
            return wyjscia[wyjscia.Length - 1];
        }

        public void PropagacjaWprzod(double[] wejscia)
        {
            // Tymczasowo pusta - implementacja w następnym commicie
        }

        public void PropagacjaWsteczna(double[] oczekiwaneWyjscia)
        {
            // Tymczasowo pusta - implementacja w następnym commicie
        }

        private double FunkcjaAktywacji(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-beta * x));
        }

        private double PochodnaFunkcji(double wyjscie)
        {
            return beta * wyjscie * (1 - wyjscie);
        }
    }
}