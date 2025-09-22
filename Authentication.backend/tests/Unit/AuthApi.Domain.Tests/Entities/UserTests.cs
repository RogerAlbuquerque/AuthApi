namespace AuthApi.Domain.Tests.Entities;

public class UserTests
{
    [Fact]
    public void Should_Create_User_With_Valid_Data()
    {
        //Arrange
        string email = "test@gmail.com";
        string hashPassword = "abcde12345";

        //Act
        User user = new User(email, hashPassword);

        //Assert
        Assert.Equal(email, user.Email);
        Assert.Contains("@", user.Email);
        Assert.NotNull(user.Email);
        Assert.Equal(hashPassword, user.PasswordHash);
        Assert.NotNull(user.PasswordHash);


    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("invalidemail.com")]
    public void Should_Throw_When_Email_Is_Invalid(string invalidEmail)
    {

        var exception = Assert.Throws<ArgumentException>(() => new User(invalidEmail, "abcde12345"));
        // Console.WriteLine("===========================================================================");
        // Console.WriteLine(exception);
        // Console.WriteLine("===========================================================================");
        Assert.Contains("email", exception.Message);
    }

    [Fact]
    public void Should_Return_True_When_PasswordHash_Matches()
    {
        // Arrange
        var user = new User("test@email.com", "hashed123");

        // Act
        var result = user.VerifyPassword("hashed123");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Should_Return_False_When_PasswordHash_Does_Not_Match()
    {
        // Arrange
        var user = new User("test@email.com", "hashed123");

        // Act
        var result = user.VerifyPassword("wrongHash");

        // Assert
        Assert.False(result);
    }
}