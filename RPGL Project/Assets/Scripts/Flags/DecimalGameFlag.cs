using UnityEngine;

[CreateAssetMenu(menuName = "Decimal Game Flag")]
public class DecimalGameFlag : GameFlag<decimal>
{
    public void Scale(decimal value)
    {
        Value += value;
        SendChanged();
    }
}

