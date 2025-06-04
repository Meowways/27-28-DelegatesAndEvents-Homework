using System;

public class ReactiveVarible<T> : IReadOnlyVarible<T> where T : IEquatable<T>
{
    public event Action<T, T> Changed;

    private T _value;

    public ReactiveVarible()
    {
        _value = default(T);
    }

    public ReactiveVarible(T value)
    {
        _value = value;
    }

    public T Value
    {
        get => _value;
        set
        {
            T oldValue = _value;
            _value = value;

            if (oldValue.Equals(_value) == false)
                Changed?.Invoke(oldValue, _value);
        }
    }
}
