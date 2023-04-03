using System;
using Maximal_sum_of_elements;
using Moq;
using NUnit.Framework;

namespace TestMaxSum
{

    public class LinesPreparerTests
    {
        private readonly ProgramManagerTests _programManagerTests = new ProgramManagerTests();

        [Test]

        public void ProcessLines_PositiveNumbers_Pass()
        {
            string[] testArr = {"45.7, 1", "1, 3", "31, abcde"};

            var rs = new LinesPreparer().ProcessLines(testArr);

            var actualMaxLineSum = rs.MaxLineSum;
            var actualMaxLineNumber = rs.MaxLineNumber;
            var actualBrokenLines = rs.BrokenLines;

            var expectedMaxLineSum = 46.7;
            var expectedMaxLineNumber = 1;
            var expectedBrokenLines = new int[] {3};

            Assert.AreEqual(expectedMaxLineSum, actualMaxLineSum);
            Assert.AreEqual(expectedMaxLineNumber, actualMaxLineNumber);
            Assert.AreEqual(expectedBrokenLines, actualBrokenLines);
        }
        

        [Test]

        public void ProcessLines_NegativeNumbers_Pass()
        {
            string[] testArray = { "-45.1, -1", "absd, -3", "-31, -10" };

            var rs = new LinesPreparer().ProcessLines(testArray);

            var actualMaxLineSum = rs.MaxLineSum;
            var actualMaxLineNumber = rs.MaxLineNumber;

            var expectedMaxLineSum = -41;
            var expectedMaxLineNumber = 3;

            Assert.AreEqual(expectedMaxLineSum, actualMaxLineSum);
            Assert.AreEqual(expectedMaxLineNumber, actualMaxLineNumber);
        }


        [Test]
        public void ProcessLines_NullValues_Throw()
        {
            Assert.Throws<NullReferenceException>(() => new LinesPreparer().ProcessLines(null));
        }
    }
}