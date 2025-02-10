using System.Collections.Generic;

namespace TaskFlow;

public interface IDatabaseService
{
    void SaveTask(Task task);
    void DeleteTask(int id);
    List<Task> GetTasks();
    void UpdateTask(Task task);
}
