using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Plant
{
    public string placeOfLive;
    private string name;
    private int hight;

    public Plant(string placeOfLive, string name, int hight)
    {
        this.placeOfLive = placeOfLive;
        this.name = name;
        this.hight = hight;
    }

    public string getPlaceOfLive()
    {
        return this.placeOfLive;
    }

    public string getName() { 
        return this.name;
    }

    public int getHight() { 
        return this.hight;
    }

    public override string ToString()
    {
        return $"{this.name}: grow up in: {this.placeOfLive}, hight: {this.hight}sm";
    }
}