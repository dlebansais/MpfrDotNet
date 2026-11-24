namespace MpirDotNet
{
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="count">The count.</param>
    public class bitcount_t(ulong count)
    {
        /// <summary>
        /// Gets the count.
        /// </summary>
        public ulong Count { get; } = count;
    }
}
