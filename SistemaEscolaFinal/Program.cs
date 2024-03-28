using System;

namespace SistemaEscolaFinal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Professor professor = null;
            Disciplina matematica = new Disciplina(121, "Matemática");
            Turma turma = null;
            int op;

            do
            {
                MostrarOpcoes();
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        if (turma == null)
                        {
                            Console.WriteLine("Crie uma turma primeiro.");
                        }
                        else
                        {
                            AdicionarAluno(turma);
                        }
                        break;

                    case 2:
                        AbrirTurma(ref turma, professor, matematica);
                        break;

                    case 3:
                        GerarPauta(turma);
                        break;

                    case 4:
                        professor = GerarProfessor();
                        break;

                    case 0:
                        Console.WriteLine("Sistema encerrado");
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (op != 0);
        }

        static void MostrarOpcoes()
        {
            Console.WriteLine("\nSelecionar uma opção:");
            Console.WriteLine("1. Adicionar Aluno");
            Console.WriteLine("2. Abrir turma");
            Console.WriteLine("3. Gerar pauta");
            Console.WriteLine("4. Gerar Professor");
            Console.WriteLine("0. Sair");
        }

        static Professor GerarProfessor()
        {
            Console.WriteLine("Digite o nome do professor:");
            string nomeProfessor = Console.ReadLine();
            Console.WriteLine("Digite a matrícula do professor:");
            int matriculaProfessor = int.Parse(Console.ReadLine());

            return new Professor(matriculaProfessor, nomeProfessor);
        }

        static void AdicionarAluno(Turma turma)
        {
            Console.WriteLine("Digite o nome do aluno: ");
            string nomeAluno = Console.ReadLine();

            Console.WriteLine("Digite a matrícula do aluno: ");
            int matriculaAluno = int.Parse(Console.ReadLine());

            Aluno aluno = new Aluno(matriculaAluno, nomeAluno);
            Console.WriteLine(turma.AdicionarAluno(aluno));
        }

        static void AbrirTurma(ref Turma turma, Professor professor, Disciplina disciplina)
        {
            if (professor == null)
            {
                Console.WriteLine("Crie um professor primeiro.");
                return;
            }

            if (turma == null)
            {
                Console.WriteLine("Digite a quantidade mínima de alunos para a turma:");
                int quantidadeMinima = int.Parse(Console.ReadLine());

                if (quantidadeMinima < 2)
                {
                    Console.WriteLine("A quantidade mínima de alunos para uma turma deve ser de pelo menos 2.");
                    return;
                }

                if (quantidadeMinima > 10)
                {
                    Console.WriteLine("A quantidade mínima de alunos para uma turma não pode exceder 10.");
                    return;
                }

                turma = new Turma(1, disciplina, professor);
                turma.Professor = professor;
                Console.WriteLine("Turma criada com sucesso.");
            }
            else
            {
                Console.WriteLine("A turma já foi criada.");
            }
        }

        static void GerarPauta(Turma turma)
        {
            if (turma == null)
            {
                Console.WriteLine("Crie uma turma primeiro.");
                return;
            }

            Console.WriteLine(turma.gerarPauta());
        }
    }
}