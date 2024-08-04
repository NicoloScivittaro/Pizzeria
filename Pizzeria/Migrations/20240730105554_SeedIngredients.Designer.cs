
using System;
using Pizzeria.Data.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Pizzeria.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240730105554_SeedIngredients")]
    partial class SeedIngredients : SeedIngredients
    {
    }
}
