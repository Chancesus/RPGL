using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    Action _completeInspection;

    public static MinigameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            _completeInspection?.Invoke();
            _completeInspection = null;
        }
    }

    public void StartMinigame(Action completeInspection)
    {
        _completeInspection = completeInspection;
    }
}
