using UnityEngine;

public class MetIntFlagCondition : MonoBehaviour, IMetInspectedCondition
{
    [SerializeField] IntGameFlag _requiredIntFlag;
    [SerializeField] int _requiredValue = 2;

    public bool Met()
    {
        if (_requiredIntFlag.Value >= _requiredValue)
        {
            return true;
        }

        return false;
    }
}