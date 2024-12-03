namespace AoC24.Day2;

public class Day2
{

    public void SolveP1()
    {
        int res = ParseInput()
            .Map(lis => P1Func(lis) ? 1 : 0)
            .Sum();
        Console.WriteLine($"Part 1: {res}");
    }

    private bool P1Func(int[] inp)
    {   
        bool monotoneCond = true;
        Func<int, int, bool> func;
        if (inp[0] < inp[1]) func = (x, y) => x < y;
        else if (inp[0] == inp[1]) return false;
        else func = (x, y) => x > y;
        for (int x = 0; x < inp.Length - 1; x++)
        {
            monotoneCond = monotoneCond && func(inp[x], inp[x + 1]);
        }
        if (!monotoneCond) return false;
        for (int x = 0; x < inp.Length - 1; x++)
        {
            int diff = Math.Abs(inp[x] - inp[x + 1]);
            monotoneCond = monotoneCond && diff is >= 1 and <= 3;
        }

        return monotoneCond;
    }
    
    
    public List<int[]> ParseInput()
    {
        string fileContent = File.ReadAllText("/Users/axiom/Desktop/GitHub_Repos/AdventOfCode/AoC24/AoC24/Day2/input.txt");
        List<int[]> lines = fileContent.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Map(str =>
            {
                return str.Split(" ").Select(int.Parse).ToArray();
            }).ToList();
        return lines;
    }
}