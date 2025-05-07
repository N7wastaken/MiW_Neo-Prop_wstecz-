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

            Random losowy = new Random();

            // Inicjalizacja wag
            wagi = new double[warstwy.Length][][];
            for (int warstwa = 1; warstwa < warstwy.Length; warstwa++)
            {
                wagi[warstwa] = new double[warstwy[warstwa]][];
                for (int neuron = 0; neuron < warstwy[warstwa]; neuron++)
                {
                    wagi[warstwa][neuron] = new double[warstwy[warstwa - 1] + 1]; // +1 dla biasu
                    for (int wejscie = 0; wejscie < wagi[warstwa][neuron].Length; wejscie++)
                    {
                        wagi[warstwa][neuron][wejscie] = losowy.NextDouble() * 2 - 1; // Wagi w zakresie [-1, 1]
                    }
                }
            }

            // Inicjalizacja struktur danych
            wyjscia = new double[warstwy.Length][];
            sumy = new double[warstwy.Length][];
            for (int warstwa = 0; warstwa < warstwy.Length; warstwa++)
            {
                wyjscia[warstwa] = new double[warstwy[warstwa]];
                sumy[warstwa] = new double[warstwy[warstwa]];
            }
        }

        public double[] PobierzWyjscia()
        {
            return wyjscia[wyjscia.Length - 1];
        }

        public void PropagacjaWprzod(double[] wejscia)
        {
            // Ustawienie wejść sieci
            for (int neuron = 0; neuron < warstwy[0]; neuron++)
            {
                wyjscia[0][neuron] = wejscia[neuron];
            }

            // Propagacja przez kolejne warstwy
            for (int warstwa = 1; warstwa < warstwy.Length; warstwa++)
            {
                for (int neuron = 0; neuron < warstwy[warstwa]; neuron++)
                {
                    sumy[warstwa][neuron] = wagi[warstwa][neuron][0]; // Bias

                    for (int wejscie = 0; wejscie < warstwy[warstwa - 1]; wejscie++)
                    {
                        sumy[warstwa][neuron] += wagi[warstwa][neuron][wejscie + 1] * wyjscia[warstwa - 1][wejscie];
                    }

                    wyjscia[warstwa][neuron] = FunkcjaAktywacji(sumy[warstwa][neuron]);
                }
            }
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