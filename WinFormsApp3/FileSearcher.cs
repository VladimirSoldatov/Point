using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3
{
    public class FileSearcher
    {
      
        public FileSearcher() { }
        public  IEnumerable<string> GetFiles(string path, string pattern)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(path);
          
            while (queue.Count > 0)
            {
                path = queue.Dequeue();
                try
                {
                    foreach (string subDir in Directory.GetDirectories(path))
                    {
                        queue.Enqueue(subDir);
                    }
                }
                catch
                {
             
                }
                string[] files = new string[0];
                try
                {
                    files = Directory.GetFiles(path, pattern);
                }
                catch 
                {
               
                }
                if (files != null)
                {
                    foreach (string file in files)
                    {
                        yield return file;
                    }
                }
            }
        }
        public IEnumerable<string> GetFile2(string path, string pattern)
        {
            return Directory.EnumerateFiles(path, pattern, SearchOption.AllDirectories);
        }
        public IEnumerable<string> GetFiles3(string path, string pattern)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(path);
            List<string> files = new List<string>();

            while (queue.Count > 0)
            {
                path = queue.Dequeue();
                try
                {
                    foreach (string subDir in Directory.GetDirectories(path))
                    {
                        queue.Enqueue(subDir);
                    }
                }
                catch
                {

                }
               
                try
                {
                    files.AddRange(Directory.GetFiles(path, pattern));
                }
                catch
                {

                }

            }
            return files;
        }
       
    }
}
