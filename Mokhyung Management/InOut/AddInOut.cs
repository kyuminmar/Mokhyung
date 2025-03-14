﻿using CommonControl;
using CommonUtil;
using CommonUtil.Model;
using EF_CodeFirst.DB_CommProc;
using EF_CodeFirst.DB_Model;
using Mokhyung_Management.Model.ViewModel.IO;
using Newtonsoft.Json;
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
    public partial class AddInOut : BaseCommonController
    {
        public AddInOut()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 화면로드시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddInOut_Load(object sender, EventArgs e)
        {
            CommProc commproc = new CommProc(db);

            //쇼핑백 검색타입 리스트만듦
            List<Model_KeyValue> Search_TypeList = new List<Model_KeyValue>();
            Search_TypeList.AddRange(ConvertUtil.Get_SPSearchType_List());

            //쇼핑백타입 리스트에 키 밸류 값 부여
            Combo_SearchType.ValueMember = Comm_Param.KeyValueString.K.ToString();
            Combo_SearchType.DisplayMember = Comm_Param.KeyValueString.V.ToString();

            //쇼핑백 타입 리스트 넣어줌
            foreach (var c in Search_TypeList)
            {
                Combo_SearchType.Items.Add(new { Key = c.Key, Value = c.Value });
            }

            //쇼핑백타입 최초 노출을 '선택'으로
            Combo_SearchType.SelectedIndex = 0;

            //톰슨집 리스트만듦
            List<Model_KeyValue> SC_List = new List<Model_KeyValue>();
            SC_List.AddRange(commproc.Get_SubContract_List());

            //쇼핑백타입 리스트에 키 밸류 값 부여
            Combo_SCList.ValueMember = Comm_Param.KeyValueString.K.ToString();
            Combo_SCList.DisplayMember = Comm_Param.KeyValueString.V.ToString();

            //쇼핑백 타입 리스트 넣어줌
            foreach (var c in SC_List)
            {
                Combo_SCList.Items.Add(new { Key = c.Key, Value = c.Value });
            }

            //쇼핑백타입 최초 노출을 '선택'으로
            Combo_SCList.SelectedIndex = 0;
        }

        /// <summary>
        /// 톰슨집리스트에서 선택시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Combo_SCList_SelectedIndexChanged(object sender, EventArgs e)
        {
            long SCSEQ = 0;

            string SCSEQText = string.Empty;
            //오브젝트를 json타입으로 변경                

            //톰슨집이 선택됬을떄만
            if (Combo_SCList.SelectedIndex > 0)
            {
                SCSEQText = JsonConvert.SerializeObject(Combo_SCList.SelectedItem);

                SCSEQ = Convert.ToInt64(JsonConvert.DeserializeObject<Model_KeyValue>(SCSEQText).Key);

                Set_MokList(SCSEQ);
            }

            Set_MokList();


        }



        //톰슨집 시퀀스 전역변수 선언
        private long Selected_SCSEQ = 0;

        /// <summary>
        /// 톰슨집 목형리스트 세팅
        /// </summary>
        /// <param name="SCSEQ"></param>
        private void Set_MokList(long SCSEQ)
        {

            Dgv_IOList.Rows.Clear();

            Selected_SCSEQ = SCSEQ;
            var List = from IO in db.MK_InOut
                       where IO.SC_Seq == SCSEQ
                       orderby IO.IO_RegDate descending
                       select new View_SCIOList
                       {
                           IOSEQ = IO.IO_Seq,
                           IODate = IO.IO_RegDate,
                           MokName = IO.MK_Info.MI_Name,
                           MokType = IO.MK_Info.MI_Type,
                       };

            int RowNum = 0;
            var ResultList = List.ToList();
            RowNum = ResultList.Count();

            ResultList = (from VS in ResultList
                          select new View_SCIOList
                          {
                              RowNum = RowNum--,
                              IOSEQ = VS.IOSEQ,
                              IODate = VS.IODate,
                              MokName = VS.MokName,
                              MokType = VS.MokType

                          }).ToList();

            if (ResultList.Count() > 0)
            {
                foreach (var i in ResultList)
                {
                    Dgv_IOList.Rows.Add(i.IOSEQ, i.RowNum, i.MokName, ConvertUtil.Get_MokType_Text(i.MokType), i.IODate.ToShortDateString());
                }
            }
        }

        /// <summary>
        /// 목형리스트 세팅
        /// </summary>
        private void Set_MokList()
        {
            Dgv_MokList.Rows.Clear();

            var List = from MI in db.MK_Info
                       where MI.MK_InOut.Count() == 0
                       orderby MI.MI_ModDate descending
                       select new View_MokList
                       {
                           MISEQ = MI.MI_Seq,
                           Mok_Name = MI.MI_Name,
                           Mok_Number = MI.MI_Number,
                           Mok_Type = MI.MI_Type
                       };


            int RowNum = 1;
            var ResultList = List.ToList();

            if (Combo_SearchType.SelectedIndex != 0)
            {
                string SearchType_String = string.Empty;
                string Search_Type = string.Empty;
                int Search_MokNum = 0;

                SearchType_String = JsonConvert.SerializeObject(Combo_SearchType.SelectedItem);
                Search_Type = JsonConvert.DeserializeObject<Model_KeyValue>(SearchType_String).Key;
                if (!string.IsNullOrWhiteSpace(Text_SearchText.Text))
                {
                    if (Search_Type == Comm_Enum.Search_Type.N.ToString())
                    {
                        ResultList = ResultList.Where(x => x.Mok_Name.Contains(Text_SearchText.Text)).ToList();
                    }
                    else if (Search_Type == Comm_Enum.Search_Type.U.ToString())
                    {
                        if (ConvertUtil.Check_Number_Validate(Text_SearchText.Text))
                        {
                            MessageBox.Show("숫자만 입력가능합니다");
                            Text_SearchText.Text = "";
                        }
                        else
                        {
                            Search_MokNum = Convert.ToInt32(Text_SearchText.Text);
                            ResultList = ResultList.Where(x => x.Mok_Number.Equals(Search_MokNum)).ToList();
                        }


                    }

                }
            }

            RowNum = ResultList.Count();

            ResultList = (from R in ResultList
                          select new View_MokList
                          {
                              RowNum = RowNum--,
                              MISEQ = R.MISEQ,
                              Mok_Name = R.Mok_Name,
                              Mok_Number = R.Mok_Number,
                              Mok_Type = R.Mok_Type
                          }).ToList();

            if (ResultList.Count() > 0)
            {
                foreach (var i in ResultList)
                {
                    Dgv_MokList.Rows.Add(i.MISEQ, i.RowNum, i.Mok_Name, i.Mok_Number, ConvertUtil.Get_MokType_Text(i.Mok_Type));
                }
            }

        }

        /// <summary>
        /// 검색시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_SearchMok_Click(object sender, EventArgs e)
        {
            Set_MokList();
        }

        /// <summary>
        /// 검색타입선택시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Combo_SearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Combo_SearchType.SelectedIndex != 0)
            {
                Text_SearchText.ReadOnly = false;
            }
            else
            {
                Text_SearchText.ReadOnly = true;
            }

            Text_SearchText.Text = "";
        }


        #region 목형리스트에서 톰슨집리스트로 이동
        /* Drag & Drop */
        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;

        //목형리스트위에서 마우스움직일때 모양을 처리
        private void Dgv_MokList_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = Dgv_MokList.DoDragDrop(Dgv_MokList.Rows[rowIndexFromMouseDown], DragDropEffects.Copy);
                }
            }

        }
        //목형 리스트 위에서 클릭했을때
        private void Dgv_MokList_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = Dgv_MokList.HitTest(e.X, e.Y).RowIndex;

            
            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;


        }

        //톰슨집 목형리스트 위로 올릴떄
        private void Dgv_IOList_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        //톰슨집 목형리스트 위로 드랍할떄
        private void Dgv_IOList_DragDrop(object sender, DragEventArgs e)
        {
            long MISEQ = 0;
            try
            {
                CommProc CP = new CommProc(db);
                if (e.Data.GetDataPresent(typeof(DataGridViewRow)))
                {

                    // The mouse locations are relative to the screen, so they must be 
                    // converted to client coordinates.
                    //선택되는 로우의값을 변수선언
                    Point clientPoint = Dgv_IOList.PointToClient(new Point(e.X, e.Y));

                    // If the drag operation was a copy then add the row to the other control.
                    if (e.Effect == DragDropEffects.Copy)
                    {
                        //목형리스트의 데이터를 가져욤
                        DataGridViewRow Row = (DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow));
                        MISEQ = Convert.ToInt64(Row.Cells[0].Value.ToString());
                        Add_SCMokList(Selected_SCSEQ, MISEQ);

                        CP.Save_InOutLog(MISEQ, Selected_SCSEQ, Comm_Enum.InOut_Type.O.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("이동에 실패했습니다.");
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show("이동에 실패했습니다.");
            }
        }
        #endregion

        //톰슨집 출고된 목형 추가 액션
        public void Add_SCMokList(long SCSEQ, long MISEQ)
        {

            if (MISEQ != 0 && SCSEQ != 0)
            {
                try
                {
                    MK_InOut IO = new MK_InOut()
                    {
                        SC_Seq = SCSEQ,
                        MI_Seq = MISEQ,
                        IO_RegDate = DateTime.Now
                    };

                    db.MK_InOut.Add(IO);
                    db.SaveChanges();

                    MessageBox.Show("목형출고가 완료되었습니다");
                    Set_MokList(SCSEQ);
                    Set_MokList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("목형출고를 실패하였습니다.");
                }
            }

        }

        /// <summary>
        /// 톰슨집에서 다시 입고된 목형 액션
        /// </summary>
        /// <param name="IOSEQ"></param>
        public void Remove_SCMokList(long IOSEQ)
        {
            if (IOSEQ != 0)
            {
                try
                {
                    var Del_IO_Info = db.MK_InOut.Find(IOSEQ);
                    db.MK_InOut.Remove(Del_IO_Info);

                    db.SaveChanges();
                    MessageBox.Show("목형 입고가 완료되었습니다");
                    Set_MokList(Selected_SCSEQ);
                    Set_MokList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("목형삭제를 실패했습니다");
                }
            }
        }

        #region 톰슨집리스트에서 목형리스트로 이동
        //톰슨집 목형리스트에서 선택해서 옮길때
        private void Dgv_IOList_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = Dgv_IOList.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }
        //톰슨집 목형리스트위로 마우스를올릴때
        private void Dgv_IOList_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = Dgv_MokList.DoDragDrop(Dgv_IOList.Rows[rowIndexFromMouseDown], DragDropEffects.Copy);
                }
            }
        }
        //목형리스트 위로 데이터를 놓을떄
        private void Dgv_MokList_DragDrop(object sender, DragEventArgs e)
        {
            long IOSEQ = 0;
            try
            {
                if (e.Data.GetDataPresent(typeof(DataGridViewRow)))
                {
                    CommProc CP = new CommProc(db);
                    // The mouse locations are relative to the screen, so they must be 
                    // converted to client coordinates.
                    //선택되는 로우의값을 변수선언
                    Point clientPoint = Dgv_MokList.PointToClient(new Point(e.X, e.Y));

                    // If the drag operation was a copy then add the row to the other control.
                    if (e.Effect == DragDropEffects.Copy)
                    {
                        long MISEQ = 0;
                        long SCSEQ = 0;

                        //목형리스트의 데이터를 가져욤
                        DataGridViewRow Row = (DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow));
                        IOSEQ = Convert.ToInt64(Row.Cells[0].Value.ToString());

                        var Result = db.MK_InOut.Find(IOSEQ);

                        MISEQ = Result.MI_Seq;
                        SCSEQ = Result.SC_Seq;
                        
                        Remove_SCMokList(IOSEQ);

                        CP.Save_InOutLog(MISEQ, SCSEQ, Comm_Enum.InOut_Type.I.ToString());

                    }
                }
                else
                {
                    MessageBox.Show("이동에 실패했습니다.");
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show("이동에 실패했습니다.");
            }
        }
        //목형리스트 위로 마우스를 올릴때
        private void Dgv_MokList_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        #endregion

        private void AddInOut_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((MainInOut)(this.Owner)).SetList();
        }
    }


}
