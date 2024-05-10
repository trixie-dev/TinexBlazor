using System.ComponentModel;
using Microsoft.AspNetCore.Components;

namespace TinexBlazor.Scripts;

public class WordsCheckerController: ComponentBase
{
    public Dictionary<string, string> Dictionary { get; set; } = new Dictionary<string, string>()
    {
        // generate 10 words where key is english word and value is ukrainian translation
        { "apple", "яблуко" },
        { "banana", "банан" },
        { "cherry", "вишня" },
        { "grape", "виноград" },
        { "lemon", "лимон" },
        { "orange", "апельсин" },
        { "peach", "персик" },
        { "pear", "груша" },
        { "plum", "слива" },
        { "strawberry", "полуниця" }
    };

    private int _initialWordsCount = 8;
    private int _correctAnswersCount = 0;
    public bool IsChecked { get; private set; } = false;
    
    
    public string CurrentWord { get; private set; }
    public string CurrentTranslation { get; private set; }
    public string Progress => $"{_correctAnswersCount}/{_initialWordsCount}";
    public int Attempts = 0;
    public int Accuracy => Attempts == 0 ? 0 : _correctAnswersCount * 100 / Attempts;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _initialWordsCount = Dictionary.Count;
        ShowRandomWord();
    }
    
    public void ShowRandomWord()
    {
        var random = new Random();
        var index = random.Next(Dictionary.Count);
        CurrentWord = Dictionary.ElementAt(index).Key;
        CurrentTranslation = "???";
        IsChecked = false;
    }
    
    public void ShowAnswer()
    {
        IsChecked = true;
        CurrentTranslation = Dictionary[CurrentWord];
    }
    
    public void CorrectAnswer()
    {
        Dictionary.Remove(CurrentWord);
        _correctAnswersCount++;
        ShowRandomWord();
        Attempts++;
    }
    
    public void WrongAnswer()
    {
        ShowRandomWord();
        Attempts++;
    }




}