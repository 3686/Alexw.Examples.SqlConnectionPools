using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Dapper;
using Microsoft.Owin.Hosting;
using Owin;

namespace Alexw.Examples.SqlConnectionPools.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() => WebApp.Start<Startup>("http://localhost:9000"));
            Console.WriteLine("Host started");
            Console.ReadLine();
        }
    }

    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            appBuilder.UseWebApi(config);
        }
    }

public class ValuesController : ApiController
{
    // GET api/values 
    public async Task<IHttpActionResult> Get(string id)
    {
        using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString))
        {
            //await connection.OpenAsync();
            var result = await connection.QueryAsync("SELECT [Data] FROM Example WHERE [Id]=@id", new { id });

            if (result.Count() == 0) 
                return NotFound();

            return Ok(result);
        }
    }
}
}
