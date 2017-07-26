using System;
using JCSoft.WX.Framework.Models.ApiRequests;
using JCSoft.WX.Framework.Models.ApiResponses;
using Xunit;
using JCSoft.WX.Framework.Models;

namespace FrameworkCoreTest
{
    public class MediaUploadTest : MockPostApiBaseTest<MediaUploadRequest, MediaUploadResponse>
    {
        
        [Fact]
        public void MediaUploadReallyTest()
        {
            var response = mock_client.Object.Execute(Request);
            if (response.IsError)
                Console.WriteLine(response.ToString());
            Console.WriteLine(response.MediaId);
        }

        [Fact]
        public void MockMediaUploadTest()
        {
            IsMock = true;
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal("MEDIA_ID", response.MediaId);
        }

        [Fact]
        public void MockMediaUploadErrorTest()
        {
            IsMock = true;
            MockSetup(true);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(true, response.IsError);
        }



        protected override MediaUploadRequest InitRequestObject()
        {
            return new MediaUploadRequest
            {
                AccessToken = GetCurrentToken(),
                FilePath = @"C:\123.amr",
                MediaType = MediaType.Voice
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult)
                return s_errmsg;
            return "{\"type\":\"Image\",\"media_id\":\"MEDIA_ID\",\"created_at\":123456789}";
        }
    }
}
