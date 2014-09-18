using System;

namespace JST.Domain
{
    public class Exception
    {
        public Exception(int exceptionId, string message, string stackTrace, DateTime dateTime)
        {
            ExceptionId = exceptionId;
            Message = message;
            StackTrace = stackTrace;
            DateTime = dateTime;
        }
    
        public int ExceptionId { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime DateTime { get; set; }
    }
}