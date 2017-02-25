using System.Diagnostics.CodeAnalysis;

// Add grobal level supressions here

// AvoidNamespacesWithFewTypes
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace")]

// DPW
[assembly: SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "DPW", Scope = "identifier")]