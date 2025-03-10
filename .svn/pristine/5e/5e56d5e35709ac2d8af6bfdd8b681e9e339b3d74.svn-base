using CommonControl;
using CommonUtil;
using Mokhyung_Management.Model.ViewModel.IO;
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
    public partial class MainInOut : BaseCommonController
    {
        public MainInOut()
        {
            InitializeComponent();
        }

        private void Load_MainInOut(object sender, EventArgs e)
        {

            SetList();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AddSubContract ASC = new AddSubContract();
            ASC.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddInOut AIO = new AddInOut();
            AIO.ShowDialog(this);
        }

        /// <summary>
        /// 목형 입출고현황 리스트 세팅
        /// </summary>
        public void SetList()
        {

            Dgv_IOList.Rows.Clear();
            var List = from IOL in db.MK_InOut_Log
                       orderby IOL.IOL_RegDate descending
                       select new View_IOList
                       {
                           IOLSEQ = IOL.IOL_Seq, 
                           Mok_Name = IOL.MK_Info.MI_Name,
                           SC_Name = IOL.MK_SubContract.SC_Name,
                           IO_Type = IOL.IOL_Type,
                           RegDate = IOL.IOL_RegDate
                       };

            int RowNum = 0;
            var ResultList = List.ToList();

            RowNum = ResultList.Count();

            ResultList = (from R in ResultList
                          select new View_IOList
                          {
                              RowNum = RowNum--,
                              IOLSEQ = R.IOLSEQ,
                              Mok_Name = R.Mok_Name,
                              IO_Type = R.IO_Type,
                              RegDate = R.RegDate,
                              SC_Name = R.SC_Name
                          }).ToList();

            if(ResultList.Count>0)
            {
                foreach(var i in ResultList)
                {
                    Dgv_IOList.Rows.Add(i.IOLSEQ, i.RowNum, i.Mok_Name, i.SC_Name, ConvertUtil.Get_InOut_Text(i.IO_Type), i.RegDate.ToShortDateString());
                }
                
            }

        }
    }
}
