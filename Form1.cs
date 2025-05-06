using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Neo
{
    public partial class Form1 : Form
    {
        private SiecNeuronowa? siec = null;
        private List<ProbkaTreningowa> probkiTreningowe = new List<ProbkaTreningowa>();

        public Form1()
        {
            InitializeComponent();
        }
    }
}