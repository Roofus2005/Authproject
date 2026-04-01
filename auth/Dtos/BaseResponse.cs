namespace auth.Dtos
{
    public class BaseResponse<T>
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public static BaseResponse<T> Success(T data, string message = "Success") =>
             new BaseResponse<T> { Status = true, Data = data, Message = message };

        public static BaseResponse<T> Failure(string message) =>
            new BaseResponse<T> { Status = false, Data = default!, Message = message };
    }
}
