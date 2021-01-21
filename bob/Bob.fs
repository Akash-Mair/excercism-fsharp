module Bob

open System

let (|IsQuestion|_|) (input: string) =
    if input.Trim() |> Seq.last |> (=) '?' then
        input |> Some
    else
        None

let (|IsShouting|_|) (input: string) =
    if input = input.ToUpper() then
        input |> Some
    else
        None

let (|SilentTreatment|_|) (input: string) =
    if String.IsNullOrEmpty(input) then
        Some SilentTreatment
    else
        None

let response (input: string): string =
    match input with
    | IsQuestion s & IsShouting _ -> "Calm down, I know what I'm doing!"
    | IsQuestion s -> "Sure."
    | IsShouting s -> "Whoa, chill out!"
    | SilentTreatment -> "Fine. Be that way!"
    | _ -> "Whatever."
