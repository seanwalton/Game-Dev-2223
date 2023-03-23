using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAchivement", 
    menuName = "Achievements/Achievement Data", order = 1)]
public class AchievementData : ScriptableObject
{
    [SerializeField] private string achievementID;
    [SerializeField] private string achievementDescription;

    private IAchievementService achievementService;

    private bool unlocked = false;

    public bool Unlocked => unlocked;

    public void SetAchievementService(IAchievementService _achievementService)
    {
        achievementService = _achievementService;
        Debug.Log(achievementService);
    }

    public bool Unlock()
    {

        bool wasUnlocked = unlocked;

        if (achievementService != null)
        {
            wasUnlocked = achievementService.UnlockAchievement(this);
        }

        unlocked = true;

        return wasUnlocked;
    }

}
