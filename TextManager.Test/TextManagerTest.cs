using Xunit;
using System.Text.RegularExpressions;
namespace TextManager.Test;

public class TextManagerTest{
TextManager TextManagerGlobal;

public TextManagerTest()
{
    TextManagerGlobal = new TextManager("hola hola desde xunit");
}

    [Fact]
    public void CountWords(){
        //Arrange
        var textManager = new TextManager("Texto Prueba");

        //Act
        var result = textManager.CountWords();

        //Assert
        Assert.Equal(2, result);
        Assert.True(result > 1);
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

    [Fact]
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
