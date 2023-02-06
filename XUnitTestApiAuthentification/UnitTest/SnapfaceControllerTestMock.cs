using Moq;
using ApiAuthentification.Controllers;
using ApiAuthentification.Model;
using ApiAuthentification.Services;
using Microsoft.AspNetCore.Mvc;

namespace XUnitTestApiAuthentification.UnitTest
{
    public class SnapfaceControllerTestMock
    {
        private readonly Mock<IFacesnapService> facesnapService;
        public SnapfaceControllerTestMock()
        {
            facesnapService = new Mock<IFacesnapService>();
        }

        [Fact]
        public void GetFacesnapList_FacesnapList()
        {
            //arrange
            var facesnapList = GetFaceSnapData();
            facesnapService.Setup(x => x.GetFacesnaps()).Returns(facesnapList);
            var facesnapController = new FacesnapsController(facesnapService.Object);

            //act
            var facesnapResult = facesnapController.Get();

            //assert
            Assert.NotNull(facesnapResult);
            Assert.Equal(GetFaceSnapData().Count(), facesnapResult.Value.Count());
            Assert.True(facesnapList.Equals(facesnapResult.Value));
        }

       
        private List<Facesnap> GetFaceSnapData()
        {
            List<Facesnap> facesnapsData = new List<Facesnap>
        {
            new Facesnap
            {
                id = new Guid("a9678c7a-ae8a-490d-8562-c88620515f12"),
                title = "test",
                description = "description test",
                location = "Nanterre",
                imageUrl = "test",
                snaps = 10,
                createdAt = DateTime.Now,
            }
        };
            return facesnapsData;
        }
    }
}
