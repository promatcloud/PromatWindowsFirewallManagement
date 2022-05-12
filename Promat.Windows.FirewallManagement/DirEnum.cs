namespace Promat.Windows.FirewallManagement
{
    /// <summary>
    /// Required.Especifica si esta regla coincide con el tráfico de red entrante o saliente.
    /// </summary>
    public enum DirEnum
    {
        /// <summary> 
        /// in. La regla coincide solo con el tráfico de red entrante que llega a la computadora.Esta regla aparece en el complemento Firewall de Windows con seguridad avanzada MMC en Reglas de entrada.
        /// </summary>
        In,
        /// <summary>
        /// out. La regla coincide solo con el tráfico de red saliente que envía la computadora.Esta regla aparece en el complemento Firewall de Windows con seguridad avanzada MMC en Reglas de salida. 
        /// </summary>
        Out
    }
}