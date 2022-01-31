using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CV19ConsoleApp
{
    internal class Program
    {
        private const string data_url = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";


        // считуем поток текстовых данных / формирует поток дынных
        private static async Task<Stream> GetDataStream()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(data_url, HttpCompletionOption.ResponseHeadersRead);
            return await response.Content.ReadAsStreamAsync();
        }

        //разбиение на строки 
        private static IEnumerable<string> GetDataLines()
        {
            using var data_stream = GetDataStream().Result;
            using var data_reader = new StreamReader(data_stream);
            while (!data_reader.EndOfStream)
            {
                var line = data_reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;
                yield return line.Replace("Bonaire,", "Bonaire -").Replace("Korea,", "Korea -");
            }
        }

        // пулучаем все даты по которым будут разбиты данные
        private static DateTime[] GetDatas() => GetDataLines()
            .First()    // берем первую строку
            .Split(',') // разделитель по запятой получаем массив строк каждый с которых содержит зоголовок каждой колоныки данных csv файла
            .Skip(4)    //отбросить первые 4 потому что там находятся названия провинции, название страны,  широта и долгота этой странны
            .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture))
            .ToArray();

        private static IEnumerable<(string County,string Province,int[] Counts)> GetData()
        {
            var lines = GetDataLines()
                .Skip(1)
                .Select(line => line.Split(','));
            foreach (var row in lines)
            {
                var province = row[0].Trim();
                var country_name = row[1].Trim(' ','"');
                var counts = row.Skip(4).Select(int.Parse).ToArray();
                yield return (country_name, province, counts);
            }

        }

        static void Main(string[] args)
        {
            //WebClient webClient = new WebClient();

            //foreach (var data_line in GetDataLines())
            //{
            //    Console.WriteLine(data_line);
            //}


            //HttpClient client = new HttpClient();
            //var resp = client.GetAsync(data_url).Result;
            //var csv_str=resp.Content.ReadAsStringAsync().Result;

            //var dates = GetDatas();// полученно только первую строку с csv файла остальные даже скачиваться не начали
            //Console.WriteLine(string.Join("\r\n", dates));
            var russia_data = GetData().First(v => v.County.Equals("Russia", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(string.Join("\r\n", GetDatas().Zip(russia_data.Counts, (date, count) => $"{date:dd:MM} - {count}")));
         
            Console.ReadLine();
        }
    }
}
