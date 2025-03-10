using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mokhyung_Management.Model.AddMok
{
    public class Route_MokInfo
    {
        [Required(ErrorMessage ="목형이름을 입력해주세요")]
        public string MI_Name { get; set; }
        [Required(ErrorMessage = "목형타입을 선택해주세요")]
        public string MI_Type { get; set; }
        [Required(ErrorMessage = "목형번호를 입력해주세요")]
        public int MI_Number { get; set; }
        [Required(ErrorMessage = "목형 길이를 입력해주세요")]
        public int MI_Jang{ get; set; }
        [Required(ErrorMessage = "목형 폭을 입력해주세요")]
        public int MI_Pok { get; set; }
        [Required(ErrorMessage = "목형 높이를 입력해주세요")]
        public int MI_Go { get; set; }

        //목형명을 파일명으로 변환해서 저장
        //public string MI_FileNamePDF
        //{
        //    get
        //    {
        //        string FileName = "";
        //        FileName = string.Format("{0}.pdf", MI_Name);

        //        return FileName;
        //    }
        //}


    }
}
