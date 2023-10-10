using System;
using System.Collections.Generic;

namespace AgendaServicios.Web.Models;

public partial class Turno
{
    public int TurnoId { get; set; }

    public DateTime FechaTurno { get; set; }

    public TimeSpan HoraTurno { get; set; }

    public int EstadoTurnoId { get; set; }

    public int? ClienteId { get; set; }

    public int? ServicioId { get; set; }

    public string? Observacion { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual EstadosTurno EstadoTurno { get; set; } = null!;

    public virtual Servicio? Servicio { get; set; }
}
