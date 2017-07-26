using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.Core.Net.Http
{
    public class HttpOptions
    {
        private static Dictionary<string, string> DefaultFileContentTypeDict = new Dictionary<string, string>
        {
            {".jpg", "image/jpeg" },
            {".mp3", "audio/mp3" },
            {".amr", "audio/amr" },
            {".mp4", "video/mp4" }
        };
        
        
        /// <summary>
        /// convert to file ext to content type
        /// e.g. "jpg" -> "image/jpeg"
        /// </summary>
        public void AddFileExtAsContentType(string fileExt, string contentType)
        {
            if (DefaultFileContentTypeDict.Keys.Contains(fileExt))
            {
                DefaultFileContentTypeDict[fileExt] = contentType;
            }
            else
            {
                DefaultFileContentTypeDict.Add(fileExt, contentType);
            }
        }

        public Dictionary<string, string> FileExtContentTypeDict
        {
            get
            {
                return DefaultFileContentTypeDict;
            }
        }
    }
}
