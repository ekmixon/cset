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
    /// A collection of NCSF_FUNCTIONS records
    /// </summary>
    public partial class NCSF_FUNCTIONS
    {
        public NCSF_FUNCTIONS()
        {
            NCSF_CATEGORY = new HashSet<NCSF_CATEGORY>();
        }

        [Key]
        [StringLength(2)]
        public string NCSF_Function_ID { get; set; }
        [StringLength(50)]
        public string NCSF_Function_Name { get; set; }
        public int? NCSF_Function_Order { get; set; }
        public int NCSF_ID { get; set; }

        [InverseProperty("NCSF_Function")]
        public virtual ICollection<NCSF_CATEGORY> NCSF_CATEGORY { get; set; }
    }
}