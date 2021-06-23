using System.Collections.Generic;

namespace ScriptPopulator
{
    public class LookupType
    {
        public int LookupTypeId { get; set; }
        public string LookupTypeName { get; set; }
        public ICollection<LookupItem> LookupItems { get; set; }
        public string LookupTypeDescription{ get; set; }
        public int? Order { get; set; }
    }
}