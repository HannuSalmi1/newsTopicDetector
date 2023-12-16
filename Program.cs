
using ConsoleApp2;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Text.Json.Nodes;

Console.WriteLine("----------------------NEWS TOPIC DETECTOR-----------------------");
Console.WriteLine("*************************turbo edition**************************");
Console.WriteLine();

List<string> titleList = new List<string> { };

string filePath = "C:\\Users\\Omistaja\\response.json";


try
{
    string json = File.ReadAllText(filePath);
    dynamic jsonObj = JsonConvert.DeserializeObject(json);

    if (jsonObj != null)
    {
       //Console.WriteLine(jsonObj.results.GetType());
        foreach (JObject jsonObject in jsonObj.results)
        {
            if (jsonObject.ContainsKey("title"))
            {
                
                titleList.Add(jsonObject["title"].ToString());

            }

            else
            {
                Console.WriteLine("object is NULL");
            }
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
foreach(string title in titleList)
{
   


var input = new MLModel1.ModelInput
{
    Title = title

};

var output = MLModel1.Predict(input);
Console.WriteLine(input.Title);
Console.WriteLine("TOPIC:    " + output.PredictedLabel);
    Console.WriteLine();
}
