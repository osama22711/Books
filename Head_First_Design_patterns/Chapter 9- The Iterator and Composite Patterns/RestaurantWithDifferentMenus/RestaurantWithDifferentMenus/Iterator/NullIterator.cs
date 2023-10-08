using System.Collections;

namespace RestaurantWithDifferentMenus.Iterator
{
    public class NullIterator : IEnumerator
    {
        public object? Current => null;

        public bool MoveNext()
        {
            return false;
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }
    }
}
