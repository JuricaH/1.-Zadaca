using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Zadaca
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;
        #region konstruktori
        public GenericList()
        {
            _internalStorage = new X[4];
        }

        public GenericList(int initialSize)
        {
            _internalStorage = new X[initialSize];
        }
        #endregion

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator() 
        {
            return GetEnumerator();
        }

        #region implementacija sučelja
        public void Add(X item)
        {
            for(int i=0;i<_internalStorage.Length;i++)
            {
                if(_internalStorage[i]==null){
                    _internalStorage[i]=item;
                    return;
                }
                if (i == _internalStorage.Length-1)
                {
                    GenericList<X> temp = new GenericList<X>(2 * _internalStorage.Length);
                    _internalStorage.CopyTo(temp._internalStorage,0);
                    _internalStorage = temp._internalStorage;
                }
            }
        }

        public bool RemoveAt(int Index)
        {
            if (Index > _internalStorage.Length || _internalStorage[Index]==null)
            {
                return false;
            }
            for(int i=Index;i<_internalStorage.Length-1;i++){//do predzadnjeg
                _internalStorage[i]=_internalStorage[i+1];
            }
            _internalStorage[_internalStorage.Length-1]=default(X);
            return true;
        }

        public bool Remove(X item)
        {
            //pronađi;
            int i;
            for(i=0;i<_internalStorage.Length && !(_internalStorage[i].Equals(item));i++);
            if (i<_internalStorage.Length)
                return RemoveAt(i);//pozicija od X
            else
                return false;
        }

        public X GetElement(int Index)
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
            return default(X);//što sad vratiti?
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i].Equals(item))
                    return i;
            }
            return default(int);
        }

        public int Count 
        {
            get
            {
                for (int i = 0; i < _internalStorage.Length; i++) 
                {
                    if (_internalStorage[i] == null)
                        return i;
                }
                return _internalStorage.Length;
            }
        }

        public void Clear()
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                _internalStorage[i] = default(X);
            }
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < _internalStorage.Length; i++) 
            {
                if (_internalStorage[i].Equals(item))
                    return true;
            }
            return false;
        }
        #endregion

    }
}
