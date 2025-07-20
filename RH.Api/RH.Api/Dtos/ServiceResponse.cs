namespace RH.Api.Dtos
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;

        public ServiceResponse() { }

        public ServiceResponse(T? data, string message = "")
        {
            Data = data;
            Message = message;
        }
    }

}
