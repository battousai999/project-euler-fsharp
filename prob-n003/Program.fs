// The prime factors of 13195 are 5, 7, 13 and 29.

// What is the largest prime factor of the number 600851475143 ?

open System
open Utilities

// Fermat Factorization (from wikipedia.org)
//
// FermatFactor(N): // N should be odd
//     a ← ceiling(sqrt(N))
//     b2 ← a*a - N
//     repeat until b2 is a square:
//         a ← a + 1
//         b2 ← a*a - N 
//      // equivalently: 
//      // b2 ← b2 + 2*a + 1 
//      // a ← a + 1
//     return a - sqrt(b2) // or a + sqrt(b2)

// Factors a number into two of its factors (with the lesser factor always first)
// using Fermat factorization (above).
//
// Ex: 13195 -> (91, 145)
let factor (num: bigint) : (bigint * bigint) =
    let sqrt = Util.bceil << Util.bsqrt
    let mutable a = sqrt(num)
    let mutable b2 = a * a - num
    while (not (Util.isSquare b2)) do
        a <- a + 1I
        b2 <- a * a - num
    (a - sqrt(b2), a + sqrt(b2))

// A function that applies the function 'f' to each of the items in the tuple 'item' and
// then recursively expands the results of that application, collecting all of the 
// results into a list.
//
// Ex: expand factor (91, 145) -> [(1, 7), (1, 13), (1, 5), (1, 29)]
let rec expand f (item: bigint * bigint) : list<(bigint * bigint)> =
    match item with
    | (x, y) when x = 1I -> [(1I, y)]
    | (x, y) -> (expand f (f x)) @ (expand f (f y))

let problem (num: bigint) =
    let groupedFactors = factor num |> expand factor
    let factors = groupedFactors
                    |> List.collect (fun (x, y) -> x :: [y])
                    |> List.distinct
    let answer = List.max factors
    Console.WriteLine answer

[<EntryPoint>]
let main argv =
    Util.measure (fun () -> Console.WriteLine (problem 600851475143I))
    0
