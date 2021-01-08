# CombinatorialOptimization

# What?

**CombinatorialOptimization** is a school project about [Combinatorial optimization](https://en.wikipedia.org/wiki/Combinatorial_optimization) using genetic algorithm in C#.

## How?

### Algorithm
We are using a basic genetic algorithm involving chromosome mutation and crossover.
![](docs/genetic_algorithm.png)

### Compilation

**Requirements:**
- .NET 5

**Steps:**
1. `cd src`
2. `dotnet build`

## Usage

You can execute the default example with these commands:
1. `cd src/CombinatorialOptimization`
2. `dotnet run`


## Examples

Default example with default parameters:
```
/*
Parameters:
- MaxGeneration = 100
- Dimension = 10
- PopulationSize = 30
- Pc = 0.75
- Pm = 0.01
*/

Genetic result
==============
Fitness: 0
Individual: |1|0|1|1|1|1|0|0|0|0|
Generation: 28
```