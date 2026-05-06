namespace Farmacia.Formularios
{
    partial class FrmRegistroVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistroVentas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbo_empleado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_crearCliente = new System.Windows.Forms.Button();
            this.btn_crearProducto = new System.Windows.Forms.Button();
            this.cbo_cliente = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_EliminarProducto = new System.Windows.Forms.Button();
            this.btn_agregarProducto = new System.Windows.Forms.Button();
            this.cbo_producto = new System.Windows.Forms.ComboBox();
            this.txt_stock = new System.Windows.Forms.TextBox();
            this.txt_precioUni = new System.Windows.Forms.TextBox();
            this.txt_cantidad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_venta = new System.Windows.Forms.DataGridView();
            this.btn_confirmarVenta = new System.Windows.Forms.Button();
            this.btn_cancelarVenta = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Subtotal = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cbo_MetodoPago = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbo_TipoComprobante = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_TotalFinal = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_venta)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(249, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 74);
            this.label1.TabIndex = 0;
            this.label1.Text = "REGISTRO VENTAS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(79)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbo_empleado);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(27, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 52);
            this.panel1.TabIndex = 1;
            // 
            // cbo_empleado
            // 
            this.cbo_empleado.FormattingEnabled = true;
            this.cbo_empleado.Location = new System.Drawing.Point(154, 17);
            this.cbo_empleado.Name = "cbo_empleado";
            this.cbo_empleado.Size = new System.Drawing.Size(292, 21);
            this.cbo_empleado.TabIndex = 1;
            this.cbo_empleado.SelectedIndexChanged += new System.EventHandler(this.cbo_empleado_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(51, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "EMPLEADO:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(79)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btn_crearCliente);
            this.panel2.Controls.Add(this.btn_crearProducto);
            this.panel2.Controls.Add(this.cbo_cliente);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.btn_EliminarProducto);
            this.panel2.Controls.Add(this.btn_agregarProducto);
            this.panel2.Controls.Add(this.cbo_producto);
            this.panel2.Controls.Add(this.txt_stock);
            this.panel2.Controls.Add(this.txt_precioUni);
            this.panel2.Controls.Add(this.txt_cantidad);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(28, 137);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(795, 216);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btn_crearCliente
            // 
            this.btn_crearCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_crearCliente.FlatAppearance.BorderSize = 0;
            this.btn_crearCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_crearCliente.Image = ((System.Drawing.Image)(resources.GetObject("btn_crearCliente.Image")));
            this.btn_crearCliente.Location = new System.Drawing.Point(464, 15);
            this.btn_crearCliente.Name = "btn_crearCliente";
            this.btn_crearCliente.Size = new System.Drawing.Size(42, 23);
            this.btn_crearCliente.TabIndex = 13;
            this.btn_crearCliente.UseVisualStyleBackColor = false;
            this.btn_crearCliente.Click += new System.EventHandler(this.btn_crearCliente_Click);
            // 
            // btn_crearProducto
            // 
            this.btn_crearProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_crearProducto.FlatAppearance.BorderSize = 0;
            this.btn_crearProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_crearProducto.Image = ((System.Drawing.Image)(resources.GetObject("btn_crearProducto.Image")));
            this.btn_crearProducto.Location = new System.Drawing.Point(464, 54);
            this.btn_crearProducto.Name = "btn_crearProducto";
            this.btn_crearProducto.Size = new System.Drawing.Size(42, 23);
            this.btn_crearProducto.TabIndex = 12;
            this.btn_crearProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_crearProducto.UseVisualStyleBackColor = false;
            this.btn_crearProducto.Click += new System.EventHandler(this.btn_crearProducto_Click);
            // 
            // cbo_cliente
            // 
            this.cbo_cliente.FormattingEnabled = true;
            this.cbo_cliente.Location = new System.Drawing.Point(153, 17);
            this.cbo_cliente.Name = "cbo_cliente";
            this.cbo_cliente.Size = new System.Drawing.Size(292, 21);
            this.cbo_cliente.TabIndex = 11;
            this.cbo_cliente.SelectedIndexChanged += new System.EventHandler(this.cbo_cliente_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(68, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 15);
            this.label10.TabIndex = 10;
            this.label10.Text = "CLIENTE:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_EliminarProducto
            // 
            this.btn_EliminarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_EliminarProducto.FlatAppearance.BorderSize = 0;
            this.btn_EliminarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EliminarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_EliminarProducto.Image = ((System.Drawing.Image)(resources.GetObject("btn_EliminarProducto.Image")));
            this.btn_EliminarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_EliminarProducto.Location = new System.Drawing.Point(566, 84);
            this.btn_EliminarProducto.Name = "btn_EliminarProducto";
            this.btn_EliminarProducto.Size = new System.Drawing.Size(186, 44);
            this.btn_EliminarProducto.TabIndex = 9;
            this.btn_EliminarProducto.Text = "ELIMINAR PRODUCTO";
            this.btn_EliminarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_EliminarProducto.UseVisualStyleBackColor = false;
            this.btn_EliminarProducto.Click += new System.EventHandler(this.btn_EliminarProducto_Click);
            // 
            // btn_agregarProducto
            // 
            this.btn_agregarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_agregarProducto.FlatAppearance.BorderSize = 0;
            this.btn_agregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_agregarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_agregarProducto.Image = ((System.Drawing.Image)(resources.GetObject("btn_agregarProducto.Image")));
            this.btn_agregarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_agregarProducto.Location = new System.Drawing.Point(566, 15);
            this.btn_agregarProducto.Name = "btn_agregarProducto";
            this.btn_agregarProducto.Size = new System.Drawing.Size(186, 44);
            this.btn_agregarProducto.TabIndex = 8;
            this.btn_agregarProducto.Text = "AGREGAR PRODUCTO";
            this.btn_agregarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_agregarProducto.UseVisualStyleBackColor = false;
            this.btn_agregarProducto.Click += new System.EventHandler(this.btn_agregarProducto_Click);
            // 
            // cbo_producto
            // 
            this.cbo_producto.FormattingEnabled = true;
            this.cbo_producto.Location = new System.Drawing.Point(153, 56);
            this.cbo_producto.Name = "cbo_producto";
            this.cbo_producto.Size = new System.Drawing.Size(292, 21);
            this.cbo_producto.TabIndex = 2;
            this.cbo_producto.SelectedIndexChanged += new System.EventHandler(this.cbo_productos_SelectedIndexChanged);
            // 
            // txt_stock
            // 
            this.txt_stock.Location = new System.Drawing.Point(153, 177);
            this.txt_stock.Name = "txt_stock";
            this.txt_stock.Size = new System.Drawing.Size(292, 20);
            this.txt_stock.TabIndex = 7;
            this.txt_stock.TextChanged += new System.EventHandler(this.txt_stock_TextChanged);
            // 
            // txt_precioUni
            // 
            this.txt_precioUni.Location = new System.Drawing.Point(153, 136);
            this.txt_precioUni.Name = "txt_precioUni";
            this.txt_precioUni.Size = new System.Drawing.Size(292, 20);
            this.txt_precioUni.TabIndex = 6;
            this.txt_precioUni.TextChanged += new System.EventHandler(this.txt_precioUni_TextChanged);
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.Location = new System.Drawing.Point(153, 97);
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.Size = new System.Drawing.Size(292, 20);
            this.txt_cantidad.TabIndex = 5;
            this.txt_cantidad.TextChanged += new System.EventHandler(this.txt_cantidad_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(80, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "STOCK:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(6, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "PRECIO UNITARIO:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(58, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "CANTIDAD:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(40, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "PRODUCTOS:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // dgv_venta
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_venta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_venta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_venta.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_venta.Location = new System.Drawing.Point(28, 359);
            this.dgv_venta.Name = "dgv_venta";
            this.dgv_venta.Size = new System.Drawing.Size(796, 181);
            this.dgv_venta.TabIndex = 3;
            this.dgv_venta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_venta_CellContentClick);
            // 
            // btn_confirmarVenta
            // 
            this.btn_confirmarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_confirmarVenta.FlatAppearance.BorderSize = 0;
            this.btn_confirmarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_confirmarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_confirmarVenta.ForeColor = System.Drawing.Color.White;
            this.btn_confirmarVenta.Location = new System.Drawing.Point(404, 711);
            this.btn_confirmarVenta.Name = "btn_confirmarVenta";
            this.btn_confirmarVenta.Size = new System.Drawing.Size(158, 44);
            this.btn_confirmarVenta.TabIndex = 9;
            this.btn_confirmarVenta.Text = "CONFIRMAR VENTA";
            this.btn_confirmarVenta.UseVisualStyleBackColor = false;
            this.btn_confirmarVenta.Click += new System.EventHandler(this.btn_confirmarVenta_Click);
            // 
            // btn_cancelarVenta
            // 
            this.btn_cancelarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_cancelarVenta.FlatAppearance.BorderSize = 0;
            this.btn_cancelarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelarVenta.ForeColor = System.Drawing.Color.White;
            this.btn_cancelarVenta.Location = new System.Drawing.Point(644, 711);
            this.btn_cancelarVenta.Name = "btn_cancelarVenta";
            this.btn_cancelarVenta.Size = new System.Drawing.Size(161, 44);
            this.btn_cancelarVenta.TabIndex = 10;
            this.btn_cancelarVenta.Text = "CANCELAR VENTA";
            this.btn_cancelarVenta.UseVisualStyleBackColor = false;
            this.btn_cancelarVenta.Click += new System.EventHandler(this.btn_cancelarVenta_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(16, 67);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(141, 33);
            this.button5.TabIndex = 11;
            this.button5.Text = "DETALLE DE VENTA";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(73, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "SUBTOTAL:";
            // 
            // txt_Subtotal
            // 
            this.txt_Subtotal.Location = new System.Drawing.Point(160, 9);
            this.txt_Subtotal.Name = "txt_Subtotal";
            this.txt_Subtotal.Size = new System.Drawing.Size(256, 20);
            this.txt_Subtotal.TabIndex = 12;
            this.txt_Subtotal.TextChanged += new System.EventHandler(this.txt_Subtotal_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(79)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button6);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.button5);
            this.panel3.Location = new System.Drawing.Point(28, 571);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(328, 119);
            this.panel3.TabIndex = 13;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(167, 67);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(141, 33);
            this.button6.TabIndex = 13;
            this.button6.Text = "EXPORTAR";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(49, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(240, 25);
            this.label8.TabIndex = 12;
            this.label8.Text = "DETALLE DE VENTA:";
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(28, 746);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(141, 33);
            this.button7.TabIndex = 14;
            this.button7.Text = "CERRAR";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "METODO DE PAGO:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbo_MetodoPago
            // 
            this.cbo_MetodoPago.FormattingEnabled = true;
            this.cbo_MetodoPago.Location = new System.Drawing.Point(160, 75);
            this.cbo_MetodoPago.Name = "cbo_MetodoPago";
            this.cbo_MetodoPago.Size = new System.Drawing.Size(256, 21);
            this.cbo_MetodoPago.TabIndex = 16;
            this.cbo_MetodoPago.SelectedIndexChanged += new System.EventHandler(this.cbo_MetodoPago_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(4, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 15);
            this.label11.TabIndex = 17;
            this.label11.Text = "TIPO COMPROBANTE:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbo_TipoComprobante
            // 
            this.cbo_TipoComprobante.FormattingEnabled = true;
            this.cbo_TipoComprobante.Location = new System.Drawing.Point(160, 108);
            this.cbo_TipoComprobante.Name = "cbo_TipoComprobante";
            this.cbo_TipoComprobante.Size = new System.Drawing.Size(256, 21);
            this.cbo_TipoComprobante.TabIndex = 18;
            this.cbo_TipoComprobante.SelectedIndexChanged += new System.EventHandler(this.cbo_TipoComprobante_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(59, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 15);
            this.label12.TabIndex = 19;
            this.label12.Text = "TOTAL FINAL:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_TotalFinal
            // 
            this.txt_TotalFinal.Location = new System.Drawing.Point(160, 41);
            this.txt_TotalFinal.Name = "txt_TotalFinal";
            this.txt_TotalFinal.Size = new System.Drawing.Size(256, 20);
            this.txt_TotalFinal.TabIndex = 20;
            this.txt_TotalFinal.TextChanged += new System.EventHandler(this.txt_TotalFinal_TextChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(79)))));
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.txt_TotalFinal);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.txt_Subtotal);
            this.panel4.Controls.Add(this.cbo_TipoComprobante);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.cbo_MetodoPago);
            this.panel4.Location = new System.Drawing.Point(381, 547);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(443, 143);
            this.panel4.TabIndex = 21;
            // 
            // FrmRegistroVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(864, 800);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btn_cancelarVenta);
            this.Controls.Add(this.btn_confirmarVenta);
            this.Controls.Add(this.dgv_venta);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "FrmRegistroVentas";
            this.Text = "    ";
            this.Load += new System.EventHandler(this.FrmRegistroVentas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_venta)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbo_empleado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_EliminarProducto;
        private System.Windows.Forms.Button btn_agregarProducto;
        private System.Windows.Forms.ComboBox cbo_producto;
        private System.Windows.Forms.TextBox txt_stock;
        private System.Windows.Forms.TextBox txt_precioUni;
        private System.Windows.Forms.TextBox txt_cantidad;
        private System.Windows.Forms.DataGridView dgv_venta;
        private System.Windows.Forms.Button btn_confirmarVenta;
        private System.Windows.Forms.Button btn_cancelarVenta;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Subtotal;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbo_MetodoPago;
        private System.Windows.Forms.Button btn_crearProducto;
        private System.Windows.Forms.ComboBox cbo_cliente;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbo_TipoComprobante;
        private System.Windows.Forms.Button btn_crearCliente;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_TotalFinal;
        private System.Windows.Forms.Panel panel4;
    }
}