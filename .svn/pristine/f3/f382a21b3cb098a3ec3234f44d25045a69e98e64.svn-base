using CommonUtil;
using CommonUtil.Model;
using EF_CodeFirst.DB_Context;
using EF_CodeFirst.DB_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EF_CodeFirst.DB_CommProc
{

    public class CommProc
    {

        MokManagementContext _db;

        public CommProc(MokManagementContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 목형 이름 중복체크
        /// </summary>
        /// <param name="MISEQ"></param>
        /// <returns></returns>
        public bool Check_MokNameDuplication(string MokName)
        {
            bool Result;
            int DupCount = 0;

            if (!string.IsNullOrEmpty(MokName))
            {
                DupCount = _db.MK_Info.Where(x => x.MI_Name.Equals(MokName)).Count();
                if (DupCount > 0)
                {
                    Result = true;
                }
                else
                {
                    Result = false;
                }
            }
            else
            {
                Result = false;
            }

            return Result;
        }

        /// <summary>
        /// 목형번호 중복체크
        /// </summary>
        /// <param name="MISEQ"></param>
        /// <returns></returns>
        public bool Check_MokNumberDuplication(string MokNum)
        {
            bool Result;
            int DupCount = 0;
            int MokNumber = 0;

            if (!string.IsNullOrEmpty(MokNum))
            {
                MokNumber = Convert.ToInt32(MokNum);
                DupCount = _db.MK_Info.Where(x => x.MI_Number.Equals(MokNumber)).Count();
                if (DupCount > 0)
                {
                    Result = true;
                }
                else
                {
                    Result = false;
                }
            }
            else
            {
                Result = false;
            }
            return Result;
        }

        /// <summary>
        /// 파일명 중복체크
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool Check_FileNameDuplication(string FileName,string Type)
        {
            bool Result;
            int DupCount = 0;

            if (!string.IsNullOrEmpty(FileName))
            {

                FileName = FileName.Replace(FileName.Split('.')[FileName.Split('.').Length - 1], "pdf");
                if (Type == Comm_Enum.Mok_Type.S.ToString())
                { 
                    DupCount = _db.MK_Info_SP.Where(x => x.MIS_FileName.Equals(FileName)).Count();
                }
                else if(Type == Comm_Enum.Mok_Type.B.ToString())
                {
                    DupCount = _db.MK_Info_Box.Where(x => x.MIB_FileName.Equals(FileName)).Count();
                }
                if (DupCount > 0)
                {
                    Result = true;
                }
                else
                {
                    Result = false;
                }
            }
            else
            {
                Result = false;
            }
            return Result;
        }

        /// <summary>
        /// 파일 이름 얻어오기
        /// </summary>
        /// <param name="MISEQ"></param>
        /// <returns></returns>
        public string Get_FileName(long MISEQ, string Type)
        {
            string FullFilePath = string.Empty;

            //FullFilePath = _db.MK_Info_SP.Where(x => x.MI_Seq == MISEQ).FirstOrDefault().MIS_FileName;
            if( Type == Comm_Enum.Mok_Type.S.ToString())
            { 
                FullFilePath = (from BB in _db.MK_Info_SP
                               where BB.MI_Seq == MISEQ
                               select BB.MIS_FileName).FirstOrDefault();
            }
            else if (Type == Comm_Enum.Mok_Type.B.ToString())
            {
                FullFilePath = (from BB in _db.MK_Info_Box
                                where BB.MI_Seq == MISEQ
                                select BB.MIB_FileName).FirstOrDefault();
            }

                return FullFilePath;
        }


        /// <summary>
        /// 톰슨집 리스트
        /// </summary>
        /// <param name="Mok_Type"></param>
        /// <returns></returns>
        public List<Model_KeyValue> Get_SubContract_List()
        {
            List<Model_KeyValue> SCList = new List<Model_KeyValue>();
            //초기 선택 텍스트를 위해 넣어줌           
            SCList.Add(new Model_KeyValue() { Key = "", Value = "선택" });


            var List = (from SC in _db.MK_SubContract
                       select new Model_KeyValue
                       {
                           Key = SC.SC_Seq.ToString(),
                           Value = SC.SC_Name
                       }).ToList();

            SCList.AddRange(List);

            return SCList;
        }

        /// <summary>
        /// 입출고내역 로그저장
        /// </summary>
        /// <param name="IOSEQ"></param>
        /// <param name="SCSEQ"></param>
        /// <param name="IOLType"></param>
        public bool Save_InOutLog(long MISEQ, long SCSEQ, string IOLType)
        {
            try
            {
                if (MISEQ != 0 && SCSEQ != 0)
                {
                    MK_InOut_Log IOL = new MK_InOut_Log()
                    {
                        MI_Seq = MISEQ,
                        SC_Seq = SCSEQ,
                        IOL_RegDate = DateTime.Now,
                        IOL_Type = IOLType
                    };

                    _db.MK_InOut_Log.Add(IOL);
                    _db.SaveChanges();

                }
                return true;

            }
            catch(Exception ex)
            {
                return false;
            }

        }








    }
}
