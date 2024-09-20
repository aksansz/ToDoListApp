using OpenAI.ObjectModels.RequestModels;

namespace ToDoListApp.Models
{
    public class AiRequest
    {
        public List<ChatMessage> Messages { get; set; } = new List<ChatMessage>();
        public string Model { get; set; } = OpenAI.ObjectModels.Models.Gpt_3_5_Turbo;
    }
}