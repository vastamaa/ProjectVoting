using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using ProjectVoting.Server.Filters;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http.Controllers;
using Xunit;

namespace ProjectVoting.Server.Tests.Filters
{
    [ExcludeFromCodeCoverage]
    public class ValidationFilterAttributeTests
    {
        [Fact]
        public void ValidationFilterAttribute_ShouldReturnUnprocessableEntityObjectResult()
        {
            // Arrange

            // Source: https://stackoverflow.com/questions/46162940/how-to-unit-test-actionfilterattribute
            var modelState = new ModelStateDictionary();
            modelState.AddModelError("name", "invalid");
            var httpContext = new DefaultHttpContext();
            var context = new ActionExecutingContext(
                new ActionContext(httpContext: httpContext, routeData: new RouteData(), actionDescriptor: new ActionDescriptor(), modelState: modelState),
                new List<IFilterMetadata>(),
                new Dictionary<string, object>(),
                null);

            var validationFilterAttribute = new ValidationFilterAttribute();

            // Act
            validationFilterAttribute.OnActionExecuting(context);

            // Assert
            using (new AssertionScope())
            {
                context.Result.Should().NotBeNull().And.BeOfType<UnprocessableEntityObjectResult>();
            }
        }
    }
}
