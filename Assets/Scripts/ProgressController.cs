using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Progress
{
	public int completedLevels;
}

public class ProgressController : MonoBehaviour
{
	private const string ProgressFilePath = "progress.json";

    private Persistent<Progress> progress;

    void Start()
    {
        progress = new Persistent<Progress>(ProgressFilePath, () => new Progress() { completedLevels = 0 });
    }

    public Progress GetProgress()
    {
        return progress.Subject;
    }

    public void CompletedLevel(int levelNumber)
	{
		progress.Subject.completedLevels = Math.Max(progress.Subject.completedLevels, levelNumber);
		progress.Save();
	}
}
