using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAchivement", 
    menuName = "Achievements/Achievement Data", order = 1)]
public class AchievementData : ScriptableObject
{
    [SerializeField] private string achievementID;
    [SerializeField] private string achievementDescription;

    public void Unlock()
    {
        throw new System.NotImplementedException();
    }

}
