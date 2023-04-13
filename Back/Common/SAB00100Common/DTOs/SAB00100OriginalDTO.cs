using R_APICommonDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAB00100Common.DTOs
{
    public class SAB00100OriginalDTO : R_APIResultBaseDTO
    {
        public List<SAB00100DTO> Data { get; set; }
    }
}
