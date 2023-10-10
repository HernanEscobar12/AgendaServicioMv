using System;
using System.Collections.Generic;

namespace AgendaServicios.Web.Models;

public partial class TiposServicio
{
    public int TipoServicioId { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
