using DependencyAttribute;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject;
[Injectable(ServiceLifetime.Scoped, typeof(ISampleScoped))]
internal class SampleScoped : ISampleScoped
{
	private readonly ILogger<SampleScoped> _logger;

	public SampleScoped(ILogger<SampleScoped> logger)
	{
		_logger = logger;
	}

	public void DoSomething()
	{
		_logger.LogInformation("Sample Scoped");
	}
}
