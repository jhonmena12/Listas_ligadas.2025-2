using System;
using System.Collections.Generic;
using System.Linq;

namespace ListaLigadaLib
{
    public class ListaDobleLigada<T> where T : IComparable<T>
    {
        private Nodo<T> primero;
        private Nodo<T> ultimo;

        public void AdicionarOrdenado(T dato)
        {
            Nodo<T> nuevo = new Nodo<T>(dato);

            if (primero == null)
            {
                primero = ultimo = nuevo;
                return;
            }

            Nodo<T> actual = primero;
            while (actual != null && actual.Dato.CompareTo(dato) < 0)
                actual = actual.Siguiente;

            if (actual == primero)
            {
                nuevo.Siguiente = primero;
                primero.Anterior = nuevo;
                primero = nuevo;
            }
            else if (actual == null)
            {
                ultimo.Siguiente = nuevo;
                nuevo.Anterior = ultimo;
                ultimo = nuevo;
            }
            else
            {
                nuevo.Anterior = actual.Anterior;
                nuevo.Siguiente = actual;
                actual.Anterior.Siguiente = nuevo;
                actual.Anterior = nuevo;
            }
        }

        public IEnumerable<T> MostrarAdelante()
        {
            Nodo<T> actual = primero;
            while (actual != null)
            {
                yield return actual.Dato;
                actual = actual.Siguiente;
            }
        }

        public IEnumerable<T> MostrarAtras()
        {
            Nodo<T> actual = ultimo;
            while (actual != null)
            {
                yield return actual.Dato;
                actual = actual.Anterior;
            }
        }

        public void OrdenarDesc()
        {
            var lista = MostrarAdelante().OrderByDescending(x => x).ToList();
            primero = ultimo = null;
            foreach (var item in lista)
                AdicionarOrdenado(item);
        }

        public List<T> Modas()
        {
            var lista = MostrarAdelante().ToList();
            var grupos = lista.GroupBy(x => x);
            int max = grupos.Max(g => g.Count());
            return grupos.Where(g => g.Count() == max).Select(g => g.Key).ToList();
        }

        public bool Existe(T dato) =>
            MostrarAdelante().Any(x => x.CompareTo(dato) == 0);

        public bool EliminarUna(T dato)
        {
            Nodo<T> actual = primero;
            while (actual != null)
            {
                if (actual.Dato.CompareTo(dato) == 0)
                {
                    if (actual == primero)
                    {
                        primero = actual.Siguiente;
                        if (primero != null) primero.Anterior = null;
                    }
                    else if (actual == ultimo)
                    {
                        ultimo = actual.Anterior;
                        if (ultimo != null) ultimo.Siguiente = null;
                    }
                    else
                    {
                        actual.Anterior.Siguiente = actual.Siguiente;
                        actual.Siguiente.Anterior = actual.Anterior;
                    }
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }

        public int EliminarTodas(T dato)
        {
            int count = 0;
            while (EliminarUna(dato)) count++;
            return count;
        }

        public Dictionary<T, int> Grafico()
        {
            return MostrarAdelante().GroupBy(x => x)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}