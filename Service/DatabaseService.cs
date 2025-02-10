using SQLite;

namespace TaskFlow;

public class DatabaseService : IDatabaseService
{
    private readonly SQLiteConnection _database;

    public DatabaseService()
    {
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "tasks.db");
        _database = new SQLiteConnection(dbPath);
        _database.CreateTable<Task>(); 
    }
    public void SaveTask(Task task) => _database.Insert(task);
    public void DeleteTask(int id) =>  _database.Delete<Task>(id);
    public List<Task> GetTasks() => _database.Table<Task>().ToList();
    public void UpdateTask(Task task) =>  _database.Update(task);

}
