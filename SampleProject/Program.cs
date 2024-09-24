using DependencyAttribute.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SampleProject;

internal class Program
{
	static void Main(string[] args)
	{
		HostApplicationBuilder builder = new HostApplicationBuilder();
		builder.Services.AddInjectables();
		builder.Services.AddHostedService<SampleHosted>();
		var app = builder.Build();
		app.Run();
	}
}