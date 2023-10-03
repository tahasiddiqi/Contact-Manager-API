﻿namespace Contact_Manager.Model
{
    public class ApiResponse
    {
        public string Code { get; set; }
        public object? ResponseData { get; set; }
        public string Message { get; set; }
    }

    public enum ResponseType
    {
        Success,
        NotFound,
        Failure
    }
}
