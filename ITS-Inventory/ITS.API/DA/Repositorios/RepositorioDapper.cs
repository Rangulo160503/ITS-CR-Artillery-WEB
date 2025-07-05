﻿using Abstracciones.Interfaces.DA;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Repositorios
{
    public class RepositorioDapper : IRepositorioDapper
    {
        private readonly IConfiguration _configuracion;
        private readonly string _cadenaConexion;

        public RepositorioDapper(IConfiguration configuracion)
        {
            _configuracion = configuracion;
            _cadenaConexion = _configuracion.GetConnectionString("BD");
        }

        public IDbConnection ObtenerRepositorio()
        {
            return new SqlConnection(_cadenaConexion);
        }
    }
}
