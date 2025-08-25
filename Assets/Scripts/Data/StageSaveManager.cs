using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StageInstance
{
    public int stageKey;
    public int currentWave;
    public StageInfo currentStageInfo;

    public StageInstance(int stageKey, int currentWave)
    {
        this.stageKey = stageKey;
        this.currentWave = currentWave;
    }

    public void SetStageInfo(StageInfo stageInfo)
    {
        currentStageInfo = stageInfo;
    }

    public bool CheckEndOfWave()
    {
        if (currentStageInfo == null)
            return false;

        if (currentWave >= currentStageInfo.waves.Length - 1)
            return false;

        return true;
    }
}

public class StageSaveManager
{
    private const string SaveKey = "StageInstance";

    public static void SaveStageInstance(StageInstance instance)
    {
        string json = JsonUtility.ToJson(instance);
        PlayerPrefs.Save();
    }

    public static StageInstance LoadStageInstance()
    {
        if (PlayerPrefs.HasKey(SaveKey))
        {
            string json = PlayerPrefs.GetString(SaveKey);
            return JsonUtility.FromJson<StageInstance>(json);
        }

        return null;
    }

    public static void ClearSavedStage()
    {
        PlayerPrefs.DeleteKey(SaveKey);
        PlayerPrefs.Save();
    }
}