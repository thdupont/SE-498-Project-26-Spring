namespace Project498.WebApi.Services;

public class StringService : IStringService
{
    public string Reverse(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }

        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    //adding reversewords
    public string ReverseWords(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return string.Empty;
        }

        var words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Array.Reverse(words);
        return string.Join(" ", words);
    }
}
