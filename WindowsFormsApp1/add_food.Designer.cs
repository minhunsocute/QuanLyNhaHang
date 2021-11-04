
namespace WindowsFormsApp1
{
    partial class add_food
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.price_text = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.category_textBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Button6 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.name_textBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.id_textBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.price_text)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(158)))), ((int)(((byte)(63)))));
            this.panel1.Controls.Add(this.price_text);
            this.panel1.Controls.Add(this.category_textBox1);
            this.panel1.Controls.Add(this.guna2Button6);
            this.panel1.Controls.Add(this.guna2Button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.name_textBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.id_textBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(11, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 366);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // price_text
            // 
            this.price_text.BackColor = System.Drawing.Color.Transparent;
            this.price_text.BorderColor = System.Drawing.Color.Black;
            this.price_text.BorderRadius = 12;
            this.price_text.BorderThickness = 2;
            this.price_text.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.price_text.DisabledState.Parent = this.price_text;
            this.price_text.FocusedState.Parent = this.price_text;
            this.price_text.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.price_text.ForeColor = System.Drawing.Color.Black;
            this.price_text.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.price_text.Location = new System.Drawing.Point(103, 248);
            this.price_text.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.price_text.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.price_text.Name = "price_text";
            this.price_text.ShadowDecoration.Parent = this.price_text;
            this.price_text.Size = new System.Drawing.Size(138, 31);
            this.price_text.TabIndex = 56;
            this.price_text.UpDownButtonFillColor = System.Drawing.Color.SeaGreen;
            this.price_text.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // category_textBox1
            // 
            this.category_textBox1.BackColor = System.Drawing.Color.Transparent;
            this.category_textBox1.BorderColor = System.Drawing.Color.Black;
            this.category_textBox1.BorderRadius = 12;
            this.category_textBox1.BorderThickness = 2;
            this.category_textBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.category_textBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.category_textBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.category_textBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.category_textBox1.FocusedState.Parent = this.category_textBox1;
            this.category_textBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.category_textBox1.ForeColor = System.Drawing.Color.Black;
            this.category_textBox1.HoverState.Parent = this.category_textBox1;
            this.category_textBox1.ItemHeight = 30;
            this.category_textBox1.ItemsAppearance.Parent = this.category_textBox1;
            this.category_textBox1.Location = new System.Drawing.Point(103, 191);
            this.category_textBox1.Name = "category_textBox1";
            this.category_textBox1.ShadowDecoration.Parent = this.category_textBox1;
            this.category_textBox1.Size = new System.Drawing.Size(138, 36);
            this.category_textBox1.TabIndex = 55;
            this.category_textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.category_textBox1.SelectedIndexChanged += new System.EventHandler(this.category_textBox1_SelectedIndexChanged);
            this.category_textBox1.Click += new System.EventHandler(this.category_textBox1_Click);
            // 
            // guna2Button6
            // 
            this.guna2Button6.BorderRadius = 11;
            this.guna2Button6.BorderThickness = 2;
            this.guna2Button6.CheckedState.Parent = this.guna2Button6;
            this.guna2Button6.CustomImages.Parent = this.guna2Button6;
            this.guna2Button6.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button6.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button6.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button6.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button6.DisabledState.Parent = this.guna2Button6;
            this.guna2Button6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(67)))), ((int)(((byte)(18)))));
            this.guna2Button6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button6.ForeColor = System.Drawing.Color.White;
            this.guna2Button6.HoverState.Parent = this.guna2Button6;
            this.guna2Button6.Location = new System.Drawing.Point(167, 309);
            this.guna2Button6.Name = "guna2Button6";
            this.guna2Button6.ShadowDecoration.Parent = this.guna2Button6;
            this.guna2Button6.Size = new System.Drawing.Size(74, 45);
            this.guna2Button6.TabIndex = 53;
            this.guna2Button6.Text = "Insert Food";
            this.guna2Button6.Click += new System.EventHandler(this.guna2Button6_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.back;
            this.guna2Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Button1.BorderRadius = 13;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.DisabledState.Parent = this.guna2Button1;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Location = new System.Drawing.Point(30, 320);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(44, 34);
            this.guna2Button1.TabIndex = 52;
            this.guna2Button1.Text = "<=";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 45);
            this.label1.TabIndex = 51;
            this.label1.Text = "Insert Food";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.add_to_basket;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(13, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(51, 44);
            this.panel2.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 25);
            this.label5.TabIndex = 49;
            this.label5.Text = "Price :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 25);
            this.label4.TabIndex = 47;
            this.label4.Text = "Category:";
            // 
            // name_textBox
            // 
            this.name_textBox.BorderColor = System.Drawing.Color.Black;
            this.name_textBox.BorderRadius = 12;
            this.name_textBox.BorderThickness = 2;
            this.name_textBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.name_textBox.DefaultText = "";
            this.name_textBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.name_textBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.name_textBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.name_textBox.DisabledState.Parent = this.name_textBox;
            this.name_textBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.name_textBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.name_textBox.FocusedState.Parent = this.name_textBox;
            this.name_textBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.name_textBox.ForeColor = System.Drawing.Color.Black;
            this.name_textBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.name_textBox.HoverState.Parent = this.name_textBox;
            this.name_textBox.Location = new System.Drawing.Point(103, 128);
            this.name_textBox.Name = "name_textBox";
            this.name_textBox.PasswordChar = '\0';
            this.name_textBox.PlaceholderForeColor = System.Drawing.Color.Black;
            this.name_textBox.PlaceholderText = "";
            this.name_textBox.SelectedText = "";
            this.name_textBox.ShadowDecoration.Parent = this.name_textBox;
            this.name_textBox.Size = new System.Drawing.Size(138, 31);
            this.name_textBox.TabIndex = 45;
            this.name_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 25);
            this.label3.TabIndex = 44;
            this.label3.Text = "Name:";
            // 
            // id_textBox
            // 
            this.id_textBox.BorderColor = System.Drawing.Color.Black;
            this.id_textBox.BorderRadius = 12;
            this.id_textBox.BorderThickness = 2;
            this.id_textBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.id_textBox.DefaultText = "";
            this.id_textBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.id_textBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.id_textBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.id_textBox.DisabledState.Parent = this.id_textBox;
            this.id_textBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.id_textBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.id_textBox.FocusedState.Parent = this.id_textBox;
            this.id_textBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.id_textBox.ForeColor = System.Drawing.Color.Black;
            this.id_textBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.id_textBox.HoverState.Parent = this.id_textBox;
            this.id_textBox.Location = new System.Drawing.Point(103, 78);
            this.id_textBox.Name = "id_textBox";
            this.id_textBox.PasswordChar = '\0';
            this.id_textBox.PlaceholderForeColor = System.Drawing.Color.Black;
            this.id_textBox.PlaceholderText = "";
            this.id_textBox.SelectedText = "";
            this.id_textBox.ShadowDecoration.Parent = this.id_textBox;
            this.id_textBox.Size = new System.Drawing.Size(138, 31);
            this.id_textBox.TabIndex = 43;
            this.id_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 25);
            this.label2.TabIndex = 42;
            this.label2.Text = "ID :";
            // 
            // add_food
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.Controls.Add(this.panel1);
            this.Name = "add_food";
            this.Size = new System.Drawing.Size(282, 390);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.price_text)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button6;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox name_textBox;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox id_textBox;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox category_textBox1;
        private Guna.UI2.WinForms.Guna2NumericUpDown price_text;
    }
}
