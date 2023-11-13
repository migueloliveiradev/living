using FluentValidation.Results;
using System.Text.Json.Serialization;

namespace Living.Domain.Base;
public partial class BaseResponse<T> : IBaseResponse
{
    public BaseResponse(T data, StatusCodes statusCode)
    {
        StatusCode = statusCode;
        Data = data;
    }

    public BaseResponse(T data)
    {
        StatusCode = StatusCodes.OK;
        Data = data;
    }

    public BaseResponse(Dictionary<string, string> erros)
    {
        StatusCode = StatusCodes.UnprocessableEntity;
        Erros = erros;
    }

    public StatusCodes StatusCode { get; set; }
    public T? Data { get; set; }

    [JsonInclude]
    public Dictionary<string, string> Erros = new();
}
public partial class BaseResponse : IBaseResponse
{
    public BaseResponse(Dictionary<string, string> erros)
    {
        StatusCode = StatusCodes.UnprocessableEntity;
        Erros = erros;
    }

    public StatusCodes StatusCode { get; set; }

    [JsonInclude]
    public Dictionary<string, string> Erros = new();
}
