using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace VMGest1.Models
{
    [Authorize]
    // È possibile aggiungere dati di profilo dell'utente specificando altre proprietà della classe ApplicationUser. Per ulteriori informazioni, visitare http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenere presente che il valore di authenticationType deve corrispondere a quello definito in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Aggiungere qui i reclami utente personalizzati
            return userIdentity;
        }
    }
    public class Anagrafica
    {
        [Key]
        public int Anagrafica_Id { get; set; }
        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Cognome")]
        public string Cognome { get; set; }
        [Display(Name = "Indirizzo")]
        public string Indirizzo { get; set; }
        [Display(Name = "CAP")]
        public string CAP { get; set; }
        [Display(Name = "Città")]
        public string Città { get; set; }
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }
        [Display(Name = "Cellulare")]
        public string Cellulare { get; set; }
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name ="Codice fiscale")]
        public string CodiceFiscale { get; set; }
        [Required]
        [Display(Name ="Data di nascita")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascita { get; set; }
        [Display(Name ="Luogo di nascita")]
        public string LuogoNascita { get; set; }

        public virtual ICollection<Azioni> Azionis { get; set; }
    }

    public class Azioni
    {
        [Key]
        public int Azioni_Id { get; set; }
        [Display(Name ="Tipo azione")]
        public string Tipo { get; set; }
        public int Anagrafica_Id { get; set; }
        public virtual Anagrafica Anagrafica { get; set; }
        [Display(Name = "Data azione")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode =true)]
        public DateTime Data { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descrizione azione")]
        public string Descrizione { get; set; }
        public string Tmt { get; set; }
        public string Endfeel { get; set; }
        [Display(Name="Es diagnostica")]
        public string Diagnostica { get; set; }
        [Display(Name ="Traumi")]
        public string Traumi { get; set; }
        [Display(Name ="Int chirurgici")]
        public string Chirurgia { get; set; }
        [Display(Name ="Viscerale")]
        public string Viscerale { get; set; }
        [Display(Name ="Area dentale")]
        public string Dentale { get; set; }
        [Display(Name ="Area visiva")]
        public string Visiva { get; set; }

        public virtual ICollection<AzioniDett> AzioniDetts { get; set; }
    }

    public class AzioniDett
    {
        [Key]
        public int AzioniDett_Id { get; set; }
        [Display(Name = "Area indagine")]
        public int Area_Id { get; set; }
        public virtual Aree Aree { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descrizione azione")]
        public string Descrizione { get; set; }
        public int Azioni_Id { get; set; }
        public virtual Azioni Azioni { get; set; }

    }

    public class Aree
    {
        [Key]
        public int Area_Id { get; set; }
        [Display(Name = "Descrizione area")]
        public string Descrizione { get; set; }
        public bool Anamnesi { get; set; }
        public bool Valutazione { get; set; }
        public bool Trattamento { get; set; }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Anagrafica> Anagraficas { get; set; }
        public DbSet<Azioni> Azionis { get; set; }
        public DbSet<AzioniDett> AzioniDetts { get; set; }
        public DbSet<Aree> Arees { get; set; }

    }
}