using System;
using System.IO;

namespace Maximal_sum_of_elements
{
    public class ProgramManager
    {
        private readonly IConsoleIo _consoleIo;
        private readonly IFileGetter _file;

        public ProgramManager(IConsoleIo console, IFileGetter file)
        {
            this._consoleIo = console ?? throw new ArgumentNullException(nameof(console));
            this._file = file ?? throw new ArgumentNullException(nameof(file));
        }
        public void DoWork()
        {
            _consoleIo.WriteLine(Messages.InputPath);
            string path = this.PromptingToEnterPath();
            string[] stringsArr = _file.GetStringsFromFile(path);
            LinesPreparer pl = new LinesPreparer();
            ProcessorLinesResult res = pl.ProcessLines(stringsArr);
            string brokenLine = string.Join(',', res.BrokenLines);

            _consoleIo.WriteLine(string.Format(Messages.MaxLineSumm, res.MaxLineSum));
            _consoleIo.WriteLine(string.Format(Messages.MaxLineNumber, res.MaxLineNumber));

            if (res.BrokenLines != null)
                _consoleIo.WriteLine(string.Format(Messages.BrokenLines, brokenLine));

            _consoleIo.ReadLine();
        }
        private string PromptingToEnterPath()
        {
            string inputedPath;
            if (_file.FileExist(inputedPath = _consoleIo.ReadLine()))
            {
                return inputedPath;
            }

            _consoleIo.WriteLine(Messages.InputError);

            return this.PromptingToEnterPath();
        }
    }
}