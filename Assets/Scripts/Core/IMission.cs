using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMission
{
    event Action OnStarted;
    event Action OnMissionPointReached;
    event Action OnFinished;
    void Start();
    void Reset();
}
