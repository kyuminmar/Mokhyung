﻿using CommonControl;
using CommonUtil;
using Mokhyung_Management.Box;
using Mokhyung_Management.InOut;
using Mokhyung_Management.SP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Mokhyung_Management
{
    public partial class Main : BaseCommonController
    {
        public Main()
        {
            InitializeComponent();
            this.Btn_MoveSP.Click += Move_SP;
            this.Btn_MoveBox.Click += Move_Box;

        }

        
        /// <summary>
        /// 쇼핑백 관리로이동
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Move_SP(object sender, EventArgs e)
        {
            MainSP SP = new MainSP();
            SP.ShowDialog(this);
            
        }

        /// <summary>
        /// 쇼핑백 관리로이동
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Move_Box(object sender, EventArgs e)
        {
            MainBox Box = new MainBox();
            Box.ShowDialog(this);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FTPClient FTP = new FTPClient();
            //FTP.test();
        }

        private void Btn_MoveInOut_Click(object sender, EventArgs e)
        {
            MainInOut IO = new MainInOut();
            IO.ShowDialog(this);

        }
    }
}
