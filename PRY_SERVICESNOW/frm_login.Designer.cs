namespace PRY_SERVICESNOW
{
    partial class frm_login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_login));
            this.pnl_superior = new System.Windows.Forms.Panel();
            this.btn_minimizar = new System.Windows.Forms.PictureBox();
            this.btn_salir = new System.Windows.Forms.PictureBox();
            this.txt_clave = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.btn_ingresar = new System.Windows.Forms.PictureBox();
            this.pcb_login = new System.Windows.Forms.PictureBox();
            this.pbc_fondo = new System.Windows.Forms.PictureBox();
            this.pbc_hoja = new System.Windows.Forms.PictureBox();
            this.pnl_superior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_salir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_ingresar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_login)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbc_fondo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbc_hoja)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_superior
            // 
            this.pnl_superior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(64)))), ((int)(((byte)(51)))));
            this.pnl_superior.Controls.Add(this.btn_minimizar);
            this.pnl_superior.Controls.Add(this.btn_salir);
            this.pnl_superior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_superior.Location = new System.Drawing.Point(0, 0);
            this.pnl_superior.Name = "pnl_superior";
            this.pnl_superior.Size = new System.Drawing.Size(1011, 30);
            this.pnl_superior.TabIndex = 0;
            this.pnl_superior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_superior_MouseDown);
            // 
            // btn_minimizar
            // 
            this.btn_minimizar.Image = global::PRY_SERVICESNOW.Properties.Resources.icn_mini;
            this.btn_minimizar.Location = new System.Drawing.Point(932, 1);
            this.btn_minimizar.Name = "btn_minimizar";
            this.btn_minimizar.Size = new System.Drawing.Size(35, 29);
            this.btn_minimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_minimizar.TabIndex = 5;
            this.btn_minimizar.TabStop = false;
            this.btn_minimizar.Click += new System.EventHandler(this.btn_minimizar_Click);
            this.btn_minimizar.MouseEnter += new System.EventHandler(this.btn_minimizar_MouseEnter);
            this.btn_minimizar.MouseLeave += new System.EventHandler(this.btn_minimizar_MouseLeave);
            // 
            // btn_salir
            // 
            this.btn_salir.Image = global::PRY_SERVICESNOW.Properties.Resources.icono_Cerrar;
            this.btn_salir.Location = new System.Drawing.Point(973, 1);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(35, 29);
            this.btn_salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_salir.TabIndex = 4;
            this.btn_salir.TabStop = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            this.btn_salir.MouseEnter += new System.EventHandler(this.btn_salir_MouseEnter);
            this.btn_salir.MouseLeave += new System.EventHandler(this.btn_salir_MouseLeave);
            // 
            // txt_clave
            // 
            this.txt_clave.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_clave.Location = new System.Drawing.Point(754, 330);
            this.txt_clave.Name = "txt_clave";
            this.txt_clave.Size = new System.Drawing.Size(213, 31);
            this.txt_clave.TabIndex = 4;
            // 
            // txt_password
            // 
            this.txt_password.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.Location = new System.Drawing.Point(754, 383);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(213, 31);
            this.txt_password.TabIndex = 5;
            // 
            // btn_ingresar
            // 
            this.btn_ingresar.Image = global::PRY_SERVICESNOW.Properties.Resources.btn_ingresar;
            this.btn_ingresar.Location = new System.Drawing.Point(679, 472);
            this.btn_ingresar.Name = "btn_ingresar";
            this.btn_ingresar.Size = new System.Drawing.Size(204, 103);
            this.btn_ingresar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_ingresar.TabIndex = 6;
            this.btn_ingresar.TabStop = false;
            this.btn_ingresar.Click += new System.EventHandler(this.btn_ingresar_Click);
            this.btn_ingresar.MouseEnter += new System.EventHandler(this.btn_ingresar_MouseEnter);
            this.btn_ingresar.MouseLeave += new System.EventHandler(this.btn_ingresar_MouseLeave);
            // 
            // pcb_login
            // 
            this.pcb_login.Image = global::PRY_SERVICESNOW.Properties.Resources.img_Sesion;
            this.pcb_login.Location = new System.Drawing.Point(501, 36);
            this.pcb_login.Name = "pcb_login";
            this.pcb_login.Size = new System.Drawing.Size(498, 582);
            this.pcb_login.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcb_login.TabIndex = 3;
            this.pcb_login.TabStop = false;
            // 
            // pbc_fondo
            // 
            this.pbc_fondo.Image = global::PRY_SERVICESNOW.Properties.Resources.img_inicio;
            this.pbc_fondo.Location = new System.Drawing.Point(12, 36);
            this.pbc_fondo.Name = "pbc_fondo";
            this.pbc_fondo.Size = new System.Drawing.Size(460, 350);
            this.pbc_fondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbc_fondo.TabIndex = 2;
            this.pbc_fondo.TabStop = false;
            // 
            // pbc_hoja
            // 
            this.pbc_hoja.Image = global::PRY_SERVICESNOW.Properties.Resources.img_hojacafe;
            this.pbc_hoja.Location = new System.Drawing.Point(0, 410);
            this.pbc_hoja.Name = "pbc_hoja";
            this.pbc_hoja.Size = new System.Drawing.Size(218, 198);
            this.pbc_hoja.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbc_hoja.TabIndex = 1;
            this.pbc_hoja.TabStop = false;
            // 
            // frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(240)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(1011, 608);
            this.Controls.Add(this.btn_ingresar);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_clave);
            this.Controls.Add(this.pcb_login);
            this.Controls.Add(this.pbc_fondo);
            this.Controls.Add(this.pbc_hoja);
            this.Controls.Add(this.pnl_superior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_login";
            this.Text = "Form1";
            this.pnl_superior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_salir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_ingresar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_login)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbc_fondo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbc_hoja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_superior;
        private System.Windows.Forms.PictureBox pbc_hoja;
        private System.Windows.Forms.PictureBox pbc_fondo;
        private System.Windows.Forms.PictureBox pcb_login;
        private System.Windows.Forms.PictureBox btn_minimizar;
        private System.Windows.Forms.PictureBox btn_salir;
        private System.Windows.Forms.TextBox txt_clave;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.PictureBox btn_ingresar;
    }
}

