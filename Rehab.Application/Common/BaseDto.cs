using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Common
{
    public class BaseDto<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;

        public BaseDto() { }

        public BaseDto(T data, bool success, string message)    
        {
            Data = data;
            Success = success;
            Message = message;
        }

        public static BaseDto<T> SuccessResult(T data, string message)
        {
            return new BaseDto<T>(data, true, message);
        }

        public static BaseDto<T> FailureResult(string message) { return new BaseDto<T>(default!, false, message); }

    }
}
