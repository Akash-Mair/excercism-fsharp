module RobotSimulator

type Direction =
    | North
    | East
    | South
    | West

type Position = int * int

type Robot =
    { direction: Direction
      position: Position }

type TurnDirection =
    | Right
    | Left

type Movement =
    | Turn of TurnDirection
    | Advance

    static member value =
        function
        | 'R' -> Turn Right
        | 'L' -> Turn Left
        | 'A' -> Advance

let create direction (position: Position) =
    { direction = direction
      position = position }

let newDirectionFacing (currentlyFacing: Direction) turn =
    match currentlyFacing, turn with
    | North, Right -> East
    | East, Right -> South
    | South, Right -> West
    | West, Right -> North
    | North, Left -> West
    | East, Left -> North
    | South, Left -> East
    | West, Left -> South

let move (instructions: string) robot =
    instructions
    |> Seq.toList
    |> List.map Movement.value
    |> List.fold
        (fun acc elem ->
            match elem with
            | Turn x ->
                { acc with
                      direction = x |> newDirectionFacing acc.direction }
            | Advance ->
                let (x, y) = acc.position

                let position =
                    match acc.direction with
                    | North -> x, y + 1
                    | East -> x + 1, y
                    | South -> x, y - 1
                    | West -> x - 1, y

                { acc with position = position })
        robot
