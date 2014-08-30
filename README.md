# FLS - Fuzzy Logic Sharp


### What is Fuzzy Logic Sharp?
Fuzzy Logic Sharp is an open source library implementing a simple to use fuzzy logic system. 

### License: Apache License 2.0  

### [Install via NuGet](https://www.nuget.org/packages/FLS/)

### Contributors

This project is looking for more contributors. If you have any interest in helping feel free to contact me or fork the project. We will make every effort to quickly evaluate and merge pull request that benefit the project.

### Features
+ Implements Center of Gravity and Middle of Maximum Defuzzification.
+ Implements a verity of membership functions.
+ Easy to use syntac for creating system rules.
+ Simple design that allows for user extensibility.
+ Easy installation via [NuGet](https://www.nuget.org/packages/FLS/)

### Usage
```csharp
LinguisticVariable water = new LinguisticVariable("Water");
var cold = water.MembershipFunctions.AddTrapezoid("Cold", 0, 0, 20, 40);
var warm = water.MembershipFunctions.AddTriangle("Warm", 30, 50, 70);
var hot = water.MembershipFunctions.AddTrapezoid("Hot", 50, 80, 100, 100);

LinguisticVariable power = new LinguisticVariable("Power");
var low = power.MembershipFunctions.AddTriangle("Low", 0, 25, 50);
var high = power.MembershipFunctions.AddTriangle("High", 25, 50, 75);

IFuzzyEngine fuzzyEngine = new FuzzyEngineFactory().Default();

fuzzyEngine.Rules.If(water.Is(cold).Or(water.Is(warm))).Then(power.Is(high));
fuzzyEngine.Rules.If(water.Is(hot)).Then(power.Is(low));

var result = fuzzyEngine.Defuzzify(new { water = 60 });
```

### Road map
1. ~~Improve interface for submitting variable input values~~
2. ~~Improve creating variables and membership functions and add more variety of membership functions.~~
3. ~~Finialize the interface for creating rules.~~
4. ~~Finialize intial project goals.~~
5. ~~Release inital build via nuget.~~
4. FCL Support for saving and loading Fuzzy Systems.
5. Additional defuzzification method implementations.
6. Expand rule syntax and add additional operators.


### Terminology

| Term                	| Description                                                    	| Alternatives        	| Example                                                                 	|
|---------------------	|----------------------------------------------------------------	|---------------------	|-------------------------------------------------------------------------	|
| Rule                	| A logic statement                                              	| Proposition         	| **If(water.Is(cold).Or(water.Is(warm))).Then(power.Is(high))**         	|
| Premise             	| The first half of a logical statement                          	| Antecedent          	| If(**water.Is(cold).Or(water.Is(warm))**).Then(power.Is(high))         	|
| Conclusion          	| The second half of a logical statement                         	| Consequent          	| If(water.Is(cold).Or(water.Is(warm))).Then(**power.Is(high)**)         	|
| Condition           	| The premise consists of one or more conditions that are tested 	|                     	| If(**water.Is(cold)**.Or(**water.Is(warm))**).Then(**power.Is(high)**) 	|
| Linguistic Variable 	| A variable expressed linguistically                            	| Variable            	| If(**water**.Is(cold).Or(**water**.Is(warm))).Then(**power**.Is(high)) 	|
| Membership Function 	| Sets whose elements have degrees of membership                 	| Membership Set, Set 	| If(water.Is(**cold**).Or(water.Is(**warm**))).Then(power.Is(**high**)) 	|
| Operator            	| Relates a variable to a membership function                    	|                     	| If(water.**Is**(cold).Or(water.**Is**(warm))).Then(power.**Is**(high)) 	|
| Conjunction         	| Joins conditions together with 'And' or 'Or'                  	|                     	| If(water.Is(cold).**Or**(water.Is(warm))).Then(power.Is(high))         	|



