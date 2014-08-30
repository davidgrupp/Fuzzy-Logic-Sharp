using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLS.Constants
{
	public static class ErrorMessages
	{
		public const String RulesAreInvalid = "One or more rules is invalid.";
		public const String InputValusMustBeIntegers = "Must provide a integer input value for all variables. Missing: {0}";
		public const String MembershipFunctionsCoG = "All membership functions must be CoG Membership functions.";
		public const String MembershipFunctionsMoM = "All membership functions must be MoM Membership functions.";
	}
}
