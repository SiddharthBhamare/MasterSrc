using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Net;
using System.Text;

namespace PhotoBookWebService
{
    public static class UtilityFunctions
    {
        public static string decryptPassword(string astrPassword)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(astrPassword);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
        public static string encryptPassword(string astrPassword)
        {
            try
            {
                byte[] encData_byte = new byte[astrPassword.Length];
                encData_byte = Encoding.UTF8.GetBytes(astrPassword);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public static WebHttpResponse? GetResponseObject(HttpStatusCode code, object objData, bool ablnIsSuccess)
        {
            WebHttpResponse webHttpResponse = new WebHttpResponse();
            webHttpResponse.Data = objData;
            webHttpResponse.StatusCode = code;
            webHttpResponse.Description = code.ToString();
            webHttpResponse.IsSuccess = ablnIsSuccess;
            return webHttpResponse;
        }
    }
}
