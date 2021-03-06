using System;
using UnityEngine;

public class WinLoseMinigamePanel : MonoBehaviour
{
    Action<MinigameResult> _completeInspection;

    public static WinLoseMinigamePanel Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    internal void StartMinigame(Action<MinigameResult> completeInspection)
    {
        _completeInspection = completeInspection;
        gameObject.SetActive(true);
    }

    public void Win()
    {
        _completeInspection?.Invoke(MinigameResult.Won);
        _completeInspection = null;
        gameObject.SetActive(false);
    }
    public void Lose()
    {
        _completeInspection?.Invoke(MinigameResult.Lost);
        _completeInspection = null;
        gameObject.SetActive(false);
    }
}
