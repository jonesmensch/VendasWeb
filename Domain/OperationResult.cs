namespace Domain
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

        public static OperationResult CreateSuccess() => new() { Success = true };
        public static OperationResult CreateFail(string message) => new() { Success = false, Message = message };
    }

    public class OperationResult<T> : OperationResult where T : class
    {
        public T? Model { get; set; }

        public static OperationResult<T> CreateSuccess(T model) => new() { Model = model, Success = true };
        public static OperationResult<T> CreateFail(string message) => new() { Message = message, Success = false };
    }
}
