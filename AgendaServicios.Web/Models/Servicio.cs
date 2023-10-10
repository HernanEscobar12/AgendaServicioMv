using System;
using System.Collections.Generic;

namespace AgendaServicios.Web.Models;

public partial class Servicio
{
    public int ServicioId { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Duracion { get; set; }

    public string? Observacion { get; set; }

    public int TipoServicioId { get; set; }

    public virtual TiposServicio TipoServicio { get; set; } = null!;

    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
