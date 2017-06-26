namespace SandboxCore11.Infrastructure.Command
{
    public class CommandResult
    {
        public CommandResult(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
        }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
