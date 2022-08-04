using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace HW2
{
    public class HTMLReader : IHTMLReader
    {
        public void ReadAndWriteHtmlToFile(string urlAdress, string path)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage resp = client.GetAsync(urlAdress).Result)
                    {
                        if (resp.IsSuccessStatusCode)
                        {
                            var html = resp.Content.ReadAsStringAsync().Result;
                            if (!string.IsNullOrEmpty(html))
                            {
                                StreamWriter sw = new StreamWriter(path);
                                sw.WriteLine(html);
                                sw.Close();

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Operation succesful!!!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }   
    }
}
