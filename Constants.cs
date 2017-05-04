namespace ChampionsLeague
{
    using System;
    public static class Constants
    {
        public const string Stop = "stop";

        public const char Pipe = '|';
        public const char Column = ':';

        public static readonly Func<string, string> trimFunc = s => s.Trim();
        public static readonly Func<string, int> parseFunc = s => int.Parse(s);
    }
}
