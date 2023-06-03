namespace doing
{
    public class use
    {
        public static void write(string path, string a = "")
        {
            if (!File.Exists(path))
                File.WriteAllText(path, "");
            File.WriteAllText(path, a);
        }
        public static string read(string path)
        {
            return File.ReadAllText(path);
        }
    }
}