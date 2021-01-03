using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RealDelusion.Utils {
    public class RandomUtils {
        // T es un identificador para que sea cualquier tipo que le llegue, generico
        // IList acepta tanto listas como arrays
        public static T Choose<T> (IList<T> options) {
            return options[Random.Range (0, options.Count)];
        }

        public static void Shuffle<T> (IList<T> options) {
            // Cuantos elementos tenemos
            int n = options.Count;
            while (n > 0) {
                // Restamos 1
                n--;

                // Valor aleatorio de los otros
                int k = Random.Range (0, n);

                // Cogemos el ultimo valor
                T temp = options[n];

                // Muevo el random a la ultima posicion
                options[n] = options[k];

                // Muevo el que era el ultimo a la posicion del temporal
                options[k] = temp;
            }
        }

        public static T RandomWeighted<T> (Dictionary<T, int> options) {
            // Add all weights (automatically grabs the int's)
            int totalWeigths = options.Values.Sum ();
            int k = Random.Range (0, totalWeigths);

            foreach (KeyValuePair<T, int> item in options) {
                if (k < item.Value) {
                    return item.Key;
                } else {
                    k -= item.Value;
                }
            }

            // Return the 'null' default type for type T
            return default (T);
        }
    }

    /// <summary>
    /// Clase para ganerar valores aleatorios, pudiendo condicionarlos a cuál ha sido
    /// el anterior.
    /// </summary>
    /// <typeparam name="T">Tipo de los valores</typeparam>
    public class ConditionalRandom<T> {
        Dictionary<T, T[]> _items;

        List<T> _startItems;

        T _lastItem = default (T);

        bool firstRun = true;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="items">Dictionary que contiene como key los valores
        /// y como value un Array con las opciones para la siguiente generación. 
        /// Si se establece un value null o con longitud 0, se toman todas las keys del Dictionary.</param>
        /// <param name="start">Array con los valores permitidos en la primera generación.</param>
        public ConditionalRandom (Dictionary<T, T[]> items, T[] start = null) {
            _items = items;
            _startItems = start == null ? new List<T> (_items.Keys) : new List<T> (start);
        }

        /// <summary>
        /// Obtiene el siguiente valor aleatorio según las condiciones establecidas.
        /// </summary>
        /// <returns>Un valor aleatorio</returns>
        public T Next () {
            T result = default (T);

            if (firstRun || _items[_lastItem] == null || _items[_lastItem].Length == 0) {
                result = RandomUtils.Choose<T> (firstRun ? _startItems : new List<T> (_items.Keys));
                firstRun = false;
            } else {
                result = RandomUtils.Choose<T> (_items[_lastItem]);
            }

            _lastItem = result;
            return result;
        }

        /// <summary>
        /// Reinicia la generación de valores aleatorios.
        /// </summary>
        /// <param name="start">Sustutuye lo valores permitidos en la primera generación</param>
        public void Reset (T[] start) {
            _startItems = new List<T> (start);
            Reset ();
        }

        /// <summary>
        /// Reinicia la generación de valores aleatorios.
        /// </summary>
        public void Reset () {
            firstRun = true;
        }
    }
}