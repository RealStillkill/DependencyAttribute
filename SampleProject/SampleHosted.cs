using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject;
internal class SampleHosted : IHostedService
{
	private readonly IServiceProvider _serviceProvider;

	public SampleHosted(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	public Task StartAsync(CancellationToken cancellationToken)
	{
		using (var scope = _serviceProvider.CreateScope())
		{
			scope.ServiceProvider.GetRequiredService<ISampleTransient>().DoSomething();
			scope.ServiceProvider.GetRequiredService<ISampleScoped>().DoSomething();
			scope.ServiceProvider.GetRequiredService<SampleSingleton>().DoSomething();
		}
		return Task.CompletedTask;
	}

	public Task StopAsync(CancellationToken cancellationToken)
		=> Task.CompletedTask;
}
