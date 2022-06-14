using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Flag/Counted Int Game Flag")]
public class IntGameFlag : GameFlag<int>
{
    public void Modify(int value)
    {
        Value += value;
        SendChanged();
    }
}
