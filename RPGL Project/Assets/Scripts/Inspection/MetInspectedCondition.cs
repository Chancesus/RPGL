using System;
using UnityEngine;

public class MetInspectedCondition : MonoBehaviour, IMetInspectedCondition
{
    [SerializeField] Inspectable _requiredInspectable;
    public bool Met()
    {
        return _requiredInspectable.WasFullyInspected;
    }

    private void OnDrawGizmos()
    {
        if (_requiredInspectable != null)
        {
            Gizmos.color = Met() ? Color.green : Color.red;
            Gizmos.DrawLine(transform.position, _requiredInspectable.transform.position);
        }
        
    }
}
