using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservarSalaoFestas.Models
{
    public class Clientes
    {
        public Clientes()
        {
            DataAtualizacao = System.DateTime.Now;
        }

        [Key]
        public int ClienteId { get; set; }

        [StringLength(256)]
        [Display(Name = "Nome do Morador")]
        [Required(ErrorMessage = "O Nome Morador é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [StringLength(100)]
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Senha é obrigatório", AllowEmptyStrings = false)]
        public string Senha { get; set; }

        [StringLength(15)]
        [Display(Name = "Número do Celular")]
        public string Celular { get; set; }

        [StringLength(2)]
        [Display(Name = "Número do Apto")]
        [Required(ErrorMessage = "O Número do Apto é obrigatório", AllowEmptyStrings = false)]
        public string Apto { get; set; }

        [ScaffoldColumn(false)]
        //[DefaultValue("Getdate()")]
        public DateTime DataAtualizacao { get; set; }

        public virtual ICollection<Agenda> Agenda { get; set; }
    }
}