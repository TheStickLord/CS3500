// <copyright file="FormulaSyntaxTests.cs" company="UofU-CS3500">
//   Copyright (c) 2025 UofU-CS3500. All rights reserved.
// </copyright>
// <authors> [Insert Your Name] </authors>
// <date> [Insert the Date] </date>

namespace CS3500.FormulaTests;

using System.Security.Cryptography;
using CS3500.Formula2; // Change this using statement to use different formula implementations. (1-3)
using Newtonsoft.Json.Linq;

/// <summary>
///   <para>
///     The following class shows the basics of how to use the MSTest framework,
///     including:
///   </para>
///   <list type="number">
///     <item> How to catch exceptions. </item>
///     <item> How a test of valid code should look. </item>
///   </list>
/// </summary>
[TestClass]
public class FormulaSyntaxTests
{
    // --- Tests for One Token Rule ---

    /// <summary>
    ///   <para>
    ///     This test makes sure the right kind of exception is thrown
    ///     when trying to create a formula with no tokens.
    ///   </para>
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestNoTokens_Invalid( )
    {
        Assert.ThrowsExactly<FormulaFormatException>( ( ) => _ = new Formula( string.Empty ) );
    }

    // --- Tests for Valid Token Rule ---

    /// <summary>
    ///   <para>
    ///     This test makes sure the right kind of exception is thrown
    ///     when trying to create a formula with no invalid tokens.
    ///   </para>
    ///   <param name="token">Invalid token to be tested</param>
    /// </summary>
    [TestMethod]
    [DataRow("%")]
    [DataRow("=")]
    [DataRow("^")]
    [DataRow("{")]
    [DataRow("}")]
    [DataRow("[")]
    [DataRow("]")]
    [DataRow("<")]
    [DataRow(">")]
    [DataRow("!")]
    [DataRow("?")]
    [DataRow(":")]
    [DataRow(";")]
    [DataRow(",")]
    [DataRow(".")]
    [DataRow("\"")]
    [DataRow("'")]
    [DataRow("`")]
    [DataRow("~")]
    [DataRow(" ")]
    [DataRow("|")]
    [DataRow("\\")]
    [DataRow("&")]
    [DataRow("#")]
    [DataRow("$")]
    [DataRow("@")]
    [DataRow("_")]
    [DataRow("1a")]
    [DataRow("a")]
    [DataRow("ab")]
    public void FormulaConstructor_TestSingleInvalidToken_Invalid(string token)
    {
        Assert.ThrowsExactly<FormulaFormatException>(
            () => _ = new Formula(token));
    }

    /// <summary>
    ///   <para>
    ///     This test makes sure no exception is thrown when a valid character(s) are presented.
    ///   </para>
    ///   <remarks>
    ///     I tried to maintain simple and valid syntax when testing for +, -, /, *, (, and ) validity to ensure that the formulas would not trigger other rules.
    ///   </remarks>
    ///   <param name="formula">Valid formula to be tested</param>
    /// </summary>
    [TestMethod]
    [DataRow("1")]
    [DataRow("2")]
    [DataRow("3")]
    [DataRow("4")]
    [DataRow("5")]
    [DataRow("6")]
    [DataRow("7")]
    [DataRow("8")]
    [DataRow("9")]
    [DataRow("0")]
    [DataRow("(1)")]
    [DataRow("1+1")]
    [DataRow("1/1")]
    [DataRow("1*1")]
    [DataRow("1-1")]
    [DataRow("AB1")]
    [DataRow("Ab1")]
    [DataRow("aB1")]
    [DataRow("ab1")]
    [DataRow("A10")]
    public void FormulaConstructor_TestValidTokens_Valid(string formula)
    {
        _ = new Formula(formula);
    }

    // --- Tests for Closing Parenthesis Rule

