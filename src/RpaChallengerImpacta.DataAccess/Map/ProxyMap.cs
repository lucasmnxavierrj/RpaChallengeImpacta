using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpaChallengeImpacta.Domain.Models;

namespace RpaChallengerImpacta.DataAccess.Map
{
    public class ProxyMap : IEntityTypeConfiguration<Proxy>
    {
        public void Configure(EntityTypeBuilder<Proxy> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
