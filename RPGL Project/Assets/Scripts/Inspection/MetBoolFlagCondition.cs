using UnityEngine;

public class MetBoolFlagCondition : MonoBehaviour, IMetInspectedCondition
{
    [SerializeField] BoolGameFlag _requiredFlag;
    public bool Met()
    {
        return _requiredFlag.Value;
    }
}