namespace Utilities

open System
open System.Diagnostics

module Util =
    let measure f =
        let sw = Stopwatch.StartNew()
        f()
        sw.Stop()
        printfn "Duration %s ms" (sw.ElapsedMilliseconds.ToString("#,##0"))

    let bsqrt (num: bigint) : double = 
        let answer = num
                        |> System.Numerics.BigInteger.Log
                        |> fun x -> x / 2.0
                        |> Math.Exp
        let intAnswer = (answer |> round |> bigint)
        if (intAnswer * intAnswer) = num
            then intAnswer |> double
            else answer

    let bceil (num: double) : bigint =
        num
            |> ceil
            |> bigint

    let isSquare num = 
        let x = bsqrt num
        let frac = x % 1.0
        (abs frac) < 0.0000000001
