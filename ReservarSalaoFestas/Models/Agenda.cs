using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservarSalaoFestas.Models
{
    public class Agenda
    {
        public Agenda()
        {
            DataAtualizacao = System.DateTime.Now;
        }

        [Key]
        public int AgendaId { get; set; }

        [Display(Name = "Data da Reserva")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "A data é obrigatória", AllowEmptyStrings = false)]
        public DateTime DataReserva { get; set; }

        [Display(Name = "Descrição do Evento")]
        [StringLength(100, ErrorMessage = "A Descrição do Evento deve possuir no máximo 100 caracteres")]
        public String Evento { get; set; }

        [Display(Name = "Quantidade de Pessoas")]
        [Required(ErrorMessage = "A Quantidade de Pessoas é obrigatório", AllowEmptyStrings = false)]
        [Range(1, 40, ErrorMessage = "Lotação máxima de 40 pessoas")]
        public int QtdePessoas { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataAtualizacao { get; set; }

        [ScaffoldColumn(false)]
        [ForeignKey("Cliente")]
        public string UserId { get; set; }
        public virtual ApplicationUser Cliente { get; set; }
    }

    public class AgendaEditView
    {
        public int AgendaId { get; set; }

        [Display(Name = "Data da Reserva")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "A data é obrigatória", AllowEmptyStrings = false)]
        public DateTime DataReserva { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataReservaOriginal { get; set; }

        [Display(Name = "Descrição do Evento")]
        [StringLength(100, ErrorMessage = "A Descrição do Evento deve possuir no máximo 100 caracteres")]
        public String Evento { get; set; }

        [Display(Name = "Quantidade de Pessoas")]
        [Required(ErrorMessage = "A Quantidade de Pessoas é obrigatório", AllowEmptyStrings = false)]
        [Range(1, 40, ErrorMessage = "Lotação máxima de 40 pessoas")]
        public int QtdePessoas { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataAtualizacao { get; set; }

        [ScaffoldColumn(false)]
        [ForeignKey("Cliente")]
        public string UserId { get; set; }
        public virtual ApplicationUser Cliente { get; set; }
    }
}
