using Newtonsoft.Json;

namespace CaseStudy.Extensions
{    
    public static class Extensions
    {
        public static async Task WriteResponseAsync(this HttpContext context, object responseObject)
        {
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(responseObject));
        }
    }

}
