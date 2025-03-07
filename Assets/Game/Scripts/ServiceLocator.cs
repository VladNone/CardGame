using System;
using System.Collections.Generic;

public class ServiceLocator
{
    private static Dictionary<Type, object> services = new Dictionary<Type, object>();

    public void RegisterService<T>(T service)
    {
        services[service.GetType()] = service;
    }

    public static T GetService<T>()
    {
        if (services.ContainsKey(typeof(T)))
        {
            return (T)services[typeof(T)];
        }
        
        
        return default(T);
    }

    public static void ResetService()
    {
        services.Clear();
    }
}
