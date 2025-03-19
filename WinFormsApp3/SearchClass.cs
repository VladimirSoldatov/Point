using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3
{
    public class SearchClass
    {
        public SearchClass() { }
        public IEnumerable<string> Search(string root, string search_pattern)
        {
            Queue<string> dirs = new Queue<string>();
            dirs.Enqueue(root);
            string dir = string.Empty;
            while (dirs.Count > 0)
            {
                dir = dirs.Dequeue();
                string[] paths = new string[0];
                try
                {
                    paths = Directory.GetFiles(dir, search_pattern);
                }
                catch
                {
                }
                if (paths.Length > 0)
                {
                    foreach (string file in paths)
                    {
                        yield return file;
                    }
                }

                paths = new string[0];
                try
                {
                    paths = Directory.GetDirectories(dir);
                }
                catch { } // swallow

                if (paths != null && paths.Length > 0)
                {
                    foreach (string subDir in paths)
                    {
                        dirs.Enqueue(subDir);

                    }
                }
            }
        }
    }
}
