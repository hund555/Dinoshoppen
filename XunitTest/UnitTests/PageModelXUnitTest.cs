using DataLayer;
using DinosaurShoppen.Pages.DinoList;
using Microsoft.EntityFrameworkCore;
using Moq;
using ServiceLayer.DinoService.DTOCollection;
using ServiceLayer.DinoService.MapDTOCollection;
using ServiceLayer.DinoService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XunitTest.UnitTests
{
    public class PageModelXUnitTest
    {
        [Fact]
        public void OnGet_PopulatesThePageModel_WithAListOfDinos()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<DinoDbContext>()
                .UseInMemoryDatabase("InMemoryDb");

            List<ListDinoDTO> dinoList = new List<ListDinoDTO>()
            {
                new ListDinoDTO { DinosaurId = 1, DinoName = "Tyrannosaurus Rex", DinoPrice = 11650000, DietId = 1 },
                new ListDinoDTO { DinosaurId = 2, DinoName = "Carnotaurus", DinoPrice = 3500000, DietId = 1 },
                new ListDinoDTO { DinosaurId = 3, DinoName = "Brontosaurus", DinoPrice = 15000000, DietId = 2 },
                new ListDinoDTO { DinosaurId = 4, DinoName = "Ornithomimus", DinoPrice = 365000, DietId = 3 }

            };


            var mockDinoDbContext = new Mock<DinoService>(optionsBuilder);
            mockDinoDbContext.Setup(
                db => db.GetTop6PromotionDino().ToList()).Returns(dinoList);
            //var pageModel = new IndexModel(null, mockDinoDbContext.Object);

            //// Act
            //pageModel.OnGet();

            //// Assert
            //var actualDinoNames = Assert.IsAssignableFrom<List<string>>(pageModel.DinoList);
            //Assert.Equal(
            //    Temp,
            //    actualDinoNames);
        }
    }
}
