using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LanguageExt;
using static LanguageExt.Prelude;

namespace AoC24.Day1;

public class Day1
{
    public void SolveP1()
    {
        Tuple<string, string>[] lines = ParseInput();
        List<int> list1 = lines.Select(t => t.Item1).Select(Int32.Parse).OrderBy(x => x).ToList();
        List<int> list2 = lines.Select(t => t.Item2).Select(Int32.Parse).OrderBy(x => x).ToList();
        
        long sum = list1.Zip(list2, (x, y) => Math.Abs(x - y)).Sum();
        Console.WriteLine($"Part 1: {sum}");
    }
    
    public void SolveP2()
    {
        Tuple<string, string>[] lines = ParseInput();
        List<int> list1 = lines.Select(t => t.Item1).Select(Int32.Parse).OrderBy(x => x).ToList();
        List<int> list2 = lines.Select(t => t.Item2).Select(Int32.Parse).OrderBy(x => x).ToList();
        
        Dictionary<int, int> frequencyMap = list2
            .GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count());
        
        long sim = list1.Fold(
            0,
            (acc, x) =>
            {
                try
                {
                    return (x * frequencyMap[x]) + acc;
                }
                catch (Exception e)
                {
                    return acc;
                }
            });
        
        Console.WriteLine($"Part 2: {sim}");
    }

    public Tuple<string, string>[] ParseInput()
    {
        string fileContent = File.ReadAllText("/Users/axiom/Desktop/GitHub_Repos/AdventOfCode/AoC24/AoC24/Day1/input.txt");
        Tuple<string, string>[] lines = fileContent.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Map(str =>
            {
                string[] parts = str.Split("   ");
                return new Tuple<string, string>(parts[0], parts[1]);
            })
            .ToArray();
        return lines;
    }
}