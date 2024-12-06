using System.Text.RegularExpressions;

namespace AoC24.Day3;

public class Day3
{
    string Pattern = @"mul\(\d+,\d+\)";
    private string Pattern2 = @"(?:don't\(\)|do\(\)|mul\(\d+,\d+\))";
    public void SolveP1()
    {
        var res = ParseInput().Map(P1Func).Sum();
        Console.WriteLine($"Part 1: {res}");
    }
    
    public void SolveP2()
    {
        BooBoo b = new BooBoo();
        long res = 0;
        foreach (var line in ParseInput())
        {
            res += P2Func(b, line);
        }
        Console.WriteLine($"Part 2: {res}");
    }

    public long P2Func(BooBoo doIt, string input)
    {
        long result = 0;
        MatchCollection matches = Regex.Matches(input, Pattern2);
        foreach (Match match in matches)
        {
            string val = match.Value;
            if ((val.Equals("do()") && doIt.doIt == false) || 
                (val.Equals("don't()") && doIt.doIt))
            {
                doIt.doIt ^= true;
            }
            
            else if (doIt.doIt && val.StartsWith("mul("))
            {
                string[] parts = match.Value.Split(",");
                result += long.Parse(parts[0].Skip(4).ToArray())
                          * long.Parse(parts[1].Take(parts[1].Length - 1).ToArray());
            }
            else
            {
                //Console.WriteLine("Skip");
            }
        }

        return result;
    }

    public long P1Func(string input)
    {
        long result = 0;
        MatchCollection matches = Regex.Matches(input, Pattern);
        foreach (Match match in matches)
        {
            string[] parts = match.Value.Split(",");
            result += long.Parse(parts[0].Skip(4).ToArray())
                * long.Parse(parts[1].Take(parts[1].Length - 1).ToArray());
        }

        return result;
    }
    
    public List<string> ParseInput()
    {
        string fileContent = File.ReadAllText("/Users/axiom/Desktop/GitHub_Repos/AdventOfCode/AoC24/AoC24/Day3/input.txt");
        List<string> lines = fileContent.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        return lines;
    }
}

public class BooBoo
{
    public bool doIt = true;
}