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
                yield return line;
            }
        }

        // пулучаем все даты по которым будут разбиты данные
        private static DateTime[] GetDatas() => GetDataLines()
            .First()    // берем первую строку
            .Split(',') // разделитель по запятой получаем массив строк каждый с которых содержит зоголовок каждой колоныки данных csv файла
            .Skip(4)    //отбросить первые 4 потому что там находятся названия провинции, название страны,  широта и долгота этой странны
            .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture))
            .ToArray();


        static void Main(string[] args)
        {
            //WebClient webClient = new WebClient();

            //foreach (var data_line in GetDataLines())
            //{
            //    Console.WriteLine(data_line);
            //}

            var dates=GetDatas();// полученно только первую строку с csv файла остальные даже скачиваться не начали
            Console.WriteLine(string.Join("\r\n",dates));


            Console.ReadLine();
        }
    }
}
