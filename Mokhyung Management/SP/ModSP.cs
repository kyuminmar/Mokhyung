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
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Mokhyung_Management.SP
{
    public partial class ModSP : BaseCommonController
    {
        public ModSP(int MI_Seq)
        {
            InitializeComponent();

            //쇼핑백 타입 리스트만듦
            List<Model_KeyValue> SPList = new List<Model_KeyValue>();
            SPList.AddRange(ConvertUtil.Get_SPType_List());

            //쇼핑백타입 리스트에 키 밸류 값 부여
            Combo_SPTypeList.ValueMember = Comm_Param.KeyValueString.K.ToString();
            Combo_SPTypeList.DisplayMember = Comm_Param.KeyValueString.V.ToString();


            //목형 타입 리스트 넣어줌
            foreach (var c in SPList)
            {
                Combo_SPTypeList.Items.Add(new { Key = c.Key, Value = c.Value });
            }

            var MokDetail = db.MK_Info.Where(x => x.MI_Seq == MI_Seq).FirstOrDefault();
            var SPDetail = db.MK_Info_SP.Where(x => x.MI_Seq == MI_Seq).FirstOrDefault();

            Text_MokName.Text = MokDetail.MI_Name;
            Text_MokNumber.Text = MokDetail.MI_Number.ToString();
            Text_MokJang.Text = MokDetail.MI_Jang.ToString();
            Text_MokPok.Text = MokDetail.MI_Pok.ToString();
            Text_MokGo.Text = MokDetail.MI_Go.ToString();
            //쇼핑백 타입 콤보박스에서 불러온 텍스트로 값을 세팅함
            Combo_SPTypeList.SelectedIndex = Combo_SPTypeList.FindString(ConvertUtil.Get_SPType_Text(SPDetail.MIS_Type));
            Text_Sangjub.Text = SPDetail.MIS_Sangjub.ToString();
            Text_Hajub.Text = SPDetail.MIS_Hajub.ToString();
            Text_Pulbari.Text = SPDetail.MIS_Pulbari.ToString();
            Chk_JjokYn.Checked = SPDetail.MIS_JJokYn;
            Text_Bigo.Text = SPDetail.MIS_Bigo;
            Hidden_MISeq.Text = MI_Seq.ToString();
            Text_FileName.Text = SPDetail.MIS_FileName;
            //Text_FilePath.Text = SPDetail.MIS_FilePath;


        }

        /// <summary>
        /// 수정버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void Btn_Mod_MokInfo_Click(object sender, EventArgs e)
        {
            MainSP MSP = new MainSP();
            try
            {
                long MISEQ = 0;
                MISEQ = Convert.ToInt64(Hidden_MISeq.Text);

                string SP_TypeString = string.Empty;
                //오브젝트를 json타입으로 변경
                SP_TypeString = JsonConvert.SerializeObject(Combo_SPTypeList.SelectedItem);
                //json 타입으로 변경된걸 모델로변경

                Route_MokInfo route = new Route_MokInfo();
                Route_MokInfo_SP routeSP = new Route_MokInfo_SP();

                MK_Info Upt_MI = db.MK_Info.Find(MISEQ);
                MK_Info_SP Upt_MIS = db.MK_Info_SP.Where(x => x.MI_Seq == MISEQ).FirstOrDefault();

                //목형 기본정보 인서트

                //목형이름으로 파일명정하기위해 여기서만 인서트
                route.MI_Name = Text_MokName.Text;
                route.MI_Jang = Convert.ToInt32(Text_MokJang.Text);
                route.MI_Pok = Convert.ToInt32(Text_MokPok.Text);
                route.MI_Go = Convert.ToInt32(Text_MokGo.Text);
                routeSP.MIS_Type = JsonConvert.DeserializeObject<Model_KeyValue>(SP_TypeString).Key;
                routeSP.MIS_Sangjub = Convert.ToInt32(Text_Sangjub.Text);
                routeSP.MIS_Hajub = Convert.ToInt32(Text_Hajub.Text);
                routeSP.MIS_Pulbari = Convert.ToInt32(Text_Pulbari.Text);
                routeSP.MIS_JJokYn = Chk_JjokYn.Checked;
                routeSP.MIS_Bigo = Text_Bigo.Text;

                //기존에 파일이 있고 교체하지않았을경우
                if (!string.IsNullOrWhiteSpace(Text_FileName.Text) && string.IsNullOrWhiteSpace(Text_FilePath.Text))
                {
                    //파일명만 유지해서 
                    routeSP.MIS_FileName = Text_FileName.Text;

                    //파일명만 반영
                    Upt_MIS.MIS_FileName = routeSP.MIS_FileName;
                }
                //파일이 교체된경우
                else if(!string.IsNullOrWhiteSpace(Text_FilePath.Text))
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

                    Upt_MIS.MIS_FileName = routeSP.MIS_FileNamePDF;
                    Upt_MIS.MIS_FilePath = routeSP.MIS_FTPFilePath;
                }
                ////파일이 없고 안교체된 경우
                //else if(!string.IsNullOrWhiteSpace(Text_FileName.Text))
                //{ 
                
                //}

                Upt_MI.MI_Jang = route.MI_Jang;
                Upt_MI.MI_Pok = route.MI_Pok;
                Upt_MI.MI_Go = route.MI_Go;
                Upt_MIS.MIS_Type = routeSP.MIS_Type;
                Upt_MIS.MIS_Sangjub = routeSP.MIS_Sangjub;
                Upt_MIS.MIS_Hajub = routeSP.MIS_Hajub;
                Upt_MIS.MIS_Pulbari = routeSP.MIS_Pulbari;
                Upt_MIS.MIS_JJokYn = routeSP.MIS_JJokYn;
                Upt_MIS.MIS_Bigo = routeSP.MIS_Bigo;
                Upt_MI.MI_ModDate = DateTime.Now;
                Upt_MIS.MIS_ModDate = DateTime.Now;

                db.Entry(Upt_MI).Property(x => x.MI_Jang).IsModified = true;
                db.Entry(Upt_MI).Property(x => x.MI_Pok).IsModified = true;
                db.Entry(Upt_MI).Property(x => x.MI_Go).IsModified = true;
                db.Entry(Upt_MI).Property(x => x.MI_ModDate).IsModified = true;
                db.Entry(Upt_MIS).Property(x => x.MIS_Type).IsModified = true;
                db.Entry(Upt_MIS).Property(x => x.MIS_Sangjub).IsModified = true;
                db.Entry(Upt_MIS).Property(x => x.MIS_Hajub).IsModified = true;
                db.Entry(Upt_MIS).Property(x => x.MIS_Pulbari).IsModified = true;
                db.Entry(Upt_MIS).Property(x => x.MIS_JJokYn).IsModified = true;
                db.Entry(Upt_MIS).Property(x => x.MIS_FileName).IsModified = true;
                db.Entry(Upt_MIS).Property(x => x.MIS_FilePath).IsModified = true;
                db.Entry(Upt_MIS).Property(x => x.MIS_Bigo).IsModified = true;
                db.Entry(Upt_MIS).Property(x => x.MIS_ModDate).IsModified = true;

                db.MK_Info.Attach(Upt_MI);
                db.MK_Info_SP.Attach(Upt_MIS);
                db.Entry(Upt_MI).State = EntityState.Modified;
                db.Entry(Upt_MIS).State = EntityState.Modified;

                db.SaveChanges();

                //부모창의 메소드 실행
                ((MainSP)(this.Owner)).RefreshData();
                MessageBox.Show("목형을 수정했습니다.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("저장에 실패했습니다.");
            }
        }

        /// <summary>
        /// 목형삭제버튼 클릭액션
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Del_MokInfo_Click(object sender, EventArgs e)
        {
            long MISEQ = 0;
            DialogResult result1 = MessageBox.Show("목형을 삭제하시겠습니까?", "목형삭제여부", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                MISEQ = Convert.ToInt64(Hidden_MISeq.Text);
                //목형삭제 메소드실행
                DeleteMok(MISEQ);
                //부모창의 메소드 실행
                ((MainSP)(this.Owner)).RefreshData();
                MessageBox.Show("목형이 삭제되었습니다.");
                this.Close();

            }

        }

        /// <summary>
        /// 목형 삭제 메소드
        /// </summary>
        /// <param name="MISEQ"></param>
        private void DeleteMok(long MISEQ)
        {
            try
            {
            var Del_MI_Info = db.MK_Info.Find(MISEQ);
            var Del_MI_Info_SP = db.MK_Info_SP.Where(x => x.MI_Seq == MISEQ).FirstOrDefault();

            db.MK_Info.Remove(Del_MI_Info);
            db.MK_Info_SP.Remove(Del_MI_Info_SP);

            db.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show("목형삭제를 실패했습니다");
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
                                        Result = true;

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
