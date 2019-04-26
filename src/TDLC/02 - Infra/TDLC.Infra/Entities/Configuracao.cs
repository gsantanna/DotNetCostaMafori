using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDLC.Infra.Entities
{
    public class Configuracao
    {
        [Key]
        [StringLength(100)]
        [Required]
        public string Nome { get; set; }

        [Required]
        [StringLength(8000)]
        public string Valor { get; set; }
        

    }
}
