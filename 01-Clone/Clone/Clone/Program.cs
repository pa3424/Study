using Clone;
using static System.Console;

Person p1 = new Person();
p1.Age = 32;
p1.Name = "Sam";
p1.IdInfo = new IdInfo(0001);

WriteLine("p1 values: ");
DisplayValues(p1);

Person p2 = p1.ShallowCopy();

p2.Age = 42;
p2.Name = "Frank";
p2.IdInfo.Id = 7878;

WriteLine("\nShallow copy");
WriteLine("p1 values: ");
DisplayValues(p1);
WriteLine("p2 values:");
DisplayValues(p2);

Person p3 = p1.DeepCopy();

p3.Name = "George";
p3.Age = 23;
p3.IdInfo.Id = 7117;

WriteLine("\nDeep copy");
WriteLine("p1 values: ");
DisplayValues(p1);
WriteLine("p3 values:");
DisplayValues(p3);

Person p4 = p1.DeepCopyClone();

p4.Name = "YongHyun";
p4.Age = 30;
p4.IdInfo.Id = 3424;

WriteLine("\nDeep copy clone");
WriteLine("p1 values: ");
DisplayValues(p1);
WriteLine("p4 values:");
DisplayValues(p4);

void DisplayValues(Person p) => WriteLine($"Name: {p.Name,-6} Age: {p.Age,-2} Id: {p.IdInfo.Id,-4}");


public class Person : ICloneable
{
    public int Age { get; set; }
    public string Name { get; set; }
    public IdInfo IdInfo { get; set; }

    public Person ShallowCopy()
    {
        return (Person)this.MemberwiseClone();
    }

    public Person DeepCopy()
    {
        Person other = (Person)this.MemberwiseClone();
        other.IdInfo = new IdInfo(IdInfo.Id);
        other.Age = Age;
        other.Name = Name;
        return other;
    }

    public Person DeepCopyClone() => new Person
    {
        IdInfo = new IdInfo(IdInfo.Id),
        Age = Age,
        Name = Name,
    };

    public object Clone() => this.GetClone();
}

public class IdInfo
{
    public int Id { get; set; }
    public IdInfo(int id) => Id = id;
}