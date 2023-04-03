using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Linq;

namespace Maximal_sum_of_elements;

public class LinesPreparer
{
    public ProcessorLinesResult ProcessLines(string[] saFullLines)
    {
        List<int> lsBrokenLines = new List<int>();
        Regex reg = new Regex(@"^(?: *([+-]*\d+\.?\d*),?)+$", RegexOptions.Multiline);
        ProcessorLinesResult res = new();
        for (var j = 1; j <= saFullLines.Length; j++)
        {
            if (reg.IsMatch(saFullLines[j - 1]))
            {
                var lineSum = this.GetLineSum(saFullLines[j - 1]);
                if (j == 1 || lineSum > res.MaxLineSum)
                {
                    res.MaxLineSum = lineSum;
                    res.MaxLineNumber = j;
                }
            }
            else
            {
                lsBrokenLines.Add(j);
            }
        }

        res.BrokenLines = lsBrokenLines.ToArray();

        return res;
    }
    private double GetLineSum(string okString)
    {
        string[] oneNumber = okString.Split(",");
        double sum = 0;
        for (int i = 0; i < oneNumber.Length; i++)
        {
            double d;
            if (double.TryParse(oneNumber[i], NumberStyles.Number, CultureInfo.InvariantCulture, out d))
            {
                sum += d;
            }
        }
        return sum;
    }
}