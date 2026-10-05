using System;
using System.Collections.Generic;

namespace week03.learn;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Testing Week 03: Sets (DuplicateCounter) ===");
        var words = new[] { "apple", "banana", "apple", "orange", "banana", "apple" };
        int duplicateCount = DuplicateCounter.CountDuplicates(words);
        Console.WriteLine($"Items: {string.Join(", ", words)}");
        Console.WriteLine($"Duplicate count (Expected 3): {duplicateCount}\n");

        Console.WriteLine("=== Testing Week 03: Maps (Translator) ===");
        var translator = new Translator();
        translator.AddWord("car", "auto");
        translator.AddWord("house", "Haus");
        translator.AddWord("book", "Buch");

        Console.WriteLine($"Translate 'car' (Expected 'auto'): {translator.Translate("car")}");
        Console.WriteLine($"Translate 'house' (Expected 'Haus'): {translator.Translate("house")}");
        Console.WriteLine($"Translate 'computer' (Expected '???'): {translator.Translate("computer")}");
    }
}
