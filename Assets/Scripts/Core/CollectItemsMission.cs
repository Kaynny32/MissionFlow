using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItemsMission : MissionBehaviour
{
    public override event Action OnStarted;
    public override event Action OnMissionPointReached;
    public override event Action OnFinished;

    public override void Start()
    {
        OnStarted?.Invoke();
        // Логика миссии...
        Debug.Log("Start");
    }
}
