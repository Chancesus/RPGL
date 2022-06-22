using System;
using UnityEngine;

internal class MetInspectedCondition : MonoBehaviour
{
    [SerializeField] Inspectable _requiredInspectable;
    public bool Met()
    {
        return _requiredInspectable.WasFullyInspected;
    }
}