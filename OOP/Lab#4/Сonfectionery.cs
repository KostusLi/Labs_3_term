using System;
using System.Net;


public abstract class Confectionery
{

    public string Name { get; set; }
    public int percentOfSugar { get; set; }
    public int weight {  get; set; }

    public Confectionery(string name, int percentOfSugar, int weight)
    {
        Name = name;
        this.percentOfSugar = percentOfSugar;
        this.weight = weight;
    }

    public override string ToString()
    {
        return Name+ '|' + percentOfSugar +'|'+weight;
    }
    public abstract void buyProduct();
}

public interface IEdible
{
    void eat();
}

struct SweetCandy
{
    public string name;
    public string recipe;
    public int id;
    public string status;

    public SweetCandy(string name, string recipe, int id, string status)
    {
        this.name = name;
        this.recipe = recipe;
        this.id = id;
        this.status = status;
    }

    public override string ToString()
    {
        return this.name+'|'+this.recipe+'|'+this.id+'|'+this.status;
    }
}

enum Status
{
    Sweet = 0,
    Chocolate = 1,
    Caramel = 2,
    Lollipop = 3
}