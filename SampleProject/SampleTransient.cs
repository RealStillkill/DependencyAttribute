using DependencyAttribute;
using Microsoft.Extensions.Logging;

namespace SampleProject;

[Injectable(ServiceLifetime.Transient, typeof(ISampleTransient))]
internal class SampleTransient : ISampleTransient
{
	private readonly ILogger<SampleTransient> _logger;

	public SampleTransient(ILogger<SampleTransient> logger)
	{
		_logger = logger;
	}
	public void DoSomething()
	{
		_logger.LogInformation("Sample Transient");
	}
}
