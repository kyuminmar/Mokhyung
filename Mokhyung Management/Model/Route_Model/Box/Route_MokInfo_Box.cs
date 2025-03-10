using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mokhyung_Management.Model.Route_Model.Box
{
    public class Route_MokInfo_Box
    {
        public long MI_Seq { get; set; }
        public string MIB_Type { get; set; }
        public int MIB_Pyunglyang { get; set; }
        public int MIB_PanNumber { get; set; }
        public string MIB_Bigo { get; set; }

        /// 로컬경로 (FTP업로드시 사용)
        public string MIB_LocalFilePath { get; set; }
        //최초 파일이름
        public string MIB_FileName { get; set; }
        //FTP다운로드url
        public string MIB_FTPFilePath { get; set; }
        //FTP 업로드시 파일명을PDF로 변환하려는 용도
        public string MIB_FTPFilePathPDF { get; set; }
        //파일이름을 PDF로저장
        public string MIB_FileNamePDF
        {
            get
            {
                string Result = null;
                if (!string.IsNullOrEmpty(MIB_FileName))
                {

                    //확장명만 pdf로변경
                    Result = MIB_FileName.Replace(MIB_FileName.Split('.')[MIB_FileName.Split('.').Length - 1], "pdf");
                }
                return Result;
            }
        }
    }
}
