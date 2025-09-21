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
        
        Assert.Contains("email", exception.Message);
    }
}