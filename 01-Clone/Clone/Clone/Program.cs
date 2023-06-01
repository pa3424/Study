using static System.Console;
// See https://aka.ms/new-console-template for more information

Person p1 = new Person();
p1.Age = 32;
p1.Name = "Sam";
p1.IdInfo = new IdInfo(3424);

Person p2 = p1.ShallowCopy();

WriteLine("p1 values: ");
DisplayValues(p1);
WriteLine("p2 values:");
DisplayValues(p2);

p2.Age = 42;
p2.Name = "Frank";
p2.IdInfo.Id = 7878;

WriteLine("\np1 values: ");
DisplayValues(p1);
WriteLine("p2 values:");
DisplayValues(p2);

Person p3 = p1.DeepCopy();

p1.Name = "George";
p1.Age = 23;
p1.IdInfo.Id = 7117;

WriteLine("\np1 values: ");
DisplayValues(p1);
WriteLine("p3 values:");
DisplayValues(p3);

void DisplayValues(Person p) => WriteLine($"Name: {p.Name,-6} Age: {p.Age,-2} Id: {p.IdInfo.Id,-4}");


public class Person
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

    public Person Clone() => new Person
    {
        IdInfo = new IdInfo(IdInfo.Id),
        Age = Age,
        Name = Name,
    };
}

public class IdInfo
{
    public int Id { get; set; }
    public IdInfo(int id) => Id = id;
}