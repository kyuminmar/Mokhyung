﻿namespace Mokhyung_Management
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_MoveSP = new System.Windows.Forms.Button();
            this.Btn_MoveBox = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Btn_MoveInOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_MoveSP
            // 
            this.Btn_MoveSP.Location = new System.Drawing.Point(35, 32);
            this.Btn_MoveSP.Name = "Btn_MoveSP";
            this.Btn_MoveSP.Size = new System.Drawing.Size(117, 98);
            this.Btn_MoveSP.TabIndex = 0;
            this.Btn_MoveSP.Text = "쇼핑백";
            this.Btn_MoveSP.UseVisualStyleBackColor = true;
            // 
            // Btn_MoveBox
            // 
            this.Btn_MoveBox.Location = new System.Drawing.Point(191, 33);
            this.Btn_MoveBox.Name = "Btn_MoveBox";
            this.Btn_MoveBox.Size = new System.Drawing.Size(121, 97);
            this.Btn_MoveBox.TabIndex = 1;
            this.Btn_MoveBox.Text = "박스";
            this.Btn_MoveBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(230, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 78);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_MoveInOut
            // 
            this.Btn_MoveInOut.Location = new System.Drawing.Point(35, 154);
            this.Btn_MoveInOut.Name = "Btn_MoveInOut";
            this.Btn_MoveInOut.Size = new System.Drawing.Size(117, 96);
            this.Btn_MoveInOut.TabIndex = 3;
            this.Btn_MoveInOut.Text = "입출고관리";
            this.Btn_MoveInOut.UseVisualStyleBackColor = true;
            this.Btn_MoveInOut.Click += new System.EventHandler(this.Btn_MoveInOut_Click);
            // 
            // Main
            // 
            this.ClientSize = new System.Drawing.Size(367, 329);
            this.Controls.Add(this.Btn_MoveInOut);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Btn_MoveBox);
            this.Controls.Add(this.Btn_MoveSP);
            this.Name = "Main";
            this.Text = "목형관리프로그램";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_MoveSP;
        private System.Windows.Forms.Button Btn_MoveBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Btn_MoveInOut;
    }
}

