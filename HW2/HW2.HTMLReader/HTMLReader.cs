using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class HTMLReader : IHTMLReader
    {
        public void ReadAndWriteHtmlToFile(string urlAdress, string path)
        {
            try
            {
                using (HttpClientHandler hdl = new HttpClientHandler())
                {
                    using (HttpClient client = new HttpClient(hdl))
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
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
            catch (SocketException ex)
            {
                throw ex;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (DirectoryNotFoundException ex)
            {
                throw ex;
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }
        }   
    }
}
