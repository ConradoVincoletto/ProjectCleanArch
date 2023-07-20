using System.ComponentModel.DataAnnotations;

namespace WebApiIdentity.Entities
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        [Required, MaxLength(80, ErrorMessage = "Nome não pode exceder mais que 80 caracteres")]
        public string Nome { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public int Idade { get; set; }

        [MaxLength(80)]
        public string Curso { get; set; }
    }
}
