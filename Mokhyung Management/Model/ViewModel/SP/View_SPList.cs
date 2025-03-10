using CommonUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mokhyung_Management.Model.ViewModel.SP
{
    public class View_SPList
    {
        public int RowNum { get; set; }
        public long MI_Seq { get; set; }

        public string MI_Type { get; set; }

        public string MI_Name { get; set; }

        public int MI_Number { get; set; }

        public int MI_Jang { get; set; }

        public int MI_Pok { get; set; }

        public int MI_Go { get; set; }

        public DateTime MI_RegDate { get; set; }

        public DateTime MI_ModDate { get; set; }

        public View_SPDetail Detail { get; set; }

    }

    public class View_SPDetail
    {

        public long MIS_Seq { get; set; }
        public string MIS_Type { get; set; }

        public string MIS_TypeText
        {
            get
            {
                string MT = string.Empty;
                if (!string.IsNullOrEmpty(this.MIS_Type))
                {
                    MT = ConvertUtil.Get_SPType_Text(MIS_Type);

                }
                return MT;
            }
        }

        public bool MIS_JJokYN { get; set; }

        public string MIS_JJokYNText
        {
            get
            {
                string MJ = string.Empty;
                MJ = ConvertUtil.Get_JJokYnText(this.MIS_JJokYN);
                return MJ;
            }
        }

        public int MIS_Sangjub { get; set; }

        public int MIS_Hajub { get; set; }

        public int MIS_Pulbari { get; set; }
        public string MIS_Bigo { get; set; }
        public string MIS_FilePath { get; set; }

        public string MIS_FileName { get; set; }

        public DateTime MIS_RegDate { get; set; }

        public DateTime MIS_ModDate { get; set; }


    }

}
