using System;
using System.Net;
using ProtoBuf;

[Serializable]
[ProtoContract]
[ProtoInclude(100, typeof(Candy))]
public abstract class Confectionery
{

    [ProtoMember(1)]public string Name { get; set; }
    [NonSerialized]
    [ProtoIgnore]
    public int percentOfSugar;
    [ProtoMember(2)] public int weight {  get; set; }

    public Confectionery(string name, int percentOfSugar, int weight)
    {
        Name = name;
        this.percentOfSugar = percentOfSugar;
        this.weight = weight;
    }

    protected Confectionery() { }

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