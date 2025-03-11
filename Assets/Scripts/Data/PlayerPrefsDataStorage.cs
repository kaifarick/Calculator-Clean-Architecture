using UnityEngine;

public class PlayerPrefsDataStorage : IDataStorage
{
    public void Save(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
    }

    public string Load(string key, string defaultValue = "")
    {
        return PlayerPrefs.HasKey(key) ? PlayerPrefs.GetString(key) : defaultValue;
    }

    public bool HasKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }
}