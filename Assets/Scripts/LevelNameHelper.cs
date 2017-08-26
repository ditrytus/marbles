using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public static class LevelNameHelper
{
    public static string GetNextLevelName()
    {
        return "Level" + (GetCurrentLevelNumber() + 1).ToString("D4");
    }

    public static int GetCurrentLevelNumber()
    {
        return int.Parse(Regex.Match(SceneManager.GetActiveScene().name, @"(\d+)$").Groups[1].Value);
    }
}