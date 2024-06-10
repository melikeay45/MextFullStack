using MextFullStactSaaS.Application.Common.Models.OpenAI;

namespace MextFullStactSaaS.Application.Common.Interfaces
{
    public interface IOpenAIService
    {
        Task<List<string>> DallECreateIconAsync(DallECreateIconRequestDto requestDto, CancellationToken cancellationToken);
    }
}
