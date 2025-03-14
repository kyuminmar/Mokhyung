﻿using CommonControl;
using CommonUtil;
using CommonUtil.Model;
using EF_CodeFirst.DB_CommProc;
using Mokhyung_Management.Model.ViewModel.Box;
using Mokhyung_Management.Model.ViewModel.SP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mokhyung_Management.Box
{
    public partial class MainBox : BaseCommonController
    {
        public MainBox()
        {
            
            InitializeComponent();         

        }

        /// <summary>
        /// 박스 데이터 바인딩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainSP_Load(object sender, EventArgs e)
        {

            //박스 검색타입 리스트만듦
            List<Model_KeyValue> Search_TypeList = new List<Model_KeyValue>();
            Search_TypeList.AddRange(ConvertUtil.Get_SPSearchType_List());

            //박스검색타입 리스트에 키 밸류 값 부여
            Combo_SearchType.ValueMember = Comm_Param.KeyValueString.K.ToString();
            Combo_SearchType.DisplayMember = Comm_Param.KeyValueString.V.ToString();

            //박스검색타입 리스트 넣어줌
            foreach (var c in Search_TypeList)
            {
                Combo_SearchType.Items.Add(new { Key = c.Key, Value = c.Value });
            }

            //박스검색타입 최초 노출을 '선택'으로
            Combo_SearchType.SelectedIndex = 0;

            RefreshData();


        }

        
        /// <summary>
        /// 새로고침 버튼액션
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_BoxList_Refresh(object sender, EventArgs e)
        {
            RefreshData();
        }

        /// <summary>
        /// 데이터를 새로고침
        /// </summary>
        public void RefreshData()
        {
            
            Dgv_BoxList.Rows.Clear();

            var List = from MI in db.MK_Info
                       where MI.MI_Type == Comm_Enum.Mok_Type.B.ToString()
                       orderby MI.MI_RegDate descending
                       select new View_BoxList
                       {
                           MI_Seq = MI.MI_Seq,
                           MI_Go = MI.MI_Go,
                           MI_Name = MI.MI_Name,
                           MI_Jang = MI.MI_Jang,
                           MI_Pok = MI.MI_Pok,
                           MI_Type = MI.MI_Type,
                           MI_Number = MI.MI_Number,
                           MI_RegDate = MI.MI_RegDate,
                           MI_ModDate = MI.MI_ModDate,
                           Detail = (from MIB in db.MK_Info_Box
                                     where MIB.MI_Seq == MI.MI_Seq
                                     select new View_BoxDetail
                                     {
                                         MIB_Seq = MIB.MIB_Seq,
                                         MIB_Type = MIB.MIB_Type,
                                         MIB_PanNumber = MIB.MIB_PanNumber,
                                         MIB_Pyunglyang = MIB.MIB_Pyunglyang,
                                         MIB_RegDate = MIB.MIB_RegDate,
                                         MIB_ModDate = MIB.MIB_ModDate,
                                         MIB_Bigo = MIB.MIB_Bigo,
                                         MIB_FileName = MIB.MIB_FileName,
                                         MIB_FilePath = MIB.MIB_FilePath
                                     }).FirstOrDefault()
                       };

            var BoxList = List.ToList();
            int RowNum = 0;

            RowNum = BoxList.Count();
            BoxList = (from MI in BoxList
                       orderby MI.MI_RegDate descending
                       select new View_BoxList
                       {
                           RowNum = RowNum--,
                           MI_Seq = MI.MI_Seq,
                           MI_Go = MI.MI_Go,
                           MI_Name = MI.MI_Name,
                           MI_Jang = MI.MI_Jang,
                           MI_Pok = MI.MI_Pok,
                           MI_Type = MI.MI_Type,
                           MI_Number = MI.MI_Number,
                           MI_RegDate = MI.MI_RegDate,
                           MI_ModDate = MI.MI_ModDate,
                           Detail = (from MIB in db.MK_Info_Box
                                     where MIB.MI_Seq == MI.MI_Seq
                                     select new View_BoxDetail
                                     {
                                         MIB_Seq = MIB.MIB_Seq,
                                         MIB_Type = MIB.MIB_Type,
                                         MIB_PanNumber = MIB.MIB_PanNumber,
                                         MIB_Pyunglyang = MIB.MIB_Pyunglyang,
                                         MIB_RegDate = MIB.MIB_RegDate,
                                         MIB_ModDate = MIB.MIB_ModDate,
                                         MIB_Bigo = MIB.MIB_Bigo,
                                         MIB_FileName = MIB.MIB_FileName,
                                         MIB_FilePath = MIB.MIB_FilePath
                                     }).FirstOrDefault()
                       }).ToList();

            if (BoxList.Count>0)
            {
                //데이터를 넣어줌(컬럼에따라 순서가 중요)
                foreach (var i in BoxList)
                {
                    Dgv_BoxList.Rows.Add(i.MI_Seq, i.RowNum, i.MI_Name, i.MI_Number, i.Detail.MIB_TypeText,
                        i.MI_Jang, i.MI_Pok, i.MI_Go, i.Detail.MIB_Pyunglyang,
                        i.Detail.MIB_PanNumber, i.MI_RegDate.ToShortDateString(),
                        i.MI_ModDate.ToShortDateString(), i.Detail.MIB_Bigo , i.Detail.MIB_FileName ?? "등록안됨");
                }
            }
            

        }

        /// <summary>
        /// 검색버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Search_Click(object sender, EventArgs e)
        {
            SearchData();
        }
        /// <summary>
        /// 검색기능
        /// </summary>
        private void SearchData()
        {
            string Search_Type = string.Empty;
            string Search_Text = string.Empty;
            string SearchType_String = string.Empty;

            //먼저  기존 목형리스트를 지워줌
            Dgv_BoxList.Rows.Clear();

            var List = from MI in db.MK_Info
                       where MI.MI_Type == Comm_Enum.Mok_Type.B.ToString()
                       orderby MI.MI_RegDate descending
                       select new View_BoxList
                       {
                           MI_Seq = MI.MI_Seq,
                           MI_Go = MI.MI_Go,
                           MI_Name = MI.MI_Name,
                           MI_Jang = MI.MI_Jang,
                           MI_Pok = MI.MI_Pok,
                           MI_Type = MI.MI_Type,
                           MI_Number = MI.MI_Number,
                           MI_RegDate = MI.MI_RegDate,
                           MI_ModDate = MI.MI_ModDate,
                           Detail = (from MIB in db.MK_Info_Box
                                     where MIB.MI_Seq == MI.MI_Seq
                                     select new View_BoxDetail
                                     {
                                         MIB_Seq = MIB.MIB_Seq,
                                         MIB_Type = MIB.MIB_Type,
                                         MIB_PanNumber= MIB.MIB_PanNumber,
                                         MIB_Pyunglyang = MIB.MIB_Pyunglyang,
                                         MIB_RegDate = MIB.MIB_RegDate,
                                         MIB_ModDate = MIB.MIB_ModDate,
                                         MIB_Bigo = MIB.MIB_Bigo,
                                         MIB_FileName = MIB.MIB_FileName,
                                         MIB_FilePath = MIB.MIB_FilePath
                                     }).FirstOrDefault()
                       };

            var BoxList = List.ToList();
            int RowNum = 0;
            //검색타입과 검색텍스트가 있을경우
            if (Combo_SearchType.SelectedIndex != 0 && Text_SearchText.Text != "")
            {
                SearchType_String = JsonConvert.SerializeObject(Combo_SearchType.SelectedItem);
                Search_Type = JsonConvert.DeserializeObject<Model_KeyValue>(SearchType_String).Key;
                Search_Text = Text_SearchText.Text;
                //목형이름으로 검색
                if (Search_Type == Comm_Enum.Search_Type.N.ToString())
                {
                    BoxList = List.Where(x => x.MI_Name.Contains(Search_Text)).ToList();
                }
                //목형번호로 검색
                else if (Search_Type == Comm_Enum.Search_Type.U.ToString())
                {
                    int Search_Num = 0;
                    Search_Num = Convert.ToInt32(Search_Text);
                    BoxList = List.Where(x => x.MI_Number.Equals(Search_Num)).ToList();
                }

            }
            else
            {
                //장폭고 검색중 하나라도있으면
                if (!string.IsNullOrWhiteSpace(Text_SearchJang.Text) || !string.IsNullOrWhiteSpace(Text_SearchPok.Text) || !string.IsNullOrWhiteSpace(Text_SearchGo.Text))
                {
                    int Jang = 0;
                    int Pok = 0;
                    int Go = 0;
                    //int GapSize = 0;


                        //장이 있을떄
                        if (!string.IsNullOrWhiteSpace(Text_SearchJang.Text))
                        {
                            Jang = Convert.ToInt32(Text_SearchJang.Text);
                            //장,폭이 있을떄
                            if (!string.IsNullOrWhiteSpace(Text_SearchPok.Text))
                            {
                                Pok = Convert.ToInt32(Text_SearchPok.Text);
                                //장,폭,고가있을때
                                if (!string.IsNullOrWhiteSpace(Text_SearchGo.Text))
                                {
                                    Go = Convert.ToInt32(Text_SearchGo.Text);
                                BoxList = BoxList.Where(x => x.MI_Jang.Equals(Jang) && x.MI_Pok.Equals(Pok) && x.MI_Go.Equals(Go)).ToList();
                                }
                                //장,폭있을때
                                else
                                {
                                BoxList = BoxList.Where(x => x.MI_Jang.Equals(Jang) && x.MI_Pok.Equals(Pok)).ToList();
                                }
                            }
                            //장,고가 있을떄
                            else if (!string.IsNullOrWhiteSpace(Text_SearchGo.Text))
                            {
                                Go = Convert.ToInt32(Text_SearchGo.Text);
                            BoxList = BoxList.Where(x => x.MI_Jang.Equals(Jang) && x.MI_Go.Equals(Go)).ToList();
                            }
                            //장만 있을때
                            else
                            {
                            BoxList = BoxList.Where(x => x.MI_Jang.Equals(Jang)).ToList();
                            }
                        }
                        //폭이 있을때
                        else if (!string.IsNullOrWhiteSpace(Text_SearchPok.Text))
                        {
                            Pok = Convert.ToInt32(Text_SearchPok.Text);
                            //폭,고가 있을때
                            if (!string.IsNullOrWhiteSpace(Text_SearchGo.Text))
                            {
                                Go = Convert.ToInt32(Text_SearchGo.Text);
                            BoxList = BoxList.Where(x => x.MI_Pok.Equals(Pok) && x.MI_Go.Equals(Go)).ToList();
                            }
                            //폭만 있을때
                            else
                            {
                            BoxList = BoxList.Where(x => x.MI_Pok.Equals(Pok)).ToList();
                            }
                        }
                        //고만 있을때
                        else
                        {
                            Go = Convert.ToInt32(Text_SearchGo.Text);
                        BoxList = BoxList.Where(x => x.MI_Go.Equals(Go)).ToList();
                        }
                        //오차범위사용시(개발예정)
                        //if(Chk_UseGap.Checked)
                        //{
                        //    GapSize = Convert.ToInt32(Text_GapSize);
                        //    if (Rb_GapGo.Checked)
                        //    {

                        //    }
                        //}
                    }
                }

            RowNum = BoxList.Count();
            BoxList = (from MI in BoxList
                       orderby MI.MI_RegDate descending
                      select new View_BoxList
                      {
                          RowNum = RowNum--,
                          MI_Seq = MI.MI_Seq,
                          MI_Go = MI.MI_Go,
                          MI_Name = MI.MI_Name,
                          MI_Jang = MI.MI_Jang,
                          MI_Pok = MI.MI_Pok,
                          MI_Type = MI.MI_Type,
                          MI_Number = MI.MI_Number,
                          MI_RegDate = MI.MI_RegDate,
                          MI_ModDate = MI.MI_ModDate,
                          Detail = (from MIB in db.MK_Info_Box
                                    where MIB.MI_Seq == MI.MI_Seq
                                    select new View_BoxDetail
                                    {
                                        MIB_Seq = MIB.MIB_Seq,
                                        MIB_Type = MIB.MIB_Type,
                                        MIB_PanNumber = MIB.MIB_PanNumber,
                                        MIB_Pyunglyang = MIB.MIB_Pyunglyang,
                                        MIB_RegDate = MIB.MIB_RegDate,
                                        MIB_ModDate = MIB.MIB_ModDate,
                                        MIB_Bigo = MIB.MIB_Bigo,
                                        MIB_FileName = MIB.MIB_FileName,
                                        MIB_FilePath = MIB.MIB_FilePath
                                    }).FirstOrDefault()
                      }).ToList();

            if (BoxList.Count > 0)
            {
                //데이터를 넣어줌(컬럼에따라 순서가 중요)
                foreach (var i in BoxList)
                {
                    Dgv_BoxList.Rows.Add(i.MI_Seq, i.RowNum, i.MI_Name, i.MI_Number,
                        i.Detail.MIB_TypeText, i.MI_Jang, i.MI_Pok, i.MI_Go, i.Detail.MIB_Pyunglyang,
                        i.Detail.MIB_PanNumber,i.MI_RegDate.ToShortDateString(),
                        i.MI_ModDate.ToShortDateString(), i.Detail.MIB_Bigo, i.Detail.MIB_FileName ?? "등록안됨");
                }
            }

        }

        //오차범위 체크시(개발예정)
        private void Ckb_UseGap_CheckedChanged(object sender, EventArgs e)
        {
            if(Chk_UseGap.Checked)
            {
                Lb_GapUse.Visible = true;
            }
            else
            {
                Lb_GapUse.Visible = false;
            }
        }

        /// <summary>
        /// 목형추가버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AddMok_Click(object sender, EventArgs e)
        {
            AddBox AB = new AddBox();
            AB.ShowDialog(this);
        }

        /// <summary>
        /// 키입력시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainSP_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                //F5키 눌렀을시
                case Keys.F5:
                    RefreshData();
                    break;
                case Keys.Enter:
                    SearchData();
                    break;
                default:
                    break;

            }
        }

        /// <summary>
        /// 장폭고 숫자 유효성검사
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Validate_Leave(object sender, EventArgs e)
        {

            if(ConvertUtil.Check_Number_Validate(Text_SearchJang.Text))
            {
                MessageBox.Show("숫자만 입력가능합니다");
                Text_SearchJang.Text = "";
                Text_SearchJang.Focus();
            }
            if (ConvertUtil.Check_Number_Validate(Text_SearchPok.Text))
            {
                MessageBox.Show("숫자만 입력가능합니다");
                Text_SearchPok.Text = "";
                Text_SearchPok.Focus();
            }
            if (ConvertUtil.Check_Number_Validate(Text_SearchGo.Text))
            {
                MessageBox.Show("숫자만 입력가능합니다");
                Text_SearchGo.Text = "";
                Text_SearchGo.Focus();
            }
           
        }

        /// <summary>
        /// 셀클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_BoxList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            CommProc commproc = new CommProc(db);
            int BtnIndex = 0;
            long MISEQ = 0;
            string FullFilePath = string.Empty;
            string FileName = string.Empty;

            //선택된 로우의 인덱스 값을 가져옴
            int i = Dgv_BoxList.SelectedCells[0].RowIndex;
            //해당로우의 제일마지막 컬럼값을가져옴
            BtnIndex = Dgv_BoxList.Columns.Count - 1;
            if (e.ColumnIndex == BtnIndex)
            {
                //해당 로우의 셀이름으로 찾아서 그값을 가져옴
                MISEQ = Convert.ToInt32(Dgv_BoxList.Rows[i].Cells["MI_Seq"].Value.ToString());
                FileName = commproc.Get_FileName(MISEQ,Comm_Enum.Mok_Type.B.ToString());

                if (!string.IsNullOrEmpty(FileName))
                {

                    FullFilePath = string.Format("{0}/Box/{1}", ConfigurationManager.AppSettings["UrlService"], FileName);
                    Process.Start(FullFilePath);

                }
                else
                {
                    MessageBox.Show("등록된 파일이 없습니다");
                }

            }
        }



        /// <summary>
        /// 셀 더블클릭시 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_BoxList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = Dgv_BoxList.SelectedCells[0].RowIndex;
            int Mi_Seq = 0;

            Mi_Seq = Convert.ToInt32(Dgv_BoxList.Rows[i].Cells["MI_Seq"].Value.ToString());

            //자식창선언
            ModBox SP = new ModBox(Mi_Seq);
            //자식창을 열면서 부모창의 값을 넘김
            SP.ShowDialog(this);

        }
    }
}
