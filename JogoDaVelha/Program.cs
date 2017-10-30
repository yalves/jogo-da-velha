using System;

namespace JogoDaVelha
{
    class Program
    {
        static void Main(string[] args)
        {
            Jogar();
            Console.ReadKey();
        }

        private static void Jogar()
        {
            int[] tabuleiro = new int[9];
            var operadorDoJogo = new OperadorDoJogo();
            bool usuarioEhX;


            Console.WriteLine("Olá, bem-vindo ao jogo da velha. \nPor favor, escolha X ou O");
            usuarioEhX = Console.ReadLine().ToString().ToUpper() == "X" ? true : false;

            operadorDoJogo.MostrarTabuleiro(tabuleiro);

            while (true)
            {
                operadorDoJogo.JogadaDoUsuario(tabuleiro, usuarioEhX);

                if (operadorDoJogo.ChegouAoFimDoJogo(tabuleiro, usuarioEhX))
                    break;

                operadorDoJogo.JogadaDoComputador(tabuleiro, usuarioEhX);

                if (operadorDoJogo.ChegouAoFimDoJogo(tabuleiro, usuarioEhX))
                    break;
            }

            Console.WriteLine("Deseja reiniciar o jogo? S/N");
            var reiniciar = Console.ReadLine();

            if (reiniciar.ToString().ToUpper() == "S")
            {
                Console.Clear();
                Jogar();
            }
        }
    }
}
