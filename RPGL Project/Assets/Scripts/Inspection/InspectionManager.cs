using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InspectionManager : MonoBehaviour
{
    public static bool Inspecting => _currentInspectable != null && _currentInspectable.WasFullyInspected == false;

    public static float InspectionProgress => _currentInspectable?.InspectionProgress ?? 0f;

    static Inspectable _currentInspectable;

    [SerializeField] Canvas _inspectionCanvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _currentInspectable = Inspectable.InspectablesInRange.FirstOrDefault();
        }
        if (Input.GetKey(KeyCode.E) && _currentInspectable != null)
        {
            _currentInspectable.Inspect();
        }
        else
        {
            _currentInspectable = null;
        }
    }
}
