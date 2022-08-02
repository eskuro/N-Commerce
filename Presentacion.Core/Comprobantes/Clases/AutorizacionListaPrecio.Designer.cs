namespace Presentacion.Core.Comprobantes.Clases
{
	partial class AutorizacionListaPrecio
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
			this.txtUsuario = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.asdasd = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnIngresar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtUsuario
			// 
			this.txtUsuario.Location = new System.Drawing.Point(66, 92);
			this.txtUsuario.Name = "txtUsuario";
			this.txtUsuario.Size = new System.Drawing.Size(202, 20);
			this.txtUsuario.TabIndex = 0;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(66, 157);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(202, 20);
			this.txtPassword.TabIndex = 1;
			// 
			// asdasd
			// 
			this.asdasd.AutoSize = true;
			this.asdasd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
			this.asdasd.Location = new System.Drawing.Point(60, 59);
			this.asdasd.Name = "asdasd";
			this.asdasd.Size = new System.Drawing.Size(66, 18);
			this.asdasd.TabIndex = 2;
			this.asdasd.Text = "Usuario";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
			this.label2.Location = new System.Drawing.Point(63, 136);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(93, 18);
			this.label2.TabIndex = 3;
			this.label2.Text = "Contraseña";
			// 
			// btnIngresar
			// 
			this.btnIngresar.BackColor = System.Drawing.Color.Black;
			this.btnIngresar.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
			this.btnIngresar.ForeColor = System.Drawing.Color.Tomato;
			this.btnIngresar.Location = new System.Drawing.Point(46, 208);
			this.btnIngresar.Name = "btnIngresar";
			this.btnIngresar.Size = new System.Drawing.Size(110, 39);
			this.btnIngresar.TabIndex = 4;
			this.btnIngresar.Text = "Ingresar";
			this.btnIngresar.UseVisualStyleBackColor = false;
			this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.BackColor = System.Drawing.Color.Black;
			this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
			this.btnCancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnCancelar.Location = new System.Drawing.Point(179, 209);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(107, 38);
			this.btnCancelar.TabIndex = 5;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = false;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// AutorizacionListaPrecio
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.ClientSize = new System.Drawing.Size(365, 278);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnIngresar);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.asdasd);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtUsuario);
			this.Name = "AutorizacionListaPrecio";
			this.Text = "AutorizacionListaPrecio";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtUsuario;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label asdasd;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnIngresar;
		private System.Windows.Forms.Button btnCancelar;
	}
}