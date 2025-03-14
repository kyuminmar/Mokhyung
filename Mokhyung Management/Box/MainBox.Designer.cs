﻿
namespace Mokhyung_Management.Box
{
    partial class MainBox
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
            this.Dgv_BoxList = new System.Windows.Forms.DataGridView();
            this.MI_Seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MI_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MI_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MIS_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MI_Jang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MI_Pok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MI_Go = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MIB_Pyunglyang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MIS_PanNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MI_RegDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MI_ModDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MIS_Bigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MIB_FileNAme = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Combo_SearchType = new System.Windows.Forms.ComboBox();
            this.Text_SearchText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Text_SearchJang = new System.Windows.Forms.TextBox();
            this.Text_SearchPok = new System.Windows.Forms.TextBox();
            this.Text_SearchGo = new System.Windows.Forms.TextBox();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Chk_UseGap = new System.Windows.Forms.CheckBox();
            this.Text_GapSize = new System.Windows.Forms.TextBox();
            this.Lb_GapUse = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Rb_GapGo = new System.Windows.Forms.RadioButton();
            this.Rb_GapPok = new System.Windows.Forms.RadioButton();
            this.Rb_GapJang = new System.Windows.Forms.RadioButton();
            this.Btn_AddMok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_BoxList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.Lb_GapUse.SuspendLayout();
            this.SuspendLayout();
            // 
            // Dgv_BoxList
            // 
            this.Dgv_BoxList.AllowUserToAddRows = false;
            this.Dgv_BoxList.AllowUserToOrderColumns = true;
            this.Dgv_BoxList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_BoxList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MI_Seq,
            this.RowNum,
            this.MI_Name,
            this.MI_Number,
            this.MIS_Type,
            this.MI_Jang,
            this.MI_Pok,
            this.MI_Go,
            this.MIB_Pyunglyang,
            this.MIS_PanNumber,
            this.MI_RegDate,
            this.MI_ModDate,
            this.MIS_Bigo,
            this.MIB_FileNAme});
            this.Dgv_BoxList.Location = new System.Drawing.Point(0, 72);
            this.Dgv_BoxList.Name = "Dgv_BoxList";
            this.Dgv_BoxList.RowHeadersVisible = false;
            this.Dgv_BoxList.RowTemplate.Height = 23;
            this.Dgv_BoxList.Size = new System.Drawing.Size(1153, 378);
            this.Dgv_BoxList.TabIndex = 0;
            this.Dgv_BoxList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_BoxList_CellClick);
            this.Dgv_BoxList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_BoxList_CellDoubleClick);
            this.Dgv_BoxList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainSP_KeyDown);
            // 
            // MI_Seq
            // 
            this.MI_Seq.HeaderText = "MI_Seq";
            this.MI_Seq.Name = "MI_Seq";
            this.MI_Seq.Visible = false;
            // 
            // RowNum
            // 
            this.RowNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.RowNum.HeaderText = "번호";
            this.RowNum.Name = "RowNum";
            this.RowNum.ReadOnly = true;
            this.RowNum.Width = 54;
            // 
            // MI_Name
            // 
            this.MI_Name.HeaderText = "목형명";
            this.MI_Name.Name = "MI_Name";
            this.MI_Name.ReadOnly = true;
            this.MI_Name.Width = 150;
            // 
            // MI_Number
            // 
            this.MI_Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MI_Number.HeaderText = "목형번호";
            this.MI_Number.Name = "MI_Number";
            this.MI_Number.ReadOnly = true;
            this.MI_Number.Width = 78;
            // 
            // MIS_Type
            // 
            this.MIS_Type.HeaderText = "타입";
            this.MIS_Type.Name = "MIS_Type";
            this.MIS_Type.ReadOnly = true;
            this.MIS_Type.Width = 54;
            // 
            // MI_Jang
            // 
            this.MI_Jang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MI_Jang.HeaderText = "장";
            this.MI_Jang.Name = "MI_Jang";
            this.MI_Jang.ReadOnly = true;
            this.MI_Jang.Width = 42;
            // 
            // MI_Pok
            // 
            this.MI_Pok.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MI_Pok.HeaderText = "폭";
            this.MI_Pok.Name = "MI_Pok";
            this.MI_Pok.ReadOnly = true;
            this.MI_Pok.Width = 42;
            // 
            // MI_Go
            // 
            this.MI_Go.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MI_Go.HeaderText = "고";
            this.MI_Go.Name = "MI_Go";
            this.MI_Go.ReadOnly = true;
            this.MI_Go.Width = 42;
            // 
            // MIB_Pyunglyang
            // 
            this.MIB_Pyunglyang.HeaderText = "평량";
            this.MIB_Pyunglyang.Name = "MIB_Pyunglyang";
            this.MIB_Pyunglyang.ReadOnly = true;
            this.MIB_Pyunglyang.Width = 66;
            // 
            // MIS_PanNumber
            // 
            this.MIS_PanNumber.HeaderText = "판수";
            this.MIS_PanNumber.Name = "MIS_PanNumber";
            this.MIS_PanNumber.ReadOnly = true;
            this.MIS_PanNumber.Width = 66;
            // 
            // MI_RegDate
            // 
            this.MI_RegDate.HeaderText = "등록일자";
            this.MI_RegDate.Name = "MI_RegDate";
            this.MI_RegDate.ReadOnly = true;
            this.MI_RegDate.Width = 80;
            // 
            // MI_ModDate
            // 
            this.MI_ModDate.HeaderText = "수정일자";
            this.MI_ModDate.Name = "MI_ModDate";
            this.MI_ModDate.ReadOnly = true;
            this.MI_ModDate.Width = 80;
            // 
            // MIS_Bigo
            // 
            this.MIS_Bigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MIS_Bigo.HeaderText = "비고";
            this.MIS_Bigo.Name = "MIS_Bigo";
            this.MIS_Bigo.ReadOnly = true;
            // 
            // MIB_FileNAme
            // 
            this.MIB_FileNAme.HeaderText = "파일명";
            this.MIB_FileNAme.Name = "MIB_FileNAme";
            this.MIB_FileNAme.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MIB_FileNAme.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1078, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "새로고침";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Dgv_BoxList_Refresh);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Combo_SearchType);
            this.groupBox1.Controls.Add(this.Text_SearchText);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 56);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "텍스트로검색";
            // 
            // Combo_SearchType
            // 
            this.Combo_SearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_SearchType.FormattingEnabled = true;
            this.Combo_SearchType.Location = new System.Drawing.Point(22, 20);
            this.Combo_SearchType.Name = "Combo_SearchType";
            this.Combo_SearchType.Size = new System.Drawing.Size(89, 20);
            this.Combo_SearchType.TabIndex = 0;
            // 
            // Text_SearchText
            // 
            this.Text_SearchText.Location = new System.Drawing.Point(117, 20);
            this.Text_SearchText.Name = "Text_SearchText";
            this.Text_SearchText.Size = new System.Drawing.Size(101, 21);
            this.Text_SearchText.TabIndex = 1;
            this.Text_SearchText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainSP_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "장";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "폭";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "고";
            // 
            // Text_SearchJang
            // 
            this.Text_SearchJang.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Text_SearchJang.Location = new System.Drawing.Point(40, 20);
            this.Text_SearchJang.Name = "Text_SearchJang";
            this.Text_SearchJang.Size = new System.Drawing.Size(52, 21);
            this.Text_SearchJang.TabIndex = 2;
            this.Text_SearchJang.Leave += new System.EventHandler(this.Search_Validate_Leave);
            // 
            // Text_SearchPok
            // 
            this.Text_SearchPok.Location = new System.Drawing.Point(121, 20);
            this.Text_SearchPok.Name = "Text_SearchPok";
            this.Text_SearchPok.Size = new System.Drawing.Size(52, 21);
            this.Text_SearchPok.TabIndex = 3;
            this.Text_SearchPok.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainSP_KeyDown);
            this.Text_SearchPok.Leave += new System.EventHandler(this.Search_Validate_Leave);
            // 
            // Text_SearchGo
            // 
            this.Text_SearchGo.Location = new System.Drawing.Point(202, 20);
            this.Text_SearchGo.Name = "Text_SearchGo";
            this.Text_SearchGo.Size = new System.Drawing.Size(52, 21);
            this.Text_SearchGo.TabIndex = 4;
            this.Text_SearchGo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainSP_KeyDown);
            this.Text_SearchGo.Leave += new System.EventHandler(this.Search_Validate_Leave);
            // 
            // Btn_Search
            // 
            this.Btn_Search.Location = new System.Drawing.Point(919, 21);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(68, 36);
            this.Btn_Search.TabIndex = 5;
            this.Btn_Search.Text = "검색";
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.Chk_UseGap);
            this.groupBox2.Controls.Add(this.Text_SearchGo);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Text_SearchPok);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Text_SearchJang);
            this.groupBox2.Location = new System.Drawing.Point(264, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 56);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "사이즈로검색";
            // 
            // Chk_UseGap
            // 
            this.Chk_UseGap.AutoSize = true;
            this.Chk_UseGap.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Chk_UseGap.Enabled = false;
            this.Chk_UseGap.Location = new System.Drawing.Point(269, 23);
            this.Chk_UseGap.Name = "Chk_UseGap";
            this.Chk_UseGap.Size = new System.Drawing.Size(96, 16);
            this.Chk_UseGap.TabIndex = 10;
            this.Chk_UseGap.Text = "오차범위사용";
            this.Chk_UseGap.UseVisualStyleBackColor = true;
            this.Chk_UseGap.CheckedChanged += new System.EventHandler(this.Ckb_UseGap_CheckedChanged);
            // 
            // Text_GapSize
            // 
            this.Text_GapSize.Location = new System.Drawing.Point(209, 22);
            this.Text_GapSize.Name = "Text_GapSize";
            this.Text_GapSize.Size = new System.Drawing.Size(41, 21);
            this.Text_GapSize.TabIndex = 11;
            this.Text_GapSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainSP_KeyDown);
            // 
            // Lb_GapUse
            // 
            this.Lb_GapUse.Controls.Add(this.label4);
            this.Lb_GapUse.Controls.Add(this.Rb_GapGo);
            this.Lb_GapUse.Controls.Add(this.Rb_GapPok);
            this.Lb_GapUse.Controls.Add(this.Rb_GapJang);
            this.Lb_GapUse.Controls.Add(this.Text_GapSize);
            this.Lb_GapUse.Location = new System.Drawing.Point(657, 10);
            this.Lb_GapUse.Name = "Lb_GapUse";
            this.Lb_GapUse.Size = new System.Drawing.Size(256, 55);
            this.Lb_GapUse.TabIndex = 12;
            this.Lb_GapUse.TabStop = false;
            this.Lb_GapUse.Text = "오차범위설정";
            this.Lb_GapUse.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(138, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "오차범위+-";
            // 
            // Rb_GapGo
            // 
            this.Rb_GapGo.AutoSize = true;
            this.Rb_GapGo.Location = new System.Drawing.Point(88, 25);
            this.Rb_GapGo.Name = "Rb_GapGo";
            this.Rb_GapGo.Size = new System.Drawing.Size(35, 16);
            this.Rb_GapGo.TabIndex = 14;
            this.Rb_GapGo.TabStop = true;
            this.Rb_GapGo.Text = "고";
            this.Rb_GapGo.UseVisualStyleBackColor = true;
            // 
            // Rb_GapPok
            // 
            this.Rb_GapPok.AutoSize = true;
            this.Rb_GapPok.Location = new System.Drawing.Point(47, 25);
            this.Rb_GapPok.Name = "Rb_GapPok";
            this.Rb_GapPok.Size = new System.Drawing.Size(35, 16);
            this.Rb_GapPok.TabIndex = 13;
            this.Rb_GapPok.TabStop = true;
            this.Rb_GapPok.Text = "폭";
            this.Rb_GapPok.UseVisualStyleBackColor = true;
            // 
            // Rb_GapJang
            // 
            this.Rb_GapJang.AutoSize = true;
            this.Rb_GapJang.Location = new System.Drawing.Point(6, 25);
            this.Rb_GapJang.Name = "Rb_GapJang";
            this.Rb_GapJang.Size = new System.Drawing.Size(35, 16);
            this.Rb_GapJang.TabIndex = 12;
            this.Rb_GapJang.TabStop = true;
            this.Rb_GapJang.Text = "장";
            this.Rb_GapJang.UseVisualStyleBackColor = true;
            // 
            // Btn_AddMok
            // 
            this.Btn_AddMok.Location = new System.Drawing.Point(1078, 29);
            this.Btn_AddMok.Name = "Btn_AddMok";
            this.Btn_AddMok.Size = new System.Drawing.Size(75, 36);
            this.Btn_AddMok.TabIndex = 7;
            this.Btn_AddMok.Text = "목형추가";
            this.Btn_AddMok.UseVisualStyleBackColor = true;
            this.Btn_AddMok.Click += new System.EventHandler(this.Btn_AddMok_Click);
            // 
            // MainBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 450);
            this.Controls.Add(this.Btn_AddMok);
            this.Controls.Add(this.Lb_GapUse);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Btn_Search);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Dgv_BoxList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainBox";
            this.Text = "박스목형목록";
            this.Load += new System.EventHandler(this.MainSP_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainSP_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_BoxList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.Lb_GapUse.ResumeLayout(false);
            this.Lb_GapUse.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Dgv_BoxList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox Combo_SearchType;
        private System.Windows.Forms.TextBox Text_SearchText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Text_SearchJang;
        private System.Windows.Forms.TextBox Text_SearchPok;
        private System.Windows.Forms.TextBox Text_SearchGo;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox Text_GapSize;
        private System.Windows.Forms.CheckBox Chk_UseGap;
        private System.Windows.Forms.GroupBox Lb_GapUse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton Rb_GapGo;
        private System.Windows.Forms.RadioButton Rb_GapPok;
        private System.Windows.Forms.RadioButton Rb_GapJang;
        private System.Windows.Forms.Button Btn_AddMok;
        private System.Windows.Forms.DataGridViewTextBoxColumn MI_Seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn MI_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn MI_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn MIS_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn MI_Jang;
        private System.Windows.Forms.DataGridViewTextBoxColumn MI_Pok;
        private System.Windows.Forms.DataGridViewTextBoxColumn MI_Go;
        private System.Windows.Forms.DataGridViewTextBoxColumn MIB_Pyunglyang;
        private System.Windows.Forms.DataGridViewTextBoxColumn MIS_PanNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn MI_RegDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MI_ModDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MIS_Bigo;
        private System.Windows.Forms.DataGridViewButtonColumn MIB_FileNAme;
    }
}