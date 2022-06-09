using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quests")]
public class Quest : ScriptableObject
{
    [SerializeField] string _displayName;
    [SerializeField] string _description;
    [Tooltip("Editor notes, not visable to player.")]
    [SerializeField] string _notes;
    [SerializeField] Sprite _sprite;

    int _currentStepIndex;

    public List<Step> Steps;
    public string DisplayName => _displayName;
    public string Description => _description;
    public Sprite Sprite => _sprite;

    public void TryProgress()
    {
        var currentStep = GetCurrentStep();
        if (currentStep.HasAllObjectivesCompleted())
        {
            _currentStepIndex++;
            //Add in progression
        }
    }

    
    public Step GetCurrentStep()
    {
      return Steps[_currentStepIndex];
    }
}

[Serializable]
public class Step
{
    [SerializeField] string _instructions;
    public string Instructions => _instructions;

    public List<Objective> Objectives;

    public bool HasAllObjectivesCompleted()
    {
        return Objectives.TrueForAll(t => t.IsCompleted);
    }
}

[Serializable]
public class Objective
{
    [SerializeField] ObjectiveType _objectiveType;

    public bool IsCompleted { get; }

    public enum ObjectiveType
    {
        Flag,
        Item,
        Kill,
    }
    public override string ToString()
    {
        return _objectiveType.ToString();
    }
}


