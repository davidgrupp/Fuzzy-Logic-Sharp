# FLS - Fuzzy Logic Sharp Release Notes

### 1.1.6
Bug Fixes
+ Fixed issue with CoG defuzzification.

### 1.1.5
Features
+ Added new way to create rules.


### 1.1.4
Features
+ Added new membership function types.
    + Generalized Bell Shapped
    + S-Shaped
    + Z-Shaped
    + Rectangle

Bug Fixes
+ Fixed setting the same membership function modifications if used in multiple rules.
+ Added additional membership function min &  max overloads to be able to set min & max values for membership functions.

### 1.1.2
Features
+ Added Trapeziod specific CoG defuzzification method for faster defuzzification of trapezoids and triangles
+ Now allows Doubles, Decimals, and Integers as variable input values.

Bug Fixes
+ Fixed bug in composite membership function defuzzification
+ Fixed bug in composite membership function max & min calculations
 
Other
+ Increased unit test code coverage to more than 95%

### 1.1.1
Bug Fixes
+ Conclusion Membership functions are reset when defuzzing.

### 1.1.0
Features
+ Defuzzification uses the composite function of the conclustion functions.

Bug Fixes
+ Fixed rule evaluation with multiple conditions.

### 1.0.0
Features
+ Initial project build.
