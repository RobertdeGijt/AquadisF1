using System;
using System.Web.Http.Results;

namespace AquadisF1.Util
{
    public class SuccessResponse
    {
        public bool Success { get; } = true;
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public class ErrorResponse
    {
        public bool Success { get; } = false;
        public string Error { get; set; }
        public object Data { get; set; }
    }

    public static class BaseResponse
    {
        public static SuccessResponse SuccessResponse(string message, object data, int code)
        {
            return new SuccessResponse { Data = data, Message = message};
        }

        public static ErrorResponse ErrorResponse(string error, object data, int code)
        {
            return new ErrorResponse { Data = data, Error = error };
        }
    }
}
