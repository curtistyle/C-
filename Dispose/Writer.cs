using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispose
{
    public class Writer : IDisposable
    {
        private string _path;
        private StreamWriter _file;

        public Writer(string path)
        {
            this._path = path;
            this._file = new StreamWriter(path);
        }

        public void Dispose()
        {
            this._file.Close();
        }

        public void Write(string text)
        {
            this._file.Write(text);
        }
    }
}
