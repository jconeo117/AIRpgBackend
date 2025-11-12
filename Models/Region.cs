using System.Collections.Generic;

namespace AiRpgBackend.Models;

public class Region
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public string Posicion { get; set; }
    public string Descripcion { get; set; }
    public Geografia Geografia { get; set; }
    public Poblacion Poblacion { get; set; }
    public Gobierno Gobierno { get; set; }
    public Economia Economia { get; set; }
    public Cultura Cultura { get; set; }
    public PoliticaExterna PoliticaExterna { get; set; }
    public List<string> PuntosDeInteres { get; set; }
    public List<string> AmenazasInternas { get; set; }
    public dynamic ConexionesConOtrasRegiones { get; set; }
}

public class Geografia
{
    public string Tipo { get; set; }
    public string Clima { get; set; }
    public List<string> CaracteristicasPrincipales { get; set; }
}

public class Poblacion
{
    public dynamic RazasDominantes { get; set; }
    public List<string> RazasPresentes { get; set; }
    public int PorcentajeUrbano { get; set; }
    public string PoblacionAproximada { get; set; }
}

public class Gobierno
{
    public string Tipo { get; set; }
    public string Descripcion { get; set; }
    public string Liderazgo { get; set; }
    public string IdeologiaPublica { get; set; }
    public string Secretos { get; set; }
}

public class Economia
{
    public string Especialidad { get; set; }
    public dynamic RecursosPrincipales { get; set; }
    public string Moneda { get; set; }
    public string DependenciaComercial { get; set; }
}

public class Cultura
{
    public string LenguajePrincipal { get; set; }
    public List<string> IdiomasSecundarios { get; set; }
    public List<string> ValoresCulturales { get; set; }
    public List<string> Festivales { get; set; }
}

public class PoliticaExterna
{
    public dynamic Alianzas { get; set; }
    public dynamic Enemigos { get; set; }
    public string Relaciones { get; set; }
    public string ConflictosPotenciales { get; set; }
}
