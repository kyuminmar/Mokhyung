using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mokhyung_Management.Model.AddMok
{
    public class Route_MokInfo_SP
    {
        public long MI_Seq { get; set; }
        public string MIS_Type { get; set; }
        public bool MIS_JJokYn { get; set; }
        public int MIS_Sangjub { get; set; }
        public int MIS_Hajub { get; set; }
        public int MIS_Pulbari { get; set; }
        public string MIS_Bigo { get; set; }
        /// 로컬경로 (FTP업로드시 사용)
        public string MIS_LocalFilePath { get; set; }
        //최초 파일이름
        public string MIS_FileName { get; set; }       
        //FTP다운로드url
        public string MIS_FTPFilePath { get; set; }
        //FTP 업로드시 파일명을PDF로 변환하려는 용도
        public string MIS_FTPFilePathPDF { get; set; }
        //파일이름을 PDF로저장
        public string MIS_FileNamePDF
        {
            get
            {
                string Result = null;
                if (!string.IsNullOrEmpty(MIS_FileName))
                {

                    //확장명만 pdf로변경
                    Result = MIS_FileName.Replace(MIS_FileName.Split('.')[MIS_FileName.Split('.').Length - 1], "pdf");
                }
                return Result;
            }
        }


    }
}
