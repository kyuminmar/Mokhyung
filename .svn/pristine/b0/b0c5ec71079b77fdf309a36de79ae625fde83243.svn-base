using CommonControl;
using CommonUtil;
using CommonUtil.Model;
using EF_CodeFirst.DB_CommProc;
using EF_CodeFirst.DB_Model;
using Mokhyung_Management.Model.AddMok;
using Mokhyung_Management.Model.Route_Model.Box;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Mokhyung_Management.Box
{
    public partial class ModBox : BaseCommonController
    {

        public ModBox(int MI_Seq)
        {
            InitializeComponent();

            //쇼핑백 타입 리스트만듦
            List<Model_KeyValue> BoxList = new List<Model_KeyValue>();
            BoxList.AddRange(ConvertUtil.Get_BoxType_List());

            //쇼핑백타입 리스트에 키 밸류 값 부여
            Combo_BoxTypeList.ValueMember = Comm_Param.KeyValueString.K.ToString();
            Combo_BoxTypeList.DisplayMember = Comm_Param.KeyValueString.V.ToString();


            //목형 타입 리스트 넣어줌
            foreach (var c in BoxList)
            {
                Combo_BoxTypeList.Items.Add(new { Key = c.Key, Value = c.Value });
            }

            var MokDetail = db.MK_Info.Where(x => x.MI_Seq == MI_Seq).FirstOrDefault();
            var BoxDetail = db.MK_Info_Box.Where(x => x.MI_Seq == MI_Seq).FirstOrDefault();

            Text_MokName.Text = MokDetail.MI_Name;
            Text_MokNumber.Text = MokDetail.MI_Number.ToString();
            Text_MokJang.Text = MokDetail.MI_Jang.ToString();
            Text_MokPok.Text = MokDetail.MI_Pok.ToString();
            Text_MokGo.Text = MokDetail.MI_Go.ToString();
            //쇼핑백 타입 콤보박스에서 불러온 텍스트로 값을 세팅함
            Combo_BoxTypeList.SelectedIndex = Combo_BoxTypeList.FindString(ConvertUtil.Get_BoxType_Text(BoxDetail.MIB_Type));
            Text_Pyunglyang.Text = BoxDetail.MIB_Pyunglyang.ToString();
            Text_PanNumber.Text = BoxDetail.MIB_PanNumber.ToString();
            Text_Bigo.Text = BoxDetail.MIB_Bigo;
            Hidden_MISeq.Text = MI_Seq.ToString();
            Text_FileName.Text = BoxDetail.MIB_FileName;
            //Text_FilePath.Text = BoxDetail.MIB_FilePath;

        }

        /// <summary>
        /// 수정버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void Btn_Mod_MokInfo_Click(object sender, EventArgs e)
        {
            MainBox MBox = new MainBox();
            try
            {
                if (Check_Validate())
                {
                    long MISEQ = 0;
                    MISEQ = Convert.ToInt64(Hidden_MISeq.Text);

                    string Box_TypeString = string.Empty;
                    //오브젝트를 json타입으로 변경
                    Box_TypeString = JsonConvert.SerializeObject(Combo_BoxTypeList.SelectedItem);
                    //json 타입으로 변경된걸 모델로변경

                    Route_MokInfo route = new Route_MokInfo();
                    Route_MokInfo_Box routeBox = new Route_MokInfo_Box();

                    MK_Info Upt_MI = db.MK_Info.Find(MISEQ);
                    MK_Info_Box Upt_MIB = db.MK_Info_Box.Where(x => x.MI_Seq == MISEQ).FirstOrDefault();

                    //목형 기본정보 인서트
                    route.MI_Jang = Convert.ToInt32(Text_MokJang.Text);
                    route.MI_Pok = Convert.ToInt32(Text_MokPok.Text);
                    route.MI_Go = Convert.ToInt32(Text_MokGo.Text);
                    routeBox.MIB_Type = JsonConvert.DeserializeObject<Model_KeyValue>(Box_TypeString).Key;
                    routeBox.MIB_Pyunglyang = Convert.ToInt32(Text_Pyunglyang.Text);
                    routeBox.MIB_PanNumber = Convert.ToInt32(Text_PanNumber.Text);
                    routeBox.MIB_Bigo = Text_Bigo.Text;

                    //기존에 파일이 있고 교체하지않았을경우
                    if (!string.IsNullOrWhiteSpace(Text_FileName.Text) && string.IsNullOrWhiteSpace(Text_FilePath.Text))
                    {
                        //파일명만 유지해서 
                        routeBox.MIB_FileName = Text_FileName.Text;

                        //파일명만 반영
                        Upt_MIB.MIB_FileName = routeBox.MIB_FileName;
                    }
                    //파일이 교체된경우
                    else if (!string.IsNullOrWhiteSpace(Text_FilePath.Text))
                    {
                        //FTP통신시 로컬경로를 가져올때만 사용
                        routeBox.MIB_LocalFilePath = Text_FilePath.Text;
                        //파일이름 .PDF로 변환해서 저장
                        routeBox.MIB_FileName = Text_FileName.Text;

                        //ftp 다운로드시 사용
                        routeBox.MIB_FTPFilePath = string.Format("ftp://{0}/Box/{1}", ConfigurationManager.AppSettings["serverIP"], Text_FileName.Text);
                        routeBox.MIB_FTPFilePathPDF = string.Format("ftp://{0}/Box/{1}", ConfigurationManager.AppSettings["serverIP"], routeBox.MIB_FileNamePDF);

                        //파일업로드 액션
                        FTPClient ftpClient = new FTPClient();
                        ftpClient.UpLoad(routeBox.MIB_LocalFilePath, routeBox.MIB_FTPFilePathPDF);

                        Upt_MIB.MIB_FileName = routeBox.MIB_FileNamePDF;
                        Upt_MIB.MIB_FilePath = routeBox.MIB_FTPFilePath;
                    }



                    Upt_MI.MI_Jang = route.MI_Jang;
                    Upt_MI.MI_Pok = route.MI_Pok;
                    Upt_MI.MI_Go = route.MI_Go;
                    Upt_MIB.MIB_Type = routeBox.MIB_Type;
                    Upt_MIB.MIB_Pyunglyang = routeBox.MIB_Pyunglyang;
                    Upt_MIB.MIB_PanNumber = routeBox.MIB_PanNumber;
                    Upt_MIB.MIB_Bigo = routeBox.MIB_Bigo;
                    Upt_MI.MI_ModDate = DateTime.Now;
                    Upt_MIB.MIB_ModDate = DateTime.Now;

                    db.Entry(Upt_MI).Property(x => x.MI_Jang).IsModified = true;
                    db.Entry(Upt_MI).Property(x => x.MI_Pok).IsModified = true;
                    db.Entry(Upt_MI).Property(x => x.MI_Go).IsModified = true;
                    db.Entry(Upt_MI).Property(x => x.MI_ModDate).IsModified = true;
                    db.Entry(Upt_MIB).Property(x => x.MIB_Type).IsModified = true;
                    db.Entry(Upt_MIB).Property(x => x.MIB_Pyunglyang).IsModified = true;
                    db.Entry(Upt_MIB).Property(x => x.MIB_PanNumber).IsModified = true;
                    db.Entry(Upt_MIB).Property(x => x.MIB_Bigo).IsModified = true;
                    db.Entry(Upt_MIB).Property(x => x.MIB_ModDate).IsModified = true;
                    db.Entry(Upt_MIB).Property(x => x.MIB_FileName).IsModified = true;
                    db.Entry(Upt_MIB).Property(x => x.MIB_FilePath).IsModified = true;

                    db.MK_Info.Attach(Upt_MI);
                    db.MK_Info_Box.Attach(Upt_MIB);
                    db.Entry(Upt_MI).State = EntityState.Modified;
                    db.Entry(Upt_MIB).State = EntityState.Modified;

                    db.SaveChanges();

                    //부모창의 메소드 실행
                    ((MainBox)(this.Owner)).RefreshData();
                    MessageBox.Show("목형을 수정했습니다.");
                    this.Close();
                }
                else
                {
                    return;
                }




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
            long MIBEQ = 0;
            DialogResult result1 = MessageBox.Show("목형을 삭제하시겠습니까?", "목형삭제여부", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                MIBEQ = Convert.ToInt64(Hidden_MISeq.Text);
                //목형삭제 메소드실행
                DeleteMok(MIBEQ);
                //부모창의 메소드 실행
                ((MainBox)(this.Owner)).RefreshData();
                MessageBox.Show("목형이 삭제되었습니다.");
                this.Close();

            }

        }

        /// <summary>
        /// 목형 삭제 메소드
        /// </summary>
        /// <param name="MIBEQ"></param>
        private void DeleteMok(long MIBEQ)
        {
            var Del_MI_Info = db.MK_Info.Find(MIBEQ);
            var Del_MI_Info_Box = db.MK_Info_Box.Where(x => x.MI_Seq == MIBEQ).FirstOrDefault();

            db.MK_Info.Remove(Del_MI_Info);
            db.MK_Info_Box.Remove(Del_MI_Info_Box);

            db.SaveChanges();
        }

        private void ModBox_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 목형입력 유효성검사
        /// </summary>
        /// <returns></returns>
        public bool Check_Validate()
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
                        if (Combo_BoxTypeList.SelectedIndex == 0)
                        {
                            errorProviderApp.SetError(Combo_BoxTypeList, "세부타입을 선택해주세요");
                            Combo_BoxTypeList.Focus();

                            Result = false;
                        }
                        else
                        {
                            //이전에러 표시 삭제
                            errorProviderApp.Clear();
                            //평량이 숫자가 아닌경우
                            if (ConvertUtil.Check_Number_Validate(Text_Pyunglyang.Text.ToString()))
                            {
                                errorProviderApp.SetError(Text_Pyunglyang, "숫자만 입력가능합니다");
                                Text_Pyunglyang.Text = "";
                                Text_Pyunglyang.Focus();

                                Result = false;
                            }
                            //평량이 빈값일 경우
                            else if (string.IsNullOrWhiteSpace(Text_Pyunglyang.Text.ToString()))
                            {
                                errorProviderApp.SetError(Text_Pyunglyang, "평량을 입력해주세요");
                                Text_Pyunglyang.Focus();

                                Result = false;
                            }
                            else
                            {

                                //이전에러 표시 삭제
                                errorProviderApp.Clear();
                                //판수가 숫자가 아닌경우
                                if (ConvertUtil.Check_Number_Validate(Text_PanNumber.Text.ToString()))
                                {
                                    errorProviderApp.SetError(Text_PanNumber, "숫자만 입력가능합니다");
                                    Text_PanNumber.Text = "";
                                    Text_PanNumber.Focus();

                                    Result = false;
                                }
                                //판수가 빈값일경우
                                else if (string.IsNullOrWhiteSpace(Text_PanNumber.Text.ToString()))
                                {
                                    errorProviderApp.SetError(Text_PanNumber, "판수를 입력해주세요");
                                    Text_PanNumber.Focus();

                                    Result = false;
                                }
                                else
                                {
                                    errorProviderApp.Clear();
                                    Result = true;

                                    //파일명이 있을경우
                                    if (commProc.Check_FileNameDuplication(Text_FileName.Text,Comm_Enum.Mok_Type.B.ToString()))
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
