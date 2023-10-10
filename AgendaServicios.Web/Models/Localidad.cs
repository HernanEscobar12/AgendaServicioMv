using System;
using System.Collections.Generic;

namespace AgendaServicios.Web.Models;

public partial class Localidad
{
    public int LocalidadId { get; set; }

    public string Descripcion { get; set; } = null!;

    public int ProvinciaId { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Provincia? Provincia { get; set; } = null!;
}
