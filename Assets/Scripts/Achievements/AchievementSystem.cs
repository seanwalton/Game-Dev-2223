using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Achievement System",
    menuName = "Achievements/Achievement System", order = 1)]
public class AchievementSystem : ScriptableObject, IAchievementService
{

    [SerializeField] private AchievementData[] achievements;

    private void OnEnable()
    {
        Debug.Log("Achievement system awake");

        for (int i = 0; i < achievements.Length; i++)
        {
            achievements[i].SetAchievementService(this);
        }
    }

    public bool IsAchievementUnlocked(AchievementData achievement)
    {
        return achievement.Unlocked;
    }

    public bool UnlockAchievement(AchievementData achievement)
    {
        if (achievement.Unlocked)
        {
            return false;
        }
        else
        {
            achievement.Unlock();
            return true;
        }
    }
}
