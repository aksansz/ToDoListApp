using ToDoListApp.Models;

namespace ToDoListApp.Interfaces
{
    public interface IPlannerService
    {
        Task<AiResponse> GenerateSubtasks(AiRequest request);
    }
}