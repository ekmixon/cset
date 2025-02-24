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
    /// A collection of PROCUREMENT_LANGUAGE_HEADINGS records
    /// </summary>
    public partial class PROCUREMENT_LANGUAGE_HEADINGS
    {
        public PROCUREMENT_LANGUAGE_HEADINGS()
        {
            PROCUREMENT_LANGUAGE_DATA = new HashSet<PROCUREMENT_LANGUAGE_DATA>();
        }

        /// <summary>
        /// The Id is used to
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// The Heading Num is used to
        /// </summary>
        public int? Heading_Num { get; set; }
        /// <summary>
        /// The Heading Name is used to
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Heading_Name { get; set; }

        [InverseProperty("Parent_Heading")]
        public virtual ICollection<PROCUREMENT_LANGUAGE_DATA> PROCUREMENT_LANGUAGE_DATA { get; set; }
    }
}