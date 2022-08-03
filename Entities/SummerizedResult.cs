using Entities.Utilities;

namespace Entities
{
    public class SummerizedResult
    {
        [PKey]
        public int Roll { get; set; }
        public string Name { get; set; }
        public decimal GPA { get; set; }
    }
}