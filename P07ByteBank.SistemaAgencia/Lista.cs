﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07ByteBank.SistemaAgencia
{
    public class Lista<T>
    {
        private T[] _itens;
        private int _proximaPosicao;

        public Lista(int capacidadeInicial = 5) // 5 vira um valor inicial e padrão de 5
        {
            _itens = new T[capacidadeInicial];
            _proximaPosicao = 0;
        }
        public int Tamanho { get { return _proximaPosicao; } }
        public void Adicionar(T item)
        {
            VerificarCapacidade(_proximaPosicao + 1);
            //Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");

            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }
        public void AdicionarVarios(params T[] itens) //params para receber mais de uma paramêtro
        {
            foreach (T item in itens)
            {
                Adicionar(item);
            }
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }

            int novoTamanho = _itens.Length * 2;

            if (novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }

            //Console.WriteLine("Aumentando a capacidade da lista");

            T[] novoArray = new T[novoTamanho];

            for (int i = 0; i < _itens.Length; i++)
            {
                novoArray[i] = _itens[i];
                //Console.WriteLine("interando");
            }

            _itens = novoArray;
        }

        public void Remover(T item)
        {
            int indiceItem = -1;

            for (int i = 0; i < _proximaPosicao; i++)
            {
                object itemAtual = _itens[i];
                if (itemAtual.Equals(item))
                {
                    indiceItem = i;
                    break;
                }
            }

            for (int i = indiceItem; i < _proximaPosicao - 1; i++)
            {
                _itens[i] = _itens[i + 1];
            }

            _proximaPosicao--;
            //_itens[_proximaPosicao] = null;

        }

        public T GetItemNoIndice(int indice)
        {
            if (indice < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }

        public T this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }
    }
}
