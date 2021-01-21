module Allergies

open System

type Allergen =
    | Eggs
    | Peanuts
    | Shellfish
    | Strawberries
    | Tomatoes
    | Chocolate
    | Pollen
    | Cats

let allergenValue =
    function
    | Eggs -> 1
    | Peanuts -> 2
    | Shellfish -> 4
    | Strawberries -> 8
    | Tomatoes -> 16
    | Chocolate -> 32
    | Pollen -> 64
    | Cats -> 128

let valueToAllergen =
    function
    | 1 -> Eggs
    | 2 -> Peanuts
    | 4 -> Shellfish
    | 8 -> Strawberries
    | 16 -> Tomatoes
    | 32 -> Chocolate
    | 64 -> Pollen
    | 128 -> Cats


let allergens = [
    (Eggs, 1)
    (Peanuts,2)
    (Shellfish, 4)
    (Strawberries, 8)
    (Tomatoes, 16)
    (Chocolate, 32)
    (Pollen, 64)
    (Cats, 128)
]


let rec b value allergens = 
    match value with 
    | 0 -> allergens 
    | x when  -> 









let (|IsAnotherAllergen|_|) (value, allergen) =
    if (valueToAllergen value) = allergen |> not then
        Some true
    else
        None


let allergicTo codedAllergies allergen =
    // match codedAllergies, allergen with
    // | x when codedAllergies = (allergenValue allergen) -> true
    // | IsAnotherAllergen x -> false
    // | x when codedAllergies > (allergenValue allergen) -> true
    // | _ -> false
    let aV = allergen |> allergenValue 
    match codedAllergies with 
    | x when codedAllergies = (allergenValue allergen) -> true
    | y when 
    
      


let list codedAllergies =
    failwith "You need to implement this function."
