namespace WebAPIForHousing.Middlewares
{
    public class ExceptionMiddlewares
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddlewares> logger;

        public ExceptionMiddlewares(RequestDelegate next, ILogger<ExceptionMiddlewares> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex) 
            {
                logger.LogError(ex, ex.Message);
                context.Response.StatusCode= StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(ex.Message);  
            }
        }
    }
}
