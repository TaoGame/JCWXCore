using System;
using System.IO;
using System.Text;

namespace JCSoft.Common.Http
{
    public class HttpResult
    {
        /// <summary>
        /// 0 is success, other is fail
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// error message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// ex
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// is error
        /// </summary>
        public bool IsError { get; set; }

        public Encoding Encoding { get; set; }

        private string p_result = String.Empty;
        /// <summary>
        /// string result
        /// </summary>
        public string Result
        {
            get
            {
                if(StreamResult != null && String.IsNullOrEmpty(p_result))
                {
                    if (Encoding == null)
                        Encoding = Encoding.GetEncoding(0);

                    using (var reader = new StreamReader(StreamResult, Encoding))
                    {
                        return reader.ReadToEnd();
                    }

                }

                return p_result;
            }
        }

        /// <summary>
        /// stream result
        /// </summary>
        public Stream StreamResult { get; set; }
    }
}
