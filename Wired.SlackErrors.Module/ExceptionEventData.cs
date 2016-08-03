using System;

namespace Wired.SlackErrors.Module
{
    internal class ExceptionEventData
    {
        private Exception Exception { get; }

        public string ExceptionType => Exception.GetType().FullName;
        public string EventTitle => Exception.Message;
        public string EventBody => Exception.StackTrace;

        public ExceptionEventData(Exception exception)
        {
            Exception = exception;
        }

        public override string ToString()
        {
            return $"{Exception.Message}\n\n{Exception.StackTrace}";
        }
    }
}