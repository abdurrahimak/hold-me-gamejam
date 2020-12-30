using UnityEngine;

public class GameData
{
    public void SaveLevel(int level)
    {
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.Save();
    }

    public int GetLevel()
    {
        return PlayerPrefs.GetInt("Level", 1);
    }
}
