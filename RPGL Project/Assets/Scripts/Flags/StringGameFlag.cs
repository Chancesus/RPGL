using UnityEngine;

[CreateAssetMenu(menuName = "String Game Flag")]
public class StringGameFlag : GameFlag<string>
{
    public void Write(string value)
    {
        Value = value;
        SendChanged();
    }
}

