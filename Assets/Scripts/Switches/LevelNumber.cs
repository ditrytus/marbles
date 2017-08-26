using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class LevelNumber : MonoBehaviour
{
	public int LevelNum {get; private set;}

	public string numberRegexPattern = @".* (\d+)";

	public int numberRegexGroupNumber = 1;
	
	void Start ()
	{
		LevelNum = int.Parse(Regex.Match(gameObject.name, numberRegexPattern).Groups[1].Value);
	}
}
