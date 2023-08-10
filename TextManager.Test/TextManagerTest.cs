using Xunit;
using System.Text.RegularExpressions;
namespace TextManager.Test;

public class TextManagerTest{
TextManager TextManagerGlobal;

public TextManagerTest()
{
    TextManagerGlobal = new TextManager("hola hola desde xunit");
}

    [Theory]
    [InlineData("Hola Mundo",2)]
    [InlineData("",0)]
    [InlineData("saludos a todos desde el curso de xunit",8)]
    public void CountWords(string text, int expected){
        //Arrange
        var textManager = new TextManager(text);

        //Act
        var result = textManager.CountWords();

        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(TextManagerClassData))]
    public void CountWords_ClassData(string text, int expected){
        //Arrange
        var textManager = new TextManager(text);

        //Act
        var result = textManager.CountWords();

        //Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CountWords_NotZero()
    {
        // Given
        var textManager = new TextManager("Tex");
        // When
        var result = textManager.CountWords();
        // Then
        Assert.NotEqual(0, result);
    }

    [Fact]
    public void FindWord()
    {
        // When
        var result = TextManagerGlobal.FindWord("Hola",true);
        // Then
        Assert.NotEmpty(result);
        Assert.Contains(0, result);
        Assert.Contains(5, result);
    }

     [Fact]
    public void FindWord_Empty()
    {
        // Given
        // When
        var result = TextManagerGlobal.FindWord("mundo",true);
        // Then
        Assert.Empty(result);
    }

    [Fact(Skip = "This test is not valid for the current code")]
    public void FindExactWord()
    {
        // When
        var result = TextManagerGlobal.FindExactWord("mundo",true);
        // Then
        Assert.IsType<List<Match>>(result);
    }

    [Fact]
    public void FindExactWord_Exception()
    {
        // When - Then
        //We need add function call in this line, because if we call this function before the exception will be thrown
        Assert.ThrowsAny<Exception>(()=> TextManagerGlobal.FindExactWord(null,true));
    }
}
