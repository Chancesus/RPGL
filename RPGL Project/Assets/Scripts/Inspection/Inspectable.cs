using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inspectable : MonoBehaviour
{
    public static event Action<bool> InspectablesInRangeChanged;

    public static IReadOnlyCollection<Inspectable> InspectablesInRange => _inspectablesInRange;

    public float InspectionProgress => _timeInspected / _totalTimeToInspect;

    static HashSet<Inspectable> _inspectablesInRange = new HashSet<Inspectable>();
    
    float _timeInspected;
    [SerializeField] float _totalTimeToInspect = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inspectablesInRange.Add(this);
            InspectablesInRangeChanged?.Invoke(true);
        }
    }

    public void Inspect()
    {
        _timeInspected += Time.deltaTime;
        if (_timeInspected >= _totalTimeToInspect)
        {
            CompleteInspection();
        }
    }

    void CompleteInspection()
    {
        _inspectablesInRange.Remove(this);
        InspectablesInRangeChanged.Invoke(_inspectablesInRange.Any());
        gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inspectablesInRange.Remove(this);
            InspectablesInRangeChanged.Invoke(_inspectablesInRange.Any());
        }
    }
}
