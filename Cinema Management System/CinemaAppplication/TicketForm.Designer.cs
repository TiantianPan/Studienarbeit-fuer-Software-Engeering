namespace CinemaAppplication
{
    partial class TicketForm
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
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.tbPSale = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoStudent = new System.Windows.Forms.RadioButton();
            this.rdoNormal = new System.Windows.Forms.RadioButton();
            this.cmbDiscount = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCoupon = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rdoFree = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblFullPrice = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblActor = new System.Windows.Forms.Label();
            this.lblDirector = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblScreen = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.TbPReturn = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblTypeReturn = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblDateReturn = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTimeReturn = new System.Windows.Forms.Label();
            this.lblNameReturn = new System.Windows.Forms.Label();
            this.lblFullPriceReturn = new System.Windows.Forms.Label();
            this.lblPriceReturn = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.buttonRuturn = new System.Windows.Forms.Button();
            this.txtBoxReturn = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TabControl1.SuspendLayout();
            this.tbPSale.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.TbPReturn.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.tbPSale);
            this.TabControl1.Controls.Add(this.TbPReturn);
            this.TabControl1.Location = new System.Drawing.Point(33, 30);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(1718, 1153);
            this.TabControl1.TabIndex = 6;
            this.TabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.TabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tbPSale
            // 
            this.tbPSale.Controls.Add(this.groupBox3);
            this.tbPSale.Controls.Add(this.groupBox1);
            this.tbPSale.Controls.Add(this.groupBox2);
            this.tbPSale.Controls.Add(this.treeView1);
            this.tbPSale.Controls.Add(this.comboBox1);
            this.tbPSale.Location = new System.Drawing.Point(8, 39);
            this.tbPSale.Name = "tbPSale";
            this.tbPSale.Padding = new System.Windows.Forms.Padding(3);
            this.tbPSale.Size = new System.Drawing.Size(1702, 1106);
            this.tbPSale.TabIndex = 0;
            this.tbPSale.Text = "Sale System";
            this.tbPSale.UseVisualStyleBackColor = true;
            this.tbPSale.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoStudent);
            this.groupBox3.Controls.Add(this.rdoNormal);
            this.groupBox3.Controls.Add(this.cmbDiscount);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtCoupon);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.rdoFree);
            this.groupBox3.Location = new System.Drawing.Point(1152, 42);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(465, 349);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ticket Art";
            // 
            // rdoStudent
            // 
            this.rdoStudent.AutoSize = true;
            this.rdoStudent.Location = new System.Drawing.Point(38, 94);
            this.rdoStudent.Name = "rdoStudent";
            this.rdoStudent.Size = new System.Drawing.Size(181, 29);
            this.rdoStudent.TabIndex = 9;
            this.rdoStudent.TabStop = true;
            this.rdoStudent.Text = "Student Ticket";
            this.rdoStudent.UseVisualStyleBackColor = true;
            this.rdoStudent.CheckedChanged += new System.EventHandler(this.rdoStudent_CheckedChanged_1);
            // 
            // rdoNormal
            // 
            this.rdoNormal.AutoSize = true;
            this.rdoNormal.Location = new System.Drawing.Point(38, 41);
            this.rdoNormal.Name = "rdoNormal";
            this.rdoNormal.Size = new System.Drawing.Size(111, 29);
            this.rdoNormal.TabIndex = 8;
            this.rdoNormal.TabStop = true;
            this.rdoNormal.Text = "Normal";
            this.rdoNormal.UseVisualStyleBackColor = true;
            this.rdoNormal.CheckedChanged += new System.EventHandler(this.rdoNormal_CheckedChanged);
            // 
            // cmbDiscount
            // 
            this.cmbDiscount.FormattingEnabled = true;
            this.cmbDiscount.Location = new System.Drawing.Point(135, 150);
            this.cmbDiscount.Name = "cmbDiscount";
            this.cmbDiscount.Size = new System.Drawing.Size(273, 33);
            this.cmbDiscount.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 25);
            this.label9.TabIndex = 5;
            this.label9.Text = "Discount";
            // 
            // txtCoupon
            // 
            this.txtCoupon.Location = new System.Drawing.Point(135, 238);
            this.txtCoupon.Name = "txtCoupon";
            this.txtCoupon.Size = new System.Drawing.Size(273, 31);
            this.txtCoupon.TabIndex = 4;
            this.txtCoupon.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 25);
            this.label8.TabIndex = 3;
            this.label8.Text = "Coupon";
            // 
            // rdoFree
            // 
            this.rdoFree.AutoSize = true;
            this.rdoFree.Location = new System.Drawing.Point(38, 197);
            this.rdoFree.Name = "rdoFree";
            this.rdoFree.Size = new System.Drawing.Size(151, 29);
            this.rdoFree.TabIndex = 2;
            this.rdoFree.TabStop = true;
            this.rdoFree.Text = "Free Ticket";
            this.rdoFree.UseVisualStyleBackColor = true;
            this.rdoFree.CheckedChanged += new System.EventHandler(this.rdoFree_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblPrice);
            this.groupBox1.Controls.Add(this.lblFullPrice);
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.lblActor);
            this.groupBox1.Controls.Add(this.lblDirector);
            this.groupBox1.Controls.Add(this.lblTime);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(446, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 349);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Movie Information";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(75, 41);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 25);
            this.lblDate.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 25);
            this.label11.TabIndex = 15;
            this.label11.Text = "Date:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(343, 283);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(0, 25);
            this.lblPrice.TabIndex = 14;
            // 
            // lblFullPrice
            // 
            this.lblFullPrice.AutoSize = true;
            this.lblFullPrice.Location = new System.Drawing.Point(365, 244);
            this.lblFullPrice.Name = "lblFullPrice";
            this.lblFullPrice.Size = new System.Drawing.Size(0, 25);
            this.lblFullPrice.TabIndex = 13;
            this.lblFullPrice.Click += new System.EventHandler(this.lblFullPrice_Click);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(328, 201);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(0, 25);
            this.lblType.TabIndex = 12;
            this.lblType.Click += new System.EventHandler(this.lblType_Click);
            // 
            // lblActor
            // 
            this.lblActor.AutoSize = true;
            this.lblActor.Location = new System.Drawing.Point(328, 158);
            this.lblActor.Name = "lblActor";
            this.lblActor.Size = new System.Drawing.Size(0, 25);
            this.lblActor.TabIndex = 11;
            // 
            // lblDirector
            // 
            this.lblDirector.AutoSize = true;
            this.lblDirector.Location = new System.Drawing.Point(343, 121);
            this.lblDirector.Name = "lblDirector";
            this.lblDirector.Size = new System.Drawing.Size(0, 25);
            this.lblDirector.TabIndex = 10;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(440, 41);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 25);
            this.lblTime.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(356, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 25);
            this.label10.TabIndex = 8;
            this.label10.Text = "Time:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(328, 80);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 25);
            this.lblName.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(235, 283);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Price:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(235, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Full Price:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(235, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Actor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Director:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(210, 204);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblScreen);
            this.groupBox2.Location = new System.Drawing.Point(446, 427);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1171, 650);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seat Status";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lblScreen
            // 
            this.lblScreen.AutoSize = true;
            this.lblScreen.BackColor = System.Drawing.Color.DimGray;
            this.lblScreen.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblScreen.Location = new System.Drawing.Point(513, 53);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(80, 25);
            this.lblScreen.TabIndex = 0;
            this.lblScreen.Text = "Screen";
            this.lblScreen.Click += new System.EventHandler(this.lblScreen_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(20, 90);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(365, 563);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect_1);
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "Time";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(20, 51);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(365, 33);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.ValueMember = "Time";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            this.comboBox1.TextUpdate += new System.EventHandler(this.comboBox1_TextUpdate);
            // 
            // TbPReturn
            // 
            this.TbPReturn.Controls.Add(this.groupBox4);
            this.TbPReturn.Controls.Add(this.buttonRuturn);
            this.TbPReturn.Controls.Add(this.txtBoxReturn);
            this.TbPReturn.Controls.Add(this.label12);
            this.TbPReturn.Location = new System.Drawing.Point(8, 39);
            this.TbPReturn.Name = "TbPReturn";
            this.TbPReturn.Padding = new System.Windows.Forms.Padding(3);
            this.TbPReturn.Size = new System.Drawing.Size(1702, 1106);
            this.TbPReturn.TabIndex = 2;
            this.TbPReturn.Text = "Return System";
            this.TbPReturn.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblTypeReturn);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.lblDateReturn);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.lblTimeReturn);
            this.groupBox4.Controls.Add(this.lblNameReturn);
            this.groupBox4.Controls.Add(this.lblFullPriceReturn);
            this.groupBox4.Controls.Add(this.lblPriceReturn);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Location = new System.Drawing.Point(63, 113);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(580, 299);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ticket Information";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // lblTypeReturn
            // 
            this.lblTypeReturn.AutoSize = true;
            this.lblTypeReturn.Location = new System.Drawing.Point(149, 242);
            this.lblTypeReturn.Name = "lblTypeReturn";
            this.lblTypeReturn.Size = new System.Drawing.Size(0, 25);
            this.lblTypeReturn.TabIndex = 18;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 242);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 25);
            this.label13.TabIndex = 17;
            this.label13.Text = "Ticket type:";
            // 
            // lblDateReturn
            // 
            this.lblDateReturn.AutoSize = true;
            this.lblDateReturn.Location = new System.Drawing.Point(75, 41);
            this.lblDateReturn.Name = "lblDateReturn";
            this.lblDateReturn.Size = new System.Drawing.Size(0, 25);
            this.lblDateReturn.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 41);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 25);
            this.label14.TabIndex = 15;
            this.label14.Text = "Date:";
            // 
            // lblTimeReturn
            // 
            this.lblTimeReturn.AutoSize = true;
            this.lblTimeReturn.Location = new System.Drawing.Point(106, 80);
            this.lblTimeReturn.Name = "lblTimeReturn";
            this.lblTimeReturn.Size = new System.Drawing.Size(0, 25);
            this.lblTimeReturn.TabIndex = 14;
            // 
            // lblNameReturn
            // 
            this.lblNameReturn.AutoSize = true;
            this.lblNameReturn.Location = new System.Drawing.Point(161, 121);
            this.lblNameReturn.Name = "lblNameReturn";
            this.lblNameReturn.Size = new System.Drawing.Size(0, 25);
            this.lblNameReturn.TabIndex = 13;
            // 
            // lblFullPriceReturn
            // 
            this.lblFullPriceReturn.AutoSize = true;
            this.lblFullPriceReturn.Location = new System.Drawing.Point(161, 158);
            this.lblFullPriceReturn.Name = "lblFullPriceReturn";
            this.lblFullPriceReturn.Size = new System.Drawing.Size(0, 25);
            this.lblFullPriceReturn.TabIndex = 12;
            // 
            // lblPriceReturn
            // 
            this.lblPriceReturn.AutoSize = true;
            this.lblPriceReturn.Location = new System.Drawing.Point(114, 201);
            this.lblPriceReturn.Name = "lblPriceReturn";
            this.lblPriceReturn.Size = new System.Drawing.Size(0, 25);
            this.lblPriceReturn.TabIndex = 11;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 80);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 25);
            this.label21.TabIndex = 8;
            this.label21.Text = "Time:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(8, 201);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(67, 25);
            this.label23.TabIndex = 6;
            this.label23.Text = "Price:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 158);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(108, 25);
            this.label24.TabIndex = 5;
            this.label24.Text = "Full Price:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(6, 121);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(138, 25);
            this.label28.TabIndex = 1;
            this.label28.Text = "Movie Name:";
            // 
            // buttonRuturn
            // 
            this.buttonRuturn.Location = new System.Drawing.Point(493, 51);
            this.buttonRuturn.Name = "buttonRuturn";
            this.buttonRuturn.Size = new System.Drawing.Size(150, 45);
            this.buttonRuturn.TabIndex = 2;
            this.buttonRuturn.Text = "Return";
            this.buttonRuturn.UseVisualStyleBackColor = true;
            this.buttonRuturn.Click += new System.EventHandler(this.buttonRuturn_Click);
            // 
            // txtBoxReturn
            // 
            this.txtBoxReturn.Location = new System.Drawing.Point(174, 58);
            this.txtBoxReturn.Name = "txtBoxReturn";
            this.txtBoxReturn.Size = new System.Drawing.Size(274, 31);
            this.txtBoxReturn.TabIndex = 1;
            this.txtBoxReturn.TextChanged += new System.EventHandler(this.txtBoxReturn_TextChanged);
            this.txtBoxReturn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBoxReturn_KeyUp);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(58, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 25);
            this.label12.TabIndex = 0;
            this.label12.Text = "Ticket ID";
            // 
            // TicketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1782, 1195);
            this.Controls.Add(this.TabControl1);
            this.Name = "TicketForm";
            this.Text = "Sale/Return System";
            this.Load += new System.EventHandler(this.TicketForm_Load);
            this.TabControl1.ResumeLayout(false);
            this.tbPSale.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.TbPReturn.ResumeLayout(false);
            this.TbPReturn.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl1;
        private System.Windows.Forms.TabPage tbPSale;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabPage TbPReturn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoFree;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCoupon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbDiscount;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblActor;
        private System.Windows.Forms.Label lblDirector;
        private System.Windows.Forms.Label lblFullPrice;
        private System.Windows.Forms.Label lblPrice;
        //private CinemaDBDataSet cinemaDBDataSet;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.RadioButton rdoNormal;
        private System.Windows.Forms.RadioButton rdoStudent;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblDateReturn;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTimeReturn;
        private System.Windows.Forms.Label lblNameReturn;
        private System.Windows.Forms.Label lblFullPriceReturn;
        private System.Windows.Forms.Label lblPriceReturn;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button buttonRuturn;
        private System.Windows.Forms.TextBox txtBoxReturn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTypeReturn;
        private System.Windows.Forms.Label label13;
        //private System.Windows.Forms.BindingSource scheduleItemsBindingSource;
        //private CinemaDBDataSetTableAdapters.ScheduleItemsTableAdapter scheduleItemsTableAdapter;
        //private CinemaDBDataSet1 cinemaDBDataSet1;
        //private System.Windows.Forms.BindingSource cinemaDBDataSet1BindingSource;
        //private System.Windows.Forms.BindingSource bindingSource1;


    }
}

