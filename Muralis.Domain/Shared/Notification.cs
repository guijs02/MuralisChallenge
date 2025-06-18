namespace Muralis.Domain.Shared
{
    public class NotificationErrorProps(string context, string message)
    {
        public string Context { get; set; } = context;
        public string Message { get; set; } = message;
    }

    public class Notification
    {
        private List<NotificationErrorProps> Errors = [];

        public void AddErro(string context, string message)
        {
            Errors.Add(new NotificationErrorProps(context, message));
        }

        public string ObterMensagens(string? context)
        {
            string messages = string.Empty;

            Errors.ForEach(e =>
            {
                if (e.Context == context || context == null)
                {
                    messages += $"{e.Context}: {e.Message}, ";
                }
            });

            return messages;
        }
        public bool PossuiErros()
            => Errors.Count != 0;
    }
}
