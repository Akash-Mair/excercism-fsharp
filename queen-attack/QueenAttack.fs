module QueenAttack

let create =
    function
    | (8, _)
    | (_, 8) -> false
    | (x, y) when (x > 0 && y > 0) -> true
    | _ -> false


let (|IsDiagonal|_|) queens =
    let (x1, y1), (x2, y2) = queens
    let (x, y) = (x1 - x2, y1 - y2)
    if (x = y) then Some() else None


let canAttack (queen1: int * int) (queen2: int * int) =
    match queen1, queen2 with
    | (x1, _), (x2, _) when x1 = x2 -> true
    | (_, y1), (_, y2) when y1 = y2 -> true
    | IsDiagonal -> true
    | _ -> false
