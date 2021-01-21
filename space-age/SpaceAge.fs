module SpaceAge

// TODO: define the Planet type
open System

type Planet =
    | Mercury // orbital period 0.2408467 Earth years
    | Venus // orbital period 0.61519726 Earth years
    | Earth // orbital period 1.0 Earth years, 365.25 Earth days, or 31557600 seconds
    | Mars // orbital period 1.8808158 Earth years
    | Jupiter // orbital period 11.862615 Earth years
    | Saturn // orbital period 29.447498 Earth years
    | Uranus // orbital period 84.016846 Earth years
    | Neptune // orbital period 164.79132 Earth years

let ageInEarth ((s: int64) = s / 31557600L) |> float

let ageConversion s =
    function
    | Mercury -> 0.2408467 |> (/) (ageInEarth s)
    | Venus -> 0.61519726 |> (/) (ageInEarth s)
    | Earth -> (ageInEarth s)
    | Mars -> 1.8808158 |> (/) (ageInEarth s)
    | Jupiter -> 11.862615 |> (/) (ageInEarth s)
    | Saturn -> 29.447498 |> (/) (ageInEarth s)
    | Uranus -> 29.447498 |> (/) (ageInEarth s)
    | Neptune -> 164.79132 |> (/) (ageInEarth s)

let age (planet: Planet) (seconds: int64) =
    Math.Round(ageConversion seconds planet, 2)
