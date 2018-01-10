using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// additional references
using FinalA.Controllers;
using FinalA.Models;
using Moq;
using System.Linq;
using System.Web.Mvc;

namespace FinalA.Tests.Controllers
{
    [TestClass]
    public class TeamsControllerTest
    {
        TeamsController controller;
        Mock<ITeamRepository> mock;
        List<Team> teams;
        
        [TestInitialize] 
        public void TestInitialize()
        {
            // arrange
            mock = new Mock<ITeamRepository>();

            teams = new List<Team> {
                new Team { Name = "Toronto Maple Leafs", Points = 41 },
                new Team { Name = "Vancouver Canucks", Points = 35 },
                new Team { Name = "Montreal Canadiens", Points = 32 }
            };

            mock.Setup(m => m.Teams).Returns(teams.AsQueryable());

            controller = new TeamsController(mock.Object);
        }

        [TestMethod] 
        public void IndexValidLoadsTeams()
        {
            var actual = (List<Team>)controller.Index().Model;

           CollectionAssert.AreEqual(teams, actual);
        }

        [TestMethod]
        public void DetailsValidId()
        {
            var actual = controller.Details(1);

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void DetailsInvalidId()
        {
           

            // Act
            var actual = controller.Details(-65);

            // Assert
            Assert.AreEqual("Error", actual.ViewName);

            // assert
        }

        [TestMethod]
        public void DetailsMissingId()
        {
            int? id = null;

            // Act
            var actual = controller.Details(id);

            // Assert
            Assert.AreEqual("Error", actual.ViewName);

        }



    }
}
