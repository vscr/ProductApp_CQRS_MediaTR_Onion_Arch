using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Application.Wrappers
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public ServiceResponse(T value)
        {
            Data = value;
        }
        public ServiceResponse()
        {
            
        }
    }
}
