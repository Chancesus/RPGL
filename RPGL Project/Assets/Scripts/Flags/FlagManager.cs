using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FlagManager : MonoBehaviour
{
    [SerializeField] private GameFlagBase[] _allFlags;
    Dictionary<string, GameFlagBase> _flagsByName;
    public static FlagManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _flagsByName = _allFlags.ToDictionary(
            k => k.name.Replace(" ",""),
            v => v);
    }

    private void OnValidate()
    {
        _allFlags = Extensions.GetAllInstances<GameFlagBase>();
    }

    

    public void Set(string flagName, string value)
    {
        if (_flagsByName.TryGetValue(flagName, out var flag) == false) 
        {
            Debug.LogError($"Flag not found {flagName}");
            return;
        }
        if (flag is IntGameFlag intGameFlag)
        {
            if (int.TryParse(value, out var intGameValue))
                intGameFlag.Set(intGameValue);
            Debug.Log("Second check hit");
        }
        else if (flag is BoolGameFlag boolGameFlag)
        {
            if (bool.TryParse(value, out var boolGameValue))
                boolGameFlag.Set(boolGameValue);
        }
        else if (flag is StringGameFlag stringGameFlag)
        {
                stringGameFlag.Set(value);
        }
        else if (flag is DecimalGameFlag decimalGameFlag)
        {
            if (decimal.TryParse(value, out var decimalGameValue))
                decimalGameFlag.Set(decimalGameValue);
        }
    }

    
}
