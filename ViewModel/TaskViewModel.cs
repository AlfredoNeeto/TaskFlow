using System.Collections.ObjectModel;
using System.Windows.Input;

namespace TaskFlow;

public class TaskViewModel : BindableObject
{
    private readonly IDatabaseService _databaseService;

    public ObservableCollection<Task> Tasks { get; set; } = new ObservableCollection<Task>();
    public ICommand AddTaskCommand { get; }
    public ICommand DeleteTaskCommand { get; }
    public ICommand EditTaskCommand { get; }

    public TaskViewModel()
    {
        _databaseService = new DatabaseService();

        DeleteTaskCommand = new Command<Task>(DeleteTask);
        EditTaskCommand = new Command<Task>(EditTask);
        AddTaskCommand = new Command(AddTask);
        Tasks = new ObservableCollection<Task>(_databaseService.GetTasks());
    }

    private async void AddTask()
    {
        var mainPage = Application.Current?.Windows[0]?.Page;
        if (mainPage != null)
        {
            string taskName = await mainPage.DisplayPromptAsync(
                "Nova Tarefa",
                "Digite o nome da tarefa",
                placeholder: "Nome da tarefa");
            if (!string.IsNullOrEmpty(taskName))
            {
                int newId = Tasks.Any() ? Tasks.Max(t => t.Id) + 1 : 1;

                var newTask = new Task
                {
                    Id = newId,
                    Name = taskName,
                    IsCompleted = false
                };

                Tasks.Add(newTask);
                _databaseService.SaveTask(newTask);
            }
        }
    }

    private void DeleteTask(Task task)
    {
        Tasks.Remove(task);
        _databaseService.DeleteTask(task.Id);
    }

    private async void EditTask(Task task)
    {
        var mainPage = Application.Current?.Windows[0]?.Page;
        if (mainPage != null)
        {
            string newTaskName = await mainPage.DisplayPromptAsync(
                "Editar Tarefa",
                "Digite o novo nome da tarefa:",
                placeholder: "Nome da tarefa",
                initialValue: task.Name);
            if (!string.IsNullOrEmpty(newTaskName) && newTaskName != task.Name)
            {
                task.Name = newTaskName;
                _databaseService.UpdateTask(task);
                var taskIndex = Tasks.IndexOf(task);
                if (taskIndex >= 0)
                {
                    Tasks[taskIndex] = task; // Substitui a tarefa na coleção
                }

                //LoadTasks();
            }
        }
    }

    private void LoadTasks()
    {
        Tasks.Clear();

        var tasksFromDb = _databaseService.GetTasks();

        foreach (var task in tasksFromDb)
        {
            Tasks.Add(task);
        }
    }


}
