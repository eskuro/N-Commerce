namespace Presentacion.Core.Usuario
{
	partial class Login
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtUsuario = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnIngresar = new System.Windows.Forms.Button();
			this.imgLogin = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.imgLogin)).BeginInit();
			this.SuspendLayout();
			// 
			// txtPassword
			// 
			this.txtPassword.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
			this.txtPassword.Location = new System.Drawing.Point(55, 326);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(278, 26);
			this.txtPassword.TabIndex = 0;
			// 
			// txtUsuario
			// 
			this.txtUsuario.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
			this.txtUsuario.Location = new System.Drawing.Point(55, 261);
			this.txtUsuario.Name = "txtUsuario";
			this.txtUsuario.Size = new System.Drawing.Size(278, 26);
			this.txtUsuario.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(52, 301);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 18);
			this.label1.TabIndex = 2;
			this.label1.Text = "Contraseña";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
			this.label2.Location = new System.Drawing.Point(52, 240);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 18);
			this.label2.TabIndex = 3;
			this.label2.Text = "Usuario";
			// 
			// btnIngresar
			// 
			this.btnIngresar.BackColor = System.Drawing.Color.Black;
			this.btnIngresar.FlatAppearance.BorderSize = 0;
			this.btnIngresar.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnIngresar.ForeColor = System.Drawing.Color.Tomato;
			this.btnIngresar.Location = new System.Drawing.Point(77, 377);
			this.btnIngresar.Name = "btnIngresar";
			this.btnIngresar.Size = new System.Drawing.Size(256, 39);
			this.btnIngresar.TabIndex = 4;
			this.btnIngresar.Text = "Ingresar";
			this.btnIngresar.UseVisualStyleBackColor = false;
			this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
			// 
			// imgLogin
			// 
			this.imgLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.imgLogin.Location = new System.Drawing.Point(55, 12);
			this.imgLogin.Name = "imgLogin";
			this.imgLogin.Size = new System.Drawing.Size(278, 210);
			this.imgLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgLogin.TabIndex = 5;
			this.imgLogin.TabStop = false;
			// 
			// Login
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.ClientSize = new System.Drawing.Size(382, 447);
			this.Controls.Add(this.imgLogin);
			this.Controls.Add(this.btnIngresar);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtUsuario);
			this.Controls.Add(this.txtPassword);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Login";
			this.Text = "Login";
			((System.ComponentModel.ISupportInitialize)(this.imgLogin)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtUsuario;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnIngresar;
		private System.Windows.Forms.PictureBox imgLogin;
	}
}