using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinFormsApp3
{
    internal class FileWorker
    {
        Dictionary<string, int> magic_words;

        public FileWorker() 
        {
            magic_words = new Dictionary<string, int>();
        }
         public void Insert_words(IEnumerable <string> words)
        {
            
            foreach (string word in words)
            {
                magic_words[word] = 0;
            }

        }


        public string ReadFile(string path)
        {
            string text = string.Empty;
            using(StreamReader sr = new StreamReader(path))
            {
                if(sr is not null)
                text = sr.ReadToEnd();
            }
            return text;
        }
        public int SearchRegex(string text, string magic_word)
        {
            return Regex.Count(text, magic_word);
        }

    }
}
