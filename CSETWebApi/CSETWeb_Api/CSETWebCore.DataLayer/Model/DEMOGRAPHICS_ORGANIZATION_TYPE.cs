﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CSETWebCore.DataLayer.Model
{
    /// <summary>
    /// A collection of DEMOGRAPHICS_ORGANIZATION_TYPE records
    /// </summary>
    public partial class DEMOGRAPHICS_ORGANIZATION_TYPE
    {
        public DEMOGRAPHICS_ORGANIZATION_TYPE()
        {
            DEMOGRAPHICS = new HashSet<DEMOGRAPHICS>();
        }

        [Key]
        public int OrganizationTypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string OrganizationType { get; set; }

        [InverseProperty("OrganizationTypeNavigation")]
        public virtual ICollection<DEMOGRAPHICS> DEMOGRAPHICS { get; set; }
    }
}