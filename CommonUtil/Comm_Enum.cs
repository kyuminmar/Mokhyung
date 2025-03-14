﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtil
{
   public  class Comm_Enum
    {

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
       
        /// <summary>
        /// 목형타입
        /// </summary>
        public enum Mok_Type : int
        {
           
            /// <summary>
            /// 쇼핑백
            /// </summary>
            S,
            /// <summary>
            /// 박스
            /// </summary>
            B,
            /// <summary>
            /// 기타
            /// </summary>
            E
        }

        public enum KeyValue : int
        {
            /// <summary>
            /// 인덱스
            /// </summary>
            K,
            /// <summary>
            /// 값
            /// </summary>
            V
        }

        public enum SP_Type : int
        {

            /// <summary>
            /// 타공
            /// </summary>
            T,
            /// <summary>
            /// 매립
            /// </summary>
            M,
            /// <summary>
            /// 쪽
            /// </summary>
            J

        }

        public enum Box_Type : int
        {

            /// <summary>
            /// 단상자
            /// </summary>
            D,
            /// <summary>
            /// 골판지
            /// </summary>
            G,
            /// <summary>
            /// 싸개지
            /// </summary>
            S,
            /// <summary>
            /// 합지
            /// </summary>
            H,
            /// <summary>
            /// 띠지
            /// </summary>
            I

        }

        public enum Y_N : int
        {
            Y,
            N
        }

        public enum Search_Type : int
        {
            /// <summary>
            /// 목형명
            /// </summary>
            N,
            /// <summary>
            /// 목형번호
            /// </summary>
            U,
            /// <summary>
            /// 타입
            /// </summary>
            T
        }

        /// <summary>
        /// 텍스트 유효성검사 타입
        /// </summary>
        public enum Validate_Text : int
        {
            /// <summary>
            /// 숫자만
            /// </summary>
            N,
            /// <summary>
            /// 한글만
            /// </summary>
            K               
        }

        /// <summary>
        /// 목형 입출고 타입
        /// </summary>
        public enum InOut_Type : int
        {
            /// <summary>
            /// 입고
            /// </summary>
            I,
            /// <summary>
            /// 출고
            /// </summary>
            O
        }
    }
}
