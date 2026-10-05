namespace week02.code;

public class PersonQueue
{
    private readonly List<Person> _people = new();

    public int Length => _people.Count;

    public void Enqueue(Person person)
    {
        _people.Add(person);
    }

    public Person Dequeue()
    {
        if (_people.Count == 0)
            throw new InvalidOperationException("Queue is empty");
        
        var person = _people[0];
        _people.RemoveAt(0);
        return person;
    }

    public bool IsEmpty()
    {
        return _people.Count == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _people)}]";
    }
}
