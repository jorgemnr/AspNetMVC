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
        [Range(1, 40, ErrorMessage = "Lotação máxima de 40 adultos")]
        public int QtdePessoas { get; set; }

        [Display(Name = "Morador/Apto")]
        [Required(ErrorMessage = "O Morador/Apto é obrigatório", AllowEmptyStrings = false)]
        public int ClienteId { get; set; }

        [Display(Name = "Atualização")]
        [Editable(false)]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DataAtualizacao { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Clientes Clientes { get; set; }


    }
}