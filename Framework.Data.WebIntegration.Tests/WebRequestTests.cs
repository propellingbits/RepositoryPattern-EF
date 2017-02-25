using System.Collections;
using System.Web;
using MbUnit.Framework;
using Moq;


namespace Framework.Data.WebIntegration.Tests
{
    [TestFixture]
    public class WebRequestTests
    {
        [Test]
        public void getItems_FakeHttpContext_ReturnsFakeItems()
        {
            var context = new Mock<HttpContextBase>();
            var items = new Mock<IDictionary>();

            context.Setup(c => c.Items).Returns(items.Object);

            var request = new WebRequest(context.Object);

            Assert.AreSame(items.Object, request.Items);
        }

        [Test]
        public void getItems_DifferentHttpRequests_ReturnsDifferentItems()
        {
            var context1 = new Mock<HttpContextBase>();
            var context2 = new Mock<HttpContextBase>();

            var items1 = new Mock<IDictionary>();
            var items2 = new Mock<IDictionary>();

            context1.Setup(c => c.Items).Returns(items1.Object);
            context2.Setup(c => c.Items).Returns(items2.Object);


            var request1 = new WebRequest(context1.Object);
            var request2 = new WebRequest(context2.Object);

            Assert.AreNotSame(request1.Items, request2.Items);
        }

        [Test, MultipleAsserts]
        public void getItems_DifferentContextsOnSameWebRequest_ReturnsDifferentItems()
        {
            var context1 = new Mock<HttpContextBase>();
            var items1 = new Mock<IDictionary>();
            context1.Setup(c => c.Items).Returns(items1.Object);

            var request = new WebRequest(context1.Object);
                        
            var context2 = new Mock<HttpContextBase>();
            var items2 = new Mock<IDictionary>();
            context2.Setup(c => c.Items).Returns(items2.Object);

            // Pretend a new HttpRequest replaces the previous one
            Mirror.ForObject(WebRequest.Instance)["_httpContext"].Value = context2.Object;

            Assert.AreNotSame(items2.Object, request.Items);     
        }
    }
}
