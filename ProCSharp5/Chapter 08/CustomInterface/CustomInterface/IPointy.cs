
namespace CustomInterface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// An interface
    /// </summary>
    interface IPointy
    {
        byte Points { get; }

        byte GetNumberOfPoints();
    }
}
