﻿using CommonControl;
using EF_CodeFirst.DB_Model;
using Mokhyung_Management.Model.Route_Model.InOut;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mokhyung_Management.InOut
{
    public partial class AddSubContract : BaseCommonController
    {
        public AddSubContract()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 목형집추가 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                Route_AddSubContract route = new Route_AddSubContract();

                if (Check_Validate())
                {
                    route.Name = Text_Name.Text;
                    route.Tel = Text_Tel.Text;
                    route.Address = Text_Address.Text;
                    route.Bigo = Text_Bigo.Text;


                    MK_SubContract MSC = new MK_SubContract()
                    {

                        SC_Name = route.Name,
                        SC_Tel = route.Tel,
                        SC_Address = route.Address,
                        SC_Bigo = route.Bigo,
                        SC_RegDate = DateTime.Now,
                        SC_ModDate = DateTime.Now
                    };

                    db.MK_SubContract.Add(MSC);

                    db.SaveChanges();

                    //((MainInOut)(this.Owner)).RefreshData();
                    MessageBox.Show("목형집을 추가했습니다.");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("목형집 추가를 실패했습니다.");
            }


        }

        /// <summary>
        /// 유효성검사
        /// </summary>
        public bool Check_Validate()
        {
            bool Result = true;

            if (string.IsNullOrWhiteSpace(Text_Name.Text))
            {
                errorProviderApp.SetError(Text_Name, "톰슨집이름을 입력해주세요");
                Text_Name.Focus();

                Result = false;
            }
            else
            {
                //이전에러 표시 삭제
                errorProviderApp.Clear();
                if (string.IsNullOrWhiteSpace(Text_Tel.Text))
                {
                    errorProviderApp.SetError(Text_Tel, "전화번호를 입력해주세요");
                    Text_Tel.Focus();

                    Result = false;
                }
                else
                {
                    //이전에러 표시 삭제
                    errorProviderApp.Clear();
                    if (string.IsNullOrWhiteSpace(Text_Address.Text))
                    {
                        errorProviderApp.SetError(Text_Address, "주소를 입력해주세요");
                        Text_Address.Focus();

                        Result = false;
                    }
                    else
                    {
                        errorProviderApp.Clear();
                        Result = true;
                    }


                }
            }

            return Result;
        }
    }
}
