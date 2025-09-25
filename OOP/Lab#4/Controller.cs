using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

public class Controller
{
    private BoxOfCandy<Candy> boxik { get; set; }

    public BoxOfCandy<Candy> getList()
    {
        return boxik;
    }

    public Controller(BoxOfCandy<Candy> boxik)
    {
        this.boxik = boxik;
    }

    public void sortCandy()
    {
        this.boxik.list.Sort((a, b)=>a.weight.CompareTo(b.weight));
    }

    public void searchCandy(int leftBorder, int rightBorder)
    {
        foreach(var item in this.boxik.list)
        {
            if(item.percentOfSugar>=leftBorder && item.percentOfSugar<=rightBorder)
            {
                Console.WriteLine(item);
            }
        }
    }

    public void readFromFile(string fileName)
    {
        while (true) {
            string[] lines = File.ReadAllLines(fileName);
            foreach (string str in lines)
            {
                string[] stroke = str.Split('|');
                Candy temp = new Candy(stroke[0], int.Parse(stroke[1]), int.Parse(stroke[2]));
                boxik.add(temp);
            }
            break;
        }
    }

    public void InitWithJson(string path)
    {
        string json = File.ReadAllText(path);
        this.boxik.list = JsonConvert.DeserializeObject<List<Candy>>(json);
    }

}
