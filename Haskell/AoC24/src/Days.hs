module Days (runDay) where

import qualified Days.Day1 as Day1

runDay :: Int -> IO ()
runDay day = case day of
    1 -> Day1.run
    _ -> pure ()