using RestaurantWithDifferentMenus.Menus;
using System.Collections;

namespace RestaurantWithDifferentMenus.Iterator
{
    public class CompositeIterator : IEnumerator<object>
    {
        Stack<IEnumerator> stack = new Stack<IEnumerator>();

        public CompositeIterator(IEnumerator iterator)
        {
            stack.Push(iterator);
        }

        public object Current
        {
            get
            {
                if (MoveNext())
                {
                    var iterator = stack.Peek();
                    var component = (MenuComponent)iterator.Current;
                    if (component is Menu)
                    {
                        stack.Push(component.CreateIterator());
                    }
                    return component;
                }
                else
                {
                    return null;
                }
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            if (stack.Count == 0)
            {
                return false;
            }
            else
            {
                var iterator = (IEnumerator)stack.Peek();
                if (!iterator.MoveNext())
                {
                    stack.Pop();
                    return MoveNext();
                }
                else
                {
                    return true;
                }
            }
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}