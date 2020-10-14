using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.DinoService.DTOCollection;
using ServiceLayer.DinoService.Services;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class TestAfDinoServiceLayer
    {
        [TestMethod]
        public async Task AddNewDino()
        {
            //ARRANGE
            DbContextOptions<DinoDbContext> options = new DbContextOptionsBuilder<DinoDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            //ACT 
            using (DinoDbContext context = new DinoDbContext(options))
            {
                DinoService service = new DinoService(context);

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
                Assert.AreEqual(1, context.Dinosaurs.Count());
                Assert.AreEqual("Fucking Dinosaurus", context.Dinosaurs.SingleOrDefault().DinoName);
            }
        }
    }
}
