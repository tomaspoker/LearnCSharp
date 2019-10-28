using System;
namespace LearnCSharp
{
    public class MyList<T>
    {
        const int c_DefaultCapacity = 4;

        T[] m_Items;
        int m_Count;

        public MyList(int capacity = c_DefaultCapacity)
        {
            m_Items = new T[capacity];
        }

        public int Count => m_Count;

        public int Capacity
        {
            get { return m_Items.Length; }
            set
            {
                if (value < m_Count) value = m_Count;
                if (value != m_Items.Length)
                {
                    T[] items = new T[value];
                    Array.Copy(m_Items, 0, items, 0, m_Count);
                    m_Items = items;
                }
            }
        }

        public T this[int index]
        {
            get
            {
                return m_Items[index];
            }
            set
            {
                m_Items[index] = value;
                OnChanged();
            }
        }

        public void Add(T item)
        {
            if (m_Count == Capacity) Capacity = m_Count * 2;
            m_Items[m_Count] = item;
            m_Count++;
            OnChanged();
        }

        protected virtual void OnChanged() => Changed?.Invoke(this, EventArgs.Empty);

        public override bool Equals(object other) => Equals(this, other as MyList<T>);

        static bool Equals(MyList<T> a, MyList<T> b)
        {
            if (Object.ReferenceEquals(a, null)) return Object.ReferenceEquals(b, null);
            if (Object.ReferenceEquals(b, null) || a.Count != b.Count) return false;

            for (int i = 0; i < a.Count; i++)
            {
                if (!object.Equals(a.m_Items[i], b.m_Items[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public event EventHandler Changed;

        public static bool operator ==(MyList<T> a, MyList<T> b) => Equals(a, b);
        public static bool operator !=(MyList<T> a, MyList<T> b) => !Equals(a, b);
    }
}
