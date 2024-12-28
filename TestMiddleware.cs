using SysProgLab3.Models;

namespace SysProgLab3
{
    public class TestMiddleware
    {
        private RequestDelegate nextDelegate;
        public TestMiddleware(RequestDelegate next)
        {
            nextDelegate = next;
        }
        public async Task Invoke(HttpContext context,
                DataContext dataContext)
        {
            if (context.Request.Path == "/test")
            {
                await context.Response.WriteAsync($"There are "
                    + dataContext.PriceCurants.Count() + " prices\n");
                await context.Response.WriteAsync("There are "
                    + dataContext.AccountingGoods.Count() + " accounting\n");
               
            }
            else
            {
                await nextDelegate(context);
            }
        }
    }
}
