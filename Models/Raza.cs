namespace AiRpgBackend.Models
{

    public enum TipoRaza
    {
        Natural,
        Monstruo,
        hibrido,
        condicion,
    }

    public enum CategoriaRaza
    {
        RazaNatural,
        RazaMonstruosa
    }

    public enum TierPoder
    {
        F, E, D, C, B, A, S, SS, Z, Zplus, Zplusplus
    }

    public abstract class RazaBase
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public TipoRaza Tipo { get; set; }
        public CategoriaRaza Categoria { get; set; }

        // Características biológicas
        public CaracteristicasBiologicas Biologia { get; set; }

        // Capacidades mágicas integradas
        public bool PuedeDespertarHabilidades { get; set; } = true;
        public double PorcentajeDespertar { get; set; } = 0.93; // 93% por defecto
        public int EdadDespertarMin { get; set; }
        public int EdadDespertarMax { get; set; }
        public string EspecialidadMagica { get; set; }

        // Habilidades raciales
        public HabilidadRacial HabilidadRacial { get; set; }

        // Distribución geográfica
        public DistribucionGeografica Distribucion { get; set; }

        // Cultura y economía
        public List<string> ValoresCulturales { get; set; }
        public List<string> EspecialidadesEconomicas { get; set; }

        // Sistema de evolución
        public List<NivelEvolucion> SistemasEvolucion { get; set; }

        protected RazaBase()
        {
            ValoresCulturales = new List<string>();
            EspecialidadesEconomicas = new List<string>();
            SistemasEvolucion = new List<NivelEvolucion>();
        }
    }

    // Clases específicas para razas naturales
    public class RazaNatural : RazaBase
    {
        public RazaNatural()
        {
            Categoria = CategoriaRaza.RazaNatural;
        }
    }

    // Clases específicas para razas monstruosas
    public class RazaMonstruosa : RazaBase
    {
        public RazaMonstruosa()
        {
            Categoria = CategoriaRaza.RazaMonstruosa;
        }
    }

    public class CaracteristicasBiologicas
    {
        public string AlturaPromedio { get; set; }
        public string PesoPromedio { get; set; }
        public string ExpectativaVida { get; set; }
        public List<string> RasgosDistintivos { get; set; }
        public bool TieneGenero { get; set; }
        public List<Subraza> Subrazas { get; set; }
        public string NotasEspeciales { get; set; }

        // Para razas específicas
        public string EnvergaduraAlas { get; set; } // Arpías
        public string EstructuraSocial { get; set; } // Arpías: Matriarcado

        public CaracteristicasBiologicas()
        {
            RasgosDistintivos = new List<string>();
            Subrazas = new List<Subraza>();
        }
    }

    public class Subraza
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
    }

    public class HabilidadRacial
    {
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public List<string> Ejemplos { get; set; }

        public HabilidadRacial()
        {
            Ejemplos = new List<string>();
        }
    }

    public class DistribucionGeografica
    {
        public Dictionary<string, string> RegionesPrimarias { get; set; }
        public Dictionary<string, string> RegionesSecundarias { get; set; }
        public string PorcentajeGlobal { get; set; }
        public string NotasEspeciales { get; set; }

        public DistribucionGeografica()
        {
            RegionesPrimarias = new Dictionary<string, string>();
            RegionesSecundarias = new Dictionary<string, string>();
        }
    }

    public class NivelEvolucion
    {
        public int Nivel { get; set; }
        public string Nombre { get; set; }
        public string RangoEdad { get; set; }
        public string PoderAproximado { get; set; }
        public TierPoder? TierMinimo { get; set; }
        public TierPoder? TierMaximo { get; set; }
        public string Caracteristicas { get; set; }
    }

    // Clases especiales para condiciones sobrenaturales
    public class CondicionSobrenatural
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Aclaracion { get; set; }
        public CaracteristicasPrincipales Caracteristicas { get; set; }
        public List<string> Origenes { get; set; }
        public CapacidadesMagicasCondicion CapacidadesMagicas { get; set; }
        public HabilidadRacial HabilidadRacial { get; set; }
        public DistribucionGeografica Distribucion { get; set; }
        public List<NivelEvolucion> SistemasEvolucion { get; set; }
        public string ControlPolitico { get; set; } // Para vampirismo

        public CondicionSobrenatural()
        {
            Origenes = new List<string>();
            SistemasEvolucion = new List<NivelEvolucion>();
        }
    }

    public class CaracteristicasPrincipales
    {
        public string Retienen { get; set; }
        public string Manifestacion { get; set; }
        public string CaracteristicaUniversal { get; set; }
    }

    public class CapacidadesMagicasCondicion
    {
        public string RetienenHabilidades { get; set; }
        public string NotaImportante { get; set; }
        public string AccesoInnato { get; set; }
    }

    public class ModuloRazasMundo
    {
        public MetadataModulo Metadata { get; set; }
        public string LinguaUniversal { get; set; }
        public string Longevidad { get; set; }

        // Listas de razas
        public List<RazaNatural> RazasNaturales { get; set; }
        public List<RazaMonstruosa> RazasMonstruosas { get; set; }
        public List<CondicionSobrenatural> CondicionesSobrenaturales { get; set; }

        // Resúmenes
        public Dictionary<string, string> ResumenDistribucionGlobal { get; set; }
        public NotasCriticasGlobales NotasCriticas { get; set; }

        public ModuloRazasMundo()
        {
            RazasNaturales = new List<RazaNatural>();
            RazasMonstruosas = new List<RazaMonstruosa>();
            CondicionesSobrenaturales = new List<CondicionSobrenatural>();
            ResumenDistribucionGlobal = new Dictionary<string, string>();
        }
    }

    public class MetadataModulo
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int TotalRazas { get; set; }
        public int CondicionesNoRaciales { get; set; }
        public string NotaCritica { get; set; }
    }

    public class NotasCriticasGlobales
    {
        public string SistemaNombres { get; set; }
        public string Despertar { get; set; }
        public string Lenguaje { get; set; }
        public string ConflictoFundamental { get; set; }
        public string EventoCritico { get; set; }
        public string PoderCosmico { get; set; }
    }
}
