namespace LiderBoard
{
    public class LiderBoardManager
    {
        string fileName = "LiderBoard.txt";
        string fullPath;
        public readonly List<Result> results;
        public LiderBoardManager()
        {
            fullPath = Path.Combine(Environment.CurrentDirectory, fileName);
            results = new();
            Load();
        }
        void Load()
        {
            if (!File.Exists(fullPath))
            {
                File.Create(fullPath);
            }
            Scanner scanner = new Scanner(File.ReadAllText(fullPath));
            while (scanner.hasNext())
            {
                string name = scanner.nextString();
                int turns = scanner.nextInt();
                Result result = new Result(name, turns);
                results.Add(result);
            }

        }
        public void AddResult(Result result)
        {
            File.AppendAllText(fullPath,result.ToString()+"\n");
        }
    }
}