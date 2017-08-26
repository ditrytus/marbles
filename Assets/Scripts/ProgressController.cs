using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class Progress
{
	public int completedLevels;
}

public class ProgressController : MonoBehaviour {

	private const string ProgressFilePath = "progress.json";

	private string ProgressFileFullPath
	{
		get
		{
			return Path.Combine(Application.persistentDataPath, ProgressFilePath);
		}
	}

    public Progress GetProgress()
    {
        if (!File.Exists(ProgressFileFullPath))
        {
            var progress = new Progress() { completedLevels = 0 };
            SaveProgress(progress);
			return progress;
        }
        else
        {
            return LoadProgress();
        }
    }

	public void CompletedLevel(int levelNumber)
	{
		var progress = GetProgress();
		progress.completedLevels = Math.Max(progress.completedLevels, levelNumber);
		SaveProgress(progress);
	}

    private Progress LoadProgress()
    {
        return JsonUtility.FromJson<Progress>(File.ReadAllText(ProgressFileFullPath));
    }

    private void SaveProgress(Progress progress)
    {
        File.WriteAllText(ProgressFileFullPath, JsonUtility.ToJson(progress));
    }
}
