using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quests")]
public class Quest : ScriptableObject
{
    public event Action Changed;

    [SerializeField] string _displayName;
    [SerializeField] string _description;
    [Tooltip("Editor notes, not visable to player.")]
    [SerializeField] string _notes;
    [SerializeField] Sprite _sprite;

    int _currentStepIndex;

    GameFlag gameflag;

    public List<Step> Steps;
    public string DisplayName => _displayName;
    public string Description => _description;
    public Sprite Sprite => _sprite;

    public Step CurrentStep => Steps[_currentStepIndex];
    void OnEnable()
    {
        _currentStepIndex = 0;
        foreach (var step in Steps)
            foreach (var objective in step.Objectives)
                if (objective.GameFlag != null)
                    objective.GameFlag.Changed += HandleFlagChanged;
               
    }

    void HandleFlagChanged()
    {
        TryProgress();
        Changed?.Invoke();
    }

    public void TryProgress()
    {
        var currentStep = GetCurrentStep();
        Debug.Log("Tried to Progress"); //If statement is failing that is why index isn't increaseing
        if (currentStep.HasAllObjectivesCompleted())
        {
            _currentStepIndex++;
            Debug.Log("Progressed");
            Changed?.Invoke();
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
    [SerializeField] GameFlag _gameFlag;

    public GameFlag GameFlag => _gameFlag;

    public bool IsCompleted { 
        get
        {
            switch(_objectiveType)
            {
                case ObjectiveType.Flag: return _gameFlag.Value;
                    default: return false;
            }
        }
    }

   

    public enum ObjectiveType
    {
        Flag,
        Item,
        Kill,
    }
    public override string ToString()
    {
        {
            switch (_objectiveType)
            {
                case ObjectiveType.Flag: return _gameFlag.name;
                default: return _objectiveType.ToString();
            }
        }
    }
}


