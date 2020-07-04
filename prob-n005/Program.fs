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




// map each number 1..10 to its list of factors
// --------------------------------------------
// 1   2   3   4   5   6   7   8   9   10
// --------------------------------------
// 1   2   3   2   5   2   7   2   3   2
//             2       3       2   3   5
//                             2
// 
// group by for each # above using max of each factor for # and already accumulated
// max for that factor so far
// ----------------------------------------------------------
// 1   2   3   5   7   = product(all #'s to then left) = 2520
//     2   3
//     2
