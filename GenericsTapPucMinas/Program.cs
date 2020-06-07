using System;

namespace GenericsTapPucMinas
{
    class Program
    {
        static void Main(string[] args)
        {
            var fila = new FilaGenerica<string>(3);
            fila.Enfileirar("Lucas");
            fila.Enfileirar("Mika");
            fila.Enfileirar("Jeffin");

            Console.WriteLine(fila.Desenfileirar());
            Console.WriteLine(fila.Desenfileirar());
            Console.WriteLine(fila.Desenfileirar());

            fila.Enfileirar("Alana");
            fila.Enfileirar("Michelly");

            Console.WriteLine(fila.Desenfileirar());
            Console.WriteLine(fila.Desenfileirar());

            fila.Enfileirar("Jania");
            Console.WriteLine(fila.Desenfileirar());
        }
    }

    class FilaGenerica<T> : IFila<T>
    {
        private int _inicio;
        private int _capacidade;
        public int Total { get; private set; }
        T[] itens;

        public FilaGenerica(int capacidade)
        {
            itens = new T[capacidade];
            Total = 0;

            _inicio = 0;
            _capacidade = capacidade;
        }

        public T Desenfileirar()
        {
            T item = itens[_inicio];
            Total--;
            _inicio++;
            return item;
        }

        public void Enfileirar(T item)
        {
            if (_inicio + Total >= _capacidade)
                _inicio = 0;

            int posicao = _inicio + Total;

            itens[posicao] = item;
            Total++;
        }
    }

    interface IFila<T>
    {
        void Enfileirar(T item);
        T Desenfileirar();
    }
}
