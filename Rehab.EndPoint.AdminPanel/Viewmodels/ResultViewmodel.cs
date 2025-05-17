namespace Rehab.EndPoint.AdminPanel.Viewmodels
{
    public class ResultViewmodel<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public ResultViewmodel() { }

        public ResultViewmodel(T data, string message, bool success, string status)
        {
            Data = data;
            Success = success;
            Message = message;
            Status = status;
        }
    }
}
