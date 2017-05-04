namespace ChampionsLeague
{
    using System;
    using System.Linq;
    public static class StringManipulator
    {
        public static TType[] SplitString<TType>(string toSplit, char toSplitBy, Func<string, TType> func)
        {
            return toSplit
                    .Split(new[] { toSplitBy }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => func(s))
                    .ToArray();
        }

        public static string GetInputLine()
        {
            return Console.ReadLine().Trim();
        }
    }
}
