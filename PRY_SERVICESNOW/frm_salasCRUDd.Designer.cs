namespace PRY_SERVICESNOW
{
    partial class frm_salasCRUDd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nud_capacidad = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_ubicacion = new System.Windows.Forms.ComboBox();
            this.rdb_inactivo = new System.Windows.Forms.RadioButton();
            this.rdb_activo = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmb_tiposala = new System.Windows.Forms.ComboBox();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.txt_descripcion = new System.Windows.Forms.TextBox();
            this.txt_idsala = new System.Windows.Forms.TextBox();
            this.pnl_superior = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_salas = new System.Windows.Forms.DataGridView();
            this.pnl_datosSala = new System.Windows.Forms.Panel();
            this.txt_buscarSala = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_limpiar = new System.Windows.Forms.PictureBox();
            this.btn_eliminar = new System.Windows.Forms.PictureBox();
            this.btn_modificar = new System.Windows.Forms.PictureBox();
            this.btn_guardar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nud_capacidad)).BeginInit();
            this.pnl_superior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_salas)).BeginInit();
            this.pnl_datosSala.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_limpiar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_eliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_modificar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_guardar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(64)))), ((int)(((byte)(51)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(31, 836);
            this.panel4.TabIndex = 40;
            // 
            // nud_capacidad
            // 
            this.nud_capacidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_capacidad.Location = new System.Drawing.Point(676, 215);
            this.nud_capacidad.Name = "nud_capacidad";
            this.nud_capacidad.Size = new System.Drawing.Size(233, 34);
            this.nud_capacidad.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(64)))), ((int)(((byte)(51)))));
            this.label3.Location = new System.Drawing.Point(532, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 28);
            this.label3.TabIndex = 24;
            this.label3.Text = "Capacidad:";
            // 
            // cmb_ubicacion
            // 
            this.cmb_ubicacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_ubicacion.FormattingEnabled = true;
            this.cmb_ubicacion.Items.AddRange(new object[] {
            "Departamento A",
            "Departamento B",
            "Departamento C",
            "Departamento D ",
            "Servicios de mantenimiento",
            "Biblioteca",
            ""});
            this.cmb_ubicacion.Location = new System.Drawing.Point(676, 54);
            this.cmb_ubicacion.Name = "cmb_ubicacion";
            this.cmb_ubicacion.Size = new System.Drawing.Size(233, 36);
            this.cmb_ubicacion.TabIndex = 22;
            // 
            // rdb_inactivo
            // 
            this.rdb_inactivo.AutoSize = true;
            this.rdb_inactivo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_inactivo.Location = new System.Drawing.Point(1046, 132);
            this.rdb_inactivo.Name = "rdb_inactivo";
            this.rdb_inactivo.Size = new System.Drawing.Size(102, 32);
            this.rdb_inactivo.TabIndex = 21;
            this.rdb_inactivo.TabStop = true;
            this.rdb_inactivo.Text = "Inactivo";
            this.rdb_inactivo.UseVisualStyleBackColor = true;
            // 
            // rdb_activo
            // 
            this.rdb_activo.AutoSize = true;
            this.rdb_activo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_activo.Location = new System.Drawing.Point(1046, 85);
            this.rdb_activo.Name = "rdb_activo";
            this.rdb_activo.Size = new System.Drawing.Size(89, 32);
            this.rdb_activo.TabIndex = 20;
            this.rdb_activo.TabStop = true;
            this.rdb_activo.Text = "Activo";
            this.rdb_activo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(679, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "SALAS";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(64)))), ((int)(((byte)(51)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1547, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(31, 836);
            this.panel1.TabIndex = 41;
            // 
            // cmb_tiposala
            // 
            this.cmb_tiposala.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_tiposala.FormattingEnabled = true;
            this.cmb_tiposala.Location = new System.Drawing.Point(676, 110);
            this.cmb_tiposala.Name = "cmb_tiposala";
            this.cmb_tiposala.Size = new System.Drawing.Size(233, 36);
            this.cmb_tiposala.TabIndex = 19;
            // 
            // txt_nombre
            // 
            this.txt_nombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombre.Location = new System.Drawing.Point(243, 110);
            this.txt_nombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(239, 34);
            this.txt_nombre.TabIndex = 15;
            // 
            // txt_descripcion
            // 
            this.txt_descripcion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_descripcion.Location = new System.Drawing.Point(243, 172);
            this.txt_descripcion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_descripcion.Multiline = true;
            this.txt_descripcion.Name = "txt_descripcion";
            this.txt_descripcion.Size = new System.Drawing.Size(239, 73);
            this.txt_descripcion.TabIndex = 14;
            // 
            // txt_idsala
            // 
            this.txt_idsala.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_idsala.Location = new System.Drawing.Point(243, 54);
            this.txt_idsala.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_idsala.Name = "txt_idsala";
            this.txt_idsala.ReadOnly = true;
            this.txt_idsala.Size = new System.Drawing.Size(239, 34);
            this.txt_idsala.TabIndex = 12;
            // 
            // pnl_superior
            // 
            this.pnl_superior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(64)))), ((int)(((byte)(51)))));
            this.pnl_superior.Controls.Add(this.pictureBox3);
            this.pnl_superior.Controls.Add(this.pictureBox2);
            this.pnl_superior.Controls.Add(this.pictureBox1);
            this.pnl_superior.Controls.Add(this.label1);
            this.pnl_superior.Location = new System.Drawing.Point(-9, 0);
            this.pnl_superior.Name = "pnl_superior";
            this.pnl_superior.Size = new System.Drawing.Size(1596, 60);
            this.pnl_superior.TabIndex = 39;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(64)))), ((int)(((byte)(51)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 836);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1578, 26);
            this.panel2.TabIndex = 42;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(64)))), ((int)(((byte)(51)))));
            this.label10.Location = new System.Drawing.Point(41, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(172, 28);
            this.label10.TabIndex = 11;
            this.label10.Text = "Nombre de sala :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(64)))), ((int)(((byte)(51)))));
            this.label5.Location = new System.Drawing.Point(1108, 437);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 28);
            this.label5.TabIndex = 43;
            this.label5.Text = "Buscar sala:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(64)))), ((int)(((byte)(51)))));
            this.label9.Location = new System.Drawing.Point(37, 172);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 28);
            this.label9.TabIndex = 10;
            this.label9.Text = "Descripcion:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(64)))), ((int)(((byte)(51)))));
            this.label8.Location = new System.Drawing.Point(975, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 28);
            this.label8.TabIndex = 9;
            this.label8.Text = "Estado:  ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(64)))), ((int)(((byte)(51)))));
            this.label7.Location = new System.Drawing.Point(532, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 28);
            this.label7.TabIndex = 8;
            this.label7.Text = "Ubicacion:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(64)))), ((int)(((byte)(51)))));
            this.label6.Location = new System.Drawing.Point(532, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 28);
            this.label6.TabIndex = 7;
            this.label6.Text = "Tipo de sala:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(64)))), ((int)(((byte)(51)))));
            this.label4.Location = new System.Drawing.Point(37, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 28);
            this.label4.TabIndex = 5;
            this.label4.Text = "id de la sala:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(64)))), ((int)(((byte)(51)))));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 38);
            this.label2.TabIndex = 4;
            this.label2.Text = "Datos de la sala";
            // 
            // dgv_salas
            // 
            this.dgv_salas.AllowUserToAddRows = false;
            this.dgv_salas.AllowUserToDeleteRows = false;
            this.dgv_salas.AllowUserToResizeColumns = false;
            this.dgv_salas.AllowUserToResizeRows = false;
            this.dgv_salas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(199)))), ((int)(((byte)(184)))));
            this.dgv_salas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(64)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(123)))), ((int)(((byte)(99)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_salas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_salas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(123)))), ((int)(((byte)(99)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_salas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_salas.EnableHeadersVisualStyles = false;
            this.dgv_salas.Location = new System.Drawing.Point(67, 477);
            this.dgv_salas.MultiSelect = false;
            this.dgv_salas.Name = "dgv_salas";
            this.dgv_salas.ReadOnly = true;
            this.dgv_salas.RowHeadersVisible = false;
            this.dgv_salas.RowHeadersWidth = 51;
            this.dgv_salas.RowTemplate.Height = 24;
            this.dgv_salas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_salas.Size = new System.Drawing.Size(1456, 345);
            this.dgv_salas.TabIndex = 47;
            // 
            // pnl_datosSala
            // 
            this.pnl_datosSala.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(199)))), ((int)(((byte)(184)))));
            this.pnl_datosSala.Controls.Add(this.btn_limpiar);
            this.pnl_datosSala.Controls.Add(this.btn_eliminar);
            this.pnl_datosSala.Controls.Add(this.btn_modificar);
            this.pnl_datosSala.Controls.Add(this.btn_guardar);
            this.pnl_datosSala.Controls.Add(this.nud_capacidad);
            this.pnl_datosSala.Controls.Add(this.label3);
            this.pnl_datosSala.Controls.Add(this.cmb_ubicacion);
            this.pnl_datosSala.Controls.Add(this.rdb_inactivo);
            this.pnl_datosSala.Controls.Add(this.rdb_activo);
            this.pnl_datosSala.Controls.Add(this.cmb_tiposala);
            this.pnl_datosSala.Controls.Add(this.txt_nombre);
            this.pnl_datosSala.Controls.Add(this.txt_descripcion);
            this.pnl_datosSala.Controls.Add(this.txt_idsala);
            this.pnl_datosSala.Controls.Add(this.label10);
            this.pnl_datosSala.Controls.Add(this.label9);
            this.pnl_datosSala.Controls.Add(this.label8);
            this.pnl_datosSala.Controls.Add(this.label7);
            this.pnl_datosSala.Controls.Add(this.label6);
            this.pnl_datosSala.Controls.Add(this.label4);
            this.pnl_datosSala.Controls.Add(this.label2);
            this.pnl_datosSala.Location = new System.Drawing.Point(67, 80);
            this.pnl_datosSala.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_datosSala.Name = "pnl_datosSala";
            this.pnl_datosSala.Size = new System.Drawing.Size(1456, 341);
            this.pnl_datosSala.TabIndex = 46;
            // 
            // txt_buscarSala
            // 
            this.txt_buscarSala.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_buscarSala.Location = new System.Drawing.Point(1285, 437);
            this.txt_buscarSala.Name = "txt_buscarSala";
            this.txt_buscarSala.Size = new System.Drawing.Size(238, 34);
            this.txt_buscarSala.TabIndex = 44;
            this.txt_buscarSala.TextChanged += new System.EventHandler(this.txt_buscarSala_TextChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::PRY_SERVICESNOW.Properties.Resources.img_hojablanca;
            this.pictureBox3.Location = new System.Drawing.Point(1506, 9);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(69, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PRY_SERVICESNOW.Properties.Resources.img_hojablanca;
            this.pictureBox2.Location = new System.Drawing.Point(3, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(69, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PRY_SERVICESNOW.Properties.Resources.icn_salones;
            this.pictureBox1.Location = new System.Drawing.Point(789, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(64)))), ((int)(((byte)(51)))));
            this.btn_limpiar.Image = global::PRY_SERVICESNOW.Properties.Resources.boton_limpiar;
            this.btn_limpiar.Location = new System.Drawing.Point(1239, 262);
            this.btn_limpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(195, 62);
            this.btn_limpiar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_limpiar.TabIndex = 27;
            this.btn_limpiar.TabStop = false;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(64)))), ((int)(((byte)(51)))));
            this.btn_eliminar.Image = global::PRY_SERVICESNOW.Properties.Resources.boton_eliminar1;
            this.btn_eliminar.Location = new System.Drawing.Point(1239, 20);
            this.btn_eliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(195, 62);
            this.btn_eliminar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_eliminar.TabIndex = 25;
            this.btn_eliminar.TabStop = false;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_modificar
            // 
            this.btn_modificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(64)))), ((int)(((byte)(51)))));
            this.btn_modificar.Image = global::PRY_SERVICESNOW.Properties.Resources.boton_modificar;
            this.btn_modificar.Location = new System.Drawing.Point(1239, 102);
            this.btn_modificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(195, 62);
            this.btn_modificar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_modificar.TabIndex = 26;
            this.btn_modificar.TabStop = false;
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(64)))), ((int)(((byte)(51)))));
            this.btn_guardar.Image = global::PRY_SERVICESNOW.Properties.Resources.boton_guardar;
            this.btn_guardar.Location = new System.Drawing.Point(1239, 183);
            this.btn_guardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(195, 62);
            this.btn_guardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_guardar.TabIndex = 24;
            this.btn_guardar.TabStop = false;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // frm_salasCRUDd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(240)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(1578, 862);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_superior);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgv_salas);
            this.Controls.Add(this.pnl_datosSala);
            this.Controls.Add(this.txt_buscarSala);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_salasCRUDd";
            this.Text = "frm_salasCRUDd";
            this.Load += new System.EventHandler(this.frm_salasCRUD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_capacidad)).EndInit();
            this.pnl_superior.ResumeLayout(false);
            this.pnl_superior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_salas)).EndInit();
            this.pnl_datosSala.ResumeLayout(false);
            this.pnl_datosSala.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_limpiar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_eliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_modificar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_guardar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox btn_limpiar;
        private System.Windows.Forms.PictureBox btn_eliminar;
        private System.Windows.Forms.PictureBox btn_modificar;
        private System.Windows.Forms.PictureBox btn_guardar;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.NumericUpDown nud_capacidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_ubicacion;
        private System.Windows.Forms.RadioButton rdb_inactivo;
        private System.Windows.Forms.RadioButton rdb_activo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmb_tiposala;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_descripcion;
        private System.Windows.Forms.TextBox txt_idsala;
        private System.Windows.Forms.Panel pnl_superior;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_salas;
        private System.Windows.Forms.Panel pnl_datosSala;
        private System.Windows.Forms.TextBox txt_buscarSala;
    }
}