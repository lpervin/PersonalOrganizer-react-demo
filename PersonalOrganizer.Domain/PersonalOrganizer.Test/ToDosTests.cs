using PersonalOrganizer.Domain.DataAccess;
using PersonalOrganizer.Domain.Repos.Notes;
using Xunit;

namespace PersonalOrganizer.Test
{
    public class ToDosTests
    {

        [Fact]
        public void GetToDosByUserIdentifier()
        {
            var repo = new ToDoRepository(new TrackerDbContext());
            var usersTodos = repo.GetAllTodos("auth0|6071b3b0fa89ef00695d29a6").Result;
            Assert.NotEmpty(usersTodos);
        }
        
        [Fact]
        public void GetToDosByInvalidUserIdentifier()
        {
            var repo = new ToDoRepository(new TrackerDbContext());
            var usersTodos = repo.GetAllTodos("fake").Result;
            Assert.Empty(usersTodos);
        }

    }
}