namespace Presentacion.Core.Configuracion
{
	partial class _00055_Abm_Deposito
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
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.txtUbicacion = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Location = new System.Drawing.Point(154, 106);
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.Size = new System.Drawing.Size(306, 20);
			this.txtDescripcion.TabIndex = 4;
			// 
			// txtUbicacion
			// 
			this.txtUbicacion.Location = new System.Drawing.Point(154, 170);
			this.txtUbicacion.Name = "txtUbicacion";
			this.txtUbicacion.Size = new System.Drawing.Size(306, 20);
			this.txtUbicacion.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.label1.Location = new System.Drawing.Point(55, 106);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 6;
			this.label1.Text = "Descripcion";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.label2.Location = new System.Drawing.Point(66, 170);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 16);
			this.label2.TabIndex = 7;
			this.label2.Text = "Ubicacion";
			// 
			// _00055_Abm_Deposito
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(537, 245);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtUbicacion);
			this.Controls.Add(this.txtDescripcion);
			this.Name = "_00055_Abm_Deposito";
			this.Text = "_00055_Abm_Deposito";
			this.Controls.SetChildIndex(this.txtDescripcion, 0);
			this.Controls.SetChildIndex(this.txtUbicacion, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtDescripcion;
		private System.Windows.Forms.TextBox txtUbicacion;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}