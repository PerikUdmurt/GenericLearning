using System;

[Serializable]
public class Range<T>
{
    public T minValue;
    public T maxValue;

    public Range(T minValue, T maxValue)
    {
        this.maxValue = maxValue;
        this.minValue = minValue;
    }
}
