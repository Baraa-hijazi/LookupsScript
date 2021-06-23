namespace ScriptPopulator
{
    public class LookupItem
    {
        public int LookupItemId { set; get; }
        public string LookupItemName { set; get; }
        public string LookupItemCode { set; get; }
        public string Description { set; get; }
        public int? ParentLookupItemId { set; get; }
        public LookupItem ParentLookupItem { set; get; }
        public int LookupTypeId { set; get; }
        public LookupType LookupType { set; get; }
        public int? Order { get; set; }
        public string LookupItemParents { get; set; }
    }
}