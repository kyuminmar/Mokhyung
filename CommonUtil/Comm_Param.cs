using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CommonUtil
{
    public class Comm_Param
    {

        /// <summary>
        /// 목형타입
        /// </summary>
        public abstract class Mok_type
        {
            public const string S = "쇼핑백";
            public const string B = "박스";
            public const string E = "기타";
        }

        /// <summary>
        /// 키밸류
        /// </summary>
        public abstract class KeyValueString
        {
            public const string K = "Key";
            public const string V = "Value";
        }

        /// <summary>
        /// 쇼핑백타입
        /// </summary>
        public abstract class SP_type
        {
            public const string T = "타공";
            public const string M = "매립";
            public const string J = "J칼";
        }

        /// <summary>
        /// 박스타입
        /// </summary>
        public abstract class Box_type
        {
            public const string D = "단상자";
            public const string G = "골판지";
            public const string S = "싸개지";
            public const string H = "합지";
            public const string I = "띠지";
        }

        /// <summary>
        /// 검색 타입
        /// </summary>
        public abstract class Search_Type
        {
            public const string N = "목형명";
            public const string U = "목형번호";
            public const string T = "타입";
        }

        /// <summary>
        /// 목형 입출고 타입
        /// </summary>
        public abstract class InOut_Type
        {
            public const string I = "입고";
            public const string O = "출고";
        }



    }
}