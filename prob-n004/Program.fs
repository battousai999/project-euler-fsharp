// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
// 
// Find the largest palindrome made from the product of two 3-digit numbers.

open System
open System.Linq
open Utilities

// A function that returns a stream/sequence of the palindrome numbers in descending order and with a 
// number of digits equal to twice the given 'digits' parameter.
//
// Ex: buildPalindromes 2 = [ 9999, 9889, 9779, 9669, ... ]
let buildPalindromes (digits: int) =
    let fdigits = digits |> double
    let upper = (10.0 ** fdigits) - 1.0 |> bigint
    let lower = 10.0 ** (fdigits - 1.0) |> bigint
    let makePalindrome x = 
        let str = x.ToString()
        let rstr = new String(str.Reverse().ToArray())
        (str + rstr) |> bigint.Parse
    seq { for n in upper.. -1I ..lower do yield makePalindrome n }

let problem (digitSize: int) =
    let palindromes = buildPalindromes digitSize
    let upper = (10.0 ** (digitSize |> double)) - 1.0 |> bigint
    // We only need to check for numbers evenly dividing the candidate palindrome down to a 
    // certain amount
    let lower num = num / upper
    // This predicate is used to test each palindrome candidate to see if there are any 
    // appropriate numbers that evenly divide it
    let predicate num = 
        let candidates = seq { upper.. -1I ..(lower num) }
        Seq.exists (fun x -> num % x = 0I) candidates
    let answer = Seq.find predicate palindromes
    Console.WriteLine answer

[<EntryPoint>]
let main argv =
    Util.measure (fun () -> problem 3)
    0 
