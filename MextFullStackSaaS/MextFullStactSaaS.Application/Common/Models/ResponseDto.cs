﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaaS.Application.Common.Models
{
    public class ResponseDto<T>
    {
        public ResponseDto(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = new();
            Data = data;
        }
        
        public ResponseDto(T data,string message)
        {
            Succeeded = true;
            Message = message;
            Errors = new();
            Data = data;
        }
        public ResponseDto(string message, List<ErrorDto> errors)
        {
            Succeeded = false;
            Message = message;
            Errors = errors;
            Data = default;
        } 
        public ResponseDto(string message, bool succeded)
        {
            Succeeded = succeded;
            Message = message;
            Errors = new();
            Data = default;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<ErrorDto> Errors { get; set; }
        public T Data { get; set; }
    }
}