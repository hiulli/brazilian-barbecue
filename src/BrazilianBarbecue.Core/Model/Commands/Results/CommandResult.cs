namespace BrazilianBarbecue.Core.Entities.Model.Result
{
    public class CommandResult
    {
        public CommandResult(string message, bool success, object data)
        {
            Message = message;
            Success = success;
            Data = data;
        }

        public string Message { get; private set; }
        public bool Success { get; private set; }
        public object Data { get; private set; }
    }
}
