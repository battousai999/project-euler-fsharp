// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
// 
// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

open System
open Utilities

let problem limit =
    Console.WriteLine 0

[<EntryPoint>]
let main argv =
    Util.measure (fun () -> problem 20)
    0
