﻿using System;
using Microsoft.Extensions.Configuration;

namespace Customers.Infrastructure.DependencyBuilder
{
    public static class Binder
    {
        public static T BindSettings<T>(this IConfiguration configuration, string sectionName) where T : class, new()
        {
            T implementation = new T();
            configuration.GetSection(sectionName).Bind(implementation);
            return implementation;
        }
    }
}
