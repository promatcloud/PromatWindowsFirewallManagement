using System;

namespace Promat.Windows.FirewallManagement
{
    /// <summary>
    /// Especifica los perfiles a los que se asigna la regla de firewall.La regla está activa en la computadora local solo cuando el perfil especificado está actualmente activo.
    /// Puede incluir varias entradas para el perfil separándolas con una coma.No incluya espacios.Si no se especifica el perfil, el valor predeterminado es any.
    /// </summary>
    [Flags]
    public enum ProfileEnum
    {
        /// <summary>
        /// NotSet. Este campo no es obligatorio y este el valor por defecto
        /// </summary>
        NotSet = 0,
        Private = 1,
        Domain = 2,
        Public = 4,
        Any = 7
    }
}