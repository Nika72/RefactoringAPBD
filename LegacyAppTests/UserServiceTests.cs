using LegacyApp;
using Xunit;

namespace LegacyAppTests
{
    public class UserServiceTests
    {
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _userService = new UserService();
        }

        [Fact]
        public void AddUser_Should_Return_False_When_Missing_FirstName()
        {
            
            var result = _userService.AddUser(null, null, "kowalski@wp.pl", new DateTime(1980, 1, 1), 1);

            
            Assert.False(result);
        }

        [Fact]
        public void AddUser_Should_Return_False_When_Missing_At_Sign_And_Dot_In_Email()
        {
            
            var result = _userService.AddUser("John", "Doe", "kowalskiwppl", new DateTime(1980, 1, 1), 1);

            
            Assert.False(result);
        }

        [Fact]
        public void AddUser_Should_Return_False_When_Younger_Than_21_Years_Old()
        {
            
            var result = _userService.AddUser("John", "Doe", "kowalski@wp.pl", new DateTime(2010, 1, 1), 1);

            
            Assert.False(result);
        }

        [Theory]
        [InlineData("John", "Malewski", "kowalski@wp.pl", 2)]
        [InlineData("John", "Smith", "smith@gmail.pl", 3)]
        [InlineData("John", "Kwiatkowski", "kwiatkowski@wp.pl", 5)]
        public void AddUser_Should_Return_True_For_Valid_Clients(string firstName, string lastName, string email, int clientId)
        {
            
            var result = _userService.AddUser(firstName, lastName, email, new DateTime(1980, 1, 1), clientId);

            
            Assert.True(result);
        }

        [Fact]
        public void AddUser_Should_Return_False_For_Normal_Client_With_No_Credit_Limit()
        {
            
            var result = _userService.AddUser("John", "Kowalski", "kowalski@wp.pl", new DateTime(1980, 1, 1), 1);

            
            Assert.False(result);
        }

        [Fact]
        public void AddUser_Should_Throw_Exception_When_User_Does_Not_Exist()
        {
            
            Assert.Throws<ArgumentException>(() =>
            {
                _ = _userService.AddUser("John", "Unknown", "kowalski@wp.pl", new DateTime(1980, 1, 1), 100);
            });
        }

        [Fact]
        public void AddUser_Should_Throw_Exception_When_User_No_Credit_Limit_Exists_For_User()
        {
            
            Assert.Throws<ArgumentException>(() =>
            {
                _ = _userService.AddUser("John", "Andrzejewicz", "andrzejewicz@wp.pl", new DateTime(1980, 1, 1), 6);
            });
        }
    }
}
