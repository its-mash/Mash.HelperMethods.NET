using System;

namespace Mash.HelperMethods.NET
{
    public class Result<T>
    {
        public T ResultObject { get; set; }
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public string ErrorCode { get; set; }

        public static Result<T> GetSucceedObject(T obj, string message = "")
        {
            return new Result<T>
            {
                ResultObject = obj,
                IsValid = true,
                Message = message
            };
        }

        public static Result<T> GetFailedObject(string message, string erroCode = "", T obj = default(T))
        {
            return new Result<T>
            {
                Message = message,
                ErrorCode = erroCode,
                ResultObject = obj,
                IsValid = false
            };
        }

        public static Result<T> GetFailedObject(Exception ex, bool includeStackTrace = false, string erroCode = "", T obj = default(T))
        {
            var message = "";

            if (includeStackTrace)
                message = ex.ToString();
            else
                message = GetAllMessagesFromException(ex);

            return new Result<T>
            {
                Message = message,
                ErrorCode = erroCode,
                ResultObject = obj,
                IsValid = false
            };
        }

        private static string GetAllMessagesFromException(Exception ex)
        {
            var message = ex.Message;

            if (ex.InnerException != null)
                message += Environment.NewLine + GetAllMessagesFromException(ex.InnerException);

            return message;
        }

    }
}
