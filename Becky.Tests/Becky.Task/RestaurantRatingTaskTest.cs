using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Becky.Data;
using Becky.Data.DataAccess;
using Becky.Task.Interface;
using Becky.Task.Task;
using Moq;
using NUnit.Framework;

namespace Becky.Tests.Becky.Task
{
    [TestFixture]
    public class RestaurantRatingTaskTest
    {
        private IRestaurantRatingTask _restaurantRatingTask;
        private Mock<IRepository<RestaurantRating>> _restaurantRatingRepository;
        private IList<RestaurantRating> _restaurantRatings;
        private int _restaurantBranchId;

        [SetUp]
        public void SetUp()
        {
            _restaurantBranchId = 1;
            _restaurantRatings = new List<RestaurantRating>(3)
            {
                new RestaurantRating { Id = 1, RestaurantBranchId = _restaurantBranchId, CreatedBy = "uvaraj", CreatedOn = DateTime.Now, Rating = 3 },
                new RestaurantRating { Id = 2, RestaurantBranchId = _restaurantBranchId, CreatedBy = "uvaraj", CreatedOn = DateTime.Now, Rating = 4 },
                new RestaurantRating { Id = 3, RestaurantBranchId = _restaurantBranchId, CreatedBy = "uvaraj", CreatedOn = DateTime.Now, Rating = 5 }
            };

            _restaurantRatingRepository = new Mock<IRepository<RestaurantRating>>();
            _restaurantRatingRepository.Setup(q => q.Find(It.IsAny<Expression<Func<RestaurantRating, bool>>>()))
                .Returns(_restaurantRatings.AsQueryable());

            _restaurantRatingTask = new RestaurantRatingTask(_restaurantRatingRepository.Object);
        }

        [Test]
        public void ConsolidatedRatingBasicTest()
        {
            var expectation = 4;

            var actual = _restaurantRatingTask.GetConsolidatedRating(_restaurantBranchId);

            Assert.AreEqual(expectation, actual);
        }
    }
}