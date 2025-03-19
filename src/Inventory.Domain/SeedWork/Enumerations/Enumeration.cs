using System.Reflection;
using Inventory.Domain.SeedWork.ValueObjects;

namespace Inventory.Domain.SeedWork.Enumerations;

/// <summary>
/// Enumeration is pattern abstraction, which allows you to create "smart" enums with additional properties and methods.
/// <para><see href="https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types">Read more about the Enumeration pattern</see>.</para>
/// </summary>
/// <typeparam name="T">Enumeration class.</typeparam>
public abstract record Enumeration<T> : ValueObject
    where T : ValueObject
{
    /// <summary>
    /// Uses reflection to get all the public static instances of itself.
    /// </summary>
    /// <returns>All the enumeration values.</returns>
    public static IEnumerable<T> GetAll()
    {
        return typeof(T)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Select(fieldInfo => fieldInfo.GetValue(null))
            .Cast<T>();
    }
}