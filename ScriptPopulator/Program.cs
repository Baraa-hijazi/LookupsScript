using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace ScriptPopulator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await using var lookupItemContext = new LookupItemContext();
            var lookups = lookupItemContext.LookupItems.ToList();
            
            foreach (var lookup in lookups)
            {
                if (lookup.ParentLookupItemId == null) continue;
                var lookupItemsList = await GetLookupItems((int) lookup.ParentLookupItemId);
                lookup.LookupItemParents = lookupItemsList.ToJson();

                lookupItemContext.LookupItems.Update(lookup);
                await lookupItemContext.SaveChangesAsync();
            }
        }
        
        private static async Task<List<LookupDto>> GetLookupItems(int lookupItemId, ICollection<LookupDto> lookupsList = null)
        {
            lookupsList ??= new List<LookupDto>();
            
            await using var lookupItemContext = new LookupItemContext();
            var lookup = await lookupItemContext.LookupItems.Where(w => w.LookupItemId == lookupItemId)
                .Include(w => w.LookupType).SingleOrDefaultAsync();

            if (lookup == null) return null;
            
            lookupsList.Add(new LookupDto
            {
                LookupType = lookup.LookupType.LookupTypeName,
                LookupItemName = lookup.LookupItemName,
                LookupItemId = lookup.LookupItemId
            });
            
            if (lookup.ParentLookupItemId == null) return lookupsList.ToList();
            
            return await GetLookupItems((int) lookup.ParentLookupItemId, lookupsList);
        }
    }
}