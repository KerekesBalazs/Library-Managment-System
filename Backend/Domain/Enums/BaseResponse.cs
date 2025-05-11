

namespace WebAPI.Controllers
{
    public class BaseResponse<T>
    {
        public T? Data { get; set; }
        public string Type { get; set; } = null!;
        public string Message { get; set; } = null!;

        public BaseResponse()
        {

        }

        public BaseResponse(T? data, string responseType)
        {
            Data = data;
            Type = responseType;
        }

        public BaseResponse(string responseType, string message)
        {
            Type = responseType;
            Message = message;
        }
    }
}