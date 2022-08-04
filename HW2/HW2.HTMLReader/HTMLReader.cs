using HW2.MenuOut;
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
            catch (InvalidOperationException ex)
            {
                MenuOutput.PrintInfoException("Wrong URL, try again", ex);
            }
            catch (ArgumentException ex)
            {
                MenuOutput.PrintInfoException("Argument excepton", ex);
            }
            catch (HttpRequestException ex)
            {
                MenuOutput.PrintInfoException("The host of this url is unknown, try again", ex);
            }
            catch (SocketException ex)
            {
                MenuOutput.PrintInfoException("The host of this url is unknown, try again", ex);
            }
            catch (AggregateException ex)
            {
                MenuOutput.PrintInfoException("Wrong URL, try again", ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                MenuOutput.PrintInfoException("Wrong directory, try again", ex);
            }
            catch (FileNotFoundException ex)
            {
                MenuOutput.PrintInfoException("Wrong file, try again", ex);
            }
        }   
    }
}
