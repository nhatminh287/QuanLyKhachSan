
namespace QuanLyKhachSanGUI
{
    partial class MHxemyeucaudatphong
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MaDoan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TiepNhanYeuCau = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.Email,
            this.MaDoan,
            this.columnHeader1});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(51, 102);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(809, 394);
            this.listView1.TabIndex = 15;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ngày đến";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số đêm lưu trú";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Phòng";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Yêu cầu đặc biệt";
            this.columnHeader5.Width = 100;
            // 
            // Email
            // 
            this.Email.Text = "Mã khách hàng";
            this.Email.Width = 100;
            // 
            // MaDoan
            // 
            this.MaDoan.Text = "Nhân viên tiếp nhận";
            this.MaDoan.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tình trạng";
            this.columnHeader1.Width = 100;
            // 
            // TiepNhanYeuCau
            // 
            this.TiepNhanYeuCau.BackColor = System.Drawing.SystemColors.Control;
            this.TiepNhanYeuCau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TiepNhanYeuCau.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TiepNhanYeuCau.Location = new System.Drawing.Point(314, 517);
            this.TiepNhanYeuCau.Name = "TiepNhanYeuCau";
            this.TiepNhanYeuCau.Size = new System.Drawing.Size(232, 52);
            this.TiepNhanYeuCau.TabIndex = 16;
            this.TiepNhanYeuCau.Text = "Tiếp nhận yêu cầu";
            this.TiepNhanYeuCau.UseVisualStyleBackColor = false;
            this.TiepNhanYeuCau.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Location = new System.Drawing.Point(225, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(381, 51);
            this.label7.TabIndex = 34;
            this.label7.Text = "Yêu cầu đặt phòng";
            // 
            // MHxemyeucaudatphong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 593);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TiepNhanYeuCau);
            this.Controls.Add(this.listView1);
            this.Name = "MHxemyeucaudatphong";
            this.Text = "Danh sách yêu cầu đặt phòng";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ColumnHeader MaDoan;
        private System.Windows.Forms.Button TiepNhanYeuCau;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}