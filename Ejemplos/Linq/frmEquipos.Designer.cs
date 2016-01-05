namespace Ejemplos.Linq
{
    partial class frmEquipos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtAños = new System.Windows.Forms.NumericUpDown();
            this.lstEquipos = new System.Windows.Forms.ListBox();
            this.lstJugadores = new System.Windows.Forms.ListBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.txtSalario = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtAños)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAños
            // 
            this.txtAños.Location = new System.Drawing.Point(45, 35);
            this.txtAños.Name = "txtAños";
            this.txtAños.Size = new System.Drawing.Size(118, 22);
            this.txtAños.TabIndex = 0;
            this.txtAños.ValueChanged += new System.EventHandler(this.txtAños_ValueChanged);
            // 
            // lstEquipos
            // 
            this.lstEquipos.FormattingEnabled = true;
            this.lstEquipos.ItemHeight = 16;
            this.lstEquipos.Location = new System.Drawing.Point(45, 99);
            this.lstEquipos.Name = "lstEquipos";
            this.lstEquipos.Size = new System.Drawing.Size(216, 340);
            this.lstEquipos.TabIndex = 1;
            this.lstEquipos.SelectedIndexChanged += new System.EventHandler(this.lstEquipos_SelectedIndexChanged);
            // 
            // lstJugadores
            // 
            this.lstJugadores.FormattingEnabled = true;
            this.lstJugadores.ItemHeight = 16;
            this.lstJugadores.Location = new System.Drawing.Point(285, 99);
            this.lstJugadores.Name = "lstJugadores";
            this.lstJugadores.Size = new System.Drawing.Size(248, 340);
            this.lstJugadores.TabIndex = 2;
            this.lstJugadores.SelectedIndexChanged += new System.EventHandler(this.lstJugadores_SelectedIndexChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(566, 124);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(268, 22);
            this.txtNombre.TabIndex = 3;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(566, 99);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(106, 22);
            this.txtId.TabIndex = 4;
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(566, 173);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.ReadOnly = true;
            this.txtAltura.Size = new System.Drawing.Size(106, 22);
            this.txtAltura.TabIndex = 5;
            // 
            // txtSalario
            // 
            this.txtSalario.Location = new System.Drawing.Point(566, 227);
            this.txtSalario.Name = "txtSalario";
            this.txtSalario.ReadOnly = true;
            this.txtSalario.Size = new System.Drawing.Size(106, 22);
            this.txtSalario.TabIndex = 6;
            // 
            // frmEquipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 576);
            this.Controls.Add(this.txtSalario);
            this.Controls.Add(this.txtAltura);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lstJugadores);
            this.Controls.Add(this.lstEquipos);
            this.Controls.Add(this.txtAños);
            this.Name = "frmEquipos";
            this.Text = "frmEquipos";
            this.Load += new System.EventHandler(this.frmEquipos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtAños)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown txtAños;
        private System.Windows.Forms.ListBox lstEquipos;
        private System.Windows.Forms.ListBox lstJugadores;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.TextBox txtSalario;
    }
}