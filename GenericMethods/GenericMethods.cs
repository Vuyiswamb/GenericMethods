using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GenericMethods
{
    
    public static class GenericMethods
    {

        public static string VERSION = "Version 1.0";
         
        public static Guid GenerateToken()
        {
            return Guid.NewGuid();
        }
        public static bool RemoteFileExists(string url)
        {
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";
                //Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //Returns TRUE if the Status code == 200
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                //Any exception will returns false.
                return false;
            }
        }

    
        public static byte[] StreamToByteArray(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        public static DateTime Convert_To_System_DateTime(DateTime input,string Culture)
        {
            string finaldate = string.Empty;
            var EnglishCultureInfo = new CultureInfo(Culture);
            try
            {

                finaldate = input.ToString("yyyy-MM-dd hh:mm:ss tt", CultureInfo.CreateSpecificCulture("en-US"));
            }
            catch (Exception)
            {

            }

            return DateTime.Parse(finaldate, EnglishCultureInfo);
        }

        public static string Convert_To_System_DateTime_String(DateTime input, string Culture)
        {
            string finaldate = string.Empty;
            var EnglishCultureInfo = new CultureInfo(Culture);
            try
            {

                finaldate = input.ToString("yyyy-MM-dd hh:mm:ss tt", CultureInfo.CreateSpecificCulture("en-US"));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return finaldate;
        }
        /// GenericMethods.RemoveSpacesIn_String (System.String code)
        ///System.NullReferenceException: Object reference not set to an instance of an object
        public static string RemoveSpacesIn_String(string code)
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(code))
            {
                try
                {

                    string[] lststrings = code.Split(' ');

                    foreach (string st in lststrings)
                    {
                        sb.Append(st);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return string.Empty;
            }
            return sb.ToString();
        }
        public static void ByteArray_To_File(Byte[] file, string extension, string filename,string Path)
        {
            File.WriteAllBytes(Path + filename + "." + extension, file);
        }

        public static bool IsNumeric(this string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    return false;
                }
            }

            return true;
        }



        public static string GetContentType(string Extension)
        {
            string fileType = string.Empty;
            //set the file type based on File Extension
            switch (Extension)
            {

                case "jpg":
                    return fileType = "image/jpg";

                case "png":
                    return fileType = "image/png";

                case "gif":
                    return fileType = "image/gif";
            }

            return fileType;
        }

        public static bool CheckInternetConnection()
        {
            string CheckUrl = "http://google.com";

            try
            {
                HttpWebRequest iNetRequest = (HttpWebRequest)WebRequest.Create(CheckUrl);

                iNetRequest.Timeout = 5000;

                WebResponse iNetResponse = iNetRequest.GetResponse();

                iNetResponse.Close();

                return true;

            }
            catch (WebException)
            {

                return false;
            }
        }


    }
}
