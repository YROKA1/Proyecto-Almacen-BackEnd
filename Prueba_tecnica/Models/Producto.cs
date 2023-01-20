using System;
using System.Collections.Generic;

namespace Prueba_tecnica.Models;

public partial class Producto
{
    public int Identificador { get; set; }

    public string Nombre { get; set; } = null!;

    public string Estado { get; set; } = null!;

	public string? Acciones { get; set; }
}
