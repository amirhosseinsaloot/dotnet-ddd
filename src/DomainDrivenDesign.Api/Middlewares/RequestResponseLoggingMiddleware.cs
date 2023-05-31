using Microsoft.IO;

namespace DomainDrivenDesign.Api.Middlewares;

public sealed class RequestResponseLoggingMiddleware
{
    private readonly ILogger<RequestResponseLoggingMiddleware> _logger;
    private readonly RequestDelegate _next;
    private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;

    public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
        _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
    }

    public async Task Invoke(HttpContext context)
    {
        await LogRequest(context);
        await LogResponse(context);
    }

    private async Task LogRequest(HttpContext context)
    {
        context.Request.EnableBuffering();

        await using var requestStream = _recyclableMemoryStreamManager.GetStream();
        await context.Request.Body.CopyToAsync(requestStream);
        _logger.LogInformation($"{context.Request.Method} {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString} | {ReadStreamInChunks(requestStream)} | RemoteIpAddress: {context.Connection.RemoteIpAddress}");
        context.Request.Body.Position = 0;
    }

    private static string ReadStreamInChunks(Stream stream)
    {
        const int readChunkBufferLength = 4096;

        stream.Seek(0, SeekOrigin.Begin);

        using var textWriter = new StringWriter();
        using var reader = new StreamReader(stream);

        var readChunk = new char[readChunkBufferLength];
        int readChunkLength;

        do
        {
            readChunkLength = reader.ReadBlock(readChunk, 0, readChunkBufferLength);
            textWriter.Write(readChunk, 0, readChunkLength);
        } while (readChunkLength > 0);

        return textWriter.ToString();
    }

    private async Task LogResponse(HttpContext context)
    {
        await _next(context);
        _logger.LogDebug($"{context.Request.Method} {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString} : {context.Response.StatusCode} " + "\n");
    }

}
