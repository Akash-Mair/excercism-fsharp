module KindergartenGarden

// TODO: define the Plant type

type Plant =
    | Radishes
    | Clover
    | Grass
    | Violets
    static member value x =
        match x with
        | 'R' -> Plant.Radishes
        | 'C' -> Plant.Clover
        | 'G' -> Plant.Grass
        | 'V' -> Plant.Violets

let nameToIndex =
    function
    | "Alice" -> 0
    | "Bob" -> 1
    | "Charlie" -> 2
    | "David" -> 3
    | "Eve" -> 4
    | "Fred" -> 5
    | "Ginny" -> 6
    | "Harriet" -> 7
    | "Ileana" -> 8
    | "Joseph" -> 9
    | "Kincaid" -> 10
    | "Larry" -> 11

let chunk xs = xs |> List.chunkBySize 2


let plants (diagram: string) (student: string) =
    let [ x; y ] =
        diagram.Split '\n'
        |> Array.toList
        |> List.map Seq.toList
        |> List.map chunk

    y
    |> List.zip x
    |> List.map (fun (x, y) -> x @ y)
    |> fun x -> x.[nameToIndex student]
    |> List.map Plant.value
