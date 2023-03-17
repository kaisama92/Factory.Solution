using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Engineer
  {
    public int EngineerId { get; set; }
    [Required(ErrorMessage = "You must add a name for this Engineer!")]
    public string EngineerName { get; set; }
    public List<EngineerMachine> JoinEntities { get; }
  }
}