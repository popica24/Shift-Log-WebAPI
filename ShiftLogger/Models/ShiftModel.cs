using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShiftLogger.Models
{

    public class ShiftModel
    {
        public int ShiftModelId { get; set; }
        public DateTime StartOfShift { get; set; }
        public DateTime EndOfShift { get; set; }
        [ForeignKey("UserModelId")]
        public int UserModelId { get; set; }
    }
   
}
