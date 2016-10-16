using System;
using System.Web.Http; 
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.Cors;

namespace Danita
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			HttpConfiguration config = new HttpConfiguration();
			config.Routes.MapHttpRoute (
			name: "Api",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { 
					id = RouteParameter.Optional
				}
			);

			app.UseWelcomePage (new Microsoft.Owin.Diagnostics.WelcomePageOptions(){
				Path = new Microsoft.Owin.PathString("/home")
			});
			app.UseWebApi (config);
			app.UseCors (CorsOptions.AllowAll);
			app.MapSignalR ();
		}
	}
}

