using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VMGest1.Models
{
    public class GestViewModels
    {
    }

    public class AzioniDettsViewModel
    {
        [Key]
        public int AzioniDett_Id { get; set; }
        [Display(Name = "Area indagine")]
        public int Area_Id { get; set; }
        public virtual Aree Aree { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descrizione azione")]
        public string Descrizione { get; set; }
        public int Azioni_Azioni_Id { get; set; }
    }
}