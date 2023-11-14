using System.Text.Json.Serialization;

namespace Living.Domain.Base;
public class BaseResponse<T> : IBaseResponse
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

    
    public BaseResponse()
    {
    }

    public StatusCodes StatusCode { get; set; }
    public T? Data { get; set; }

    [JsonInclude]
    public Dictionary<string, string> Erros = new();
}