using DataLayer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DinoService.DTOCollection;
using ServiceLayer.DinoService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace XunitTest.UnitTests
{
    public class XUnitTest
    {
        [Fact]
        public async Task DinoAdminService_AddNewDino()
        {
            //ARRANGE
            DbContextOptions<DinoDbContext> options = new DbContextOptionsBuilder<DinoDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            //ACT 
            using (DinoDbContext context = new DinoDbContext(options))
            {
                DinoAdminService service = new DinoAdminService(context);

                DinosaurDTO dinosaur = new DinosaurDTO()
                {
                    DinoName = "Fucking Dinosaurus",
                    DinoWeight = 2000,
                    DinoPrice = 15.95,
                    DinoHeight = 25000,
                    DinoLenght = 0.02,
                    PromotionId = 1,
                    DietId = 1
                };

                await service.AddNewDino(dinosaur);
            }

            //ASSERT
            using (DinoDbContext context = new DinoDbContext(options))
            {
                Assert.Equal(1, context.Dinosaurs.Count());
                Assert.Equal("Fucking Dinosaurus", context.Dinosaurs.SingleOrDefault().DinoName);
            }

            
        }

        [Fact]
        public async Task DinoService_GetTop6PromotionDino()
        {
            using (var db = new DinoDbContext(Utilities.Utilities.TestDbContextOptions()))
            {
                //Arrenge
                var dinoService = new DinoService(db);
                var expectedDinos = DinoDbContext.GetSeedingDinos();
                await db.AddRangeAsync(expectedDinos);
                await db.SaveChangesAsync();
                var expectedNames = expectedDinos.Select(n => n.DinoName).ToList();

                //Act
                var result = dinoService.GetTop6PromotionDino().Select(n => n.DinoName).ToList();

                //Assert
                var actualDinosNames = Assert.IsAssignableFrom<List<string>>(result);
                Assert.Equal(
                    expectedNames.OrderBy(n => n),
                    actualDinosNames.OrderBy(n => n));
            }
        }
    }
}
