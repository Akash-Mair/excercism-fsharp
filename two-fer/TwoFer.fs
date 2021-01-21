module TwoFer

let twoFer =
    function
    | None -> "One for you, one for me."
    | Some x -> x |> sprintf "One for %s, one for me."
