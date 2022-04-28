using System;
using System.Collections.Generic;

#nullable disable

namespace SGPI.Models
{
    public partial class ProgramaUsuario
    {
        public int IdProgramaUsu { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdPrograma { get; set; }

        public virtual Usuario IdPrograma1 { get; set; }
        public virtual Programa IdProgramaNavigation { get; set; }
    }
}
