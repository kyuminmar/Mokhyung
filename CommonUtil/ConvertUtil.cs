﻿using CommonUtil.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommonUtil
{
    public class ConvertUtil
    {

        /// <summary>
        /// 키밸류 텍스트변환
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string Get_KeyValueText(string index)
        {
            string KeyValueText = string.Empty;
            Comm_Enum.KeyValue KV = Comm_Enum.ParseEnum<Comm_Enum.KeyValue>(index);

            if (index != null)
            {
                switch (KV)
                {
                    case Comm_Enum.KeyValue.K:
                        KeyValueText = Comm_Param.KeyValueString.K;
                        break;
                    case Comm_Enum.KeyValue.V:
                        KeyValueText = Comm_Param.KeyValueString.V;
                        break;

                    default:
                        break;
                }
            }
            return KeyValueText;
        }

        /// <summary>
        /// 목형 타입 텍스트  
        /// </summary>
        /// <param name="PopupType"></param>
        /// <returns></returns>
        public static string Get_MokType_Text(string Mok_Type)
        {
            string MokTypeText = string.Empty;
            Comm_Enum.Mok_Type MT = Comm_Enum.ParseEnum<Comm_Enum.Mok_Type>(Mok_Type);

            if (Mok_Type != null)
            {
                switch (MT)
                {
                    case Comm_Enum.Mok_Type.S:
                        MokTypeText = Comm_Param.Mok_type.S;
                        break;
                    case Comm_Enum.Mok_Type.B:
                        MokTypeText = Comm_Param.Mok_type.B;
                        break;
                    case Comm_Enum.Mok_Type.E:
                        MokTypeText = Comm_Param.Mok_type.E;
                        break;

                    default:
                        break;
                }
            }
            return MokTypeText;
        }


        /// <summary>
        /// 목형 타입 텍스트 리스트 만들기 
        /// </summary>
        /// <param name="Mok_Type"></param>
        /// <returns></returns>
        public static List<Model_KeyValue> Get_MokType_List()
        {
            List<Model_KeyValue> MKList = new List<Model_KeyValue>();
            Model_KeyValue MK = new Model_KeyValue();

            //초기 선택 텍스트를 위해 넣어줌           
            MKList.Add(new Model_KeyValue() { Key = "", Value = "선택"});

            MKList.Add(new Model_KeyValue() { Key = Comm_Enum.Mok_Type.S.ToString(), Value = Get_MokType_Text(Comm_Enum.Mok_Type.S.ToString()) });
            MKList.Add(new Model_KeyValue() { Key = Comm_Enum.Mok_Type.B.ToString(), Value = Get_MokType_Text(Comm_Enum.Mok_Type.B.ToString()) });
            MKList.Add(new Model_KeyValue() { Key = Comm_Enum.Mok_Type.E.ToString(), Value = Get_MokType_Text(Comm_Enum.Mok_Type.E.ToString()) });

            return MKList;
        }


        /// <summary>
        /// 쇼핑백 타입 텍스트  
        /// </summary>
        /// <param name="PopupType"></param>
        /// <returns></returns>
        public static string Get_SPType_Text(string SP_Type)
        {
            string SPTypeText = string.Empty;
            Comm_Enum.SP_Type MT = Comm_Enum.ParseEnum<Comm_Enum.SP_Type>(SP_Type);

            if (SP_Type != null)
            {
                switch (MT)
                {
                    case Comm_Enum.SP_Type.T:
                        SPTypeText = Comm_Param.SP_type.T;
                        break;
                    case Comm_Enum.SP_Type.M:
                        SPTypeText = Comm_Param.SP_type.M;
                        break;
                    case Comm_Enum.SP_Type.J:
                        SPTypeText = Comm_Param.SP_type.J;
                        break;

                    default:
                        break;
                }
            }
            return SPTypeText;
        }

        /// <summary>
        /// 박스 타입 텍스트  
        /// </summary>
        /// <param name="PopupType"></param>
        /// <returns></returns>
        public static string Get_BoxType_Text(string Box_Type)
        {
            string BoxTypeText = string.Empty;
            Comm_Enum.Box_Type MT = Comm_Enum.ParseEnum<Comm_Enum.Box_Type>(Box_Type);

            if (Box_Type != null)
            {
                switch (MT)
                {
                    case Comm_Enum.Box_Type.D:
                        BoxTypeText = Comm_Param.Box_type.D;
                        break;
                    case Comm_Enum.Box_Type.G:
                        BoxTypeText = Comm_Param.Box_type.G;
                        break;
                    case Comm_Enum.Box_Type.H:
                        BoxTypeText = Comm_Param.Box_type.H;
                        break;
                    case Comm_Enum.Box_Type.S:
                        BoxTypeText = Comm_Param.Box_type.S;
                        break;
                    case Comm_Enum.Box_Type.I:
                        BoxTypeText = Comm_Param.Box_type.I;
                        break;

                    default:
                        break;
                }
            }
            return BoxTypeText;
        }

        /// <summary>
        /// 쇼핑백 타입 텍스트 리스트 만들기 
        /// </summary>
        /// <param name="Mok_Type"></param>
        /// <returns></returns>
        public static List<Model_KeyValue> Get_SPType_List()
        {
            List<Model_KeyValue> SPList = new List<Model_KeyValue>();
            Model_KeyValue SP = new Model_KeyValue();

            //초기 선택 텍스트를 위해 넣어줌           
            SPList.Add(new Model_KeyValue() { Key = "", Value = "선택" });

            SPList.Add(new Model_KeyValue() { Key = Comm_Enum.SP_Type.T.ToString(), Value = Get_SPType_Text(Comm_Enum.SP_Type.T.ToString()) });
            SPList.Add(new Model_KeyValue() { Key = Comm_Enum.SP_Type.M.ToString(), Value = Get_SPType_Text(Comm_Enum.SP_Type.M.ToString()) });
            SPList.Add(new Model_KeyValue() { Key = Comm_Enum.SP_Type.J.ToString(), Value = Get_SPType_Text(Comm_Enum.SP_Type.J.ToString()) });

            return SPList;
        }


        /// <summary>
        /// 박스 타입 텍스트 리스트 만들기 
        /// </summary>
        /// <param name="Mok_Type"></param>
        /// <returns></returns>
        public static List<Model_KeyValue> Get_BoxType_List()
        {
            List<Model_KeyValue> BoxList = new List<Model_KeyValue>();
            Model_KeyValue Box = new Model_KeyValue();

            //초기 선택 텍스트를 위해 넣어줌           
            BoxList.Add(new Model_KeyValue() { Key = "", Value = "선택" });

            BoxList.Add(new Model_KeyValue() { Key = Comm_Enum.Box_Type.D.ToString(), Value = Get_BoxType_Text(Comm_Enum.Box_Type.D.ToString()) });
            BoxList.Add(new Model_KeyValue() { Key = Comm_Enum.Box_Type.G.ToString(), Value = Get_BoxType_Text(Comm_Enum.Box_Type.G.ToString()) });
            BoxList.Add(new Model_KeyValue() { Key = Comm_Enum.Box_Type.S.ToString(), Value = Get_BoxType_Text(Comm_Enum.Box_Type.S.ToString()) });
            BoxList.Add(new Model_KeyValue() { Key = Comm_Enum.Box_Type.H.ToString(), Value = Get_BoxType_Text(Comm_Enum.Box_Type.H.ToString()) });
            BoxList.Add(new Model_KeyValue() { Key = Comm_Enum.Box_Type.I.ToString(), Value = Get_BoxType_Text(Comm_Enum.Box_Type.I.ToString()) });

            return BoxList;
        }
        /// <summary>
        /// t/f 를 YN으로
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Get_YN_Value(bool value)
        {

            string Result = string.Empty;

            if(value)
            {
                Result = Comm_Enum.Y_N.Y.ToString();
            }    
            else
            {
                Result = Comm_Enum.Y_N.N.ToString();
            }

            return Result;
        }

        /// <summary>
        /// 쪽여부 텍스트
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Get_JJokYnText(bool value)
        {

            string Result = string.Empty;
            if(value)
            {
                Result = "예";
            }
            else
            {
                Result = "아니오";
            }
            return Result;
        }

        /// <summary>
        /// 쇼핑백 검색 타입 리스트
        /// </summary>
        /// <param name="Mok_Type"></param>
        /// <returns></returns>
        public static List<Model_KeyValue> Get_SPSearchType_List()
        {
            List<Model_KeyValue> SPList = new List<Model_KeyValue>();
            Model_KeyValue SP = new Model_KeyValue();

            //초기 선택 텍스트를 위해 넣어줌           
            SPList.Add(new Model_KeyValue() { Key = "", Value = "선택" });

            SPList.Add(new Model_KeyValue() { Key = Comm_Enum.Search_Type.N.ToString(), Value = Comm_Param.Search_Type.N});
            //SPList.Add(new Model_KeyValue() { Key = Comm_Enum.Search_Type.T.ToString(), Value = Comm_Param.Search_Type.T });
            SPList.Add(new Model_KeyValue() { Key = Comm_Enum.Search_Type.U.ToString(), Value = Comm_Param.Search_Type.U });

            return SPList;
        }

        /// <summary>
        /// 텍스트박스 정규식 유효성검사
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static bool Check_TextBox_Validate(string Type, string Text)
        {
            bool Result = true;
            Comm_Enum.Validate_Text VT = Comm_Enum.ParseEnum<Comm_Enum.Validate_Text>(Type);
            if (Text != "")
            {
                switch (VT)
                {
                    //숫자만 입력해야될때
                    case Comm_Enum.Validate_Text.N:
                        string str = Regex.Replace(Text, @"[0-9]", "");
                        if (str.Length > 0)
                        {
                            Result = false;
                        }
                        else
                        {
                            Result = true;
                        }
                        break;
                    case Comm_Enum.Validate_Text.K:
                        break;

                    default:
                        break;
                }
            }
            return Result;
        }

        /// <summary>
        /// 번호 유효성검사
        /// </summary>
        /// <param name="MokNum"></param>
        /// <returns></returns>
        public static bool Check_Number_Validate(string InputNumber)
        {
            bool Result=true;

            string Number = Regex.Replace(InputNumber, @"[0-9]", "");
            if (!string.IsNullOrEmpty(InputNumber))
            {
                if (!string.IsNullOrWhiteSpace(Number) &&
                Number.Length > 0)
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
        /// 목형 입출고 텍스트
        /// </summary>
        /// <param name="PopupType"></param>
        /// <returns></returns>
        public static string Get_InOut_Text(string IO_Type)
        {
            string InOutText = string.Empty;
            Comm_Enum.InOut_Type IOT = Comm_Enum.ParseEnum<Comm_Enum.InOut_Type>(IO_Type);

            if (IO_Type != null)
            {
                switch (IOT)
                {
                    case Comm_Enum.InOut_Type.I:
                        InOutText = Comm_Param.InOut_Type.I;
                        break;
                    case Comm_Enum.InOut_Type.O:
                        InOutText = Comm_Param.InOut_Type.O;
                        break;

                    default:
                        break;
                }
            }
            return InOutText;
        }

    }
}
