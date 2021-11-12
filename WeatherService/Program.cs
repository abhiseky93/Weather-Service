using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using WeatherService.Model;

namespace WeatherService
{
   public class Program
    {
       public static void Main(string[] args)
        {
            /// The weather service will receive a daily file that contains a list of cities. 
            /// For each city in the file we need to retrieve the weather information from the Open WeatherRESTful web service.
            /// Results will need to be stored in the outputfolder, so that each file only holds the information for each city for today’s date.
            /// We need to establish historic information, so file naming should cater for it.
            Console.Title = "Weather Service";
            #region START
            string inputFolder = @"D:\DEVELOPMENT\M&G\Data\Input";
            string outputFolder = @"D:\DEVELOPMENT\M&G\Data\Output";
            fetchDataFromFile(inputFolder, outputFolder);
            #endregion START

            Console.ReadLine();
        }

        public static void GetWeather(string cityName, string outputFolderPath, Int64 countryCode,string fileName,string optionWether)
        {
            try
            {
                string weatherData = string.Empty;
                // Create a new WebClient instance.
                WebClient client = new WebClient();
                if (optionWether == "CITYCODE")
                {
                    // If City Name is blank then data will be fetched based on country code
                    // Download the weather data.
                    weatherData = client.DownloadString(
                    string.Format("http://api.openweathermap.org/data/2.5/weather?id=" + countryCode + "&units=metric&appid=aa69195559bd4f88d79f9aadeb77a8f6"));

                    // For Json components used 
                    // Deserialize the JSON data Newtonsoft.Json.13.0.1
                    Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(weatherData);
                    // WeatherData weather = JsonConvert.DeserializeObject<WeatherData>(weatherData);
                    // Write the data to a file.
                    if (myDeserializedClass.cod == 200)
                        File.WriteAllText(Path.Combine(outputFolderPath, string.Format("{0}", Path.GetFileNameWithoutExtension(fileName) + "_" + myDeserializedClass.id) + "_.txt"), weatherData);
                    else
                        File.WriteAllText(Path.Combine(outputFolderPath, string.Format("{0}", Path.GetFileNameWithoutExtension(fileName) + "_" + countryCode) + "_.txt"), weatherData);
                }
                else
                {
                    // If City Name is not blank then data will be fetched based on country name
                    weatherData = client.DownloadString(
                    string.Format("http://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&appid=aa69195559bd4f88d79f9aadeb77a8f6"));

                    // For Json components used 
                    // Deserialize the JSON data Newtonsoft.Json.13.0.1
                    Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(weatherData);
                    // WeatherData weather = JsonConvert.DeserializeObject<WeatherData>(weatherData);
                    // Write the data to a file.
                    if (myDeserializedClass.cod == 200)
                        File.WriteAllText(Path.Combine(outputFolderPath, string.Format("{0}", Path.GetFileNameWithoutExtension(fileName) + "_" + myDeserializedClass.name) + "_.txt"), weatherData);
                    else
                        File.WriteAllText(Path.Combine(outputFolderPath, string.Format("{0}", Path.GetFileNameWithoutExtension(fileName) + "_" + cityName) + "_.txt"), weatherData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void readData(string inputPath,string outputFolder)
        {
            try
            {
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string[] words = fileName.Split('_');

                string[] lines = System.IO.File.ReadAllLines(inputPath);
                foreach (string line in lines)
                {
                    if (words[0] == "CITYCODE")
                    {
                        Console.WriteLine("Fetch Data using City code : " + line);
                        GetWeather("", outputFolder, Convert.ToInt64(line), fileName, words[0]);
                    }
                    else
                    {
                        Console.WriteLine("Fetch Data using City name : " + line);
                        GetWeather(line, outputFolder, 0, fileName, words[0]);
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void fetchDataFromFile(string inputFolder,string outputFolder)
        {
            try
            {
                if (!Directory.Exists(inputFolder))
                {
                    Directory.CreateDirectory(inputFolder);
                }
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }
                string[] files = Directory.GetFiles(inputFolder);
                foreach (string file in files)
                {
                    Console.WriteLine("Fetch file from input Folder : " + file);
                    readData(file, outputFolder);
                }
                Console.WriteLine("PROCESS COMPLETED");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}