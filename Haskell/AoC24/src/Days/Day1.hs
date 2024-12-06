module Days.Day1 (run, part1, part2) where

run :: IO ()
run = do
    input <- readFile "input/d1.txt"
    print $ part1 input
    print $ part2 input

part1 :: String -> Int
part1 _ = 1

part2 :: String -> Int
part2 _ = 1
