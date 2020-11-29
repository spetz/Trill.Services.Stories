using System;
using System.Collections.Concurrent;
using System.Net;
using Convey.WebApi.Exceptions;
using Trill.Services.Stories.Application.Exceptions;
using Trill.Services.Stories.Core.Exceptions;

namespace Trill.Services.Stories.Infrastructure.Exceptions
{
    public class ExceptionToResponseMapper : IExceptionToResponseMapper
    {
        private static readonly ConcurrentDictionary<Type, string> Codes = new ConcurrentDictionary<Type, string>();

        public ExceptionResponse Map(Exception exception)
            => exception switch
            {
                DomainException ex => new ExceptionResponse(new {code = GetCode(ex), reason = ex.Message},
                    HttpStatusCode.BadRequest),
                AppException ex => new ExceptionResponse(new {code = GetCode(ex), reason = ex.Message},
                    HttpStatusCode.BadRequest),
                _ => new ExceptionResponse(new {code = "error", reason = "There was an error."},
                    HttpStatusCode.BadRequest)
            };

        private static string GetCode(Exception exception)
        {
            var type = exception.GetType();
            if (Codes.TryGetValue(type, out var code))
            {
                return code;
            }

            var exceptionCode = exception.GetExceptionCode();
            Codes.TryAdd(type, exceptionCode);

            return exceptionCode;
        }
    }
}