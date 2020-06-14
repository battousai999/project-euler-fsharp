// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
// Find the sum of all the multiples of 3 or 5 below 1000.

open System
open System.Diagnostics

let measure f =
    let sw = Stopwatch.StartNew()
    f()
    sw.Stop()
    printfn "Duration %s ms" (sw.ElapsedMilliseconds.ToString("#,##0"))

let problem limit =
    let answer = seq { 1 .. (limit - 1) }
                    |> Seq.filter (fun x -> x % 3 = 0 || x % 5 = 0)
                    |> Seq.sum
    Console.WriteLine answer

[<EntryPoint>]
let main argv =
    measure (fun () -> problem 1000)
    0
