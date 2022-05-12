namespace Promat.Windows.FirewallManagement
{
    /// <summary>
    /// Especifica que el tráfico generado por el servicio identificado coincide con esta regla.
    /// </summary>
    public enum ServiceEnum
    {
        /// <summary>
        /// NotSet. Este campo no es obligatorio y este el valor por defecto
        /// </summary>
        NotSet,
        /// <summary>
        /// El ServiceShortName para un servicio se puede encontrar en el complemento Servicios de MMC, haciendo clic con el botón derecho en el servicio, seleccionando Propiedades y examinando el Nombre del servicio.
        /// </summary>
        ServicesShortName,
        /// <summary>
        /// Si no se especifica el servicio, el tráfico de red generado por cualquier programa o servicio coincide con esta regla.
        /// </summary>
        Any
    }
}