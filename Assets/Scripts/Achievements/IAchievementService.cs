using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAchievementService
{
    public bool IsAchievementUnlocked(AchievementData achievement);

    public bool UnlockAchievement(AchievementData achievement);
}
