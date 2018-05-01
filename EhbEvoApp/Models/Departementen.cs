using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EhbEvo.Models
{
    public enum Departementen
    {
        [Display(Name = "Design & Technologie")]
        DesignEnTechnologie,
        [Display(Name = "Gezondheidszorg & Landschapsarchitectuur")]
        GezondheidszorgEnLandschapsarchitectuur,
        [Display(Name = "Management, Media & Maatschappij")]
        ManagementMediaEnMaatschappij,
        [Display(Name = "Onderwijs & Pedagogie")]
        OnderwijsEnPedagogie,
        [Display(Name = "KoninklijkConservatorium")]
        KoninklijkConservatorium,
        [Display(Name = "RITCS")]
        RITCS
    };
}