using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Inspectable : MonoBehaviour
{
    public static event Action<bool> InspectablesInRangeChanged;
    public static event Action<Inspectable, string> AnyInspectionComplete;

    static HashSet<Inspectable> _inspectablesInRange = new HashSet<Inspectable>();

    public static IReadOnlyCollection<Inspectable> InspectablesInRange => _inspectablesInRange;

    public float InspectionProgress => _data?.TimeInspected ?? 0f / _totalTimeToInspect;

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

    [SerializeField, TextArea] string _completedInspectionText;

    [SerializeField] UnityEvent OnInspectionCompleted;

    [SerializeField] bool _requireMinigame;

    

     InspectableData _data;

    private IMetInspectedCondition[] _allConditions;

    public void Bind(InspectableData inspectableData)
    {
        _data = inspectableData;
        if (WasFullyInspected)
        {
            RestoreInspection();
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
        //Debug.Log($"{_data.TimeInspected} {WasFullyInspected} {_data.TimeInspected >= _totalTimeToInspect}", gameObject);
        if (WasFullyInspected)
        {
            if (_requireMinigame)
                MinigameManager.Instance.StartMinigame(HandleMinigameCompletion);
            else
                CompleteInspection();
        }
    }

    void HandleMinigameCompletion(MinigameResult result)
    {
        if (result == MinigameResult.Won)
            CompleteInspection();
        else if (result == MinigameResult.Lost)
            _data.TimeInspected = 0f;
    }

    void CompleteInspection()
    {
        Debug.LogError("Completed Inspection", gameObject);
        _inspectablesInRange.Remove(this);
        InspectablesInRangeChanged.Invoke(_inspectablesInRange.Any());
        OnInspectionCompleted?.Invoke();
        AnyInspectionComplete?.Invoke(this, _completedInspectionText);
    }

    void RestoreInspection()
    {
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
