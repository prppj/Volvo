using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Volvo.Models
{
    public class Caminhao
    {
        public int CaminhaoID { get; set; }

        [Required(ErrorMessage = "O modelo é obrigatório", AllowEmptyStrings = false)]
        [Display(Name ="Modelo")]
        [ValidarModelos( new string[]{ "FH","FM" })]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O ano de fabricação é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Ano de Fabricação")]        
        public int AnoFabricacao { get; set; }

        [Required(ErrorMessage = "O ano do modelo é obrigatório", AllowEmptyStrings = false)]        
        [Display(Name = "Ano do Modelo")]        
        public int AnoModelo { get; set; }

        [Display(Name = "Cor")]
        public string Cor { get; set; }
        
        [Display(Name = "Nro. de Eixos")]
        public int NroEixos { get; set; }
    }
}
