module Main where

import Days (runDay)
import System.Environment (getArgs)

main :: IO ()
main = do
    args <- getArgs
    putStrLn "LOLOL"
    print $ length args
    if length args == 0
        then runDay 1
        else runDay $ read $ args !! 0
