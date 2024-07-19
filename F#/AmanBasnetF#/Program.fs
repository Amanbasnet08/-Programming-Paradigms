

// For more information see https://aka.ms/fsharp-console-apps
//1) Partial Application:
let power exponent value = int (pown (float value) exponent)

let square = power 2
let cube = power 3
printfn"1) Partial Application:"
printfn "Square of 4: %d" (square 4)
printfn "Square of 5: %d" (square 5)
printfn "Cube of 2: %d" (cube 2)
printfn "Cube of 3: %d" (cube 3)
printfn""
//Tail Recursion 1:
let productOfList p =
    let rec helper p acc =
        match p with
        | [] -> acc
        | head :: tail -> helper tail (acc * head)
    helper p 1

let res = productOfList [1; 2; 3; 4]
printfn"2) Tail Recursion 1:"
printfn "The product of all elements in the list is %d" res
printfn""

//Tail Recursion 2: Product of All Odd Numbers
let productOfOdd (n: int) =
    let rec helper current acc =
        if current <= 0 then acc
        else helper (current - 2) (acc * current)
    helper n 1

let result = productOfOdd 11
printfn"3) Tail Recursion 2"
printfn "The product of all odd numbers from 11 to 1 is %d" result
printfn""


//Using Map Function with a Collection
let trimTheGivenSpace (givenList: string list) =
    givenList |> List.map (fun x -> x.Trim())

let list = [" Charles"; "Babbage  "; "  Von Neumann  "; "  Dennis Ritchie  "]
let trimmedNames = trimTheGivenSpace list
printfn"4) Using Map Function with a Collection"
trimmedNames |> List.iter (printfn "%s")
printfn""


//Using Filter and Reduce with a Collection
let sequence = seq {1 .. 700}
let numberList = Seq.toList sequence
let filteredList = List.filter (fun x -> x % 7 = 0 && x % 5 = 0) numberList
let sumOfFilteredNumbers = List.fold (+) 0 filteredList
printfn"5) Using Filter and Reduce with a Collection"
printfn "The sum of all numbers that are multiples of both 7 and 5 is %d" sumOfFilteredNumbers
printfn""


//Using Filter and Reduce with Collection of Strings:
let names: string list = ["James, "; "Robert, "; "John, "; "William, "; "Michael, "; "David, "; "Richard, "]

let filteredNames: string list =
    List.filter (fun (name: string) -> name.Contains("i", System.StringComparison.OrdinalIgnoreCase)) names

let concatenatedNames: string =
    List.fold (fun acc name -> acc + name) "" filteredNames
    

printfn"6) Using Filter and Reduce with Collection of Strings:"

printfn "Concatenated names containing 'i': %s" concatenatedNames
printfn""