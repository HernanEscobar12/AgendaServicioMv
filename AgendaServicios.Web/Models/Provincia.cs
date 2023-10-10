using System;
using System.Collections.Generic;

namespace AgendaServicios.Web.Models;

public partial class Provincia
{
    public int ProvinciaId { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Localidad> Localidades { get; set; } = new List<Localidad>();
}
