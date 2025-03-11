public interface IDataStorage
{
    void Save(string key, string value);
    string Load(string key, string defaultValue = "");
    bool HasKey(string key);
}