namespace AAXHash
{
    using System;
    using Newtonsoft.Json;
    using System.Net;
    using System.Text;
    public class Data
    {
        public void Reverse(string file) { GB(Solve.Hash(file)); }
        public string bytes { get; set; }
        private string GB(string chk)
        {
            try
            {
                this.bytes = Solve.Checksum(chk);
                return this.bytes;
            }
            catch
            {
                return String.Empty;
            }
        }
    }
    class Solve
    {
        internal static string Hash(string file)
        {
            try
            {
                using (var fs = System.IO.File.OpenRead(file))
                using (var br = new BinaryReader(fs))
                {
                    fs.Position = 0x251 + 56 + 4;
                    var checksum = br.ReadBytes(20);
                    return bytes(checksum);
                }
            }
            catch (Exception ex)
            {
                Alert.Error("Error calculating Hash: "+ ex.Message);
            }
            return String.Empty;
        }
        internal static string bytes(byte[] bt)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bt)
                    sb.Append(b.ToString("X2"));

                string hexString = sb.ToString();
                return hexString;
            }
            catch (Exception ex)
            {
                Alert.Error("Converting Hash to Hex: "+ex.Message);
                return String.Empty;
            }
        }
        internal static string Checksum(string checksum)
        {
            WebClient client = new WebClient();
            string rest = client.DownloadString($@"https://aax.api.j-kit.me/api/v2/activation/{checksum.Trim()}");
            Response rpns = JsonConvert.DeserializeObject<Response>(rest);

            if (rpns.success == true)
            {
                return rpns.activationBytes.Trim();
            }
            else
            {
                Alert.Error(rpns.message);
                return String.Empty;
            }
        }
    }
    public class Response
    {
        public bool success { get; set; }
        public string message { get; set; }
        public string checksum { get; set; }
        public string activationBytes { get; set; }
    }
class Alert
    {
        internal static void Notify(string alert)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("  [");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(alert);
            Console.ResetColor();
            Console.WriteLine("]");
            Console.OutputEncoding = Encoding.Default;
        }
        internal static void Error(string alert)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("  [Error: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(alert);
            Console.ResetColor();
            Console.WriteLine("]");
            Console.OutputEncoding = Encoding.Default;
        }
        internal static void Success(string alert)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("  [");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(alert);
            Console.ResetColor();
            Console.WriteLine("]");
            Console.OutputEncoding = Encoding.Default;
        }
    }
}