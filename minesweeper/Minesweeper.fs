module Minesweeper

type Position = int * int

type Content =
    | Empty
    | NearLandmine of int
    | Landmine

    static member stringify =
        function
        | Empty -> " "
        | NearLandmine x -> sprintf "%i" x
        | Landmine -> "*"


let calcAdjacentPos (x, y) =
    [ x - 1, y
      x + 1, y
      x, y - 1
      x, y + 1
      x - 1, y - 1
      x - 1, y + 1
      x + 1, y - 1
      x + 1, y + 1 ]

let updateSquare =
    function
    | Empty, pos -> NearLandmine 1, pos
    | NearLandmine x, pos -> NearLandmine(x + 1), pos
    | Landmine, pos -> Landmine, pos


let calcNearLandMineScores x =
    x
    |> List.fold
        (fun acc elem ->
            match elem with
            | Landmine, pos ->
                let positions = pos |> calcAdjacentPos

                acc
                |> List.map
                    (fun (x, y) ->
                        match y with
                        | z when positions |> List.exists ((=) y) -> updateSquare (x, y)
                        | _ -> (x, y))
            | _ -> acc)
        x


let structureGame x =
    let columnSize =
        x
        |> List.maxBy (snd >> snd)
        |> snd
        |> snd
        |> (+) 1

    x
    |> List.map fst
    |> List.chunkBySize columnSize
    |> List.map (String.concat "")

let createCoordinate i l = l |> List.mapi (fun j x -> x, (i, j))

let annotate =
    function
    | [] -> []
    | [ "" ] -> [ "" ]
    | x ->
        x
        |> List.map (Seq.toList)
        |> List.mapi createCoordinate
        |> List.collect id
        |> List.map
            (fun elem ->
                match elem with
                | '*', pos -> Landmine, pos
                | _ -> Empty, snd elem)
        |> calcNearLandMineScores
        |> List.map (fun (x, y) -> x |> Content.stringify, y)
        |> structureGame








// pos is made up of index, internal index (0,0)           //done
// actual pos int * int // done
// top get all adjacent -> let (x,y) = top -> left -> [x+1,y; x, y+1; x +1,y+1] //done
// get all the landmine positions -> LandMine 1,2; LandMine 2,8 ..... //done
// count by pos -> this will give you the score needed for the NearLandmine int //done
// loop through them and calc all valid adjacent pos's //done
// need to remove all pos that are landmines  //done
// create new board //done
