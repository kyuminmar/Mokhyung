﻿
namespace Mokhyung_Management.InOut
{
    partial class MainInOut
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Dgv_IOList = new System.Windows.Forms.DataGridView();
            this.IOLSEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IO_MokName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IO_SCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IO_IOType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IO_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_IOList)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(460, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "입/출고등록하기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(460, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 47);
            this.button2.TabIndex = 1;
            this.button2.Text = "톰슨집등록";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Dgv_IOList
            // 
            this.Dgv_IOList.AllowUserToAddRows = false;
            this.Dgv_IOList.AllowUserToDeleteRows = false;
            this.Dgv_IOList.AllowUserToResizeColumns = false;
            this.Dgv_IOList.AllowUserToResizeRows = false;
            this.Dgv_IOList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_IOList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IOLSEQ,
            this.RowNum,
            this.IO_MokName,
            this.IO_SCName,
            this.IO_IOType,
            this.IO_Date});
            this.Dgv_IOList.Location = new System.Drawing.Point(0, 120);
            this.Dgv_IOList.Name = "Dgv_IOList";
            this.Dgv_IOList.RowHeadersVisible = false;
            this.Dgv_IOList.RowTemplate.Height = 23;
            this.Dgv_IOList.Size = new System.Drawing.Size(600, 331);
            this.Dgv_IOList.TabIndex = 2;
            // 
            // IOLSEQ
            // 
            this.IOLSEQ.HeaderText = "IOLSEQ";
            this.IOLSEQ.Name = "IOLSEQ";
            this.IOLSEQ.Visible = false;
            // 
            // RowNum
            // 
            this.RowNum.HeaderText = "번호";
            this.RowNum.Name = "RowNum";
            this.RowNum.ReadOnly = true;
            this.RowNum.Width = 40;
            // 
            // IO_MokName
            // 
            this.IO_MokName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IO_MokName.HeaderText = "목형이름";
            this.IO_MokName.Name = "IO_MokName";
            this.IO_MokName.ReadOnly = true;
            // 
            // IO_SCName
            // 
            this.IO_SCName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IO_SCName.HeaderText = "목형집이름";
            this.IO_SCName.Name = "IO_SCName";
            this.IO_SCName.ReadOnly = true;
            // 
            // IO_IOType
            // 
            this.IO_IOType.HeaderText = "입출고여부";
            this.IO_IOType.Name = "IO_IOType";
            this.IO_IOType.ReadOnly = true;
            this.IO_IOType.Width = 70;
            // 
            // IO_Date
            // 
            this.IO_Date.HeaderText = "입출고일자";
            this.IO_Date.Name = "IO_Date";
            this.IO_Date.ReadOnly = true;
            // 
            // MainInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 450);
            this.Controls.Add(this.Dgv_IOList);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "MainInOut";
            this.Text = "입출고내역";
            this.Load += new System.EventHandler(this.Load_MainInOut);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_IOList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView Dgv_IOList;
        private System.Windows.Forms.DataGridViewTextBoxColumn IOLSEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn IO_MokName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IO_SCName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IO_IOType;
        private System.Windows.Forms.DataGridViewTextBoxColumn IO_Date;
    }
}