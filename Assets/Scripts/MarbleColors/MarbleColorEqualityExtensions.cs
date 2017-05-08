public static class MarbleColorEqualityExtensions
{
    public static bool ColorEquals(this MarbleColor x, MarbleColor y)
    {
        if (x == MarbleColor.Joker || y == MarbleColor.Joker)
        {
            return true;
        }
        else
        {
            return x == y;
        }
    }
}