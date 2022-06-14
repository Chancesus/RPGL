using System.Collections;
using UnityEngine;

public class GamePersistance : MonoBehaviour
{
    GameData _gameData;
    void Start()
    {
        LoadGameFlags();
    }

    private void OnDisable()
    {
        SaveGameFlags();
    }

    private void SaveGameFlags()
    {
        
        var json = JsonUtility.ToJson(_gameData);
        PlayerPrefs.SetString("GameData", json);
        Debug.Log(json);
        Debug.Log("Saving Game Flags Complete");
    }

    private void LoadGameFlags()
    {
        var json = PlayerPrefs.GetString("GameData");
        _gameData = JsonUtility.FromJson<GameData>(json);
        if (_gameData == null)
        {
            _gameData = new GameData();
        }
        
        FlagManager.Instance.Bind(_gameData.GameFlagDatas);
    }
}
