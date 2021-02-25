namespace HSEPeergrade2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Additional function: we can switch between Russian and English localizations.
            // Command: switchLang.
            FileManager fileManager = new FileManager();
            fileManager.Start();
        }
    }
}