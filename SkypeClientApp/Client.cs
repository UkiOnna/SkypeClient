using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SkypeClientApp
{
    public class Client
    {
        public async Task<bool> Working(TcpClient client, string path)
        {

            await client.ConnectAsync(IPAddress.Parse("127.0.0.1"), 3535);
            using (var networkStream = client.GetStream())
            {
                //while (true)
                // {

                if (path == "4")
                {
                    client.Close();
                    return false;
                    //break;
                }
                else
                {
                    FileInfo file = new FileInfo(path);
                    FileInfoo filee = new FileInfoo();
                    filee.Extension = file.Extension;
                    filee.fileName = file.Name;
                    filee.Bytes = File.ReadAllBytes(path);
                    string serialized = JsonConvert.SerializeObject(filee);
                    var buffer = Encoding.Default.GetBytes(serialized);
                    await networkStream.WriteAsync(buffer, 0, buffer.Length);
                    return true;
                }
                // }
            }
            return false;
        }
    }
}
