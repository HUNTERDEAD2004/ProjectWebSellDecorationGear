using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DecorGearApplication.DataTransferObj.User
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }

        public ResponseDto()
        {
            Data = default;
            Status = StatusCodes.Status200OK; // Mặc định là 200 OK
            Message = "Success"; // Thông điệp mặc định
        }

        public ResponseDto(int status, string message, T data = default)
        {
            Status = status;
            Message = message;
            Data = data;
        }
    }
}
