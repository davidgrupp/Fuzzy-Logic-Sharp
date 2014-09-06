#region License
//   FLS - Fuzzy Logic Sharp for .NET
//   Copyright 2014 David Grupp
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLS.Constants
{
	public static class ErrorMessages
	{
		public const String RulesAreInvalid = "One or more rules is invalid.";
		public const String InputValusMustBeValid = "Must provide a double, decimal, or integer input value for all variables. Missing: {0}";
		public const String MembershipFunctionsDefuzzType = "All membership functions must be {0} defuzz type.";
		public const String AllMembershipFunctionsMustBeTrapezoid = "All membership functions must be trapezoid and triangle.";
	}
}
