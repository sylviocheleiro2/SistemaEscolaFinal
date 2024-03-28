using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolaFinal
{
    internal class Turma
    {
        public int Codigo { get; set; }
        public Disciplina Disciplina { get; set; }
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();
        public Professor Professor { get; set; }
        public Turma(int codigo, Disciplina disciplina, Professor professor)
        {
            Codigo = codigo;
            Disciplina = disciplina;
            Professor = professor;
        }

        public string AdicionarAluno(Aluno aluno)
        {
            if (Alunos.Count < 10)
            {
                Alunos.Add(aluno);
                return "Aluno adicionado";

            }
            else
            {
                return "Turma cheia";
            }

        }
        public Boolean abrirTurma()
        {
            return Alunos.Count >= 2 && Alunos.Count <= 10;
        }
        public string gerarPauta()
        {
            if (abrirTurma())
            {
                string pauta = $"Código da turma: {Codigo}\n";
                pauta += $"Disciplina: {Disciplina.Nome}\n";
                pauta += $"Professor: {Professor.Nome}\n";
                pauta += ("Lista de alunos:\n");
                foreach (var aluno in Alunos)
                {
                    pauta += $"{aluno.Nome}\n";
                }

                return pauta;

            }
            else
            {
                return "Nenhuma turma aberta, pois não tem alunos o suficite.";
            }


        }
    }
}