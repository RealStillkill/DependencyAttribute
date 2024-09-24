using DependencyAttribute;
using Microsoft.Extensions.Logging;

namespace SampleProject;
[Injectable(ServiceLifetime.Singleton)]
internal class SampleSingleton
{
	private readonly ILogger<SampleSingleton> _logger;

	public SampleSingleton(ILogger<SampleSingleton> logger)
	{
		_logger = logger;
	}

	public void DoSomething()
	{
		_logger.LogInformation("Sample Singleton");
	}
}
