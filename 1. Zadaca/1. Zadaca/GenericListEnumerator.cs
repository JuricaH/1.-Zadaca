using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Zadaca
{
    public class GenericListEnumerator<T>: IEnumerator<T>
    {
        private IGenericList<T> _collection;
        private int currentPosition;
        public GenericListEnumerator(IGenericList<T> collection) 
        {
            _collection = collection;
            currentPosition = -1;         
        }

        public bool MoveNext() 
        { 
            // Zove se prije svake iteracije. 
            // Vratite true ako treba ući u iteraciju, false ako ne 
            // Hint: čuvajte neko globalno stanje po kojem pratite gdje se 
            // nalazimo u kolekciji 
            currentPosition++;
            return (currentPosition < _collection.Count);
        }

        public T Current 
        { 
            get 
            { 
                // Zove se na svakom ulasku u iteraciju 
                // Hint: Koristite stanje postavljeno u MoveNext() dijelu 
                // kako bi odredili što se zapravo vraća u ovom koraku 
                return _collection.GetElement(currentPosition);
            } 
        }

        object IEnumerator.Current 
        { 
            get 
            { 
                return Current; 
            } 
        }

        public void Dispose() 
        { 
            // Ignorirajte 
        }

        public void Reset() 
        { 
            // Ignorirajte 
        }
        
    }
}
