using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace Neo
{
    public partial class Form1 : Form
    {
        private SiecNeuronowa? siec = null;
        private List<ProbkaTreningowa> probkiTreningowe = new List<ProbkaTreningowa>();
        private Random losowy = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnUczXOR_Click(object sender, EventArgs e)
        {
            UczXOR();
        }

        private void btnUczXOR_NOR_Click(object sender, EventArgs e)
        {
            UczXOR_NOR();
        }

        private void btnUczSumator_Click(object sender, EventArgs e)
        {
            UczSumator();
        }

        private void btnTestuj_Click(object sender, EventArgs e)
        {
            TestujSiec();
        }

        private void UczXOR()
        {
            try
            {
                double beta = double.Parse(txtBeta.Text);
                double wspUcz = double.Parse(txtWspUcz.Text);
                int epoki = int.Parse(txtEpoki.Text);

                probkiTreningowe = new List<ProbkaTreningowa>
                {
                    new ProbkaTreningowa(new double[] {0, 0}, new double[] {0}),
                    new ProbkaTreningowa(new double[] {0, 1}, new double[] {1}),
                    new ProbkaTreningowa(new double[] {1, 0}, new double[] {1}),
                    new ProbkaTreningowa(new double[] {1, 1}, new double[] {0})
                };

                siec = new SiecNeuronowa(new int[] { 2, 2, 1 }, beta, wspUcz);

                txtWyniki.AppendText($"Uczenie XOR (2-2-1), beta={beta}, wsp. uczenia={wspUcz}, epok={epoki}...\r\n");
                UczSiec(epoki);
                txtWyniki.AppendText("Uczenie zakończone.\r\n\r\n");
            }
            catch (Exception ex)
            {
                txtWyniki.AppendText($"Błąd: {ex.Message}\r\n");
            }
        }

        private void UczXOR_NOR()
        {
            try
            {
                double beta = double.Parse(txtBeta.Text);
                double wspUcz = double.Parse(txtWspUcz.Text);
                int epoki = int.Parse(txtEpoki.Text);

                probkiTreningowe = new List<ProbkaTreningowa>
                {
                    new ProbkaTreningowa(new double[] {0, 0}, new double[] {0, 1}),
                    new ProbkaTreningowa(new double[] {0, 1}, new double[] {1, 0}),
                    new ProbkaTreningowa(new double[] {1, 0}, new double[] {1, 0}),
                    new ProbkaTreningowa(new double[] {1, 1}, new double[] {0, 0})
                };

                siec = new SiecNeuronowa(new int[] { 2, 2, 2, 2 }, beta, wspUcz);

                txtWyniki.AppendText($"Uczenie XOR+NOR (2-2-2-2), beta={beta}, wsp. uczenia={wspUcz}, epok={epoki}...\r\n");
                UczSiec(epoki);
                txtWyniki.AppendText("Uczenie zakończone.\r\n\r\n");
            }
            catch (Exception ex)
            {
                txtWyniki.AppendText($"Błąd: {ex.Message}\r\n");
            }
        }

        private void UczSumator()
        {
            try
            {
                double beta = double.Parse(txtBeta.Text);
                double wspUcz = double.Parse(txtWspUcz.Text);
                int epoki = int.Parse(txtEpoki.Text);

                probkiTreningowe = new List<ProbkaTreningowa>
                {
                    new ProbkaTreningowa(new double[] {0, 0, 0}, new double[] {0, 0}),
                    new ProbkaTreningowa(new double[] {0, 1, 0}, new double[] {1, 0}),
                    new ProbkaTreningowa(new double[] {1, 0, 0}, new double[] {1, 0}),
                    new ProbkaTreningowa(new double[] {1, 1, 0}, new double[] {0, 1}),
                    new ProbkaTreningowa(new double[] {0, 0, 1}, new double[] {1, 0}),
                    new ProbkaTreningowa(new double[] {0, 1, 1}, new double[] {0, 1}),
                    new ProbkaTreningowa(new double[] {1, 0, 1}, new double[] {0, 1}),
                    new ProbkaTreningowa(new double[] {1, 1, 1}, new double[] {1, 1})
                };

                siec = new SiecNeuronowa(new int[] { 3, 3, 2, 2 }, beta, wspUcz);

                txtWyniki.AppendText($"Uczenie Sumatora (3-3-2-2), beta={beta}, wsp. uczenia={wspUcz}, epok={epoki}...\r\n");
                UczSiec(epoki);
                txtWyniki.AppendText("Uczenie zakończone.\r\n\r\n");
            }
            catch (Exception ex)
            {
                txtWyniki.AppendText($"Błąd: {ex.Message}\r\n");
            }
        }

        private void TestujSiec()
        {
            if (siec == null)
            {
                txtWyniki.AppendText("Sieć nie została zainicjalizowana. Proszę najpierw przeprowadzić uczenie.\r\n");
                return;
            }

            txtWyniki.AppendText("\r\nTestowanie sieci na próbkach treningowych:\r\n");

            foreach (var probka in probkiTreningowe)
            {
                siec.PropagacjaWprzod(probka.Wejscia);
                var wyjscia = siec.PobierzWyjscia();

                txtWyniki.AppendText($"Wejście: [{string.Join(", ", probka.Wejscia)}], ");
                txtWyniki.AppendText($"Oczekiwane: [{string.Join(", ", probka.Wyjscia)}], ");
                txtWyniki.AppendText($"Otrzymane: [{string.Join(", ", wyjscia.Select(x => x.ToString("F3")))}]\r\n");
            }
        }

        private void UczSiec(int epoki)
        {
            for (int epoka = 0; epoka < epoki; epoka++)
            {
                probkiTreningowe = probkiTreningowe.OrderBy(x => losowy.Next()).ToList();
                double bladCalk = 0;

                foreach (var probka in probkiTreningowe)
                {
                    siec?.PropagacjaWprzod(probka.Wejscia);
                    siec?.PropagacjaWsteczna(probka.Wyjscia);

                    var wyjscia = siec?.PobierzWyjscia();
                    if (wyjscia != null)
                    {
                        for (int i = 0; i < wyjscia.Length; i++)
                        {
                            bladCalk += Math.Abs(probka.Wyjscia[i] - wyjscia[i]);
                        }
                    }
                }

                if (epoka % 1000 == 0)
                {
                    txtWyniki.AppendText($"Epoka: {epoka}, Błąd: {bladCalk / probkiTreningowe.Count}\r\n");
                    Application.DoEvents();
                }
            }

            txtWyniki.AppendText("\r\nWyniki końcowe:\r\n");
            foreach (var probka in probkiTreningowe)
            {
                siec?.PropagacjaWprzod(probka.Wejscia);
                var wyjscia = siec?.PobierzWyjscia();

                if (wyjscia != null)
                {
                    txtWyniki.AppendText($"Wejście: [{string.Join(", ", probka.Wejscia)}], ");
                    txtWyniki.AppendText($"Oczekiwane: [{string.Join(", ", probka.Wyjscia)}], ");
                    txtWyniki.AppendText($"Otrzymane: [{string.Join(", ", wyjscia.Select(x => x.ToString("F3")))}]\r\n");
                }
            }
        }
    }
}