using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DependencyAttribute.Extensions;
public static class ServiceProviderBuilderExtensions
{
	public static void AddInjectables(this IServiceCollection collection)
	{
		Assembly asm = Assembly.GetCallingAssembly();
		Type[] types = asm.GetTypes()
			.Where(x => x.CustomAttributes.Any(a => a.AttributeType == typeof(InjectableAttribute)))
			.ToArray();

		for (int i = 0; i < types.Length; i++)
		{
			Type t = types[i];
			InjectableAttribute injectAttribute = t.GetCustomAttribute<InjectableAttribute>()!;
			if (injectAttribute != null)
			{
				switch (injectAttribute.Lifetime)
				{
					case ServiceLifetime.Transient:
						if (injectAttribute.ImplementationOf != null)
							collection.AddTransient(injectAttribute.ImplementationOf, t);
						else collection.AddTransient(t);
						break;
					case ServiceLifetime.Scoped:
						if (injectAttribute.ImplementationOf != null)
							collection.AddScoped(injectAttribute.ImplementationOf, t);
						else collection.AddScoped(t);
						break;
					case ServiceLifetime.Singleton:
						if (injectAttribute.ImplementationOf != null)
							collection.AddSingleton(injectAttribute.ImplementationOf, t);
						else collection.AddSingleton(t);
						break;
				}
			}
		}
	}
}