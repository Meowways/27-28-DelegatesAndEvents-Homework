using System;

public interface IReadOnlyVarible<T>
{
    event Action<T, T> Changed;

    T Value { get; }
}
