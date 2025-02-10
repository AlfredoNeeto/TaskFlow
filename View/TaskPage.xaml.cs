namespace TaskFlow.Views;

public partial class TaskPage : ContentPage
{
    private readonly TaskViewModel _task;
    public TaskPage(TaskViewModel taskView)
    {

        InitializeComponent();
        _task = taskView;
        BindingContext = _task;
    }
}
