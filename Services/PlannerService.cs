using OpenAI.Interfaces;
using OpenAI.ObjectModels.RequestModels;
using ToDoListApp.Interfaces;
using ToDoListApp.Models;

namespace ToDoListApp.Services
{
    public class PlannerService : IPlannerService
    {
        private readonly IOpenAIService openAIService;

        public PlannerService(IOpenAIService _openAIService)
        {
            openAIService = _openAIService;
        }

        public async Task<AiResponse> GenerateSubtasks(AiRequest request)
        {
            var chatRequest = new ChatCompletionCreateRequest
            {
                Messages = request.Messages,
                Model = request.Model
            };

            var result = await openAIService.ChatCompletion.CreateCompletion(chatRequest);
            if(result.Successful)
            {
                return new AiResponse
                {
                    Successful = true,
                    Content = result.Choices.First().Message.Content
                };
            }
            return new AiResponse
            {
                Successful = false,
                Content = "Failed to generate subtask"
            };
        }
    }
}