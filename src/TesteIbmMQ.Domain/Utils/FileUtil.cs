namespace TesteIbmMQ.Domain.Utils
{
    public static class FileUtil
    {
        public static string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
        public static void WriteFile(string path, string content)
        {
            File.WriteAllText(path, content);
        }
        public static string ReadEncriptedFile(string path)
        {
            return CriptoUtil.DecryptString(File.ReadAllText(path));
        }


        public static void EncriptWriteFile(string path, string content)
        {
            var encriptedContent = CriptoUtil.EncryptString(content);
            File.WriteAllText(path, encriptedContent);
        }
        public static void WriteFile(string path, byte[] content)
        {
            File.WriteAllBytes(path, content);
        }
        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }
        public static bool FileExists(string path)
        {
            return File.Exists(path);
        }
        public static string GetFileName(string path)
        {
            return Path.GetFileName(path);
        }
        public static string GetFileExtension(string path)
        {
            return Path.GetExtension(path);
        }
        public static string GetFileNameWithoutExtension(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }
        public static string GetDirectoryName(string path)
        {
            return Path.GetDirectoryName(path);
        }
        public static string CombinePath(params string[] paths)
        {
            return Path.Combine(paths);
        }
        public static string GetTempPath()
        {
            return Path.GetTempPath();
        }
        public static string GetTempFileName()
        {
            return Path.GetTempFileName();
        }
        public static string GetFullPath(string path)
        {
            return Path.GetFullPath(path);
        }
        public static string GetRandomFileName()
        {
            return Path.GetRandomFileName();
        }
        public static string GetInvalidFileNameChars()
        {
            return new string(Path.GetInvalidFileNameChars());
        }
        public static string GetInvalidPathChars()
        {
            return new string(Path.GetInvalidPathChars());
        }
        public static string GetPathRoot(string path)
        {
            return Path.GetPathRoot(path);
        }
        public static string GetTempPathWithFileName(string fileName)
        {
            return Path.Combine(GetTempPath(), fileName);
        }
        public static string GetTempPathWithFileName(string fileName, string extension)
        {
            return Path.Combine(GetTempPath(), $"{fileName}{extension}");
        }
        public static string GetTempPathWithFileName(string fileName, string extension, string tempPath)
        {
            return Path.Combine(tempPath, $"{fileName}{extension}");
        }
        
    }
}