    /// <summary>
    ///   <para>
    ///     This test makes sure an exception is thrown when there are more closing paranthesis than opening paranthesis.
    ///   </para>
    ///   <remarks>
    ///     I have tried to keep the formulas as syntatically correct as possible
    ///   </remarks>
    ///   <param name="formula">Inavlid formula to be tested</param>
    /// </summary>
    [TestMethod]
    [DataRow(")")]
    [DataRow("1)")]
    [DataRow("(1))")]
    [DataRow("((1)))")]
    public void FormulaConstructor_TestGreaterClosingAmount_Invalid(string formula)
    {
        Assert.ThrowsExactly<FormulaFormatException>(
            () => _ = new Formula(formula));
    }

    // --- Tests for Balanced Parentheses Rule

    /// <summary>
    ///   <para>
    ///     This test makes sure no exception is thrown when a balenced paratheses formula is passed.
    ///   </para>
    ///   <param name="formula">Valid formula to be tested</param>
    /// </summary>
    [TestMethod]
    [DataRow("(1)")]
    [DataRow("((1))")]
    [DataRow("(((1)))")]
    public void FormulaConstructor_TestBalancedParanthesis_Valid(string formula)
    {
        _ = new Formula(formula);
    }

    /// <summary>
    ///   <para>
    ///     This test makes sure an exception is thrown when a non-balenced paratheses formula is passed.
    ///   </para>
    ///   <param name="formula">Invalid formula to be tested</param>
    /// </summary>
    [TestMethod]
    [DataRow("((1)")]
    [DataRow("(1))")]
    [DataRow("((((1)))")]
    public void FormulaConstructor_TestUnbalancedParanthesis_Invalid(string formula)
    {
        Assert.ThrowsExactly<FormulaFormatException>(
            () => _ = new Formula(formula));
    }

    // --- Tests for First Token Rule

    /// <summary>
    ///   <para>
    ///     Makes sure that a formula with a valid first token passes the constructor
    ///   </para>
    ///   <param name="formula">Valid formula to be tested</param>
    /// </summary>
    [TestMethod]
    [DataRow("1")]
    [DataRow("0")]
    [DataRow("AB1")]
    [DataRow("(1)")]
    public void FormulaConstructor_TestFirstToken_Valid(string formula)
    {
        _ = new Formula(formula);
    }

    /// <summary>
    ///   <para>
    ///     Makes sure that a formula with an invalid first token throws a FormulaFormatException.
    ///   </para>
    ///   <param name="formula">Invalid formula to be tested</param>
    /// </summary>
    [TestMethod]
    [DataRow("+1")]
    [DataRow("-1")]
    [DataRow("*1")]
    [DataRow("/1")]
    [DataRow(")")]
    public void FormulaConstructor_TestFirstTokenNumber_Invalid(string formula)
    {
        Assert.ThrowsExactly<FormulaFormatException>(
            () => _ = new Formula(formula));
    }

    // --- Tests for  Last Token Rule ---

    /// <summary>
    ///   <para>
    ///     Makes sure that a formula with a valid last token passes the constructor.
    ///   </para>
    ///   <param name="formula">Valid formula to be tested</param>
    /// </summary>
    [TestMethod]
    [DataRow("(1)")]
    [DataRow("1+1")]
    [DataRow("1+AB1")]
    public void FormulaConstructor_TestLastToken_Valid(string formula)
    {
        _ = new Formula(formula);
    }

    /// <summary>
    ///   <para>
    ///     Makes sure that a formula with an invalid last token throws a FormulaFormatException.
    ///   </para>
    ///   <param name="formula">Invalid formula to be tested</param>
    /// </summary>
    [TestMethod]
    [DataRow("1(")]
    [DataRow("1+")]
    [DataRow("1*")]
    [DataRow("1-")]
    [DataRow("1/")]
    public void FormulaConstructor_TestLastToken_Invalid(string formula)
    {
        Assert.ThrowsExactly<FormulaFormatException>(
            () => _ = new Formula(formula));
    }

