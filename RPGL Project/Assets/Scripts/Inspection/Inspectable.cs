using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Inspectable : MonoBehaviour
{
    public static event Action<bool> InspectablesInRangeChanged;

    static HashSet<Inspectable> _inspectablesInRange = new HashSet<Inspectable>();

    public static IReadOnlyCollection<Inspectable> InspectablesInRange => _inspectablesInRange;

    public float InspectionProgress => _data.TimeInspected / _totalTimeToInspect;

    public bool WasFullyInspected => InspectionProgress >= 1f;

    private void Awake()
    {
        _allConditions = GetComponents<IMetInspectedCondition>();
    }

    public bool GetMeetsConditions()
    {
       
        foreach (var condition in _allConditions)
        {
            if (condition.Met() == false)
            {
                return false;
            }

        }
        return true;
    }

    [SerializeField] float _totalTimeToInspect = 3f;

    [SerializeField] UnityEvent OnInspectionCompleted;

    

     InspectableData _data;

    private IMetInspectedCondition[] _allConditions;

    public void Bind(InspectableData inspectableData)
    {
        _data = inspectableData;
        if (_data.TimeInspected >= _totalTimeToInspect)
        {
            CompleteInspection();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && WasFullyInspected == false && GetMeetsConditions())
        {
            _inspectablesInRange.Add(this);
            InspectablesInRangeChanged?.Invoke(true);
        }
    }

    public void Inspect()
    {
        if (WasFullyInspected)
            return;
        _data.TimeInspected += Time.deltaTime;
        if (_data.TimeInspected >= _totalTimeToInspect)
        {
            CompleteInspection();
        }
    }

    void CompleteInspection()
    {
        _inspectablesInRange.Remove(this);
        InspectablesInRangeChanged.Invoke(_inspectablesInRange.Any());
        OnInspectionCompleted?.Invoke();
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_inspectablesInRange.Remove(this))
                InspectablesInRangeChanged.Invoke(_inspectablesInRange.Any());
        }
    }
}
