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

            wagi = new double[warstwy.Length][][];
            for (int warstwa = 1; warstwa < warstwy.Length; warstwa++)
            {
                wagi[warstwa] = new double[warstwy[warstwa]][];
                for (int neuron = 0; neuron < warstwy[warstwa]; neuron++)
                {
                    wagi[warstwa][neuron] = new double[warstwy[warstwa - 1] + 1];
                    for (int wejscie = 0; wejscie < wagi[warstwa][neuron].Length; wejscie++)
                    {
                        wagi[warstwa][neuron][wejscie] = losowy.NextDouble() * 10 - 5;
                    }
                }
            }

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
            for (int neuron = 0; neuron < warstwy[0]; neuron++)
            {
                wyjscia[0][neuron] = wejscia[neuron];
            }

            for (int warstwa = 1; warstwa < warstwy.Length; warstwa++)
            {
                for (int neuron = 0; neuron < warstwy[warstwa]; neuron++)
                {
                    sumy[warstwa][neuron] = wagi[warstwa][neuron][0];

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
            double[][] delty = new double[warstwy.Length][];
            for (int warstwa = 0; warstwa < warstwy.Length; warstwa++)
            {
                delty[warstwa] = new double[warstwy[warstwa]];
            }

            for (int neuron = 0; neuron < warstwy[warstwy.Length - 1]; neuron++)
            {
                double wyjscie = wyjscia[warstwy.Length - 1][neuron];
                double blad = oczekiwaneWyjscia[neuron] - wyjscie;
                delty[warstwy.Length - 1][neuron] = wspUcz * blad * PochodnaFunkcji(wyjscie);
            }

            for (int warstwa = warstwy.Length - 2; warstwa > 0; warstwa--)
            {
                for (int neuron = 0; neuron < warstwy[warstwa]; neuron++)
                {
                    double suma = 0;
                    for (int neuronNast = 0; neuronNast < warstwy[warstwa + 1]; neuronNast++)
                    {
                        suma += delty[warstwa + 1][neuronNast] * wagi[warstwa + 1][neuronNast][neuron + 1];
                    }
                    delty[warstwa][neuron] = suma * PochodnaFunkcji(wyjscia[warstwa][neuron]);
                }
            }

            for (int warstwa = 1; warstwa < warstwy.Length; warstwa++)
            {
                for (int neuron = 0; neuron < warstwy[warstwa]; neuron++)
                {
                    wagi[warstwa][neuron][0] += delty[warstwa][neuron];

                    for (int wejscie = 0; wejscie < warstwy[warstwa - 1]; wejscie++)
                    {
                        wagi[warstwa][neuron][wejscie + 1] += delty[warstwa][neuron] * wyjscia[warstwa - 1][wejscie];
                    }
                }
            }
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