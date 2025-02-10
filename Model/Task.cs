using SQLite;

public class Task
{
    [PrimaryKey, AutoIncrement] 
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public bool IsCompleted { get; set; }

    public Task() { }

    public Task(int id, string name, bool isCompleted)
    {
        Id = id;
        Name = name;
        IsCompleted = isCompleted;
    }
}