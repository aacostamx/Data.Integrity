using System;

namespace Data.Integrity.Custom
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class HashAttribute : Attribute {}
}
