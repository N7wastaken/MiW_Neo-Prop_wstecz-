using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

        private void TestujPropagacje()
        {
            siec = new SiecNeuronowa(new int[] { 2, 2, 1 }, 1.0, 0.1);
            double[] wejscia = new double[] { 1.0, 0.5 };
            
            siec.PropagacjaWprzod(wejscia);
            var wyjscia = siec.PobierzWyjscia();
            
            MessageBox.Show($"Wyjście sieci: {wyjscia[0].ToString("F4")}", "Test propagacji");
        }
    }
}