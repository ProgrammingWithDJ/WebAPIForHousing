using System.Net;
using WebAPIForHousing.Errors;

namespace WebAPIForHousing.Middlewares
{
    public class ExceptionMiddlewares
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddlewares> logger;
        private readonly IHostEnvironment env;

        public ExceptionMiddlewares(RequestDelegate next, ILogger<ExceptionMiddlewares> logger,
            IHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex) 
            {
                ApiErrors response;
                HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
                String message;
                var exceptionType= ex.GetType();

                if(exceptionType == typeof(UnauthorizedAccessException))
                {
                    statusCode= HttpStatusCode.Forbidden;
                    message= "You are not authorize";
                }else 
                {
                    statusCode = HttpStatusCode.InternalServerError;
                    message = "Unknown error occured";
                }

                if (env.IsDevelopment())
                {
                    response = new ApiErrors((int)statusCode, ex.Message, ex.StackTrace.ToString());
                }
                else
                {
                    response = new ApiErrors((int)statusCode, ex.Message, "");
                }

                logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)statusCode;
                context.Response.ContentType = "applicaion/json";
                await context.Response.WriteAsync(response.ToString());  
            }
        }
    }
}
