using ApiAuthentification.Controllers;
using ApiAuthentification.Model;
using ApiAuthentification.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace XUnitTestApiAuthentification.UnitTest
{
    public class SnapfaceControllerTest
    {
        private readonly FacesnapsController _controller;
        private readonly IFacesnapService _service;
        public SnapfaceControllerTest()
        {
            _service = new FacesnapServiceFake();
            _controller = new FacesnapsController(_service);
        }

        // Test GET METHOD
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<ActionResult<IEnumerable<Facesnap>>>(okResult);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<List<Facesnap>>(okResult.Value);
            Assert.Single(okResult.Value);
        }
        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get(Guid.NewGuid());
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }
        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var testGuid = new Guid("a9678c7a-ae8a-490d-8562-c88620515f12");
            // Act
            var okResult = _controller.Get(testGuid);
            // Assert
            Assert.IsType<ActionResult<Facesnap>>(okResult);
        }
        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            var testGuid = new Guid("a9678c7a-ae8a-490d-8562-c88620515f12");
            // Act
            var okResult = _controller.Get(testGuid);
            // Assert
            Assert.IsType<Facesnap>(okResult.Value);
            Assert.Equal(testGuid, (okResult.Value as Facesnap).id);
        }

        //Test POST METHOD


        //Test DELETE METHOD
        [Fact]
        public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingGuid = Guid.NewGuid();
            // Act
            var badResponse = _controller.Delete(notExistingGuid);
            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }
        [Fact]
        public void Remove_ExistingGuidPassed_ReturnsNoContentResult()
        {
            // Arrange
            var existingGuid = new Guid("a9678c7a-ae8a-490d-8562-c88620515f12");
            // Act
            var noContentResponse = _controller.Delete(existingGuid);
            // Assert
            Assert.IsType<NoContentResult>(noContentResponse);
        }
        [Fact]
        public void Remove_ExistingGuidPassed_RemovesOneItem()
        {
            // Arrange
            var existingGuid = new Guid("a9678c7a-ae8a-490d-8562-c88620515f12");
            // Act
            var okResponse = _controller.Delete(existingGuid);
            // Assert
            Assert.Equal(0, _service.GetFacesnaps().Count());
        }
    }
}
