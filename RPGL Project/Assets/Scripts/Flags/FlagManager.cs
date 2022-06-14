using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FlagManager : MonoBehaviour
{
    [SerializeField] private List<GameFlagBase> _allFlags;
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
    }

    
}