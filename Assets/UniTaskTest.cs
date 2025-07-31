using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniTaskTest : MonoBehaviour
{
    private async void Start()
    {
        Debug.Log("Start Delely...");
        await UniTask.Delay(1000);
        Debug.Log("Done!");
    }
}
