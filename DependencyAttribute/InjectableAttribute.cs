using System;

namespace DependencyAttribute;

[AttributeUsage(AttributeTargets.Class)]
public sealed class InjectableAttribute : Attribute
{
	public ServiceLifetime Lifetime { get; private set; }
	public Type? ImplementationOf { get; private set; }
	/// <summary>
	/// Marks the class as an injectable service, which will be automatically injected when the extension method AddInjectable() is called
	/// </summary>
	/// <param name="lifetime">The lifetime of the service</param>
	/// <param name="implementationOf"></param>
	public InjectableAttribute(ServiceLifetime lifetime, Type implementationOf = null!)
	{
		Lifetime = lifetime;
		ImplementationOf = implementationOf;
	}
}

public enum ServiceLifetime
{
	Transient,
	Scoped,
	Singleton
}