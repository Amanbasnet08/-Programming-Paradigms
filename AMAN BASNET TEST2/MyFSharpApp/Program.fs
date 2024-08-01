type Genre =
    | Horror
    | Drama
    | Thriller
    | Comedy
    | Fantasy
    | Sport

type Director = {
    Name: string
    Movies: int
}

type Movie = {
    Name: string
    RunLength: int
    Genre: Genre
    Director: Director
    IMDBRating: float
}

let movies = [
    { Name = "The Silent Sea"; RunLength = 112; Genre = Horror; Director = { Name = "Choi Hang-yong"; Movies = 5 }; IMDBRating = 7.9 }
    { Name = "The French Dispatch"; RunLength = 108; Genre = Comedy; Director = { Name = "Wes Anderson"; Movies = 21 }; IMDBRating = 7.5 }
    { Name = "The Power of the Dog"; RunLength = 126; Genre = Drama; Director = { Name = "Jane Campion"; Movies = 11 }; IMDBRating = 6.9 }
    { Name = "West Side Story"; RunLength = 156; Genre = Drama; Director = { Name = "Steven Spielberg"; Movies = 34 }; IMDBRating = 7.6 }
    { Name = "Eternals"; RunLength = 157; Genre = Fantasy; Director = { Name = "Chloé Zhao"; Movies = 8 }; IMDBRating = 6.8 }
    { Name = "No Time to Die"; RunLength = 163; Genre = Thriller; Director = { Name = "Cary Joji Fukunaga"; Movies = 12 }; IMDBRating = 7.3 }
    { Name = "Encanto"; RunLength = 102; Genre = Comedy; Director = { Name = "Byron Howard"; Movies = 19 }; IMDBRating = 7.9 }
    { Name = "House of Gucci"; RunLength = 158; Genre = Drama; Director = { Name = "Ridley Scott"; Movies = 30 }; IMDBRating = 6.7 }
]

let oscarProbables = 
    movies 
    |> List.filter (fun movie -> movie.IMDBRating > 7.4)

let convertRunLengthToHoursMinutes runLength =
    let hours = runLength / 60
    let minutes = runLength % 60
    sprintf "%dh %dmin" hours minutes

let runLengthsInHoursMinutes =
    movies 
    |> List.map (fun movie -> (movie.Name, convertRunLengthToHoursMinutes movie.RunLength))

printfn "Probable Oscars winners:"
oscarProbables |> List.iter (fun movie -> printfn "%s" movie.Name)

printfn "\nMovie Run Lengths in Hours and Minutes:"
runLengthsInHoursMinutes |> List.iter (fun (name, length) -> printfn "%s: %s" name length)
