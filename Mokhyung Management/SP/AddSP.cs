﻿using CommonControl;
using CommonUtil;
using CommonUtil.Model;
using EF_CodeFirst.DB_CommProc;
using EF_CodeFirst.DB_Model;
using Mokhyung_Management.Model.AddMok;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Mokhyung_Management.SP
{
    public partial class AddSP : BaseCommonController
    {


        public AddSP()
        {


            InitializeComponent();


            //쇼핑백 타입 리스트만듦
            List<Model_KeyValue> SPList = new List<Model_KeyValue>();
            SPList.AddRange(ConvertUtil.Get_SPType_List());

            //쇼핑백타입 리스트에 키 밸류 값 부여
            Combo_SPTypeList.ValueMember = Comm_Param.KeyValueString.K.ToString();
            Combo_SPTypeList.DisplayMember = Comm_Param.KeyValueString.V.ToString();


            //쇼핑백 타입 리스트 넣어줌
            foreach (var c in SPList)
            {
                Combo_SPTypeList.Items.Add(new { Key = c.Key, Value = c.Value });
            }

            //쇼핑백타입 최초 노출을 '선택'으로
            Combo_SPTypeList.SelectedIndex = 0;

            Text_MokName.Focus();
        }





        /// <summary>
        /// 저장버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void Btn_Save_MokInfo_Click(object sender, EventArgs e)
        {
            try
            {
                string Mk_typeString = string.Empty;
                string SP_TypeString = string.Empty;
                //오브젝트를 json타입으로 변경                
                SP_TypeString = JsonConvert.SerializeObject(Combo_SPTypeList.SelectedItem);
                //json 타입으로 변경된걸 모델로변경
                Route_MokInfo route = new Route_MokInfo();
                Route_MokInfo_SP routeSP = new Route_MokInfo_SP();

                if (Check_Validate())
                {
                    //목형 기본정보 인서트
                    route.MI_Name = Text_MokName.Text;
                    route.MI_Type = Comm_Enum.Mok_Type.S.ToString();
                    route.MI_Number = Convert.ToInt32(Text_MokNumber.Text);
                    route.MI_Jang = Convert.ToInt32(Text_MokJang.Text);
                    route.MI_Pok = Convert.ToInt32(Text_MokPok.Text);
                    route.MI_Go = Convert.ToInt32(Text_MokGo.Text);
                    routeSP.MIS_Type = JsonConvert.DeserializeObject<Model_KeyValue>(SP_TypeString).Key;
                    routeSP.MIS_Sangjub = Convert.ToInt32(Text_Sangjub.Text);
                    routeSP.MIS_Hajub = Convert.ToInt32(Text_Hajub.Text);
                    routeSP.MIS_Pulbari = Convert.ToInt32(Text_Pulbari.Text);
                    routeSP.MIS_JJokYn = Chk_JjokYn.Checked;
                    routeSP.MIS_Bigo = Text_Bigo.Text;

                    //파일이 선택되어있을떄만
                    if (!string.IsNullOrWhiteSpace(Text_FilePath.Text))
                    {
                        //FTP통신시 로컬경로를 가져올때만 사용
                        routeSP.MIS_LocalFilePath = Text_FilePath.Text;
                        //파일이름 .PDF로 변환해서 저장
                        routeSP.MIS_FileName = Text_FileName.Text;
                        //ftp 다운로드시 사용
                        routeSP.MIS_FTPFilePath = string.Format("ftp://{0}/SP/{1}", ConfigurationManager.AppSettings["serverIP"], Text_FileName.Text);
                        routeSP.MIS_FTPFilePathPDF = string.Format("ftp://{0}/SP/{1}", ConfigurationManager.AppSettings["serverIP"], routeSP.MIS_FileNamePDF);

                        //파일업로드 액션
                        FTPClient ftpClient = new FTPClient();
                        ftpClient.UpLoad(routeSP.MIS_LocalFilePath, routeSP.MIS_FTPFilePathPDF);
                    }

                    MK_Info MI = new MK_Info()
                    {
                        MI_Name = route.MI_Name,
                        MI_Type = route.MI_Type,
                        MI_Number = route.MI_Number,
                        MI_Jang = route.MI_Jang,
                        MI_Pok = route.MI_Pok,
                        MI_Go = route.MI_Go,
                        MI_RegDate = DateTime.Now,
                        MI_ModDate = DateTime.Now
                    };

                    db.MK_Info.Add(MI);

                    MK_Info_SP MIS = new MK_Info_SP()
                    {
                        MI_Seq = routeSP.MI_Seq,
                        MIS_Type = routeSP.MIS_Type,
                        MIS_Sangjub = routeSP.MIS_Sangjub,
                        MIS_Hajub = routeSP.MIS_Hajub,
                        MIS_Pulbari = routeSP.MIS_Pulbari,
                        MIS_JJokYn = routeSP.MIS_JJokYn,
                        MIS_Bigo = routeSP.MIS_Bigo,
                        MIS_FileName = routeSP.MIS_FileNamePDF,
                        MIS_FilePath = routeSP.MIS_FTPFilePath,
                        MIS_RegDate = DateTime.Now,
                        MIS_ModDate = DateTime.Now
                    };

                    db.MK_Info_SP.Add(MIS);
                    db.SaveChanges();



                    //부모창 초기화 메소드실행
                    ((MainSP)(this.Owner)).RefreshData();
                    MessageBox.Show("목형을 추가했습니다.");

                    //여러개 추가하기 체크된경우
                    if (Chk_ManyAdd.Checked == false)
                    {
                        this.Close();
                    }
                    else
                    {
                        Text_MokName.Clear();
                        Text_MokNumber.Clear();
                        Text_MokJang.Clear();
                        Text_MokPok.Clear();
                        Text_Sangjub.Clear();
                        Text_Hajub.Clear();
                        Text_Pulbari.Clear();
                        Text_Bigo.Clear();
                        Text_MokGo.Clear();
                        Chk_JjokYn.Checked = false;
                        Combo_SPTypeList.SelectedIndex = 0;
                        Text_FileName.Clear();
                        Text_FilePath.Clear();
                    }
                }
                else
                {
                    return;
                }
            }
            catch (WebException ex)
            {
                String status = ((FtpWebResponse)ex.Response).StatusDescription;
                MessageBox.Show(status);
            }

        }

        /// <summary>
        /// 목형입력 유효성검사
        /// </summary>
        /// <returns></returns>
        private bool Check_Validate()
        {
            CommProc commProc = new CommProc(db);
            bool Result = true;

            //목형이름이 빈값이아니면서 중복일경우
            if (commProc.Check_MokNameDuplication(Text_MokName.Text.ToString()))
            {
                errorProviderApp.SetError(Text_MokName, "중복된 목형이름입니다");
                Text_MokName.Text = "";
                Text_MokName.Focus();

                Result = false;
            }
            //목형이름이 빈값일경우
            else if (string.IsNullOrWhiteSpace(Text_MokName.Text.ToString()))
            {
                errorProviderApp.SetError(Text_MokName, "목형이름을 입력해주세요");
                Text_MokName.Focus();

                Result = false;
            }
            //위의 두개가 아닌경우
            else
            {
                //이전에러 표시 삭제
                errorProviderApp.Clear();

                //목형번호가 빈값이아니면서 번호가아닐경우
                if (ConvertUtil.Check_Number_Validate(Text_MokNumber.Text.ToString()))
                {
                    errorProviderApp.SetError(Text_MokNumber, "숫자만 입력가능합니다");
                    Text_MokNumber.Text = "";
                    Text_MokNumber.Focus();

                    Result = false;
                }
                //목형번호가 빈값이아니면서 중복일경우
                else if (commProc.Check_MokNumberDuplication(Text_MokNumber.Text))
                {
                    errorProviderApp.SetError(Text_MokNumber, "중복된 목형번호입니다");
                    Text_MokNumber.Text = "";
                    Text_MokNumber.Focus();

                    Result = false;
                }
                //목형번호가 빈값일 경우
                else if (string.IsNullOrWhiteSpace(Text_MokNumber.Text.ToString()))
                {
                    errorProviderApp.SetError(Text_MokNumber, "목형번호를 입력해주세요");
                    Text_MokNumber.Focus();

                    Result = false;
                }
                else
                {
                    //이전에러 표시 삭제
                    errorProviderApp.Clear();

                    //장이 숫자가아닐경우
                    if (ConvertUtil.Check_Number_Validate(Text_MokJang.Text.ToString()))
                    {
                        errorProviderApp.SetError(Text_MokJang, "숫자만 입력가능합니다");
                        Text_MokJang.Text = "";
                        Text_MokJang.Focus();

                        Result = false;
                    }
                    //장이 빈값일 경우
                    else if (string.IsNullOrWhiteSpace(Text_MokJang.Text.ToString()))
                    {
                        errorProviderApp.SetError(Text_MokJang, "장을 입력해주세요");
                        Text_MokJang.Focus();

                        Result = false;
                    }
                    else
                    {
                        //이전에러 표시 삭제
                        errorProviderApp.Clear();

                        //폭이 숫자가아닐경우
                        if (ConvertUtil.Check_Number_Validate(Text_MokPok.Text.ToString()))
                        {
                            errorProviderApp.SetError(Text_MokPok, "숫자만 입력가능합니다");
                            Text_MokPok.Text = "";
                            Text_MokPok.Focus();

                            Result = false;
                        }
                        //폭이 빈값일 경우
                        else if (string.IsNullOrWhiteSpace(Text_MokPok.Text.ToString()))
                        {
                            errorProviderApp.SetError(Text_MokPok, "폭을 입력해주세요");
                            Text_MokPok.Focus();

                            Result = false;
                        }
                        else
                        {
                            //이전에러 표시 삭제
                            errorProviderApp.Clear();

                            //고가 숫자가 아닐경우
                            if (ConvertUtil.Check_Number_Validate(Text_MokGo.Text.ToString()))
                            {
                                errorProviderApp.SetError(Text_MokGo, "숫자만 입력가능합니다");
                                Text_MokGo.Text = "";
                                Text_MokGo.Focus();

                                Result = false;
                            }
                            //고가 빈값일 경우
                            else if (string.IsNullOrWhiteSpace(Text_MokGo.Text.ToString()))
                            {
                                errorProviderApp.SetError(Text_MokGo, "고를 입력해주세요");
                                Text_MokGo.Focus();

                                Result = false;
                            }
                            else
                            {
                                //이전에러 표시 삭제
                                errorProviderApp.Clear();
                                //세부타입이 선택이 안된경우
                                if (Combo_SPTypeList.SelectedIndex == 0)
                                {
                                    errorProviderApp.SetError(Combo_SPTypeList, "세부타입을 선택해주세요");
                                    Combo_SPTypeList.Focus();

                                    Result = false;
                                }
                                else
                                {
                                    //이전에러 표시 삭제
                                    errorProviderApp.Clear();
                                    //상접이 숫자가 아닌경우
                                    if (ConvertUtil.Check_Number_Validate(Text_Sangjub.Text.ToString()))
                                    {
                                        errorProviderApp.SetError(Text_Sangjub, "숫자만 입력가능합니다");
                                        Text_Sangjub.Text = "";
                                        Text_Sangjub.Focus();

                                        Result = false;
                                    }
                                    //상접이 빈값일 경우
                                    else if (string.IsNullOrWhiteSpace(Text_Sangjub.Text.ToString()))
                                    {
                                        errorProviderApp.SetError(Text_Sangjub, "상접을 입력해주세요");
                                        Text_Sangjub.Focus();

                                        Result = false;
                                    }
                                    else
                                    {
                                        //이전에러 표시 삭제
                                        errorProviderApp.Clear();
                                        //하접이 숫자가 아닌경우
                                        if (ConvertUtil.Check_Number_Validate(Text_Hajub.Text.ToString()))
                                        {
                                            errorProviderApp.SetError(Text_Hajub, "숫자만 입력가능합니다");
                                            Text_Hajub.Text = "";
                                            Text_Hajub.Focus();

                                            Result = false;
                                        }
                                        //하접이 빈값일경우
                                        else if (string.IsNullOrWhiteSpace(Text_Hajub.Text.ToString()))
                                        {
                                            errorProviderApp.SetError(Text_Hajub, "상접을 입력해주세요");
                                            Text_Hajub.Focus();

                                            Result = false;
                                        }
                                        else
                                        {
                                            //이전에러 표시 삭제
                                            errorProviderApp.Clear();
                                            //풀바리가 숫자가 아닌경우
                                            if (ConvertUtil.Check_Number_Validate(Text_Pulbari.Text.ToString()))
                                            {
                                                errorProviderApp.SetError(Text_Pulbari, "숫자만 입력가능합니다");
                                                Text_Pulbari.Text = "";
                                                Text_Pulbari.Focus();

                                                Result = false;
                                            }
                                            //하접이 빈값일경우
                                            else if (string.IsNullOrWhiteSpace(Text_Pulbari.Text.ToString()))
                                            {
                                                errorProviderApp.SetError(Text_Pulbari, "풀바리를 입력해주세요");
                                                Text_Pulbari.Focus();

                                                Result = false;
                                            }
                                            else
                                            {
                                                errorProviderApp.Clear();

                                                //파일명이 있을경우
                                                if (commProc.Check_FileNameDuplication(Text_FileName.Text, Comm_Enum.Mok_Type.S.ToString()))
                                                {
                                                    errorProviderApp.SetError(Text_FileName, "중복된 파일명입니다.");
                                                    Text_FileName.Focus();
                                                    Result = false;
                                                }
                                                else
                                                {
                                                    errorProviderApp.Clear();
                                                    Result = true;

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return Result;

        }

        /// <summary>
        /// 파일경로 불러오기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Add_FilePath_Click(object sender, EventArgs e)
        {
            string file_path = string.Empty;
            //파일 검색 초기위치 설정
            //openFileDialog1.InitialDirectory = "Y:\\";
            if (OpenKalsunFile.ShowDialog() == DialogResult.OK)
            {
                file_path = OpenKalsunFile.FileName;
                Text_FileName.Text = file_path.Split('\\')[file_path.Split('\\').Length - 1];
                Text_FilePath.Text = file_path;
            }
        }
    }
}
