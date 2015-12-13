using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Zadaca
{
    public class IntegerList: IIntegerList
    {
        private int[] _internalStorage;
        #region konstruktori
        public IntegerList()
        {
            _internalStorage = new int[4];
        }

        public IntegerList(int initialSize)
        {
            _internalStorage = new int[initialSize];
        }
        #endregion

        #region implementacija sučelja
        public void Add(int X)
        {
            for(int i=0;i<_internalStorage.Length;i++)
            {
                if(_internalStorage[i]==0){
                    _internalStorage[i]=X;
                    return;
                }
                if (i == _internalStorage.Length-1)
                {
                    IntegerList temp = new IntegerList(2 * _internalStorage.Length);
                    _internalStorage.CopyTo(temp._internalStorage,0);
                    _internalStorage = temp._internalStorage;
                }
            }
        }

        public bool RemoveAt(int Index)
        {
            if (Index > _internalStorage.Length || _internalStorage[Index]==0)
            {
                return false;
            }
            for(int i=Index;i<_internalStorage.Length-1;i++){//do predzadnjeg
                _internalStorage[i]=_internalStorage[i+1];
            }
            _internalStorage[_internalStorage.Length-1]=default(int);
            return true;
        }

        public bool Remove(int X)
        {
            //pronađi;
            int i;
            for(i=0;i<_internalStorage.Length && _internalStorage[i]!=X;i++);
            if (i<_internalStorage.Length)
                return RemoveAt(i);//pozicija od X
            else
                return false;
        }

        public int GetElement(int Index)
        {
            try
            {
                return _internalStorage[Index];//vrati element na poziciji Index
            }
            catch (IndexOutOfRangeException e)
            {
                System.Console.WriteLine(e.Message);
            }
            finally 
            {
                ;
            }
            return -1;//što vratiti kao int
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i] == item)
                    return i;
            }
            return -1;
        }

        public int Count 
        {
            get
            {
                for (int i = 0; i < _internalStorage.Length; i++) 
                {
                    if (_internalStorage[i] == 0)
                        return i;
                }
                return _internalStorage.Length;
            }
        }

        public void Clear()
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                _internalStorage[i] = default(int);
            }
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < _internalStorage.Length; i++) 
            {
                if (_internalStorage[i] == item)
                    return true;
            }
            return false;
        }
        #endregion

        #region primjer liste i ispisa
        public static void ListExample(IIntegerList listOfIntegers) 
        {
            listOfIntegers.Add(1); 
            listOfIntegers.Add(2); 
            listOfIntegers.Add(3); 
            listOfIntegers.Add(4); 
            listOfIntegers.Add(5); // lista je [1,2,3,4,5]

            // Mičemo prvi element liste. 
            listOfIntegers.RemoveAt(0); // Lista je [2,3,4,5]

            // Mičemo element liste čija je vrijednost "5". 
            listOfIntegers.Remove(5); // Lista je [2,3,4]

            Console.WriteLine(listOfIntegers.Count); // 3

            Console.WriteLine(listOfIntegers.Remove(100)); // false, nemamo element u vrijednosti 100

            Console.WriteLine(listOfIntegers.RemoveAt(5)); // false, nemamo ništa na poziciji 5

            // Brišemo sav sadržaj kolekcije 
            listOfIntegers.Clear();

            Console.WriteLine(listOfIntegers.Count); // 0 
        }
        #endregion

        /*#region Main
        public static void Main(String[] args)
        {
            Console.WriteLine("1. zadatak___________________");

            IntegerList tempList = new IntegerList();
            ListExample(tempList);

            Console.Read();
        }
        #endregion*/
    }
}
