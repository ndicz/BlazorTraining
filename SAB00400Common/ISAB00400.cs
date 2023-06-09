﻿using System;
using R_CommonFrontBackAPI;
using SAB00400Common.DTOs;

namespace SAB00400Common
{
    public interface ISAB00410 : R_IServiceCRUDBase<SAB00410DTO>
    {

        SAB00400ListDTO<SAB00410DTO> GetAllTerritory();
    }
}
