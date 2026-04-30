namespace Demo1.Services {
    public class DevelopmentEmailService : IEmailService {
        private string _to;
        private string _from;

        private Guid _id;

        public DevelopmentEmailService() {
            _to = "simon@email.com";
            _from = "api@email.com";

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
