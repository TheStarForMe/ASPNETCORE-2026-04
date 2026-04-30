namespace Demo1.Services {
    public class DevelopmentEmailService : IEmailService {
        private IConfiguration _config;
        private string _to;
        private string _from;

        private Guid _id;

        public DevelopmentEmailService(IConfiguration config) {
            _config = config ?? throw new ArgumentNullException(nameof(config));

            _to = _config["mail:to"] ?? throw new ArgumentNullException("mail:to");
            _from = _config["mail:from"] ?? throw new ArgumentNullException("mail:from");

            _id = Guid.NewGuid();
        }

        public void Send(string subject, string message) {
            Console.WriteLine("------------------------------");
            Console.WriteLine($"To: {_to}");
            Console.WriteLine($"From: {_from}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
            Console.WriteLine($"** ID **: {_id}");
            Console.WriteLine("------------------------------");
        }
    }
}
