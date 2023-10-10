using System;
using System.Threading;

class Piano
{
    private int[] firstOctave = { 130, 146, 164, 174, 196, 220, 246, 261 }; 
    private int[] secondOctave = { 261, 293, 329, 349, 392, 440, 493, 523 };
    private int[] thirdOctave = { 523, 587, 659, 698, 784, 880, 987, 1046 };

    private int[] GetOctave(int octave)
    {
        if (octave == 1)
            return firstOctave;
        else if (octave == 2)
            return secondOctave;
        else if (octave == 3)
            return thirdOctave;
        else
            return firstOctave;
    }

    private void PlaySound(int frequency)
    {
        Console.Beep(frequency, 300); 
    }

    public void PlayPiano()
    {
        Console.WriteLine("Нажимайте кнопки от A до L");
        Console.WriteLine("Используйте f1, f2, f3 для переключения октав");
        Console.WriteLine("Press Q to exit the program.");

        int currentOctaveIndex = 1;

        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Q)
                    break;

                if (keyInfo.Key == ConsoleKey.F1)
                    currentOctaveIndex = 1;
                else if (keyInfo.Key == ConsoleKey.F2)
                    currentOctaveIndex = 2;
                else if (keyInfo.Key == ConsoleKey.F3)
                    currentOctaveIndex = 3;

                if (keyInfo.Key >= ConsoleKey.A && keyInfo.Key <= ConsoleKey.L)
                {
                    int noteIndex = (int)keyInfo.Key - (int)ConsoleKey.A;
                    int[] currentNotes = GetOctave(currentOctaveIndex);
                    int frequency = currentNotes[noteIndex];
                    PlaySound(frequency);
                }
            }
        }
    }

    public static void Main(string[] args)
    {
        Piano piano = new Piano();
        piano.PlayPiano();
    }
}
