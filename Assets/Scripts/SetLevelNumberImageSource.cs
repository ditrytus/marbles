using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SetLevelNumberImageSource : MonoBehaviour
{
	public Image image;

	public LevelNumber levelNumber;

	public string levelImagePathTemplate = "Textures/Thumbs/Level{0:D4}";

	void Start()
	{
		if (image == null) image = GetComponent<Image>();
		if (levelNumber == null) levelNumber = GetComponent<LevelNumber>();

		var levelImagePath = string.Format(levelImagePathTemplate, levelNumber.LevelNum);
		var sprite = Resources.Load<Sprite>(levelImagePath);
        image.sprite = sprite;
	}
}
