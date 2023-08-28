namespace FiapStore.Logging
{
    public class CustomLogger : ILogger
    {
        private readonly string _loggerName;
        private readonly CustomLoggerProviderConfiguration _providerConfiguration;

        private readonly string _logFilePath = @"D:\Projetos pos tech\FiapStore\FiapStore\bin";

        public CustomLogger(string name, CustomLoggerProviderConfiguration configuration)
        {
            _loggerName = name;
            _providerConfiguration = configuration;
        }

        public IDisposable BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var message = string.Format($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] - {logLevel}: {eventId} - {formatter(state, exception)}");

            WriteLogOnFile(message);
        }

        private void WriteLogOnFile(string message)
        {
            var todayFileLog = @$"{_logFilePath}\LOG-{DateTime.Now:yyyy-MM-dd}.txt";

            if (!File.Exists(todayFileLog))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(todayFileLog));
                File.Create(todayFileLog).Dispose();
            }

            using StreamWriter streamWriter = new StreamWriter(todayFileLog, true);
            streamWriter.WriteLine(message);
            streamWriter.Close();
        }
    }
}
