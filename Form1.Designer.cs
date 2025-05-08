namespace Neo
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            this.btnUczXOR = new System.Windows.Forms.Button();
            this.btnUczXOR_NOR = new System.Windows.Forms.Button();
            this.btnUczSumator = new System.Windows.Forms.Button();
            this.btnTestuj = new System.Windows.Forms.Button();
            this.lblBeta = new System.Windows.Forms.Label();
            this.txtBeta = new System.Windows.Forms.TextBox();
            this.lblWspUcz = new System.Windows.Forms.Label();
            this.txtWspUcz = new System.Windows.Forms.TextBox();
            this.lblEpoki = new System.Windows.Forms.Label();
            this.txtEpoki = new System.Windows.Forms.TextBox();
            this.lblWyniki = new System.Windows.Forms.Label();
            this.txtWyniki = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            
            // btnUczXOR
            this.btnUczXOR.Location = new System.Drawing.Point(20, 20);
            this.btnUczXOR.Name = "btnUczXOR";
            this.btnUczXOR.Size = new System.Drawing.Size(150, 30);
            this.btnUczXOR.TabIndex = 0;
            this.btnUczXOR.Text = "Ucz XOR (2-2-1)";
            this.btnUczXOR.UseVisualStyleBackColor = true;
            this.btnUczXOR.Click += new System.EventHandler(this.btnUczXOR_Click);
            
            // btnUczXOR_NOR
            this.btnUczXOR_NOR.Location = new System.Drawing.Point(20, 60);
            this.btnUczXOR_NOR.Name = "btnUczXOR_NOR";
            this.btnUczXOR_NOR.Size = new System.Drawing.Size(150, 30);
            this.btnUczXOR_NOR.TabIndex = 1;
            this.btnUczXOR_NOR.Text = "Ucz XOR+NOR (2-2-2-2)";
            this.btnUczXOR_NOR.UseVisualStyleBackColor = true;
            this.btnUczXOR_NOR.Click += new System.EventHandler(this.btnUczXOR_NOR_Click);
            
            // btnUczSumator
            this.btnUczSumator.Location = new System.Drawing.Point(20, 100);
            this.btnUczSumator.Name = "btnUczSumator";
            this.btnUczSumator.Size = new System.Drawing.Size(150, 30);
            this.btnUczSumator.TabIndex = 2;
            this.btnUczSumator.Text = "Ucz Sumator (3-3-2-2)";
            this.btnUczSumator.UseVisualStyleBackColor = true;
            this.btnUczSumator.Click += new System.EventHandler(this.btnUczSumator_Click);
            
            // btnTestuj
            this.btnTestuj.Location = new System.Drawing.Point(20, 140);
            this.btnTestuj.Name = "btnTestuj";
            this.btnTestuj.Size = new System.Drawing.Size(150, 30);
            this.btnTestuj.TabIndex = 3;
            this.btnTestuj.Text = "Testuj Sieć";
            this.btnTestuj.UseVisualStyleBackColor = true;
            this.btnTestuj.Click += new System.EventHandler(this.btnTestuj_Click);
            
            // lblBeta
            this.lblBeta.AutoSize = true;
            this.lblBeta.Location = new System.Drawing.Point(200, 20);
            this.lblBeta.Name = "lblBeta";
            this.lblBeta.Size = new System.Drawing.Size(32, 15);
            this.lblBeta.TabIndex = 4;
            this.lblBeta.Text = "Beta:";
            
            // txtBeta
            this.txtBeta.Location = new System.Drawing.Point(300, 20);
            this.txtBeta.Name = "txtBeta";
            this.txtBeta.Size = new System.Drawing.Size(50, 23);
            this.txtBeta.TabIndex = 5;
            this.txtBeta.Text = "1";
            
            // lblWspUcz
            this.lblWspUcz.AutoSize = true;
            this.lblWspUcz.Location = new System.Drawing.Point(200, 50);
            this.lblWspUcz.Name = "lblWspUcz";
            this.lblWspUcz.Size = new System.Drawing.Size(80, 15);
            this.lblWspUcz.TabIndex = 6;
            this.lblWspUcz.Text = "Wsp. uczenia:";
            
            // txtWspUcz
            this.txtWspUcz.Location = new System.Drawing.Point(300, 50);
            this.txtWspUcz.Name = "txtWspUcz";
            this.txtWspUcz.Size = new System.Drawing.Size(50, 23);
            this.txtWspUcz.TabIndex = 7;
            this.txtWspUcz.Text = "0,3";
            
            // lblEpoki
            this.lblEpoki.AutoSize = true;
            this.lblEpoki.Location = new System.Drawing.Point(200, 80);
            this.lblEpoki.Name = "lblEpoki";
            this.lblEpoki.Size = new System.Drawing.Size(40, 15);
            this.lblEpoki.TabIndex = 8;
            this.lblEpoki.Text = "Epoki:";
            
            // txtEpoki
            this.txtEpoki.Location = new System.Drawing.Point(300, 80);
            this.txtEpoki.Name = "txtEpoki";
            this.txtEpoki.Size = new System.Drawing.Size(50, 23);
            this.txtEpoki.TabIndex = 9;
            this.txtEpoki.Text = "50000";
            
            // lblWyniki
            this.lblWyniki.AutoSize = true;
            this.lblWyniki.Location = new System.Drawing.Point(20, 180);
            this.lblWyniki.Name = "lblWyniki";
            this.lblWyniki.Size = new System.Drawing.Size(45, 15);
            this.lblWyniki.TabIndex = 10;
            this.lblWyniki.Text = "Wyniki:";
            
            // txtWyniki
            this.txtWyniki.Location = new System.Drawing.Point(20, 200);
            this.txtWyniki.Multiline = true;
            this.txtWyniki.Name = "txtWyniki";
            this.txtWyniki.ReadOnly = true;
            this.txtWyniki.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWyniki.Size = new System.Drawing.Size(375, 250);
            this.txtWyniki.TabIndex = 11;
            
            // Form1
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 475);
            this.Controls.Add(this.txtWyniki);
            this.Controls.Add(this.lblWyniki);
            this.Controls.Add(this.txtEpoki);
            this.Controls.Add(this.lblEpoki);
            this.Controls.Add(this.txtWspUcz);
            this.Controls.Add(this.lblWspUcz);
            this.Controls.Add(this.txtBeta);
            this.Controls.Add(this.lblBeta);
            this.Controls.Add(this.btnTestuj);
            this.Controls.Add(this.btnUczSumator);
            this.Controls.Add(this.btnUczXOR_NOR);
            this.Controls.Add(this.btnUczXOR);
            this.Name = "Form1";
            this.Text = "Neuronowy Trener";
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        private System.Windows.Forms.Button btnUczXOR;
        private System.Windows.Forms.Button btnUczXOR_NOR;
        private System.Windows.Forms.Button btnUczSumator;
        private System.Windows.Forms.Button btnTestuj;
        private System.Windows.Forms.Label lblBeta;
        private System.Windows.Forms.TextBox txtBeta;
        private System.Windows.Forms.Label lblWspUcz;
        private System.Windows.Forms.TextBox txtWspUcz;
        private System.Windows.Forms.Label lblEpoki;
        private System.Windows.Forms.TextBox txtEpoki;
        private System.Windows.Forms.Label lblWyniki;
        private System.Windows.Forms.TextBox txtWyniki;
    }
}