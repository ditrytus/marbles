using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class Persistent<T>
{
	private string filePath;

	private Func<T> initializeFunc;

	private T subject;

	public Persistent(string filePath, Func<T> initializeFunc)
	{
		this.filePath = filePath;
		this.initializeFunc = initializeFunc;
	}

	private string FileFullPath
	{
		get
		{
			return Path.Combine(Application.persistentDataPath, filePath);
		}
	}

	public T Subject
	{
		get
		{
			if (subject == null)
			{
				InitializeOrLoad();
			}
			return subject;
		}
	}

	private void InitializeOrLoad()
	{
		if (!File.Exists(FileFullPath))
		{
			Initialize();
		}
		else
		{
			Load();
		}
	}

	private void Initialize()
	{
		subject = initializeFunc();
		Save();
	}

	private void Load()
	{
		subject = JsonUtility.FromJson<T>(File.ReadAllText(FileFullPath));
	}

	public void Save()
	{
        File.WriteAllText(FileFullPath, JsonUtility.ToJson(subject));
	}
}
