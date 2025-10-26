namespace Services.Tax.Domain.Api
{
    public record GeneralResponse<T>
    {
        public T? Data { get; init; }
        public bool Success { get; init; } = true;
        public int StatusCode { get; init; }
        public List<string> Errors { get; init; } = new();

        public static GeneralResponse<T> SuccessResponse(T data, int statusCode = 200)
            => new() { Success = true, Data = data, StatusCode = statusCode };

        public static GeneralResponse<T> FailResponse(List<string> errors, int statusCode = 400)
            => new() { Success = false, Errors = errors, StatusCode = statusCode };

        public static GeneralResponse<T> FailResponse(string error, int statusCode = 400)
            => FailResponse(new List<string> { error }, statusCode);
    }
}
