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
    ///   <remarks>
    ///     <list type="bullet">
    ///       <item>
    ///         We use the _ (discard) notation because the formula object
    ///         is not used after that point in the method.  Note: you can also
    ///         use _ when a method must match an interface but does not use
    ///         some of the required arguments to that method.
    ///       </item>
    ///       <item>
    ///         string.Empty is often considered best practice (rather than using "") because it
    ///         is explicit in intent (e.g., perhaps the coder forgot to but something in "").
    ///       </item>
    ///       <item>
    ///         The name of a test method should follow the MS standard:
    ///         https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices
    ///       </item>
    ///       <item>
    ///         All methods should be documented, but perhaps not to the same extent
    ///         as this one.  The remarks here are for your educational
    ///         purposes (i.e., a developer would assume another developer would know these
    ///         items) and would be superfluous in your code.
    ///       </item>
    ///       <item>
    ///         In 2025, the MSTest framework has been updated to include the ability to
    ///         check for exceptions using the Assert.ThrowsExactly method (thus on a line
    ///         by line basis inside of a test).  This replaces the old way of
    ///         using the [ExpectedException] attribute which also would tell the test
    ///         that the code should throw an exception, and if it doesn't an error has occurred;
    ///         i.e., the correct implementation of the constructor should result
    ///         in this exception being thrown based on the given poorly formed formula.
    ///         You can remove the commented out code below once you understand the difference.
    ///       </item>
    ///       <item>
    ///         When using the ThrowsExactly method, you must use a lambda expression. A lambda
    ///         expression is a concise way to represent an anonymous function that can contain expressions
    ///         and statements.  We will learn more about lambda expressions later in the course.
    ///       </item>
    ///       <item>
    ///         When testing a constructor, and where you don't need the result of the constructor,
    ///         you can use the discard notation (i.e., an underscore):
    ///         <example>
    ///           <code>
    ///             _ = new Formula( "5+5" );
    ///           </code>
    ///         </example>
    ///       </item>
    ///       <item>
    ///         Once you understand all of the above, you can remove the comments.
    ///       </item>
    ///     </list>
    ///   </remarks>
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestNoTokens_Invalid( )
    {
        Assert.ThrowsExactly<FormulaFormatException>( ( ) => _ = new Formula( string.Empty ) );
    }

    /// <summary>
    ///   <para>
    ///     Example of the old way of testing for exceptions.  This style would result in a passed
    ///     test if any code in the method throws an exception. In the case where there is only
    ///     one line, it is not a problem, but if there were multiple lines of code, the ThrowsExactly
    ///     syntax is preferred.
    ///   </para>
    ///   <para>
    ///     You may delete this method once you understand the new way of testing for exceptions.
    ///   </para>
    /// </summary>
    [TestMethod]
    [ExpectedException( typeof( FormulaFormatException ) )]
    public void DELETEME_FormulaConstructor_TestNoTokens_Invalid( )
    {
        _ = new Formula( string.Empty );
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