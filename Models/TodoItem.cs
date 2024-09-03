namespace ToDoListApp.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Task { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }
    }
}