using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.TextTemplating;

namespace TextTemplateDemo.Demos.Hello
{
    public class HelloDemoService : ITransientDependency
    {
        private readonly ITemplateRenderer _templateRenderer;

        public HelloDemoService(ITemplateRenderer templateRenderer)
        {
            _templateRenderer = templateRenderer;
        }

        public async Task<string> RunAsync()
        {
            var result = await _templateRenderer.RenderAsync(
                "Hello", //the template name
                new HelloModel
                {
                    Name = "John"
                }
            );

            return result;
        }

        public async Task RunWithAnonymousModelAsync()
        {
            var result = await _templateRenderer.RenderAsync(
                "Hello", //the template name
                new
                {
                    Name = "John"
                }
            );

            Console.WriteLine(result);
        }
    }
}
