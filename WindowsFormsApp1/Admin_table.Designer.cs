
namespace WindowsFormsApp1
{
    partial class Admin_table
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.add_bill = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(89, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 45);
            this.label1.TabIndex = 2;
            this.label1.Text = "Table";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(158)))), ((int)(((byte)(63)))));
            this.panel3.Location = new System.Drawing.Point(21, 126);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(597, 411);
            this.panel3.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.smiling_chef_cartoon_character_holding_platter_266639_108;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(635, 261);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 276);
            this.panel2.TabIndex = 35;
            // 
            // add_bill
            // 
            this.add_bill.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.add_to_basket1;
            this.add_bill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.add_bill.BorderRadius = 12;
            this.add_bill.BorderThickness = 2;
            this.add_bill.CheckedState.Parent = this.add_bill;
            this.add_bill.CustomImages.Parent = this.add_bill;
            this.add_bill.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.add_bill.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.add_bill.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.add_bill.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.add_bill.DisabledState.Parent = this.add_bill;
            this.add_bill.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(67)))), ((int)(((byte)(18)))));
            this.add_bill.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.add_bill.ForeColor = System.Drawing.Color.Black;
            this.add_bill.HoverState.Parent = this.add_bill;
            this.add_bill.Location = new System.Drawing.Point(709, 144);
            this.add_bill.Name = "add_bill";
            this.add_bill.ShadowDecoration.Parent = this.add_bill;
            this.add_bill.Size = new System.Drawing.Size(92, 82);
            this.add_bill.TabIndex = 34;
            this.add_bill.Text = "INSERT TABLE";
            this.add_bill.Click += new System.EventHandler(this.add_bill_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.table1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(21, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(62, 45);
            this.panel1.TabIndex = 5;
            // 
            // Admin_table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.add_bill);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "Admin_table";
            this.Size = new System.Drawing.Size(878, 586);
            this.Load += new System.EventHandler(this.Admin_table_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2Button add_bill;
        private System.Windows.Forms.Panel panel2;
    }
}
