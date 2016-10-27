namespace UsingModalLogin.Infrastructure.Abstract
{
    internal abstract class MyJsonResult<T>
    {
        public bool HasError { get; set; }
        public T Result { get; set; }
    }
}