using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace OdeAComida
{
    public static class InicializarConexao
    {
        public static void Inicializar()
        {
            if (!WebSecurity.Initialized)
                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "PerfilUsuario",
                    "UserId", "NomeUsuario", autoCreateTables: true);
        }
    }
}