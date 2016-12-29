using Serilog;
using Serilog.Core;
using Serilog.Exceptions;
using Serilog.Formatting.Json;
using Serilog.Sinks.RollingFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NobetciEczane_IEO
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                InitLog();

                ServicePointManager.DefaultConnectionLimit = 100;

                Console.WriteLine("Nöbetçi eczane programı başladı.");
                var startDate = DateTime.Now;
                var endDate = DateTime.Now.AddDays(int.Parse(NCZParameters.Parameters["dayCount"]));

                Console.WriteLine("Nöbetçi eczaneler servisten okunuyor...");
                var eczane = new NCZEczane();


                var nobetciler = eczane.GetNobetciEczane(startDate, endDate, null);


                ToHTML(nobetciler);

                Console.WriteLine("Tamamlandı");

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Hata");
            }
        }


        static void SaveHTML(string html)
        {
            string path = System.IO.Path.Combine(NCZParameters.Parameters["htmlOutputPath"], "NobetciEczanRaporu.html");
            if (!File.Exists(path))
                File.Create(path).Dispose();


            File.WriteAllText(path, String.Empty);


            StreamWriter file2 = new StreamWriter(path, true);
            file2.WriteLine(html);
            file2.Close();
        }

        static string ToHTML(NCZNobetciEczaneCollection eczaneler)
        {
            var html = new StringBuilder();
            var innerHTML = eczaneler.Where(e => e.isFind == false)?.Select(i => new { innerHTML = i.ToHTML() });

            html.Append("<html>");
            html.Append("<body>");
            html.Append("<table border=1>");
            html.Append("<tr>");
            html.Append("<th>Id</th>");
            html.Append("<th>Eczane Adı</th>");
            html.Append("<th>Eczacı Adı</th>");
            html.Append("<th>Telefon</th>");
            html.Append("<th>Nöbet Tarihi</th>");
            html.Append("<th>Adres</th>");
            html.Append("</tr>");
            


            foreach (var item in innerHTML)
                html.Append(item.innerHTML);


            html.Append("</table>");
            html.Append("</body>");
            html.Append("</html>");

            return html.ToString();
        }

        static void InitLog()
        {
            string assemblyFolder = AppDomain.CurrentDomain.BaseDirectory;

            var levelSwitch = new LoggingLevelSwitch();

            Log.Logger = new LoggerConfiguration()
               .Enrich.WithExceptionDetails()
               //.Enrich.WithProperty("version", fvi.FileVersion)
               .WriteTo.Sink(new RollingFileSink(assemblyFolder + "\\logs\\log-{Date}.txt", new JsonFormatter(renderMessage: true), 2097152, 10, Encoding.UTF8))
               //.WriteTo.Seq("http://localhost:5341", apiKey: "flFGmmRau09ZVBnMJ62q", controlLevelSwitch: levelSwitch)
               .CreateLogger();
        }
    }



}
