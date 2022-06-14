using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Flag/String Game Flag")]
public class StringGameFlag : GameFlag<string>
{
    public void Write(string value)
    {
        Value = value;
        SendChanged();
    }
}

