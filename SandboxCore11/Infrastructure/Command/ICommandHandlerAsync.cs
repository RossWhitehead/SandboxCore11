using System.Threading.Tasks;

namespace SandboxCore11.Infrastructure.Command
{
    public interface ICommandHandlerAsync<T> where T : ICommand
    {
        Task<CommandResult> HandleAsync(T command);
    }
}
