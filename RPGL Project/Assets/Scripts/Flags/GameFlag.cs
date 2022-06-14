using System;
using UnityEngine;

public abstract class GameFlagBase : ScriptableObject
{
    public event Action Changed;
    protected void SendChanged() => Changed?.Invoke();
}



public abstract class GameFlag<T> : GameFlagBase
{
    public T Value { get; protected set; }

    private void OnEnable() => Value = default;
    private void OnDisable() => Value = default;
    public void Set(T value)
    {
        Value = value;
        SendChanged();
    }
    
}


