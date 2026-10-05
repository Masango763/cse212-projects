namespace week03.learn;

public class Translator
{
    private readonly Dictionary<string, string> _wordMap = new();

    public void AddWord(string fromWord, string toWord)
    {
        _wordMap[fromWord] = toWord;
    }

    public string Translate(string fromWord)
    {
        if (_wordMap.ContainsKey(fromWord))
        {
            return _wordMap[fromWord];
        }

        return "???";
    }
}
