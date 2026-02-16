using Project498.WebApi.Services;

namespace Project498.WebApi.Tests;

public class ReverseWordsTests
{
    private readonly StringService _stringService = new();

    [Fact]
    public void ReverseWords_SingleWord_ReturnSameWord()
    {
        var actual = _stringService.ReverseWords("Hello");
        Assert.Equal("Hello", actual);
    }

    [Fact]
    public void ReverseWords_TwoWords_ReversesOrder()
    {
        var actual = _stringService.ReverseWords("Hello World");
        Assert.Equal("World Hello", actual);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("  ", "")]
    [InlineData("hello", "hello")]
    [InlineData("Hello World", "World Hello")]
    [InlineData("  hello  world  ", "world hello")]
    [InlineData("a  b  c", "c b a")]
    public void ReverseWords_CommonCases(string input, string expected)
    {
        var actual = _stringService.ReverseWords(input);
        Assert.Equal(expected, actual);
    }
}