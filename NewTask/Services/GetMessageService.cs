namespace NewTask.Services
{
    public class GetMessageService : IGetMessageService
    {               
        public string GetName(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Please enter your name!");
        }
    }
}