    // --- Tests for Parentheses/Operator Following Rule ---

    /// <summary>
    ///   <para>
    ///     Makes sure that a formula with a valid token following '(' passes the constructor.
    ///   </para>
    ///   <param name="formula">Valid formula to be tested</param>
    /// </summary>
    [TestMethod]
    [DataRow("(1)")]
    [DataRow("(AB1)")]
    [DataRow("((1))")]
    public void FormulaConstructor_TestParenthesesFollowingToken_Valid(string formula)
    {
        _ = new Formula(formula);
    }

    /// <summary>
    ///   <para>
    ///     Makes sure that a formula with an invalid token following '(' throws a FormulaFormatException.
    ///   </para>
    ///   <param name="formula">Invalid formula to be tested</param>
    /// </summary>
    [TestMethod]
    [DataRow("(+1)")]
    [DataRow("(*1)")]
    [DataRow("(-1)")]
    [DataRow("(/1)")]
    [DataRow("())")]
    public void FormulaConstructor_TestParenthesesFollowingToken_Invalid(string formula)
    {
        Assert.ThrowsExactly<FormulaFormatException>(
            () => _ = new Formula(formula));
    }

    /// <summary>
    ///   <para>
    ///     Makes sure that a formula with a valid token following an operator passes the constructor.
    ///   </para>
    ///   <param name="formula">Valid formula to be tested</param>
    /// </summary>
    [TestMethod]
    [DataRow("1+1")]
    [DataRow("1+AB1")]
    [DataRow("1+(1)")]
    [DataRow("1-1")]
    [DataRow("1-AB1")]
    [DataRow("1-(1)")]
    [DataRow("1*1")]
    [DataRow("1*AB1")]
    [DataRow("1*(1)")]
    [DataRow("1/1")]
    [DataRow("1/AB1")]
    [DataRow("1/(1)")]
    public void FormulaConstructor_TestOperatorFollowingToken_Valid(string formula)
    {
        _ = new Formula(formula);
    }

    /// <summary>
    ///   <para>
    ///     Makes sure that a formula with an invalid token following an operator throws a FormulaFormatException.
    ///   </para>
    ///   <param name="formula">Invalid formula to be tested</param>
    /// </summary>
    [TestMethod]
    [DataRow("1++1")]
    [DataRow("1**1")]
    [DataRow("1//1")]
    [DataRow("1--1")]
    [DataRow("(1-)")]
    public void FormulaConstructor_TestOperatorFollowingToken_Invalid(string formula)
    {
        Assert.ThrowsExactly<FormulaFormatException>(
            () => _ = new Formula(formula));
    }

    // --- Tests for Extra Following Rule ---

    /// <summary>
    ///   <para>
    ///     Makes sure that a formula with a valid token following any number/variable/')' passes the constructor.
    ///   </para>
    ///   <param name="formula">Valid formula to be tested</param>
    /// </summary>
    [TestMethod]
    [DataRow("(1)+1")]
    [DataRow("(1)-1")]
    [DataRow("(1)/1")]
    [DataRow("(1)*1")]
    [DataRow("AB1+1")]
    [DataRow("AB1-1")]
    [DataRow("AB1/1")]
    [DataRow("AB1*1")]
    public void FormulaConstructor_TestExtraFollowingToken_Valid(string formula)
    {
        _ = new Formula(formula);
    }

    /// <summary>
    ///   <para>
    ///     Makes sure that a formula with an invalid token following any number/variable/')' throws a FormulaFormatException.
    ///   </para>
    ///   <param name="formula">Invalid formula to be tested</param>
    /// </summary>
    [TestMethod]
    [DataRow("(1)(2)")]
    [DataRow("(1)2")]
    [DataRow("(1)AB1")]
    public void FormulaConstructor_TestExtraFollowingToken_Invalid(string formula)
    {
        Assert.ThrowsExactly<FormulaFormatException>(
            () => _ = new Formula(formula));
    }

}
