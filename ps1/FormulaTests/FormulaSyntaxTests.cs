// <copyright file="FormulaSyntaxTests.cs" company="UofU-CS3500">
//   Copyright (c) 2025 UofU-CS3500. All rights reserved.
// </copyright>
// <authors> [Insert Your Name] </authors>
// <date> [Insert the Date] </date>

namespace CS3500.FormulaTests;

using System.Security.Cryptography;
using CS3500.Formula1; // Change this using statement to use different formula implementations.

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

    /// <summary>
    ///   <para>
    ///     Tests whether a valid numeric character will pass in the constructor
    ///   </para>
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestNumericToken_Valid()
    {
        _ = new Formula("1");
    }

    // --- Tests for Valid Token Rule ---



    // --- Tests for Closing Parenthesis Rule

    // --- Tests for Balanced Parentheses Rule

    // --- Tests for First Token Rule

    /// <summary>
    ///   <para>
    ///     Make sure a simple well formed formula is accepted by the constructor (the constructor
    ///     should not throw an exception).
    ///   </para>
    ///   <remarks>
    ///     This is an example of a test that is not expected to throw an exception.
    ///     In other words, the formula "1+1" has a valid first token (and is otherwise also correct).
    ///   </remarks>
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestFirstTokenNumber_Valid( )
    {
        _ = new Formula( "1+1" );
    }

    // --- Tests for  Last Token Rule ---

    // --- Tests for Parentheses/Operator Following Rule ---

    // --- Tests for Extra Following Rule ---
}
