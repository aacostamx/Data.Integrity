using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Data.Integrity.Custom;

public static class HashUtility
{
    public static string Concat<T>(T hashable)
    {
        var props = typeof(T).GetProperties()
            .Where(atr => Attribute.IsDefined(atr, typeof(HashAttribute)))
            .ToList();

        var sb = new StringBuilder();
        foreach (PropertyInfo prop in props)
        {
            sb.Append(prop.GetValue(hashable));
        }

        return sb.ToString();
    }

    public static string Hash(string input)
    {
        using var hashAlgorithm = MD5.Create();
        var data = hashAlgorithm.ComputeHash(Encoding.ASCII.GetBytes(input));
        var sb = new StringBuilder();
        foreach (var item in data)
            sb.Append(item.ToString("x2"));

        return sb.ToString().ToUpper();
    }

    public static List<string> ListToHash<T>(List<T> list)
    {
        return (from T item in list
                select Hash(Concat(item))).ToList();
    }
}