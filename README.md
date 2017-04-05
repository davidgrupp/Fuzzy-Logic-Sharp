# FLS - Fuzzy Logic Sharp


### What is Fuzzy Logic Sharp?
Fuzzy Logic Sharp is an open source library implementing a simple to use fuzzy logic system. 

### License: Apache License 2.0  

### [Install via NuGet](https://www.nuget.org/packages/FLS/)

### Contributors

This project is looking for more contributors. If you have any interest in helping feel free to contact me or fork the project. We will make every effort to quickly evaluate and merge pull request that benefit the project.

### Features
+ Implements Center of Gravity and Middle of Maximum Defuzzification.
    + Center of Gravity (Centroid)
    + Middle of Maximum
+ Implements a verity of [membership functions](https://github.com/davidgrupp/FLS/wiki/Membership-Functions).
    + Trapezoid
    + Triangle
    + Rectangle
    + Generalized Bell Shaped
    + Gaussian
    + S-Shaped
    + Z-Shaped
    + Composite
+ Easy to use syntax for creating system rules.
+ Simple design that allows for user extensibility.
+ Easy installation via [NuGet](https://www.nuget.org/packages/FLS/)

### Usage
```csharp
var water = new LinguisticVariable("Water");
var cold = water.MembershipFunctions.AddTrapezoid("Cold", 0, 0, 20, 40);
var warm = water.MembershipFunctions.AddTriangle("Warm", 30, 50, 70);
var hot = water.MembershipFunctions.AddTrapezoid("Hot", 50, 80, 100, 100);

var power = new LinguisticVariable("Power");
var low = power.MembershipFunctions.AddTriangle("Low", 0, 25, 50);
var high = power.MembershipFunctions.AddTriangle("High", 25, 50, 75);

IFuzzyEngine fuzzyEngine = new FuzzyEngineFactory().Default();

var rule1 = Rule.If(water.Is(cold).Or(water.Is(warm))).Then(power.Is(high));
var rule2 = Rule.If(water.Is(hot)).Then(power.Is(low));
fuzzyEngine.Rules.Add(rule1, rule2);

var result = fuzzyEngine.Defuzzify(new { water = 60 });
```

### Road map
1. FCL Support for saving and loading Fuzzy Systems.
2. Additional defuzzification method implementations.
3. Expand rule syntax and add additional operators.



