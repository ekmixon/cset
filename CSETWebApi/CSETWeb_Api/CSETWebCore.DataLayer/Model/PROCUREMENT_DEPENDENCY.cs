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
    /// A collection of PROCUREMENT_DEPENDENCY records
    /// </summary>
    public partial class PROCUREMENT_DEPENDENCY
    {
        /// <summary>
        /// The Procurement Id is used to
        /// </summary>
        [Key]
        public int Procurement_Id { get; set; }
        /// <summary>
        /// The Dependencies Id is used to
        /// </summary>
        [Key]
        public int Dependencies_Id { get; set; }

        [ForeignKey(nameof(Dependencies_Id))]
        [InverseProperty(nameof(PROCUREMENT_LANGUAGE_DATA.PROCUREMENT_DEPENDENCYDependencies))]
        public virtual PROCUREMENT_LANGUAGE_DATA Dependencies { get; set; }
        [ForeignKey(nameof(Procurement_Id))]
        [InverseProperty(nameof(PROCUREMENT_LANGUAGE_DATA.PROCUREMENT_DEPENDENCYProcurement))]
        public virtual PROCUREMENT_LANGUAGE_DATA Procurement { get; set; }
    }
}