let salaries = [75000; 48000; 120000; 190000; 300113; 92000; 36000]

printfn "All salaries:"
salaries |> List.iter (printfn "%d")
printfn ""

let highIncomeSalaries = salaries |> List.filter (fun x -> x > 100000)

printfn "High-income salaries:"
highIncomeSalaries |> List.iter (printfn "%d")
printfn ""

let calculateTax salary =
    match salary with
    | s when s <= 49020 -> float s * 0.15
    | s when s <= 98040 -> float s * 0.205
    | s when s <= 151978 -> float s * 0.26
    | s when s <= 216511 -> float s * 0.29
    | _ -> float salary * 0.33

let salaryWithTaxes = 
    salaries 
    |> List.map (fun s -> (s, calculateTax s))


printfn "Salaries and taxes:"
salaryWithTaxes |> List.iter (fun (original, taxed) -> printfn "Salary: %d, Tax: %.2f" original taxed)
printfn ""

let increasedSalaries = 
    salaries 
    |> List.filter (fun s -> s < 49020)
    |> List.map (fun s -> s + 20000)

printfn "Salaries increased by $20,000 :"
increasedSalaries |> List.iter (printfn "%d")
printfn ""

let salariesInRange = 
    salaries 
    |> List.filter (fun s -> s >= 50000 && s <= 100000)

printfn "Salaries between $50,000 and $100,000:"
salariesInRange |> List.iter (printfn "%d")

let totalSumInRange = 
    salariesInRange 
    |> List.fold (fun acc s -> acc + s) 0

printfn "Total sum of salaries in the range: %d" totalSumInRange
printfn ""

let sumOfMultiplesOfThree (n: int) =
    let rec helper (current: int) (acc: int) =
        if current <= 0 then acc
        else helper (current - 3) (acc + current)
    helper n 0

let sumOfMultiples = sumOfMultiplesOfThree 15
printfn "The sum of all multiples of 3 up to 15 is %d" sumOfMultiples