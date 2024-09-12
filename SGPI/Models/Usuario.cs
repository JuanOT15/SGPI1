using System;
using System.Collections.Generic;

#nullable disable

namespace SGPI.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Entrevista = new HashSet<Entrevistum>();
            Homologacions = new HashSet<Homologacion>();
            Pagos = new HashSet<Pago>();
            ProgramaUsuarios = new HashSet<ProgramaUsuario>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Genero { get; set; }
        public int? TipoDoc { get; set; }
        public string Documento { get; set; }
        public int? Programa { get; set; }
        public string Email { get; set; }
        public int? Telefono { get; set; }
        public int? Rol { get; set; }
        public string Direccion { get; set; }
        public string Password { get; set; }
        public bool? Engresado { get; set; }

        public virtual Genero GeneroNavigation { get; set; }
        public virtual Rol RolNavigation { get; set; }
        public virtual TipoDocumento TipoDocNavigation { get; set; }
        public virtual ICollection<Entrevistum> Entrevista { get; set; }
        public virtual ICollection<Homologacion> Homologacions { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
        public virtual ICollection<ProgramaUsuario> ProgramaUsuarios { get; set; }
    }
}
