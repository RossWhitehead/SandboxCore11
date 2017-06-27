namespace SandboxCore11.Infrastructure.Command
{
    using System.Threading.Tasks;

    public interface ICommandHandlerAsync<T> 
        where T : ICommand
    {
        Task<CommandResult> HandleAsync(T command);
    }
}
