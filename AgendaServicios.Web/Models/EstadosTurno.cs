using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgendaServicios.Web.Models;

public partial class EstadosTurno
{
    public int EstadoTurnoId { get; set; }
    [Display(Name = "Descripción del Tipo de Turno")]
    public string Descripcion { get; set; } = null!;
     
    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
