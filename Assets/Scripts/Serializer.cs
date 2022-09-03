using System.IO;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public static class Serializer
{
    public static DataForSave GameData = new DataForSave();
    private static string path = Application.persistentDataPath + "savefile.xml";

    public static void SaveData()
    {
        XElement BestScore = new XElement("BestScore");

        XElement Root = new XElement("Root");

        BestScore.Add(GameData.BestScore);
        Root.Add(BestScore);

        XDocument DataDocument = new XDocument(Root);

        File.WriteAllText(path, DataDocument.ToString());
    }

    private static void FeelXElement(ref XElement xElementToFeel, IEnumerable<int> thingsThatFeel)
    {
        foreach (int boughtThingsNumber in thingsThatFeel)
        {
            XElement Instance = new XElement("Instance");
            Instance.Add(boughtThingsNumber);
            xElementToFeel.Add(Instance);
        }
    }

    public static void GetData()
    {
        retry:
        if (File.Exists(path))
        {
            XElement Root = new XElement("Root");
            Root = XDocument.Parse(File.ReadAllText(path)).Element("Root");

            GameData.BestScore = int.Parse(Root.Element("BestScore").Value);
        }
        else
        {
            SaveData(); //Создаем файл с начальными данными и сохраняем его
            goto retry;
        }
    }
}
