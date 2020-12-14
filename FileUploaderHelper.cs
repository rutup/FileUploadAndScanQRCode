using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FileScannerApp
{
    class FileUploaderHelper
    {
        public static string UploadFileAndScanQRCode(string filePath, string fileName)
        {
            string response = string.Empty;
            string url = "http://api.qrserver.com/v1/read-qr-code/";

            using (var httpClient = new HttpClient())
            {
                using (var form = new MultipartFormDataContent())
                {
                    try
                    {
                        ByteArrayContent firstpart = new ByteArrayContent(File.ReadAllBytes(filePath));
                        firstpart.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                        form.Add(firstpart, "file", fileName);

                        HttpResponseMessage apiResponse = httpClient.PostAsync(url, form).Result;
                        if (apiResponse.IsSuccessStatusCode)
                        {
                            List<QRAPIResponse> output = JsonConvert.DeserializeObject<List<QRAPIResponse>>(apiResponse.Content.ReadAsStringAsync().Result);
                            response = output[0].symbol[0].data;
                        }

                        return response;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
    }
}
