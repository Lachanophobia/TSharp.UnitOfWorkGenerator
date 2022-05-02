﻿using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using TSharp.UnitOfWorkGenerator.EFCore.Models;

namespace TSharp.UnitOfWorkGenerator.EFCore
{
    public static class Diagnostics
    {
        private static void ValidateAppSettings(GeneratorExecutionContext context, UoWSourceGenerator settings, AdditionalText file)
        {
            if (string.IsNullOrWhiteSpace(settings.RepoNamespace))
            {
                var error = new DiagnosticDescriptor(id: "UoW002",
                    title: "Could not getIRepositories Namespace",
                    messageFormat: "Could not get Repositories Namespace, please check your appsettings.Json '{0}'.",
                    category: "UoWGenerator",
                    DiagnosticSeverity.Error,
                    isEnabledByDefault: true);

                context.ReportDiagnostic(Diagnostic.Create(error, Location.None, file.Path));
            }

            if (string.IsNullOrWhiteSpace(settings.IRepoNamespace))
            {
                var error = new DiagnosticDescriptor(id: "UoW003",
                    title: "Could not get IRepositories Namespace",
                    messageFormat: "Could not get IRepositories Namespace, please check your appsettings.Json '{0}'.",
                    category: "UoWGenerator",
                    DiagnosticSeverity.Error,
                    isEnabledByDefault: true);

                context.ReportDiagnostic(Diagnostic.Create(error, Location.None, file.Path));
            }

            if (string.IsNullOrWhiteSpace(settings.DBEntitiesNamespace))
            {
                var error = new DiagnosticDescriptor(id: "UoW004",
                    title: "Could not get DBEntities Namespace",
                    messageFormat: "Could not get DBEntities Namespace, please check your appsettings.Json '{0}'.",
                    category: "UoWGenerator",
                    DiagnosticSeverity.Error,
                    isEnabledByDefault: true);

                context.ReportDiagnostic(Diagnostic.Create(error, Location.None, file.Path));
            }

            if (string.IsNullOrWhiteSpace(settings.DBContextName))
            {
                var error = new DiagnosticDescriptor(id: "UoW005",
                    title: "Could not get DBContext Name",
                    messageFormat: "Could not get DBContext Name, please check your appsettings.Json '{0}'.",
                    category: "UoWGenerator",
                    DiagnosticSeverity.Error,
                    isEnabledByDefault: true);

                context.ReportDiagnostic(Diagnostic.Create(error, Location.None, file.Path));
            }
        }

        private static void CheckedForEntityFrameworkCoreDependency(GeneratorExecutionContext context)
        {
            if (!context.Compilation.ReferencedAssemblyNames.Any(ai => ai.Name.Equals("Microsoft.EntityFrameworkCore", StringComparison.OrdinalIgnoreCase)))
            {
                var error = new DiagnosticDescriptor(id: "UoW005",
                    title: "Could not find assembly Microsoft.EntityFrameworkCore",
                    messageFormat: "Could not find assembly Microsoft.EntityFrameworkCore.",
                    category: "UoWGenerator",
                    DiagnosticSeverity.Error,
                    isEnabledByDefault: true);

                context.ReportDiagnostic(Diagnostic.Create(error, Location.None));
            }
        }

        private static void CheckedForDapperDependency(GeneratorExecutionContext context, UoWSourceGenerator settings)
        {
            if (settings.EnableISP_Call && !context.Compilation.ReferencedAssemblyNames.Any(ai => ai.Name.Equals("Dapper", StringComparison.OrdinalIgnoreCase)))
            {
                var error = new DiagnosticDescriptor(id: "UoW006",
                    title: "Could not find assembly Dapper",
                    messageFormat: "Could not find assembly Dapper.",
                    category: "UoWGenerator",
                    DiagnosticSeverity.Error,
                    isEnabledByDefault: true);

                context.ReportDiagnostic(Diagnostic.Create(error, Location.None));
            }
        }
    }
}