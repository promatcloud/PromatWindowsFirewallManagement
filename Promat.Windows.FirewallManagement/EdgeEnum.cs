namespace Promat.Windows.FirewallManagement
{
    /// <summary>
    /// Válido solo cuando dir=in. Especifica que el tráfico que atraviesa un dispositivo perimetral,
    /// como un enrutador habilitado para traducción de direcciones de red(NAT), entre el equipo local y el remoto coincide con esta regla.
    /// Las opciones deferapp y deferuser son válidas en equipos que ejecutan Windows 7 y Windows Server 2008 R2 únicamente.
    /// desde el dispositivo de borde.complemento. 
    /// </summary>
    public enum EdgeEnum
    {
        /// <summary>
        /// NotSet. Este campo no es obligatorio y este el valor por defecto
        /// </summary>
        NotSet,
        Yes,
        /// <summary>
        /// Si se establece en deferapp o deferuser, Windows permite que la aplicación o  el usuario se registre mediante programación con el firewall para recibir el tráfico de aplicaciones entrantes no solicitado
        /// </summary>
        Deferapp,
        /// <summary>
        /// Si se establece en deferapp o deferuser, Windows permite que la aplicación o  el usuario se registre mediante programación con el firewall para recibir el tráfico de aplicaciones entrantes no solicitado
        /// </summary>
        Deferuser,
        /// <summary>
        /// Si no se especifica el borde, el valor predeterminado es no. 
        /// </summary>
        No
    }
}