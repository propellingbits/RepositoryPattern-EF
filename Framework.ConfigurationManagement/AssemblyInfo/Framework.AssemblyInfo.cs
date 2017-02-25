using System;
using System.Reflection;
using System.Resources;

[assembly: AssemblyProduct("Framework")]
[assembly: AssemblyCompany("Kentucky Cabinet of Health and Family Services")]
[assembly: AssemblyCopyright("Copyright © KY CHFS 2010")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: NeutralResourcesLanguage("en-US")] 
[assembly: CLSCompliant(true)]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif


