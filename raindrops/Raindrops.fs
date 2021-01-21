module Raindrops



type Res =
    | Label of string
    | NoLabel of int

let convert (number: int) =
    let factor num label i =
        if i % num = 0 then
            Label label
        else
            NoLabel i

    let (<+>) switch1 switch2 x =
        match (switch1 x), (switch2 x) with
        | Label l1, Label l2 -> Label(l1 + l2)
        | NoLabel x, Label l
        | Label l, NoLabel x -> Label l
        | NoLabel x, NoLabel y -> NoLabel x

    let rules =
        [ (3, "Pling")
          (5, "Plang")
          (7, "Plong") ]

    let run =
        rules
        |> List.map (fun (num, label) -> factor num label)
        |> List.reduce (<+>)

    number
    |> run
    |> function
    | NoLabel y -> sprintf "%i" y
    | Label x -> x
