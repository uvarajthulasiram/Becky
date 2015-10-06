using System.Collections.Generic;
using System.Web.Helpers;
using Becky.Data;
using Becky.Task.Interface;
using Becky.Web.Controllers;
using Becky.Web.Helpers;
using Becky.Web.Models;
using Moq;
using NUnit.Framework;

namespace Becky.Tests.Becky.Web.Controllers
{
    [TestFixture]
    public class LookupControllerTest
    {
        private LookupController _lookupController;
        private MappingService _mappingService;

        private Mock<ILookupTask> _lookupTaskMock;

        private IList<LookupRestaurantType> _cuisinesDataSetup;

        [SetUp]
        public void Setup()
        {
            _cuisinesDataSetup = new List<LookupRestaurantType>
            {
                new LookupRestaurantType {Id = 1, Type = "American"}
            };


            _lookupTaskMock = new Mock<ILookupTask>();
            _lookupTaskMock.Setup(p => p.GetCuisines()).Returns(_cuisinesDataSetup);

            _mappingService = new MappingService();
            _lookupController = new LookupController(_lookupTaskMock.Object, _mappingService);
        }

        [Test]
        public void GetLookupRestaurantTypesAsCuisineViewModelTest()
        {
            // Arrange
            var expectation = Json.Encode(new[] { new CuisineModel { Id = 1, Type = "American"} });

            // Act
            var actual = _lookupController.GetCuisines();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectation, Json.Encode(actual.Data));
        }
    }
}
