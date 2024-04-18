using Fitsync.Models;
using Fitsync.Controllers;
using Fitsync.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Threading.Tasks;

namespace FitSync_Tests
{
    public class Exercise_Tests
    {
        private DatabaseContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Exercise")
                .Options;

            return new DatabaseContext(options);
        }

        [Fact]
        public async Task CheckIfDataIsCorrectlyReceived()
        {
            using (var context = CreateInMemoryContext())
            {
                context.Add(new Exercise() { Name = "TestExercise1", Difficulty = "Test" , MuscleId = 1});
                context.Add(new Exercise() { Name = "TestExercise2", Difficulty = "Test" , MuscleId = 2});
                context.SaveChanges();
                
                ExercisesController exercisesController = new ExercisesController(context);
                    
                var result = await exercisesController.GetExercise(); 

                Assert.NotNull(result);
            }
        }
    }
}