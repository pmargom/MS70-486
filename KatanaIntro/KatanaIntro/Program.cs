using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;

namespace KatanaIntro
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var uri = "http://localhost:8080";
    //        using (WebApp.Start<Startup>(uri))
    //        {
    //            Console.WriteLine("Started!");
    //            Console.ReadKey();
    //            Console.WriteLine("Stopping!!");
    //        }
    //    }


    //}

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseWelcomePage();
            //app.Run(ctx => ctx.Response.WriteAsync("Hello world!"));
            //app.Use<HelloWorldComponent>();
            //app.Use(async (enviroment, next) =>
            //{
            //    foreach (var pair in enviroment.Environment)
            //    {
            //        Console.WriteLine("{0}:{1}", pair.Key, pair.Value);
            //    }
            //    await next();
            //});

            app.Use(async (enviroment, next) =>
            {
                Console.WriteLine("Requesting : " + enviroment.Request.Path);
                await next();
                Console.WriteLine("Response :" + enviroment.Response.StatusCode);
            });

            ConfigurationApi(app);

            app.UseHelloWorld();
        }

        private static void ConfigurationApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "DefaultApi", 
                "api/{controller}/{id}", 
                new {id = RouteParameter.Optional});

            app.UseWebApi(config);
        }
    }

    public static class AppBuilderExtentions
    {
        public static void UseHelloWorld(this IAppBuilder app)
        {
            app.Use<HelloWorldComponent>();
        }
    }

    public class HelloWorldComponent
    {
        private AppFunc _next;
        public HelloWorldComponent(AppFunc next)
        {
            _next = next;
        }

        public Task Invoke(IDictionary<string, object> enviroment)
        {
            var response = enviroment["owin.ResponseBody"] as Stream;
            using (var writer = new StreamWriter(response))
            {
                return writer.WriteAsync("Hello world! with Owin");
            }
        }
    }
}
 