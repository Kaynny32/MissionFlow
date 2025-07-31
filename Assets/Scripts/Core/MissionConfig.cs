using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MissionConfig", menuName = "Missions/Mission Configuration")]
public class MissionConfig : ScriptableObject
{
    public List<MissionData> missionChains = new List<MissionData>();
}