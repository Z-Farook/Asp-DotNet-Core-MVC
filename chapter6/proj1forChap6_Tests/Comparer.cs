using proj1forChap6.Models;
using Xunit;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace proj1forChap6.Tests
{
    public class Comparer
    {
        //method returning the class:  Comparer<T>
        public static Comparer<U> Get<U>(Func<U, U, bool> func)
        {
            return new Comparer<U>(func);
        }
    }
    public class Comparer<T> : Comparer, IEqualityComparer<T>
    {
        private Func<T, T, bool> comparisonFunction;
        //constructor  
        public Comparer(Func<T, T, bool> func)
        {
            comparisonFunction = func;
        }
        public bool Equals(T x, T y)
        {
            return comparisonFunction(x, y);
        }
        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }
    }
}