﻿using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection servisCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(servisCollection);
            }
            return ServiceTool.Create(servisCollection);
        }
    }
}
