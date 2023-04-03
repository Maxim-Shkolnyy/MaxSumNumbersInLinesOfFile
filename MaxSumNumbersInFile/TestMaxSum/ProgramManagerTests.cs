using System;
using System.IO;
using Maximal_sum_of_elements;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace TestMaxSum;

[TestFixture]
public class ProgramManagerTests
{
    private readonly ProgramManager _manager;
    private readonly Mock<IConsoleIo> _communicationMock = new();
    private readonly Mock<IFileGetter> _fileGetterMock = new();

    private string TempFile = null;

    public ProgramManagerTests()
    {
        this._manager = new ProgramManager(this._communicationMock.Object, _fileGetterMock.Object);
    }

    [Test]
    public void TestFile()
    {


        this._communicationMock.Setup(x => x.WriteLine(It.IsAny<string>()));
        this._communicationMock.SetupSequence(x => x.ReadLine()).Returns("123").Returns(TempFile);
        _fileGetterMock.SetupSequence(x => x.FileExist(It.IsAny<string>())).Returns(false).Returns(true);

        _fileGetterMock.Setup(x=>x.GetStringsFromFile(It.IsAny<string>())).Returns(new string[]{
                "45,12, 78.9",
                "sdfsf",
                ",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,",
                ",..,..,..,..,..,",
                ",3..3..3..3,",
                "-12, -12, -99999",
                "-12,-1.55",
                "-999",
                "",
                "-128",
                "3, , ,4",
                "10.78, 1",
                "456654453r45",
                "78.2, 2"});

        _manager.DoWork();

        this._communicationMock.Verify(x=> x.WriteLine("Enter the path to the file to find line with maximum sum of numbers in it"),Times.Once());
        this._communicationMock.Verify(x=> x.WriteLine("Invalid input. Path should look like     G:\\test.txt"),Times.Once());
        this._communicationMock.Verify(x=> x.ReadLine(),Times.Exactly(3));
        this._communicationMock.Verify(x=> x.WriteLine("MaxLineSumm: 135,9"), Times.Once());
        this._communicationMock.Verify(x=> x.WriteLine("MaxLineNumber: 1"), Times.Once());
        this._communicationMock.Verify(x=> x.WriteLine("Broken lines: 2,3,4,5,9,11,13,14"), Times.Once());

        this._fileGetterMock.Verify(x=> x.FileExist(It.IsAny<string>()), Times.Exactly(2));
        this._fileGetterMock.Verify(x=> x.GetStringsFromFile(It.IsAny<string>()), Times.Once());

    }
}
