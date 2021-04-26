using System;

namespace Saiive.SuperNode.Client
{
    public class ApiException : Exception
    {
        public int ErrorCode { get; }
        public string Content { get; }

        public ApiException(int errorCode, string message, string content="") : base(message)
        {
            ErrorCode = errorCode;
            Content = content;
        }
    }
}
