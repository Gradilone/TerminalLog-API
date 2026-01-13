using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TerminalLog.Api.Models.Enums;

namespace TerminalLog.Api.Models
{
    public class Doca
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string CodigoDoca { get; set; } = string.Empty;
        public double? CapacidadePeso { get; set; } = 0.0;
        public TipoOperacao TipoOperacao { get; set; } = TipoOperacao.Carga;
        public StatusDoca Status { get; set; } = StatusDoca.Livre;
    }
}
