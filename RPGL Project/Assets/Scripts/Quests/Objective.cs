using System;
using UnityEngine;

[Serializable]
public class Objective
{
    [SerializeField] ObjectiveType _objectiveType;
    [SerializeField] GameFlagBase _gameFlag;

    [Header("Int game flags")]
    
    [Tooltip("Required amount for the counted interger game flag")]
    [SerializeField] int _required;

    public GameFlagBase GameFlag => _gameFlag;
    


    public bool IsCompleted { 
        get
        {
            switch(_objectiveType)
            {
                case ObjectiveType.GameFlag:
                    {
                        if (_gameFlag is BoolGameFlag boolGameFlag)
                        {
                            return boolGameFlag.Value;
                        }
                        if (_gameFlag is IntGameFlag intGameFlag)
                        {
                            return intGameFlag.Value >= _required;
                        }
                        return false;
                    }
                    default: return false;
            }
        }
    }

   

    public enum ObjectiveType
    {
        GameFlag,
        Item,
        Kill,
    }
    public override string ToString()
    {
        {
            switch (_objectiveType)
            {
                case ObjectiveType.GameFlag:
                    {
                        if (_gameFlag is BoolGameFlag boolGameFlag)
                        {
                            return _gameFlag.name;
                        }
                        if (_gameFlag is IntGameFlag intGameFlag)
                        {
                            return $"{intGameFlag.name} ({intGameFlag.Value}/{_required})";
                        }
                        return "Invalid/Unknown Objective Type";
                    }
                   default: return _objectiveType.ToString();
            }
        }
    }
}


