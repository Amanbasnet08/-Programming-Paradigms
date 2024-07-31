type Coach = {
    Name: string
    FormerPlayer: bool
}

type Stats = {
    Wins: int
    Losses: int
}

type Team = {
    Name: string
    Coach: Coach
    Stats: Stats
}

let coaches = [
    { Name = "MIKE"; FormerPlayer = true }
    { Name = "CURRY"; FormerPlayer = false }
    { Name = "JAMES"; FormerPlayer = true }
    { Name = "LE BRON"; FormerPlayer = true }
    { Name = "JORDAN"; FormerPlayer = false }
]

let stats = [
    { Wins = 1150; Losses = 485 }
    { Wins = 1310; Losses = 653 }
    { Wins = 375; Losses = 162 }
    { Wins = 943; Losses = 681 }
    { Wins = 607; Losses = 424 }
]

let teams = [
    { Name = "Chicago Bulls"; Coach = coaches.[0]; Stats = stats.[0] }
    { Name = "San Antonio Spurs"; Coach = coaches.[1]; Stats = stats.[1] }
    { Name = "Golden State Warriors"; Coach = coaches.[2]; Stats = stats.[2] }
    { Name = "Los Angeles Clippers"; Coach = coaches.[3]; Stats = stats.[3] }
    { Name = "Miami Heat"; Coach = coaches.[4]; Stats = stats.[4] }
]

let successfulTeams = 
    teams 
    |> List.filter (fun team -> team.Stats.Wins > team.Stats.Losses)

let calculateSuccessPercentage team =
    let wins = float team.Stats.Wins
    let losses = float team.Stats.Losses
    let percentage = (wins / (wins + losses)) * 100.0
    (team.Name, percentage)

let successPercentages = 
    successfulTeams 
    |> List.map calculateSuccessPercentage

successPercentages

|> List.iter (fun (teamName, percentage) -> printfn "%s: Success Percentage = %.2f%%" teamName percentage)
printfn""





type Cuisine =
    | Korean
    | Turkish

type MovieType =
    | Regular
    | IMAX
    | DBOX
    | RegularWithSnacks
    | IMAXWithSnacks
    | DBOXWithSnacks

type Activity =
    | BoardGame
    | Chill
    | Movie of MovieType
    | Restaurant of Cuisine
    | LongDrive of int * float

let calculateBudget activity =
    match activity with
    | BoardGame -> 0.0
    | Chill -> 0.0
    | Movie movieType ->
        match movieType with
        | Regular -> 12.0
        | IMAX -> 17.0
        | DBOX -> 20.0
        | RegularWithSnacks -> 17.0
        | IMAXWithSnacks -> 22.0
        | DBOXWithSnacks -> 25.0
    | Restaurant cuisine ->
        match cuisine with
        | Korean -> 70.0
        | Turkish -> 65.0
    | LongDrive (km, fuelPerKm) -> float km * fuelPerKm

let activity1 = Movie RegularWithSnacks
let activity2 = Restaurant Korean
let activity3 = LongDrive (100, 1.2)


printfn "Budget for Movie RegularWithSnacks: %f CAD" (calculateBudget activity1)
printfn "Budget for Dinner at korean restaurant: %f CAD" (calculateBudget activity2)
printfn "Budget for Long Drive: %f CAD" (calculateBudget activity3)