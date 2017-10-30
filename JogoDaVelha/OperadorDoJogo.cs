using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JogoDaVelha
{
    public class OperadorDoJogo
    {
        public void MostrarTabuleiro(int[] tabuleiro)
        {
            string campo1 = tabuleiro[0] == 0 ? " " : Enum.GetName(typeof(CaracteresDeJogadorEnum), tabuleiro[0]);
            string campo2 = tabuleiro[1] == 0 ? " " : Enum.GetName(typeof(CaracteresDeJogadorEnum), tabuleiro[1]);
            string campo3 = tabuleiro[2] == 0 ? " " : Enum.GetName(typeof(CaracteresDeJogadorEnum), tabuleiro[2]);
            string campo4 = tabuleiro[3] == 0 ? " " : Enum.GetName(typeof(CaracteresDeJogadorEnum), tabuleiro[3]);
            string campo5 = tabuleiro[4] == 0 ? " " : Enum.GetName(typeof(CaracteresDeJogadorEnum), tabuleiro[4]);
            string campo6 = tabuleiro[5] == 0 ? " " : Enum.GetName(typeof(CaracteresDeJogadorEnum), tabuleiro[5]);
            string campo7 = tabuleiro[6] == 0 ? " " : Enum.GetName(typeof(CaracteresDeJogadorEnum), tabuleiro[6]);
            string campo8 = tabuleiro[7] == 0 ? " " : Enum.GetName(typeof(CaracteresDeJogadorEnum), tabuleiro[7]);
            string campo9 = tabuleiro[8] == 0 ? " " : Enum.GetName(typeof(CaracteresDeJogadorEnum), tabuleiro[8]);

            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {campo1}  |  {campo2}  |  {campo3}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {campo4}  |  {campo5}  |  {campo6}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {campo7}  |  {campo8}  |  {campo9}");
            Console.WriteLine("     |     |      ");
        }

        internal void JogadaDoComputador(int[] tabuleiro, bool usuarioEhX)
        {
            var listaDeEspaçosDisponiveis = tabuleiro.FindAllIndexof(0);

            var jogada = new Random().Next(listaDeEspaçosDisponiveis.Count());

            Console.WriteLine("Jogada do computador:");
            tabuleiro[listaDeEspaçosDisponiveis[jogada]] = usuarioEhX ? (int)CaracteresDeJogadorEnum.O : (int)CaracteresDeJogadorEnum.X;
            MostrarTabuleiro(tabuleiro);
        }

        internal bool ChegouAoFimDoJogo(int[] tabuleiro, bool usuarioEhX)
        {
            if (tabuleiro[0] != 0 && tabuleiro[0] == tabuleiro[1] && tabuleiro[1] == tabuleiro[2])
            {
                ChecarVencedor(tabuleiro[0], usuarioEhX);
                return true;
            }
            else if (tabuleiro[3] != 0 && tabuleiro[3] == tabuleiro[4] && tabuleiro[4] == tabuleiro[5])
            {
                ChecarVencedor(tabuleiro[3], usuarioEhX);
                return true;
            }  
            else if (tabuleiro[6] != 0 && tabuleiro[6] == tabuleiro[7] && tabuleiro[7] == tabuleiro[8])
            {
                ChecarVencedor(tabuleiro[5], usuarioEhX);
                return true;
            }
     
            else if (tabuleiro[0] != 0 && tabuleiro[0] == tabuleiro[3] && tabuleiro[3] == tabuleiro[6])
            {
                ChecarVencedor(tabuleiro[0], usuarioEhX);
                return true;
            }
            else if (tabuleiro[1] != 0 && tabuleiro[1] == tabuleiro[4] && tabuleiro[4] == tabuleiro[7])
            {
                ChecarVencedor(tabuleiro[1], usuarioEhX);
                return true;
            }
            else if (tabuleiro[2] != 0 && tabuleiro[2] == tabuleiro[5] && tabuleiro[5] == tabuleiro[8])
            {
                ChecarVencedor(tabuleiro[2], usuarioEhX);
                return true;
            }
            
            else if (tabuleiro[0] != 0 && tabuleiro[0] == tabuleiro[4] && tabuleiro[4] == tabuleiro[8])
            {
                ChecarVencedor(tabuleiro[0], usuarioEhX);
                return true;
            }
            else if (tabuleiro[2] != 0 && tabuleiro[2] == tabuleiro[4] && tabuleiro[4] == tabuleiro[6])
            {
                ChecarVencedor(tabuleiro[2], usuarioEhX);
                return true;
            }
            else if (tabuleiro.All(x => x != 0))
            {
                Empate();
                return true;
            }

            return false;
        }

        private void Empate()
        {
            Console.WriteLine("O jogo empatou!");
        }

        private void ChecarVencedor(int caracterVencedor, bool usuarioEhX)
        {
            var vencedor = Enum.GetName(typeof(CaracteresDeJogadorEnum), caracterVencedor);
            if (vencedor == "X" && usuarioEhX || vencedor == "O" && !usuarioEhX)
            {
                UsuarioVenceu();
            }
            else
            {
                ComputadorVenceu();
            }
        }

        private void ComputadorVenceu()
        {
            Console.WriteLine("O computador venceu! U suck boy");
        }

        private void UsuarioVenceu()
        {
            Console.WriteLine("Parabéns, você venceu!");
        }

        public void JogadaDoUsuario(int[] tabuleiro, bool usuarioEhX)
        {
            Console.WriteLine("Escolha uma posição de 1 a 9 para fazer sua jogada");
            var jogada = int.Parse(Console.ReadLine());

            if (tabuleiro[jogada - 1] != 0)
            {
                Console.WriteLine("Esse local já esta preenchido");
                Console.ReadKey();
                throw new InvalidOperationException();
            }

            tabuleiro[jogada - 1] = usuarioEhX ? (int)CaracteresDeJogadorEnum.X : (int)CaracteresDeJogadorEnum.O;

            MostrarTabuleiro(tabuleiro);
        }
    }

    public static class EM
    {
        public static int[] FindAllIndexof<T>(this IEnumerable<T> values, T val)
        {
            return values.Select((b, i) => object.Equals(b, val) ? i : -1).Where(i => i != -1).ToArray();
        }
    }
}
