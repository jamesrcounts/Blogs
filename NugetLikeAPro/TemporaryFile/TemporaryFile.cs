using System;

namespace TemporaryFile
{
    using System.IO;

    using ApprovalUtilities.Utilities;

    public class Temp : IDisposable
    {
        private readonly FileInfo backingFile;

        public Temp(string name)
        {
            this.backingFile = new FileInfo(PathUtilities.GetAdjacentFile(name));
            this.backingFile.Create().Close();
        }

        ~Temp()
        {
            this.Dispose();
        }

        public FileInfo File
        {
            get
            {
                return this.backingFile;
            }
        }

        public void Dispose()
        {
            // File on the file system is not a managed resource :)
            if (this.backingFile.Exists)
            {
                this.backingFile.Delete();
            }
        }
    }
}