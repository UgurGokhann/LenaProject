﻿namespace LenaProject.DataAccess.Response
{
    public interface IResponse
    {
        string Message { get; set; }
        ResponseType ResponseType { get; set; }
    }
}
