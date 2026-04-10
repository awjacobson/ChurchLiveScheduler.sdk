using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchLiveScheduler.sdk.Models;

public record GetAllResponse
{
    public IEnumerable<SeriesDto> Series { get; init; }
    public IEnumerable<SpecialDto> Specials { get; init; }
}
