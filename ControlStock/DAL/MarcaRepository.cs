using ControlStock.DAL;
using ControlStock.Models;
using System;

public class MarcaRepository : GenericRepository<Marca> , IMarcaRepository
{

    public MarcaRepository(ApplicationDbContext context) : base(context)
    {

    }

    public ApplicationDbContext  MarcaContext
    {
        get { return context as ApplicationDbContext; }

    }
}
