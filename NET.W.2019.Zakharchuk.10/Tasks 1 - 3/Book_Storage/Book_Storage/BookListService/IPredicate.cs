namespace Book_Storage
{
    internal interface IPredicate<T>
    {
        bool IsMatch(T tag);
    }
}
