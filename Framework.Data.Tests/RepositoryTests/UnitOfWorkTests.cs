using System;
using System.Collections.Generic;
using System.Text;
using Gallio.Framework;
using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;

namespace Framework.Data.Tests.RepositoryTests
{
    [TestFixture]
    public class UnitOfWorkTests
    {
        [Test]
        public void Commit_NoAmbientTransaction_NewTransactionScopeCreated()
        {
            //
            // TODO: Add test logic here
            //
        }

        [Test]
        public void Commit_AmbientTransaction_UsesExistingTransactionScope()
        {
            //
            // TODO: Add test logic here
            //
        }

        [Test]
        public void AddObjectSource_NullObjectSource_ThrowsArgumentNullException()
        { 

        }
    }
}
