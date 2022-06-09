using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bool Game Flag")]
public class GameFlag : ScriptableObject
{
    public event Action Changed;

    public bool Value { get; private set; }

    private void OnEnable()
    {
        Value = default(bool);
    }
    private void OnDisable()
    {
        Value = default(bool);
    }
    public void Set(bool value)
    {
        Value = value;
        Changed?.Invoke();
    }
}
