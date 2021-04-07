﻿// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open Graphite.Core
open Graphite

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom


//#include <stdio.h>
//void main() {
//    printf("Hello, World!");
//}


[<EntryPoint>]
let main argv =
    let printfParam0 = { name="text"; ``type``=PrimitiveType.String }
    let printf = { name="printf"; parameters=[ printfParam0 ] }
    let io = { name="io"; methods=[ printf ] }
    let stdlib = { name="stdlib"; modules=[ io ] }

    let invocation = {       
        method=MethodDeclaration.External printf; 
        arguments=[ {
            parameter=printfParam0;
            value="Hello, World!" 
        } ]
    }
    let syntax = {
        libraries=[ stdlib ];
        entrypoint=[ Invocation invocation ]  
    }

    HumanReadable.SerializeSyntax syntax
    |> Console.WriteLine
    ignore Console.ReadLine
    0