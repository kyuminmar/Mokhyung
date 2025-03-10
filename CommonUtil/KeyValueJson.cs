using System.Runtime.Serialization;

namespace CommonUtil
{

    /// <summary>
    /// Json 공통 메시지 처리 [키와 값]
    /// RtnKey, RtnValue
    /// </summary>
    [DataContract]
    public class KeyValueJson
    {
        /// <summary>
        /// 공통KEY
        /// </summary>
        [DataMember]
        public string RtnKey { get; set; }

        /// <summary>
        /// KEY에 대한  설명
        /// </summary>
        [DataMember]
        public string RtnValue { get; set; }
    }

    /// <summary>
    /// Json 공통 메시지 처리 [키와 값]
    /// </summary>
    [DataContract]
    public class KeyValueAuthJson
    {
        [DataMember]
        public string RtnKey { get; set; }

        [DataMember]
        public string RtnValue { get; set; }
    }
}
