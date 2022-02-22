using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBets.Shared.Models;

public class UfcEvent
{
   public int EventId { get; set; }
   public int LeagueId { get; set; }
   public string Name { get; set; }
   public string ShortName { get; set; }
   public int Season { get; set; }

   public DateOnly Day { get; set; }
   public DateTime DateTime { get; set; }

   public string Status { get; set; }
   public bool Active { get; set; } = false;
}
