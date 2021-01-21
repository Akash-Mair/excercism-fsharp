module Leap


let isDivisble x y = y % x |> (=) 0

let isDivisbleBy4 = isDivisble 4
let isDivisbleBy100 = isDivisble 100
let isDivisbleBy400 = isDivisble 400

let (|IsLeapYear|_|) year =
    match year with
    | x when
        year |> isDivisbleBy4
        && year |> isDivisbleBy100 |> not -> Some true
    | y when
        year |> isDivisbleBy4
        && year |> isDivisbleBy100
        && year |> isDivisbleBy400 -> Some true
    | _ -> None



let leapYear (year: int): bool =
    match year with
    | IsLeapYear y -> true
    | _ -> false
