using System.Diagnostics.CodeAnalysis;


[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Framework.Data.Repository.EF")]
[module: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", Scope = "resource", 
    Target = "Framework.Data.Properties.Resources.resources", MessageId = "referencetables", 
    Justification="This is the name of a configuration section; the casing is in line with established practice.")]