using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Task14.Exceptions;

namespace Task14
{
    internal class myList<T>
    {
        T[] myArray;
        public int Capacity { get; } = 5;
        public int Count { get; private set; }
        
        public T this[int index]
        {
            get => myArray[index];
            set => myArray[index] = value;
        }        

        public myList(int capacity):this()
        {
            Capacity = capacity >= 0 ? capacity : 5; 
        }

        public myList(params T[] item)
        {
            myArray = item;
            Count = myArray.Length;
        }

        public myList()
        {
            myArray = new T[Capacity];
        }

        public void Add(T item)
        {
            if(Count == myArray.Length)           
                Array.Resize(ref myArray, myArray.Length + Capacity);
            myArray[Count++] = item;
        }

        public void Clear()
        {
            #region Yol 1 Uyğun massivin elementləri sıfır və ya standart dəyərlə doldurulur. Bu yanaşma cari kataloqun ölçüsünü saxlamaq və məzmununu sıfırlamaq istədiyiniz hallarda faydalı ola bilər.
            Array.Clear(myArray, 0, Count);
            Count = 0;
            #endregion
            myArray = new T[0];
        }

        public bool Exist(T item)
        {
            foreach (var arrayItem in myArray)
            {
                if(arrayItem.Equals(item))
                    return true;
            }
            return false;
        }
    
        public int IndexOf(T item)
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i].Equals(item))
                    return i;
            }
            return -1;
        }

        public int LastIndexOf(T item)
        {
            for (int i = Count - 1; 0 <= i; i--)
            {
                if (myArray[i].Equals(item))
                    return i;
            }
            return -1;
        }
        
        public void Remove(T item)
        {
            if (Exist(item)) 
            {
                RemoveAt(IndexOf(item));
            }
        }
        
        #region Yol 1 Reverse
        //public void Reverse()
        //{
        //    Array.Reverse(myArray);
        //}
        #endregion
        public void Reverse()
        {
            if(Count == 0)
                throw new InvalidValueException(ExceptionsMessage.InvalidValueExceptionMessage);
            for (int i = 0; i < Count / 2; i++)
                {
                    T firstValue = myArray[i];
                    myArray[i] = myArray[Count - i - 1];
                    myArray[Count - i - 1] = firstValue;
                }
        }
        
        public void RemoveAt(int index)
        {
            if (index <= 0 || Count < index)
                throw new InvalidValueException(ExceptionsMessage.InvalidValueExceptionMessage);

            Array.Copy(myArray, index + 1, myArray, index, Count - index - 1);
            Count--;
            myArray[Count] = default(T);
        }
    }
}
