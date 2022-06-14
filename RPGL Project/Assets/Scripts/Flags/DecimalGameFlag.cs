using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Flag/Decimal Game Flag")]
public class DecimalGameFlag : GameFlag<decimal>
{
    public void Scale(decimal value)
    {
        Value += value;
        SendChanged();
    }
}

